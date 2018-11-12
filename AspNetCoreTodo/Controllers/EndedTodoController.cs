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
    public class EndedTodoController : BaseController
    {
        private readonly IEndedTodoItemService _endedTodoItemService;
        //private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor del controlador.
        /// </summary>
        /// <param name="endedTodoService"></param>
        /// <param name="userManager"></param>
        public EndedTodoController(IEndedTodoItemService endedTodoService,
                                    UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _endedTodoItemService = endedTodoService;
        }



        public async Task< IActionResult> Index()
        {
            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            if (await _userManager.IsInRoleAsync(currentUser, "Administrator"))
            {
                ObtenerListaUsuarios();

                //Current user se hace null para poder ver todos los Todo's.
                currentUser = null;
            }
            var items = await _endedTodoItemService.GetCompletItemsAsync(currentUser);

            var model = new TodoViewModel()  {  Items = items };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(TodoViewModel todo = null)
        {
            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            currentUser = await ObtenerUsuarioSeleccionado( todo);

            var items = await _endedTodoItemService.GetCompletItemsAsync(currentUser);

            var model = new TodoViewModel()   {  Items = items };

            return View(model);
        }
    }
}