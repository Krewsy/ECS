using ECS;
using System;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityManager entityManager = new EntityManager();

            Entity entity = entityManager.CreateEntity("AnEntity");

            entityManager.AddComponent<SomeComponent>(entity.id);
            entityManager.AddComponent<AnotherComponent>(entity.id);

            Console.WriteLine(entityManager.GetComponent<SomeComponent>(entity.id).stuff);
            entityManager.GetComponent<SomeComponent>(entity.id).stuff = "Goodbye World!";
            Console.WriteLine(entityManager.GetComponent<SomeComponent>(entity.id).stuff);
            Console.ReadKey();
        }
    }
}
