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
    public abstract class EntitySystem
    {

        public EntityManager entityHandler;
        public List<string> compatibleEntities;

        public List<Type> compatibleTypes;

        public EntitySystem(EntityManager entityHandler, params Type[] compatibleTypes)
        {
            var badTypes = compatibleTypes.Where(i => !i.IsSubclassOf(typeof(Component))).Select(j => j).ToList();

            if (badTypes.Any())
            {
                throw new Exception("One or more types passed in the compatibleTypes array do not inherit from the Component class.");
            }

            this.compatibleTypes = new List<Type>();
            this.compatibleTypes.AddRange(compatibleTypes);

            this.entityHandler = entityHandler;

            RefreshEntities();
        }

        /// <summary>
        /// Refreshes the compatible entity list.
        /// </summary>
        public void RefreshEntities()
        {
            compatibleEntities = getCompatibleEntities();
        }

        /// <summary>
        /// Optional update logic for the system to run in the main application loop.
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Retrieves a list of entity IDs matching one of the compatible component types.
        /// </summary>
        /// <returns></returns>
        private List<string> getCompatibleEntities()
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
