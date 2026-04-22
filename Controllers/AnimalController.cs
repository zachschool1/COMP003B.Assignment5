using COMP003B.Assignment5.Data;
using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Animal>> GetAnimals()
        {
            return Ok(AnimalStore.Animal);
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimal(int id)
        {
            var animal = AnimalStore.Animal.FirstOrDefault(p => p.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> CreateAnimal(Animal animal)
        {
            animal.Id = AnimalStore.Animal.Max(p => p.Id) + 1;

            AnimalStore.Animal.Add(animal);

            return CreatedAtAction(nameof(GetAnimal), new { id =  animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
        {
            var existingAnimal = AnimalStore.Animal.FirstOrDefault(p => p.Id == id);

            if (existingAnimal == null)
            {
                return NotFound();
            }

            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Weight = updatedAnimal.Weight;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = AnimalStore.Animal.FirstOrDefault(p => p.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            AnimalStore.Animal.Remove(animal);

            return NoContent();
        }
    }
}
