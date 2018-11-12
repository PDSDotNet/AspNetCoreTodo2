using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface IEndedTodoItemService
    {
        Task<TodoItem[]> GetCompletItemsAsync(ApplicationUser user);
    }
}
