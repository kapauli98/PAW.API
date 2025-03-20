using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Models.CustomModels
{
    public abstract class ComponentBase
    {
        public IEnumerable<Component> Data { get; set; }

        public string Url {  get; set; }
    }
}
