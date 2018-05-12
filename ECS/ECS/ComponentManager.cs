using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public class ComponentManager
    {
        public Dictionary<string, Component> components;

        public ComponentManager(Component component)
        {
            components = new Dictionary<string, Component>();
            components.Add("type", component);


        }

        public void addComponent(string entityId, Component component)
        {

            components.Add(entityId, component);

        }

        public void removeComponent(string entityId)
        {
            components.Remove(entityId);
        }

    }
}
