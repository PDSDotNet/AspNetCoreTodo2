using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;


namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<ApplicationUser> _userManager;


        /// <summary>
        /// Constuctor del TodoControler
        /// </summary>
        /// <param name="todoItemService"></param>
        /// <param name="userManager"></param>
        public TodoController(  ITodoItemService todoItemService,
                                UserManager< ApplicationUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }






        public async Task<IActionResult> Index()
        {
            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync( User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            var items = await _todoItemService.GetIncompletItemsAsync( currentUser);

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

            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            if (newItem.DueAt < DateTimeOffset.Now.AddMinutes(1))
                return RedirectToAction("Index");

            var succesfull = await _todoItemService.AddItemAsync(newItem, currentUser);
            if (!succesfull)
                return BadRequest("No se pudo agregar la tarea");

            return RedirectToAction("Index");
        }





        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            //Verifica que el identificador de Todo no este vacio
            if( id == Guid.Empty)
                return RedirectToAction("Index");

            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            //Marca el Item como realizado (done) a travez del servicio MarkDoneAsync()
            var successful = await _todoItemService.MarkDoneAsync( id, currentUser);

            //Verifica que MarkDoneAsync() halla modificado el Item
            if ( !successful)
                return BadRequest("No se pudo marcar el item como realizado."); 

            return RedirectToAction("Index");
        }






    }
}