using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetHub.Domain.Entites
{
    public class Gadget
    {
        public int GadgetID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string category { get; set; }

    }
}
