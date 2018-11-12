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
    public class EndedTodoController : Controller
    {
        private readonly IEndedTodoItemService _endedTodoItemService;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor del controlador.
        /// </summary>
        /// <param name="endedTodoService"></param>
        /// <param name="userManager"></param>
        public EndedTodoController(IEndedTodoItemService endedTodoService,
                                    UserManager<ApplicationUser> userManager)
        {
            _endedTodoItemService = endedTodoService;
            _userManager = userManager;
        }



        public async Task< IActionResult> Index()
        {
            //obtencion del usuario logeado
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge(); //fuerza el logeo, mostrando la pagina de logeo

            var items = await _endedTodoItemService.GetCompletItemsAsync(currentUser);

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
        }
    }
}