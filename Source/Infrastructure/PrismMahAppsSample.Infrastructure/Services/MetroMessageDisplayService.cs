using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PrismMahAppsSample.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismMahAppsSample.Infrastructure.Services {

  public class MetroMessageDisplayService : IMetroMessageDisplayService {

    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="container">Unity container.</param>
    public MetroMessageDisplayService(
    // IUnityContainer container
    ) {
      // MainWindow = container.Resolve<MetroWindow>(WindowNames.MainWindowName);
    }

    #region Properties

    /// <summary>
    /// The main window
    /// </summary>
    public MetroWindow MainWindow { get; private set; }

    #endregion Properties

    public async Task<MessageDialogResult> ShowDialogMessageAsync(
      string title,
      string message,
      MessageDialogStyle style = MessageDialogStyle.Affirmative,
      MetroDialogSettings settings = null
    ) {
      MainWindow = Application.Current.Windows.OfType<MetroWindow>().SingleOrDefault(x => x.IsActive);
      MainWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

      return await MainWindow.ShowMessageAsync(title, message, style, MainWindow.MetroDialogOptions);
    }

  }
}
