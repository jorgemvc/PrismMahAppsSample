using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace PrismMahAppsSample.Infrastructure.Base {
  public abstract class PrismBaseModule : IModule {

    #region Properties
    public IUnityContainer UnityContainer { get; }
    public IRegionManager RegionManager { get; }
    #endregion Properties

    #region Constructor
    protected PrismBaseModule(
      IUnityContainer unityContainer,
      IRegionManager regionManager
    ) {
      UnityContainer = unityContainer;
      RegionManager = regionManager;
    }
    #endregion Constructor

    #region Interface IModule
    public virtual void OnInitialized(IContainerProvider containerProvider) {
    }

    public virtual void RegisterTypes(IContainerRegistry containerRegistry) {
    }
    #endregion Interface IModule

  }
}
