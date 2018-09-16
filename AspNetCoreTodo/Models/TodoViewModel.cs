using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
