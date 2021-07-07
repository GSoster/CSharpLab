using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext context;
        public TodoItemsController(TodoContext todoContext)
        {
            this.context = todoContext;
        }

        //Post: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoItem)
        {
            var item = new TodoItem
            {
                IsComplete = todoItem.IsComplete,
                Name = todoItem.Name
            };
            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, ItemToDTO(item));
        }

        // Get: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem is null)
                return NotFound();
            return ItemToDTO(todoItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            //return await context.TodoItems.ToListAsync();
            return await context.TodoItems.Select(item => ItemToDTO(item)).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoItem)
        {
            if (id != todoItem.Id)
                return BadRequest();
            var item = await context.TodoItems.FindAsync(todoItem.Id);
            if (item is null)
                return NotFound();

            item.Name = todoItem.Name;
            item.IsComplete = todoItem.IsComplete;

            try
            {
                await context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemDTO>> DeleteTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem is null)
                return NotFound();

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();
            return ItemToDTO(todoItem);
        }


        private bool TodoItemExists(long id)
        {
            return context.TodoItems.Any(e => e.Id == id);
        }

        private static TodoItemDTO ItemToDTO(TodoItem todoItem)
        => new TodoItemDTO
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };

    }
}
