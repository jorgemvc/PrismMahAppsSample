using Prism.Commands;
using Prism.Services.Dialogs;
using PrismMahAppsSample.Infrastructure.Base;
using System;
using System.Windows;
using System.Windows.Media;

namespace PrismMahAppsSample.ModuleA.ViewModels {

  public class ModuleAPopupViewModel : ViewModelDialogPopupBase, IDialogAware {

    public event Action<IDialogResult> RequestClose;

    public DelegateCommand CloseDialogCommand { get; private set; }

    public override string Title => "Module A - Custom Popup";

    private string message;
    public string Message {
      get { return message; }
      set { SetProperty(ref message, value); }
    }

    public ModuleAPopupViewModel() {
      CloseDialogCommand = new DelegateCommand(CloseDialog);

      Icon = Application.Current.Resources["add_on_16x16"] as ImageSource;
    }

    private void CloseDialog() {
      var result = ButtonResult.OK;
      var p = new DialogParameters {
        { "myParam", "The dialog was closed by the user" }
      };
      RequestClose?.Invoke(new DialogResult(result, p));
    }

    public bool CanCloseDialog() {
      return true;
    }

    public void OnDialogClosed() {
    }

    public void OnDialogOpened(IDialogParameters parameters) {
      Message = parameters.GetValue<string>("message");
    }

  }
}
