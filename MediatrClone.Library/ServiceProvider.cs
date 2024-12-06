namespace MediatrClone.Library
{

    public static class ServiceProvider
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider sp => _serviceProvider;

        public static void SetInstance(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }

}
