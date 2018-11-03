using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompletItemsAsync( ApplicationsUser user);

        Task<bool> AddItemAsync(TodoItem newItem, ApplicationsUser user);

        Task<bool> MarkDoneAsync(Guid id, ApplicationsUser user);
    }
}
