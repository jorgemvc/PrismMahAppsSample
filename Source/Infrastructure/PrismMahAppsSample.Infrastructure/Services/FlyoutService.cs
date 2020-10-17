using MahApps.Metro.Controls;
using Prism.Commands;
using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Interfaces;
using System.Linq;
using System.Windows.Input;

namespace PrismMahAppsSample.Infrastructure.Services {
  public class FlyoutService : IFlyoutService {

    public ICommand ShowFlyoutCommand { get; private set; }

    public IRegionManager RegionManager { get; }

    public FlyoutService(
      IRegionManager regionManager,
      IApplicationCommands applicationCommands
    ) {
      RegionManager = regionManager;
      ShowFlyoutCommand = new DelegateCommand<string>(ShowFlyout, CanShowFlyout);
      applicationCommands.ShowFlyoutCommand.RegisterCommand(ShowFlyoutCommand);
    }

    public void ShowFlyout(string flyoutName) {
      var region = RegionManager.Regions[RegionNames.FlyoutRegion];

      if (region != null) {
        if (region.Views.Where(v => v is IFlyoutView view && view.FlyoutName.Equals(flyoutName)).FirstOrDefault() is Flyout flyout) {
          flyout.IsOpen = !flyout.IsOpen;
        }
      }
    }

    public bool CanShowFlyout(string flyoutName) {
      return true;
    }

  }
}
