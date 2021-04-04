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
        private Dictionary<string, Component> components;

        public Type _type { get; private set; }

        public ComponentManager(Type type)
        {
            if (!type.IsSubclassOf(typeof(Component)))
            {
                throw new Exception("Component Manager Type must be a subclass of Component.");
            }

            components = new Dictionary<string, Component>();
            this._type = type;
        }

        /// <summary>
        /// Add entity to the list of components along with their copy of the component of the specified type.
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="component"></param>
        public void AddComponent(string entityId, Component component)
        {
            
            components.Add(entityId, component);

        }

        public List<string> GetEntities()
        {
            return components.Keys.ToList();
        }

        /// <summary>
        /// Get the component for a specific entity ID.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public Component GetComponent(string entityId)
        {
            return components[entityId];
        }

        /// <summary>
        /// Remove entity ID and their copy of the component from the list.
        /// </summary>
        /// <param name="entityId"></param>
        public void RemoveComponent(string entityId)
        {
            components.Remove(entityId);
        }

    }
}
