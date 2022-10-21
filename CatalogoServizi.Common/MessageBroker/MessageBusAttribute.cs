using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.MessageBroker
{

    /// <summary>
    /// MessageBus Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageBusAttribute : Attribute
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        public MessageBusAttribute(string name)
        {
            this.Name = name;
        }
    }
}
