using Autofac;
using ProyextoXamarinNJA.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyextoXamarinNJA.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceCoches>();
            builder.RegisterType<CochesViewModel>();
            this.container = builder.Build();
        }

        public CochesViewModel CochesViewModel
        {
            get { return this.container.Resolve<CochesViewModel>(); }
        }
    }
}
