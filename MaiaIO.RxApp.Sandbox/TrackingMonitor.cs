namespace MaiaIO.RxApp.Sandbox
{
    public class TrackingMonitor : IObserver<TrackingInfo>
    {

        private readonly Guid _UidPedido;
        private readonly List<Guid> _pedidos = new();
        private IDisposable? _cancellation;

        public TrackingMonitor(Guid uidPedido)
        {
            _UidPedido = uidPedido;
        }


        public virtual void Subscribe(Trackinghandler provider) =>
            _cancellation = provider.Subscribe(this);


        public virtual void Unsubscribe()
        {
            _cancellation?.Dispose();
            _pedidos.Clear();
        }

        public void OnCompleted()
        {
            _pedidos.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(TrackingInfo value)
        {
           bool updated = false;
           var(origem, destino, pedido) = value;
            Console.WriteLine($"{origem} - {destino} - {pedido}");

        }
    }
}
