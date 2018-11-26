using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using AspNetCoreTodo.Models;



namespace AspNetCoreTodo.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor del UserManagerController
        /// </summary>
        /// <param name="userManager"></param>
        public ManageUsersController( UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //obtiene un array conteniendo los usuarios que son administradores.
            var admins = (await _userManager.GetUsersInRoleAsync("Administrator")).ToArray();
            //obtiene un array conteniendo todos los usuarios.
            var everyone = await _userManager.Users.ToArrayAsync();

            //construye el ViewModel
            var model = new ManageUsersViewModel
                                                {
                                                    Administrators = admins,
                                                    Everyone = everyone
                                                };

            return View(model);
        }

    }
}