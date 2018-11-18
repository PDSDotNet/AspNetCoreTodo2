using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class EndedTodoItemService :IEndedTodoItemService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constuctor del Servicio EndedTodo. 
        /// Los servicios son metodos llamados por el Controler.
        /// </summary>
        /// <param name="context"></param>
        public EndedTodoItemService( ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<TodoItem[]> GetCompletItemsAsync(ApplicationUser user)
        {
            return await _context.Items.Where(  x => x.IsDone == true && x.UserId == user.Id).OrderByDescending(c => c.EndDateTime).ToArrayAsync();
        }
    }
}
