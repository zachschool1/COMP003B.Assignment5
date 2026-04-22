using COMP003B.Assignment5.Models;
namespace COMP003B.Assignment5.Data;

public class AnimalStore
{
    public static List<Animal> Animal { get; } = new()
    {
        new Animal { Id =  1, Name = "Fluffy", Breed = "Pomeranian", Weight = 9},
        new Animal { Id =  2, Name = "Jackson", Breed = "Terrier", Weight = 14.3},
        new Animal { Id =  3, Name = "Beau", Breed = "German Shepherd", Weight = 59},
        new Animal { Id =  4, Name = "Jimmy", Breed = "Rottweiler", Weight = 39},
    };
}
