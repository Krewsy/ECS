using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public class EntityManager
    {
        public List<Entity> activeEntities;
        public List<ComponentManager> componentManagers;

        Exception ComponentNotFoundException;

        public EntityManager()
        {
            activeEntities = new List<Entity>();
            componentManagers = new List<ComponentManager>();
        }

        public Entity createEntity(string id)
        {
            Entity newEntity = new Entity();

            newEntity.id = id;

            return newEntity;
        }

        public void addComponent<T>(string entityId) where T : Component, new()
        {

            ComponentManager components;
            List<ComponentManager> tempManagers;

            tempManagers = componentManagers;

            if (!componentManagers.Any())
            {
                Console.WriteLine("I'm creating the first component list!");
                components = new ComponentManager(new T());
                components.addComponent(entityId, new T());
                componentManagers.Add(components);
            }
            else
            {
                foreach (ComponentManager cm in componentManagers.ToList<ComponentManager>())
                {
                    if (cm.components["type"].GetType() == typeof(T))
                    {
                        Console.WriteLine("Adding Component to existing list...");
                        cm.addComponent(entityId, new T());
                    }
                    else
                    {
                        Console.WriteLine("Creating new component list and adding the new Component...");
                        components = new ComponentManager(new T());
                        components.addComponent(entityId, new T());
                        componentManagers.Add(components);
                    }
                }
            }
        }

        public T getComponent<T>(string entityId)
        {
            Component component;

            foreach (ComponentManager cm in componentManagers)
            {
                if (cm.components["type"].GetType() == typeof(T))
                {

                    cm.components.TryGetValue(entityId, out component);
                    return (T)(object)component;
                }
            }

            return default(T);
        }

    }
}
