using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    /// <summary>
    /// Clase (Model) que almacena los datos de una tarea.
    /// Los objetos de esta clase se haran persistentes en la base de datos.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// numero identificador de tarea
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Indica si una tarea esta terminada (true)
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Titulo de la tarea, el [Required] indica que es un dato requerido 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Tiempo en que finaliza la tarea. el "?" indica que puede ser nuleable
        /// </summary>
        public DateTimeOffset? DueAt { get; set; }
    }
}
