using Prism.Mvvm;
using System.Windows.Media;

namespace PrismMahAppsSample.Shell.Model {

  public class AccentColor : BindableBase {

    private string name;
    public string Name {
      get { return name; }
      set { SetProperty(ref name, value); }
    }

    private Brush colorBrush;
    public Brush ColorBrush {
      get { return colorBrush; }
      set { SetProperty(ref colorBrush, value); }
    }

  }
}
