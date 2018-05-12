using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityManager entityManager = new EntityManager();

            Entity entity = entityManager.createEntity("AnEntity");

            entityManager.addComponent<SomeComponent>(entity.id);
            entityManager.addComponent<AnotherComponent>(entity.id);

            Console.WriteLine(entityManager.getComponent<SomeComponent>(entity.id).stuff);
            Console.ReadKey();
        }
    }
}
