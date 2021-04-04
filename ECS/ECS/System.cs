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
        public Dictionary<string, List<Component>> compatibleEntities;

        public List<Type> compatibleTypes;

        public System(EntityManager entityHandler, params Type[] compatibleTypes)
        {
            this.compatibleTypes = new List<Type>();
            this.compatibleTypes.AddRange(compatibleTypes);

            this.entityHandler = entityHandler;

            compatibleEntities = getCompatibleEntities();
        }

        public Dictionary<string, List<Component>> getCompatibleEntities()
        {
            Dictionary<string, List<Component>> compatible = new Dictionary<string, List<Component>>();

            foreach (Type t in compatibleTypes)
            {
                foreach (ComponentManager cm in entityHandler.componentManagers)
                {
                    if (cm.components["type"].GetType() == t)
                    {

                        foreach (KeyValuePair<string, Component> k in cm.components)
                        {
                            List<Component> list;
                            if (compatible.TryGetValue(k.Key, out list))
                            {
                                list.Add(k.Value);
                                compatible[k.Key] = list;
                            }
                            else
                            {
                                list = new List<Component>();
                                list.Add(k.Value);
                                compatible.Add(k.Key, list);
                            }
                        }
                    }
                }
            }

            return compatible;


        }

    }
}
