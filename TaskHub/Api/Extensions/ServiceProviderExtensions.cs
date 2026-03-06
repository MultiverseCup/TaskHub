using Api.Services;

namespace Api.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void TestService<TService>(this IServiceProvider provider)
            where TService : IHasInstanceId
        {
            var first = provider.GetService<TService>();
            var second = provider.GetService<TService>();

            Console.WriteLine(typeof(TService).Name);
            Console.WriteLine($"First:  {first.InstanceId}");
            Console.WriteLine($"Second: {second.InstanceId}");

            Console.WriteLine(first.InstanceId == second.InstanceId
                ? "Same instance"
                : "Different instances");

            Console.WriteLine();
        }
    }
}
