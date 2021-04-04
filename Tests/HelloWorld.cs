using ECS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class HelloWorld
    {

        public HelloWorld()
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
