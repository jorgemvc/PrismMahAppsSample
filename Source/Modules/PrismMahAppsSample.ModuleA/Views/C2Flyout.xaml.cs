using MahApps.Metro.Controls;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Interfaces;

namespace PrismMahAppsSample.ModuleA.Views {
  /// <summary>
  /// Interaction logic for C2Flyout.xaml
  /// </summary>
  public partial class C2Flyout : Flyout, IFlyoutView {
    public C2Flyout() {
      InitializeComponent();
    }

    public string FlyoutName => FlyoutNames.ModuleAC2Flyout;
  }
}
