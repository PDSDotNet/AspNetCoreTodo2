using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.EntityFrameworkCore;

using Xunit;

namespace AspNetCoreTodo.xUnitTest
{
    public class TodoItemServiceShould: IDisposable
    {
        //Inicio codigo en comun***************************
        /// <summary>
        /// OBD: Options Data Base
        /// </summary>
        private DbContextOptionsBuilder<ApplicationDbContext> ODB;

        /// <summary>
        /// Costructor por defecto de la clase de AspNetCoreTodo.xUnitTest.
        /// </summary>
        public TodoItemServiceShould()
        {
            //Crea las "opciones" para crear la base de datos en memoria
            ODB = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_BD");
        }

        /// <summary>
        /// Dispose() se encarga de borrar la base de datos en memoria
        /// despues que termina cada test.
        /// </summary>
        public void Dispose()
        {
            //CBD: Context Base de Datos
            var CBD = new ApplicationDbContext(ODB.Options);
            CBD.Database.EnsureDeleted();
        }
        
        /// <summary>
        /// SetUp() configura la base de datos y le agrega un TodoItem.
        /// </summary>
        /// <returns></returns>
        private async Task SetUp(string id = "", string mail = "", string title ="", DateTimeOffset? dueAt = null)
        {
            ///Crea el contexto (conexion con la base de datos) para poder crear
            ///el servicio TodoItemService. Luego se crea un usuario ficticio
            ///con el que se agrega un item a la base de datos mediante AddItemAsync().
            using(var context = new ApplicationDbContext(ODB.Options))
            {
                var service = new TodoItemService(context);
                var fakeUser = new ApplicationUser { Id = id, UserName = mail };
                var item = new TodoItem { Title = title, DueAt= dueAt };
                await service.AddItemAsync(item, fakeUser);
            }
        }
        //Fin codigo en comun******************************



        //Tests********************************************
        [Fact]
        public async Task AddNewItemAsIncompleteWithDueDate()
        {
            await SetUp("fake-000", "fake@example.com", "Testing?", DateTimeOffset.Now.AddDays(3));

            ///Se crea otro contexto, y se verifica:
            ///     1) Que solo tenga un TodoItem.
            ///     2) Se obtiene el primer item y se verifica que coincida el Title.
            ///     3) Que no este marcado como done 
            ///     4) Que la diferencia de tiempo sea menor de 3 segundos que la hora actual.
            using (var CDB = new ApplicationDbContext(ODB.Options))
            {
                var itemsInDataBase = await CDB.Items.CountAsync();
                Assert.Equal(1, itemsInDataBase);

                var item = await CDB.Items.FirstAsync();
                Assert.Equal("Testing?", item.Title);

                Assert.True(false == item.IsDone);

                var diference = DateTimeOffset.Now.AddDays(3) - item.DueAt;
                Assert.True(diference < TimeSpan.FromSeconds(3));
            }
        }
        /*
        [Fact]
        public async Task NoAddNewItemAsPastDueDate()
        {
            await SetUp("fake-000", "fake@example.com", "Testing?", DateTimeOffset.Now.AddDays(-3));

            ///Se crea otro contexto, y se verifica:
            ///     1) Que solo tenga un TodoItem.
            ///     2) Se obtiene el primer item y se verifica que coincida el Title.
            ///     3) Que no este marcado como done 
            ///     4) Que la diferencia de tiempo sea menor de 3 segundos que la hora actual.
            using (var CDB = new ApplicationDbContext(ODB.Options))
            {
                var itemsInDataBase = await CDB.Items.CountAsync();
                Assert.Equal(0, itemsInDataBase);
            }
        }
        */

        [Fact]
        public async Task MarkDoneAnItemWithGoodId()
        {
            await SetUp("fake-000", "fake@example.com", "Testing?", DateTimeOffset.Now.AddDays(3));

            ///Se crea otro contexto, luego se crea otro usuario(con el mismo Id), y se verifica:
            ///     1_ Que solo tenga un item.
            ///     2_ Que el item almacenado en la base de datos no este done (false)
            ///     3_ Que falle al marcar como done usando otherFakeUser usando MarkDoneAsync()
            using (var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new TodoItemService(CDB);
                var otherFakeUser = new ApplicationUser { Id = "fake-000", UserName = "fake@example.com" };

                var itemInDateBase = await CDB.Items.CountAsync();
                Assert.Equal(1, itemInDateBase);

                var item = await CDB.Items.FirstAsync();
                Assert.False(item.IsDone);

                bool resoult = await service.MarkDoneAsync(item.Id, otherFakeUser);
                Assert.True(resoult);
                Assert.True(item.IsDone);
            }
        }

        [Fact]
        public async Task NoMarkDoneAnItemWithWrongId()
        {
            await SetUp("fake-000", "fake@example.com", "Testing?", DateTimeOffset.Now.AddDays(3));

            ///Se crea otro contexto, luego se crea otro usuario(con distinto Id), y se verifica:
            ///     1_ Que solo tenga un item.
            ///     2_ Que el item almacenado en la base de datos no este done (false)
            ///     3_ Que falle al marcar como done usando otherFakeUser usando MarkDoneAsync()
            using (var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new TodoItemService(CDB);
                var otherFakeUser = new ApplicationUser { Id = "fake-000-11", UserName = "fakeee@example.com" };

                var itemInDateBase = await CDB.Items.CountAsync();
                Assert.Equal(1, itemInDateBase);

                var item = await CDB.Items.FirstAsync();
                Assert.False(item.IsDone);

                bool resoult = await service.MarkDoneAsync(item.Id, otherFakeUser);
                Assert.False(resoult);
                Assert.False(item.IsDone);
            }
        }

        [Fact]
        public async Task ReturnOwnItems()
        {
            using (var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new TodoItemService(CDB);
                for(int usrIndex = 1; usrIndex < 4; usrIndex++)
                {
                    string usr = "fake-00" + usrIndex;
                    string mail = "fake" + usrIndex + "@example.com";
                    var fakeUsr = new ApplicationUser { Id = usr, UserName = mail };
                    for (int itemIndex = 1; itemIndex < 6; itemIndex++)
                    {
                        string itemTitle = "Task_" + itemIndex;
                        var item = new TodoItem { Title = itemTitle };
                        await service.AddItemAsync(item, fakeUsr);
                    }
                }
            }

            ///Se crea otro contexto, luego se crean 3 usuarios ficticios y se agregan 5
            ///items a cada uno, y se verifica:
            ///     1_ Que tenga 15 item.
            ///     2_ Que el item almacenado en la base de datos no este done (false)
            ///     3_ Que falle al marcar como done usando otherFakeUser usando MarkDoneAsync()
            using (var CDB = new ApplicationDbContext(ODB.Options))
            {
                var service = new TodoItemService(CDB);
                var usr2 = new ApplicationUser { Id = "fake-002", UserName = "fake2@example.com" };

                var itemInDateBase = await CDB.Items.CountAsync();
                Assert.Equal(15, itemInDateBase);

                int elementsUsr2 = 0;
                int elementsOtherUsr = 0;
                foreach(var element in CDB.Items)
                {
                    if (element.UserId == usr2.Id)
                        elementsUsr2++;
                    else
                        elementsOtherUsr++;
                }
                Assert.Equal(5, elementsUsr2);
                Assert.Equal(10, elementsOtherUsr);
            }
        }
    }
}
