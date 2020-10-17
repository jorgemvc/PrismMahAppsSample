using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;

namespace PrismMahAppsSample.Infrastructure.Interfaces {

  public interface IMetroMessageDisplayService {
    Task<MessageDialogResult> ShowDialogMessageAsync(string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null);
  }

}
