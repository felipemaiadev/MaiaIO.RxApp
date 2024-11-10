using System.Collections.ObjectModel;

namespace MaiaIO.RxApp.Sandbox.CommandBus
{
    public class StoreCommands
    {

        private readonly ReadOnlyDictionary<string, IObservable<object>> _commands;

        public StoreCommands() { }

        public bool AddCommand(string name, IObservable<object> commandObservable) 
        { 
            return _commands.TryAdd(name, commandObservable);
        }

        public bool RemoveCommand(string name)
        {
            IObservable<object> command;
            return _commands.Remove(name, out command);
        }

        public void CommandSubscription(string name, IObserver<object> handler)
        {
            IObservable<object> handlerObj;
            bool result   = _commands.TryGetValue(name, out handlerObj);

            if (result) handlerObj.Subscribe(handler);
        }


    }
}
