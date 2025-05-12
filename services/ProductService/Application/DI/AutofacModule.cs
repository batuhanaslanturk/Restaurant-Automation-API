using Application.Interfaces;
using Application.Services;
using Autofac;
using Domain.Common;
using Domain.Repositories;
using Infrastructure.Common;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.DI
{
    public class AutofacModule : Module
    {
        private readonly IConfiguration _configuration;
        public AutofacModule(IConfiguration conf)
        {
            _configuration = conf;
        }
        protected override void Load(ContainerBuilder builder)
        {
            // Service injection
            builder.RegisterType<CategoryService>()
                   .As<ICategoryService>()
                   .InstancePerLifetimeScope();

            // Repository injection
            builder.RegisterType<CategoryRepository>()
                   .As<ICategoryRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>()
                              .AsSelf()
                              .InstancePerLifetimeScope();
        }
    }
}
