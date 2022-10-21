using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.MessageBroker
{
    /// <summary>
    /// Message Utility
    /// </summary>
    public static class MessageUtility
    {

        /// <summary>
        /// Add Message Sender Service
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddMessageSender(this IServiceCollection services)
        {
            services.TryAddScoped<IMessageSender, MessageSender>();
        }

        /// <summary>
        /// Return identifier
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Identifier</returns>
        public static string GetIdentifier(this Type item)
        {
            var attrs = item.GetCustomAttributes(false);

            foreach (var i in attrs)
            {
                if (i is not MessageBusAttribute attr)
                    continue;

                return attr.Name;
            }

            string? name = item.GetType().FullName;
            if (name == null)
                throw new InvalidOperationException();
            return name;
        }
    }
}
