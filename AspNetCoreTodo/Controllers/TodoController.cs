using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }


        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompletItemsAsync();

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model); 
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem( TodoItem newItem)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var succesfull = await _todoItemService.AddItemAsync(newItem);
            if (!succesfull)
                return BadRequest("No se pudo agregar la tarea");

            return RedirectToAction("Index");
        }
    }
}