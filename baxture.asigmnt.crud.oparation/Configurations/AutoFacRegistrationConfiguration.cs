using Autofac;
using AutoMapper;
using baxture.asigmnt.crud.oparation.ApplicationService.ApplicationServices;
using baxture.asigmnt.crud.oparation.services;

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

    }
}
