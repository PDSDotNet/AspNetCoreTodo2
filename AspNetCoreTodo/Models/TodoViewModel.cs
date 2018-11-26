using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreTodo.Models
{
    /// <summary>
    /// Clase que contiene un array de tareas 
    /// </summary>
    public class TodoViewModel
    {
        /// <summary>
        /// Array de objetos TodoItem. Lista de tareas.
        /// </summary>
        public TodoItem[] Items { get; set; }


        [Display(Name = "Usuarios")]
        public string Usuarios { get; set; }
    }
}
