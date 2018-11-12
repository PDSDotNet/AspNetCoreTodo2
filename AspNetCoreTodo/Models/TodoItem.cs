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
        /// Tiempo en que debe finalizarse la tarea. 
        /// El "?" indica que puede ser nuleable, para poder crear tareas sin limite de tiempo.
        /// </summary>
        public DateTimeOffset? DueAt { get; set; }


        /// <summary>
        /// Id del usuario al que le pertenece la tarea.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Indica la Fecha y Hora en que fue creada el Todo.
        /// </summary>
        public DateTimeOffset? CreateDateTime { get; set; }

        /// <summary>
        /// Indica la Fecha y Hora en que le Todo fue finalizado.
        /// </summary>
        public DateTimeOffset? EndDateTime { get; set; }
    }
}
