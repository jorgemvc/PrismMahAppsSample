using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Events;
using PrismMahAppsSample.Infrastructure.Interfaces;
using PrismMahAppsSample.ModuleA.Views;
using System.Windows.Input;
using Unity;

namespace PrismMahAppsSample.ModuleA.ViewModels {
  public class HomeTilesViewModel : ViewModelBase {

    public HomeTilesViewModel(
      IUnityContainer container,
      IRegionManager regionManager,
      IEventAggregator eventAggregator,
      IMetroMessageDisplayService metroMessageDisplayService,
      IDialogService dialogService
    ) : base(container, regionManager, eventAggregator) {
      // Initialize commands
      IntializeCommands();
      MetroMessageDisplayService = metroMessageDisplayService;
      DialogService = dialogService;
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
      var p = new DialogParameters {
        { "message", "This is a test message" }
      };
      DialogService.ShowDialog(nameof(ModuleAPopup), p, r => {
        string message;
        if (r.Result == ButtonResult.OK) {
          message = r.Parameters.GetValue<string>("myParam");
        } else {
          message = "Okay button not clicked";
        }
        EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(message);
      });
    }

    /// <summary>
    /// Show popup
    /// </summary>
    public ICommand ShowModuleAMessageCommand { get; private set; }
    public IMetroMessageDisplayService MetroMessageDisplayService { get; }
    public IDialogService DialogService { get; }

    /// <summary>
    /// Show message
    /// </summary>
    public void ShowModuleAMessage() {
      _ = MetroMessageDisplayService.ShowDialogMessageAsync("Module A Message", "This is a message from Module A");
    }

    #endregion Commands
  }
}
