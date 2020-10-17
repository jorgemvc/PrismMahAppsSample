using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismMahAppsSample.Infrastructure;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Interfaces;
using PrismMahAppsSample.Infrastructure.Services;
using PrismMahAppsSample.ModuleA;
using PrismMahAppsSample.ModuleB;
using PrismMahAppsSample.Shell.Views;
using System.Windows;
using Unity;

namespace PrismMahAppsSample.Shell {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : PrismApplication {

    protected override Window CreateShell() {
      return Container.Resolve<MainWindow>(WindowNames.MainWindowName);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry) {
      containerRegistry.Register<IDialogCoordinator, DialogCoordinator>();

      // Application commands
      containerRegistry.Register<IApplicationCommands, ApplicationCommandsProxy>();

      // Flyout service
      containerRegistry.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());

      // Localizer service
      containerRegistry.RegisterInstance(typeof(ILocalizerService), new LocalizerService("en-US"), ServiceNames.LocalizerService);

      // MessageDisplayService
      containerRegistry.RegisterInstance<IMetroMessageDisplayService>(Container.Resolve<MetroMessageDisplayService>());
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) {
      moduleCatalog.AddModule<ModuleAModule>();
      moduleCatalog.AddModule<ModuleBModule>();
    }

  }
}
