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
    /// <summary>
    /// Se sobrecargo a Controller para darle la caracteristica de crear 
    /// la lista de usuarios a ser mostrada en los DropDownList.
    /// 
    /// Se trajo a _userManager, se cambio el ambito a protected.
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }






        [ValidateAntiForgeryToken]
        protected async void ObtenerListaUsuarios()
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
        }

        [ValidateAntiForgeryToken]
        protected async Task<ApplicationUser> ObtenerUsuarioSeleccionado(TodoViewModel todo)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (await _userManager.IsInRoleAsync(currentUser, "Administrator"))
            {
                ObtenerListaUsuarios();

                //Current user se hace null para poder ver todos los Todo's.
                if (todo.Usuarios == null)
                    currentUser = null;
                else
                    currentUser = await _userManager.FindByIdAsync(todo.Usuarios);
            }
            return currentUser;
        }


    }
}