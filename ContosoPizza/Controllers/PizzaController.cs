using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController(){}

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> GetPizza(int id) {
            var pizza = PizzaService.Get(id);  
            if (pizza is null)
                return NotFound();

            return pizza; //Ok() is implied
        } 

        // POST action
        [HttpPost]
        //Because the controller is annotated with the [ApiController] attribute, it's implied that the Pizza parameter will be found in the request body.
        public ActionResult CreatePizza(Pizza pizza) {
          PizzaService.Add(pizza);          
          return CreatedAtAction(nameof(CreatePizza), new {Id = pizza.Id}, pizza);  
        } 

        // PUT action
        [HttpPut("{id}")]
        //Returns IActionResult because the ActionResult return type isn't known until runtime.
        public IActionResult UpdatePizza(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();
            
            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);
            return NoContent();
        }


        // DELETE action
        [HttpDelete("{id}")]
        //Returns IActionResult because the ActionResult return type isn't known until runtime.
        public IActionResult DeletePizza(int id) 
        {
            var pizza = PizzaService.Get(id);
            if (pizza is null)
                return NotFound();
            
            PizzaService.Delete(id);
            return NoContent();
        }
    }
}