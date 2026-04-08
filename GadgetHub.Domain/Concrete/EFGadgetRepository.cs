using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entites;

namespace GadgetHub.Domain.Concrete
{
    public class EFGadgetRepository : IGadgetRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Gadget> Gadgets
        {
            get { return context.Gadgets; }
        }

        public void SaveGadget(Gadget gadget)
        {
            if(gadget.GadgetID == 0 )
            {
                context.Gadgets.Add(gadget);
            }
            else
            {
                Gadget dbEntry = context.Gadgets.Find(gadget.GadgetID);

                if (dbEntry != null ) 
                {
                    dbEntry.Name = gadget.Name;
                    dbEntry.Description = gadget.Description;
                    dbEntry.Price = gadget.Price;
                    dbEntry.category = gadget.category;
                }
            }
            context.SaveChanges();
        }
    }
}
