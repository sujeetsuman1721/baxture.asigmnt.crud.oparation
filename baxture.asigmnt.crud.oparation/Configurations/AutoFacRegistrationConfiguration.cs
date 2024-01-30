using Autofac;
using AutoMapper;
using baxture.asigmnt.crud.oparation.Application.Commands.UserRegistration;
using baxture.asigmnt.crud.oparation.ApplicationService.ApplicationServices;
using baxture.asigmnt.crud.oparation.domain.Repositories;
using baxture.asigmnt.crud.oparation.persistance.Repositories;
using baxture.asigmnt.crud.oparation.services;
using MediatR;
using System.Reflection;

namespace baxture.asigmnt.crud.oparation.Configurations
{
    public static class AutoFacRegistrationConfiguration
    {
        public static ContainerBuilder RegisterApplicationServices(this ContainerBuilder container,ServiceCollection services)
        {
            container.RegisterType<UserService>().As<IUserServices>().InstancePerLifetimeScope();

            return container;
        }

        public static ContainerBuilder RegiterMapper(this ContainerBuilder container)
        {
            container.RegisterType<MappingProfile>().As<Profile>();
            container.Register(c => new MapperConfiguration(cfg =>
             {
                 foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                 {
                     cfg.AddProfile(profile);
                 }
             })).AsSelf().SingleInstance();

            container.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
            return container;
        }

        public static ContainerBuilder RegisterMediatorHandlers(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            containerBuilder.Register<ServiceFactory>(ctx =>
            {
                IComponentContext c = ctx.Resolve<IComponentContext>();
                return type =>
                {
                    return c.TryResolve(type, out object o) ? o : null;
                };
            });

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                containerBuilder
                    .RegisterAssemblyTypes(typeof(UserRegistrationCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            return containerBuilder;
        }

        public static ContainerBuilder RegisterRepositories(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            return containerBuilder;
        }

    }
}
