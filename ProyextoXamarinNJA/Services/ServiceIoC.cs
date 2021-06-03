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
            builder.RegisterType<ServiceCoche>();
            builder.RegisterType<CochesViewModel>();
            builder.RegisterType<CocheViewModel>();

            this.container = builder.Build();
        }

        public CochesViewModel CochesViewModel
        {
            get { return this.container.Resolve<CochesViewModel>(); }
        }

        public CocheViewModel CocheViewModel
        {
            get { return this.container.Resolve<CocheViewModel>(); }
        }
    }
}
