namespace Api.Services
{
    public abstract class DisposedService : IDisposable, IHasInstanceId
    {
        public Guid InstanceId { get; } = Guid.NewGuid();

        protected DisposedService()
        {
            Console.WriteLine($"Create {GetType().Name} {InstanceId}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose {GetType().Name} {InstanceId}");
        }
    }
}
