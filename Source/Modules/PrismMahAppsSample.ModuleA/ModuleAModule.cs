using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.ModuleA.Views;
using Unity;

namespace PrismMahAppsSample.ModuleA {
  public class ModuleAModule : PrismBaseModule {

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="unityContainer">The Unity container.</param>
    /// <param name="regionManager">The region manager.</param>
    public ModuleAModule(
      IUnityContainer unityContainer, 
      IRegionManager regionManager
    ) : base(unityContainer, regionManager) {
      // Titlebar
      regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));

      // Flyouts
      regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C1Flyout));
      regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C2Flyout));

      // Tiles
      regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));
    }

    public override void RegisterTypes(IContainerRegistry containerRegistry) {
      base.RegisterTypes(containerRegistry);
      containerRegistry.RegisterForNavigation<ModuleAPopup>();
    }

  }
}
