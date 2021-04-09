using System;
using System.Collections.Generic;
using System.Text;
using ECS;

namespace Tests.Test
{
    public class TestSystem : EntitySystem
    {
        public TestSystem(EntityManager entityHandler) :
            base(entityHandler, new Type[] {
                typeof(SomeComponent) })
        {
            compatibleEntities.ForEach(Console.WriteLine);
        }
    }
}
