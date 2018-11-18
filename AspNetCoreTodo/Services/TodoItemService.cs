﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constuctor del Servicio Todo. 
        /// Los servicios son metodos llamados por el Controler.
        /// </summary>
        /// <param name="context"></param>
        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }






        public async Task<TodoItem[]> GetIncompletItemsAsync( ApplicationUser user)
        {
            //return await _context.Items.Where(x => x.IsDone == false && x.UserId == user.Id).ToArrayAsync();
            return await _context.Items.Where(x => x.IsDone == false && x.UserId == user.Id).OrderBy(c=> c.DueAt).ToArrayAsync();
        }



        public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            //para permitir que se carge la fecha desde el formulario
            //newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            newItem.UserId = user.Id;
            //2018-11-12. Guarda la fecha de creacion del Todo.
            newItem.CreateDateTime = DateTimeOffset.Now;

            //verifica que la fecha sea actual y no este definida en le pasado.
            if (newItem.DueAt < DateTimeOffset.Now.AddSeconds(-10))
                return false;
            

            _context.Items.Add(newItem);

            var saveResoult = await _context.SaveChangesAsync();
            return saveResoult == 1;
        }


        public async Task<bool> MarkDoneAsync( Guid id, ApplicationUser user)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.UserId == user.Id).SingleOrDefaultAsync();

            //verifica que la tarea (item) obtenido de la base de datos
            //no sea nulo.
            if (item == null)
                return false;

            item.IsDone = true;
            //2018-11-12. Guarda la fecha de finalizacion del Todo.
            item.EndDateTime = DateTimeOffset.Now;

            var saveresult = await _context.SaveChangesAsync();
            return saveresult == 1;
        }



    }
}
