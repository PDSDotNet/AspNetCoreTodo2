using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;        //2018-12-10 Fix NewFeatures
using Microsoft.AspNetCore.Mvc.Rendering;   //2018-12-10 Fix NewFeatures


namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : BaseController
    {
        private readonly ITodoItemService _todoItemService;


        /// <summary>
        /// Constuctor del TodoControler
        /// </summary>
        /// <param name="todoItemService"></param>
        /// <param name="userManager"></param>
        public TodoController(  ITodoItemService todoItemService,
                                UserManager< ApplicationUser> userManager)
            :base (userManager)
        {
            _todoItemService = todoItemService;
        }



        public async Task<IActionResult> Index()
        {
            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync( User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo
            
            //2018-12-10 Fix NewFeatures (todo el if)
            if (await _userManager.IsInRoleAsync(currentUser, "Administrator"))
            {
                ObtenerListaUsuarios();

                //Current user se hace null para poder ver todos los Todo's.
                currentUser = null;
            }
            var items = await _todoItemService.GetIncompletItemsAsync( currentUser);

             //Creacion de la Vista y pasaje de informcion.
            var model = new TodoViewModel() { Items = items };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TodoViewModel todo= null)
        {
            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            currentUser = await ObtenerUsuarioSeleccionado(todo);

            var items = await _todoItemService.GetIncompletItemsAsync(currentUser);

            //Creacion de la Vista y pasaje de informcion.
            var model = new TodoViewModel() { Items = items };

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