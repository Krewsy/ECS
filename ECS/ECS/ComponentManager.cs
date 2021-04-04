using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    /// <summary>
    /// Contains a list of entity IDs and their respective components of the specified type.
    /// </summary>
    public class ComponentManager
    {
        public Dictionary<string, Component> components;

        public ComponentManager(Component component)
        {
            components = new Dictionary<string, Component>();
            components.Add("type", component);


        }

        /// <summary>
        /// Add entity to the list of components along with their copy of the component of the specified type.
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="component"></param>
        public void addComponent(string entityId, Component component)
        {

            components.Add(entityId, component);

        }

        /// <summary>
        /// Remove entity ID and their copy of the component from the list.
        /// </summary>
        /// <param name="entityId"></param>
        public void removeComponent(string entityId)
        {
            components.Remove(entityId);
        }

    }
}
