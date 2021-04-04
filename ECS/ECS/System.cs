using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    /// <summary>
    /// Facilitates the function of all systems and provides utility for managing compatible entities.
    /// </summary>
    public abstract class System
    {

        public EntityManager entityHandler;
        public List<string> compatibleEntities;

        public List<Type> compatibleTypes;

        public System(EntityManager entityHandler, params Type[] compatibleTypes)
        {
            this.compatibleTypes = new List<Type>();
            this.compatibleTypes.AddRange(compatibleTypes);

            this.entityHandler = entityHandler;

            compatibleEntities = getCompatibleEntities();
        }

        public List<string> getCompatibleEntities()
        {
            List<string> compatible = new List<string>();

            var compatibleManagers = entityHandler.componentManagers.Where(i => compatibleTypes.Contains(i._type)).Select(j => j).ToList();

            foreach (ComponentManager cm in compatibleManagers)
            {
                compatible.AddRange(cm.GetEntities());
            }

            return compatible.Distinct().ToList();


        }

    }
}
