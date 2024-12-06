using MediatrClone.Library.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatrClone.Library
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomMediator(this IServiceCollection services, Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(assembly => assembly.GetTypes()).Where(i => i.IsClass);

            var RequestHandlers = types.Where(c => ControlMethod(c, typeof(IRequestHandler<,>))).ToList();

            foreach (var requestHandler in RequestHandlers)
            {
                var handlerInterface = requestHandler.GetInterfaces().FirstOrDefault();
                var requestType = handlerInterface!.GetGenericArguments()[0];
                var responseType = handlerInterface!.GetGenericArguments()[1];
                var genericType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

                services.AddTransient(genericType, requestHandler);
            }
            services.AddSingleton<IMediator, Mediator>();

            return services;
        }

        public static IServiceProvider UseCustomMediator(this IServiceProvider serviceProvider)
        {
            ServiceProvider.SetInstance(serviceProvider);
            return serviceProvider;
        }

        private static bool ControlMethod(Type givenType, Type genericType)
        {
            bool IsGeneric(Type givenType, Type genericType)
            {
                return givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType;
            }

            var interfaceTypes = givenType.GetInterfaces();
            foreach (var interfaceType in interfaceTypes)
                return IsGeneric(interfaceType, genericType);


            Type baseType = givenType.BaseType;
            if (baseType == null) return false;
            return ControlMethod(baseType, genericType);
        }
    }

}


