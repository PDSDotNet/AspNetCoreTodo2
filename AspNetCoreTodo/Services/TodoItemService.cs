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

        /// <summary>
        /// Servicio llamado por el TodoItemControler.Index() para obtener
        /// la lista de tareas.
        /// </summary>
        /// <returns></returns>
        public async Task<TodoItem[]> GetIncompletItemsAsync()
        {
            return await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }


        /// <summary>
        /// Servicio llamado por el TodoItemControler.AddItem() para agregar una tarea
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
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
    }
}
