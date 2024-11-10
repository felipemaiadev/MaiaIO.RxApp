namespace MaiaIO.RxApp.Sandbox
{

    public readonly record struct TrackingInfo(
            int UnidadeOrigem,
            int UnidadeDestino,
            Guid UidPedido
    );


    public sealed class Trackinghandler: IObservable<TrackingInfo>
    {

        public readonly HashSet<IObserver<TrackingInfo>> _observers = new();
        public readonly HashSet<TrackingInfo> _transports = new();


        public IDisposable Subscribe(IObserver<TrackingInfo> observer)
        {
            if( _observers.Add(observer))
            {
                foreach (var item in _transports)
                {
                    observer.OnNext(item);
                }
            }

            return new Unsubscriber<TrackingInfo>(_observers, observer);
        }


        public void TrackignStatus(Guid uidPedido) =>
            TrackignStatus(0, 0, uidPedido);

        public void TrackignStatus(int unidadeOrigem, int unidadeDestino, Guid uidPedido)
        {
            var info = new TrackingInfo((int) unidadeOrigem, (int) unidadeDestino, uidPedido);

            if( _transports.Add(info))
            {
                foreach(IObserver<TrackingInfo> observer in _observers)
                {
                    observer.OnNext(info);
                }
            }

        }
    }

    internal sealed class Unsubscriber<TrackingInfo> : IDisposable
    {
        private readonly ISet<IObserver<TrackingInfo>> _observers;
        private readonly IObserver<TrackingInfo> _observer;

        internal Unsubscriber(
            ISet<IObserver<TrackingInfo>> observers,
            IObserver<TrackingInfo> observer) => (_observers, _observer) = (observers, observer);

        public void Dispose() => _observers.Remove(_observer);
    }

}