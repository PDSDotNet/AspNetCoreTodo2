using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    /// <summary>
    /// Clase que implementa una lista de tareas ficticia
    /// </summary>
    public class FakeTodoItemService: ITodoItemService
    {
        public Task<TodoItem[]> GetIncompletItemsAsync()
        {
            var item1 = new TodoItem
            {
                Title = "Aprender ASP.NET Core",
                DueAt= DateTimeOffset.Now.AddDays(10)
            };
            var item2 = new TodoItem
            {
                Title = "Construir asombrosas aplicaciones con ASP NET Core",
                DueAt = DateTimeOffset.Now.AddMonths(18)
            };
            var item3 = new TodoItem
            {
                Title = "Ganar algunos morlacos con ASP NET Core",
                DueAt = DateTimeOffset.Now.AddYears(5)
            };
            return Task.FromResult(new[] { item1, item2, item3 });
        }
    }
}
