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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="todoItemService"></param>
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        /// <summary>
        /// Muestra la lista de tareas
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompletItemsAsync();

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model); 
        }


        /// <summary>
        /// Agrega un tarea (TodoItem) a la lista
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
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