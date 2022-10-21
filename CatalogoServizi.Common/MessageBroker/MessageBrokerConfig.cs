using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.MessageBroker
{

    /// <summary>
    /// Message Configuration
    /// </summary>
    public class MessageBrokerConfig
    {
        /// <summary>
        /// HostName
        /// </summary>
        public string HostName { get; set; } = "";

        /// <summary>
        /// Port
        /// </summary>
        public string Port { get; set; } = "5672";

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = "";

    }
}
