using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Interfaces;
using System.Windows.Input;
using Unity;

namespace PrismMahAppsSample.ModuleA.ViewModels {
  public class HomeTilesViewModel : ViewModelBase {

    public HomeTilesViewModel(
      IUnityContainer container,
      IRegionManager regionManager,
      IEventAggregator eventAggregator,
      IMetroMessageDisplayService metroMessageDisplayService
    ) : base(container, regionManager, eventAggregator) {
      // Initialize commands
      IntializeCommands();
      MetroMessageDisplayService = metroMessageDisplayService;
    }

    #region Commands

    /// <summary>
    /// Initialize commands
    /// </summary>
    private void IntializeCommands() {
      ShowModuleAPopupCommand = new DelegateCommand(ShowModuleAPopup);
      ShowModuleAMessageCommand = new DelegateCommand(ShowModuleAMessage);
    }

    /// <summary>
    /// Show popup
    /// </summary>
    public ICommand ShowModuleAPopupCommand { get; private set; }

    public void ShowModuleAPopup() {
      RegionManager.RequestNavigate(RegionNames.DialogPopupRegion, PopupNames.ModuleAPopup);
    }

    /// <summary>
    /// Show popup
    /// </summary>
    public ICommand ShowModuleAMessageCommand { get; private set; }
    public IMetroMessageDisplayService MetroMessageDisplayService { get; }

    /// <summary>
    /// Show message
    /// </summary>
    public void ShowModuleAMessage() {
      _ = MetroMessageDisplayService.ShowDialogMessageAsync("Module A Message", "This is a message from Module A");
    }

    #endregion Commands
  }
}
