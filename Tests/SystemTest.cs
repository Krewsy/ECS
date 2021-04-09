using System;
using System.Collections.Generic;
using System.Text;
using ECS;
using Tests.Test;

namespace Tests
{
    class SystemTest
    {

        public SystemTest()
        {
            EntityManager em = new EntityManager();

            for (int i = 0; i < 50; i++)
            {
                em.CreateEntity(i.ToString());

                em.AddComponent<SomeComponent>(i.ToString());
            }

            TestSystem ts = new TestSystem(em);
        }
    }
}
