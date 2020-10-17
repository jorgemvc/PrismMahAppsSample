using MahApps.Metro.Controls;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Interfaces;

namespace PrismMahAppsSample.Shell.Views {

  public partial class ShellSettingsFlyout : Flyout, IFlyoutView {

    public string FlyoutName => FlyoutNames.ShellSettingsFlyout;

    public ShellSettingsFlyout() {
      InitializeComponent();
    }

  }
}
