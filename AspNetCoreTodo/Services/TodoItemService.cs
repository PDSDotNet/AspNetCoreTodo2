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
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);

            var saveResoult = await _context.SaveChangesAsync();
            return saveResoult == 1;
        }
    }
}
