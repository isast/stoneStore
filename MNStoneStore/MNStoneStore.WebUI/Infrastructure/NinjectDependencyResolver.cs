using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using MNStoneStore.Domain.Abstract;
using MNStoneStore.Domain.Entities;
using MNStoneStore.Domain.Concrete;
using System.Configuration;
using MNStoneStore.WebUI.Infrastructure.Abstract;
using MNStoneStore.WebUI.Infrastructure.Concrete;

namespace MNStoneStore.WebUI.Infrastructure
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

        private void AddBindings()
        {
            //Mock<IProductRepository> myMock = new Mock<IProductRepository>();
            //myMock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product { Name = "Football", Price = 25},
            //    new Product { Name = "Surf Board", Price = 179},
            //    new Product { Name = "Running shoes", Price = 95}
            //});
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse
                (ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            mykernel.Bind<IOrderProcessor>()
                            .To<EmailOrderProcessor>()
                            .WithConstructorArgument("settings", emailSettings);

            mykernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}