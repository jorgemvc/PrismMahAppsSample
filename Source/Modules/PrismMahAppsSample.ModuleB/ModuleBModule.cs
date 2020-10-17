using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.ModuleB.Views;
using Unity;

namespace PrismMahAppsSample.ModuleB {
  public class ModuleBModule : PrismBaseModule {
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="unityContainer">The Unity container.</param>
    /// <param name="regionManager">The region manager.</param>
    public ModuleBModule(
      IUnityContainer unityContainer,
      IRegionManager regionManager
    ) : base(unityContainer, regionManager) {
      // Titlebar
      regionManager.RegisterViewWithRegion(RegionNames.LeftWindowCommandsRegion, typeof(LeftTitlebarCommands));

      // Flyouts
      regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(C1Flyout));

      // Tiles
      regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeTiles));

    }
  }
}
