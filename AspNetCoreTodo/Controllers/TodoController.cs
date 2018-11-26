using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            if (await _userManager.IsInRoleAsync(currentUser, "Administrator"))
            {
                //Obtencion de todos los usuarios, y con estos crea lista de 
                //usuarios a nostrar en el dropdown.
                var everyone = await _userManager.Users.ToArrayAsync();
                List<SelectListItem> lstUsr = new List<SelectListItem>();
                lstUsr.Add(new SelectListItem { Text = "Todos los usuarios", Value = "" });

                foreach (var usr in everyone)
                {
                    lstUsr.Add(new SelectListItem { Text = usr.Email, Value = usr.Id });
                }
                ViewBag.ListaUsuarios = lstUsr;

                //Current user se hace null para poder ver todos los Todo's.
                currentUser = null;
            }
            var items = await _todoItemService.GetIncompletItemsAsync(currentUser);

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

            if (await _userManager.IsInRoleAsync(currentUser, "Administrator"))
            {
                //Obtencion de todos los usuarios, y con estos crea lista de 
                //usuarios a nostrar en el dropdown.
                var everyone = await _userManager.Users.ToArrayAsync();
                List<SelectListItem> lstUsr = new List<SelectListItem>();
                lstUsr.Add(new SelectListItem { Text = "Todos los usuarios", Value = "" });

                foreach (var usr in everyone)
                {
                    lstUsr.Add(new SelectListItem { Text = usr.Email, Value = usr.Id });
                }
                ViewBag.ListaUsuarios = lstUsr;

                //Current user se hace null para poder ver todos los Todo's.
                if(todo.Usuarios==null)
                    currentUser = null;
                else
                    currentUser = await _userManager.FindByIdAsync(todo.Usuarios);
            }
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