using MahApps.Metro.Controls.Dialogs;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Events;
using PrismMahAppsSample.Shell.Views;

namespace PrismMahAppsSample.Shell.ViewModels {
  public class MainWindowViewModel : BindableBase {

    private string title = "Prism MahApps Sample";
    public string Title {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    private string statusBarMessage;
    public string StatusBarMessage {
      get { return statusBarMessage; }
      set { SetProperty(ref statusBarMessage, value); }
    }

    public IEventAggregator EventAggregator { get; }
    public IRegionManager RegionManager { get; }
    public IDialogCoordinator DialogCoordinator { get; }

    public MainWindowViewModel(
      IEventAggregator eventAggregator,
      IRegionManager regionManager,
      IDialogCoordinator dialogCoordinator
    ) {
      EventAggregator = eventAggregator;
      RegionManager = regionManager;
      DialogCoordinator = dialogCoordinator;
      EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);

      RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));
      RegionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(ShellSettingsFlyout));
      RegionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));
    }

    private void OnStatusBarMessageUpdateEvent(string statusBarMessage) {
      StatusBarMessage = statusBarMessage;
    }

  }
}
