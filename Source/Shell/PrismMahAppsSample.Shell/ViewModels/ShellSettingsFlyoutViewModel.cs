using ControlzEx.Theming;
using Prism.Events;
using Prism.Regions;
using PrismMahAppsSample.Infrastructure.Base;
using PrismMahAppsSample.Infrastructure.Constants;
using PrismMahAppsSample.Infrastructure.Events;
using PrismMahAppsSample.Infrastructure.Interfaces;
using PrismMahAppsSample.Shell.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Unity;

namespace PrismMahAppsSample.Shell.ViewModels {
  public class ShellSettingsFlyoutViewModel : ViewModelBase {

    public ObservableCollection<ApplicationTheme> ApplicationThemes { get; set; }
    public ObservableCollection<AccentColor> AccentColors { get; set; }
    public ObservableCollection<CultureInfo> SupportedLanguages { get; set; }

    public ILocalizerService localizerService { get; }

    public ShellSettingsFlyoutViewModel(
      IUnityContainer container,
      IRegionManager regionManager,
      IEventAggregator eventAggregator
    ) : base(container, regionManager, eventAggregator) {
      localizerService = Container.Resolve<ILocalizerService>(ServiceNames.LocalizerService);

      SupportedLanguages = new ObservableCollection<CultureInfo>(localizerService.SupportedLanguages);

      var lst = ThemeManager.Current.Themes
                          .Select(a => new {
                            Theme = a.Name.Split('.')[0],
                            Color = a.Name.Split('.')[1]
                          }).ToList();

      var lstThemes = lst.Select(x => x.Theme).Distinct();
      var lstColors = lst.Select(x => x.Color).Distinct();

      ApplicationThemes = new ObservableCollection<ApplicationTheme>(lstThemes.Select(x => new ApplicationTheme { Name = x }).ToList());
      SelectedTheme = ApplicationThemes.FirstOrDefault();

      AccentColors = new ObservableCollection<AccentColor>(lstColors.OrderBy(x => x).Select(x => new AccentColor { Name = x }).ToList());
      SelectedAccentColor = AccentColors.FirstOrDefault(x => x.Name == "Cyan");
    }  // constructor

    #region Properties

    private AccentColor selectedAccentColor;
    public AccentColor SelectedAccentColor {
      get { return selectedAccentColor; }
      set {
        SetProperty(ref selectedAccentColor, value);
        if (SelectedTheme != null && SelectedAccentColor != null) {
          ThemeManager.Current.ChangeTheme(Application.Current, $"{SelectedTheme.Name}.{SelectedAccentColor.Name}");
          EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish($"Accent color changed to {value.Name}");
        }
      }
    }

    private ApplicationTheme selectedTheme;
    public ApplicationTheme SelectedTheme {
      get { return selectedTheme; }
      set {
        if (SetProperty(ref selectedTheme, value)) {
          if (SelectedTheme != null && SelectedAccentColor != null) {
            ThemeManager.Current.ChangeTheme(Application.Current, $"{SelectedTheme.Name}.{SelectedAccentColor.Name}");
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish($"Theme changed to {value.Name}");
          }
        }
      }
    }

    public CultureInfo SelectedLanguage {
      get { return localizerService?.SelectedLanguage; }
      set {
        if (value != null && value != localizerService.SelectedLanguage) {
          if (localizerService != null) {
            localizerService.SelectedLanguage = value;
          }
        }
      }
    }

    #endregion Properties
  }
}
