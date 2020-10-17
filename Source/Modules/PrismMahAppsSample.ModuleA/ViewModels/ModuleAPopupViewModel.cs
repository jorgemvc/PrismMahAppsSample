using PrismMahAppsSample.Infrastructure.Base;
using System.Windows;
using System.Windows.Media;

namespace PrismMahAppsSample.ModuleA.ViewModels {
  public class ModuleAPopupViewModel : ViewModelDialogPopupBase {

    public ModuleAPopupViewModel() {
    }

    /// <summary>
    /// The view title
    /// </summary>
    public override string Title => "Module A - Custom Popup";

    /// <summary>
    /// The dialog icon
    /// </summary>
    public override ImageSource Icon => Application.Current.Resources["add_on_16x16"] as ImageSource;
  }
}
