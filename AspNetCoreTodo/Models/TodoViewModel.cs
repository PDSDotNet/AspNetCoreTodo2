using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    //2018-12-10 Fix NewFeatures
using Microsoft.AspNetCore.Mvc.Rendering;       //2018-12-10 Fix NewFeatures

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


        [Display(Name = "Usuarios")]            //2018-12-10 Fix NewFeatures
        public string Usuarios { get; set; }    //2018-12-10 Fix NewFeatures
    }
}
