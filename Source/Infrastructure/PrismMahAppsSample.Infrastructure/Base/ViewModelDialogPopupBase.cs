﻿using Prism.Mvvm;
using System.Windows.Media;

namespace PrismMahAppsSample.Infrastructure.Base {

  public abstract class ViewModelDialogPopupBase : BindableBase {
    /// <summary>
    /// View title
    /// </summary>
    public abstract string Title { get; }

    /// <summary>
    /// The dialog icon
    /// </summary>
    public abstract ImageSource Icon { get; }
  }
}
