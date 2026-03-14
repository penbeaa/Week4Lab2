using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Concrete;
using GadgetHub.Domain.Entites;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace GadgetHub.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        { 
            mykernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type myserviceType)
        { 
            return mykernel.TryGet(myserviceType);
        }
        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }
        public void AddBindings()
        {
            /*
            Mock<IGadgetRepository> myMock = new Mock<IGadgetRepository>();
            myMock.Setup(m => m.Gadgets).Returns(new List<Gadget>
            {
                
                new Gadget {Name = "Phone", Price = 250},
                new Gadget {Name = "SmartWatch", Price = 179},
                new Gadget {Name = "Accessories", Price = 10}
            });

            mykernel.Bind<IGadgetRepository>().ToConstant(myMock.Object);
            */


            mykernel.Bind<IGadgetRepository>().To<EFGadgetRepository>();
            }   
       }

    }
