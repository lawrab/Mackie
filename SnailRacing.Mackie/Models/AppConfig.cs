using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailRacing.Mackie.Models
{
    internal class AppConfig
    {
        public DiscordConfig? Discord { get; } = new DiscordConfig();
    }
}
