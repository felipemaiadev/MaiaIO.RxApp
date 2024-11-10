// See https://aka.ms/new-console-template for more information
using MaiaIO.RxApp.Sandbox.Tracking;

Trackinghandler provider = new();
TrackingMonitor trc1 = new(Guid.NewGuid());   // Monitor connected
TrackingMonitor trc2 = new(Guid.NewGuid());  //  Other device connected

//trc1.Subscribe(provider);

provider.TrackignStatus(1, 2, Guid.NewGuid());
provider.TrackignStatus(5, 6, Guid.NewGuid());

trc2.Subscribe(provider);

provider.TrackignStatus(18, 31, Guid.NewGuid());
provider.TrackignStatus(16, 4, Guid.NewGuid());

//estoque.BuscaPorEstoque(true, 2);