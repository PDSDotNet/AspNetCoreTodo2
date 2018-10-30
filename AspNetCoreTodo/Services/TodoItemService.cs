using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompletItemsAsync()
        {
            return await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            //para permitir que se carge la fecha desde el formulario
            //newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);

            var saveResoult = await _context.SaveChangesAsync();
            return saveResoult == 1;
        }


        public async Task<bool> MarkDoneAsync( Guid id)
        {
            var item = await _context.Items.Where(x => x.Id == id).SingleOrDefaultAsync();

            //verifica que la tarea (item) obtenido de la base de datos
            //no sea nulo.
            if (item == null)
                return false;

            item.IsDone = true;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }



    }
}
