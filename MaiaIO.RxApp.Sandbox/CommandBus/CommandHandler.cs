namespace MaiaIO.RxApp.Sandbox.CommandBus
{

    public record struct Payload(
        string nome,
        int idade
    );

    public readonly record struct UserInfo(
           string command,
           Payload payload
     );




    public class CommandHandler : IObservable<UserInfo>
    {

        private readonly HashSet<UserInfo> _notification;
        private readonly List<HashSet<UserInfo>> _notificationsBus;


        public IDisposable CommandSubscription(IObserver<UserInfo> observer, Guid userUid)
        {


            return Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<UserInfo> observer)
        {
            throw new NotImplementedException();
        }
    }
}
