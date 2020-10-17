using MahApps.Metro.Controls;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Interfaces;

namespace PrismMahAppsSample.ModuleA.Views {
  /// <summary>
  /// Interaction logic for C1Flyout.xaml
  /// </summary>
  public partial class C1Flyout : Flyout, IFlyoutView {
    public C1Flyout() {
      InitializeComponent();
    }

    public string FlyoutName => FlyoutNames.ModuleAC1Flyout;

  }
}
