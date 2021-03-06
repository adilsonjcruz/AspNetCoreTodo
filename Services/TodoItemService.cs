using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {

        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser user)
        {

            return await _context.Items
            .Where(x => x.isDone == false && x.OwnerId == user.Id)
            .ToArrayAsync();

            //return items;

        }

        public async Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser user)
        {

            var entity = new TodoItem
            {
                Id = Guid.NewGuid(),
                OwnerId = user.Id,
                isDone = false,
                Title = newItem.Title,
                DueAt = DateTimeOffset.Now.AddDays(3)
            };

            _context.Items.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;

        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {

            var item = await _context.Items
            .Where(x => x.Id == id && x.OwnerId == user.Id)
            .SingleOrDefaultAsync();

            if (item == null) return false;

            item.isDone = true;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
            
        }

    }
}