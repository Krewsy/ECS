using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    /// <summary>
    /// This class defines our Entity object, which will be used to create all of the program entities. 
    /// </summary>
    public sealed class Entity
    {
        /// <summary>
        /// An arbitrary string value to identify the entity.
        /// </summary>
        public string id { get; set; }
    }
}
