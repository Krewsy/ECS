using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    /// <summary>
    /// The primary class for the ECS system. Handles creation and manipulation of all entities, including adding and accessing components belonging to active entities.
    /// </summary>
    public class EntityManager
    {
        /// <summary>
        /// A list of currently existing entities.
        /// </summary>
        public List<Entity> activeEntities;

        /// <summary>
        /// A list containing a manager for each type of in-use component.
        /// </summary>
        public List<ComponentManager> componentManagers;

        public EntityManager()
        {
            activeEntities = new List<Entity>();
            componentManagers = new List<ComponentManager>();
        }

        /// <summary>
        /// Creates a new entity given an ID.
        /// </summary>
        /// <param name="id">The created entity will be identified by this.</param>
        /// <returns></returns>
        public Entity CreateEntity(string id)
        {
            Entity newEntity = new Entity();

            newEntity.id = id;
            activeEntities.Add(newEntity);

            return newEntity;
        }

        public void RemoveEntity(Entity e)
        {
            activeEntities.Remove(e);
        }

        public void RemoveEntity(string id)
        {
            Entity toRemove = activeEntities.Where(i => i.id == id).Select(j => j).FirstOrDefault();
            activeEntities.Remove(toRemove);
        }

        /// <summary>
        /// Add component to an entity identified by the supplied id.
        /// </summary>
        /// <typeparam name="T">A component</typeparam>
        /// <param name="entityId">The identifier of the entity you wish to add the component to.</param>
        public void AddComponent<T>(string entityId) where T : Component, new()
        {

            ComponentManager components;
            List<ComponentManager> tempManagers;

            tempManagers = componentManagers;

            
            if (!componentManagers.Any())
            {
                components = new ComponentManager(typeof(T));
                components.AddComponent(entityId, new T());
                componentManagers.Add(components);
            }
            else
            {
                var applicableManager = componentManagers.Where(i => i._type == typeof(T)).Select(j => j).FirstOrDefault();

                if (applicableManager != null)
                {
                    applicableManager.AddComponent(entityId, new T());
                }
                else
                {
                    components = new ComponentManager(typeof(T));
                    components.AddComponent(entityId, new T());
                    componentManagers.Add(components);
                }

            }
        }

        /// <summary>
        /// Retrieve a component of the given type for the entity identified by the supplied id.
        /// </summary>
        /// <typeparam name="T">A component</typeparam>
        /// <param name="entityId">The identifier of the entity you wish to retrieve the component for.</param>
        /// <returns></returns>
        public T GetComponent<T>(string entityId)
        {

            var manager = componentManagers.Where(i => i._type == typeof(T)).Select(j => j).FirstOrDefault();

            if (manager != null)
            {
                return (T)(object)manager.GetComponent(entityId);
            }

            return default;
        }

    }
}
