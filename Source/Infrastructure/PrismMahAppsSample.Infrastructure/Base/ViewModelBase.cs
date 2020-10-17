using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace PrismMahAppsSample.Infrastructure.Base {
  public abstract class ViewModelBase : BindableBase {

    #region Properties
    public IUnityContainer Container { get; }
    public IRegionManager RegionManager { get; }
    public IEventAggregator EventAggregator { get; }
    #endregion

    protected ViewModelBase(
      IUnityContainer container,
      IRegionManager regionManager,
      IEventAggregator eventAggregator) {
      Container = container;
      RegionManager = regionManager;
      EventAggregator = eventAggregator;
    }

  }
}
