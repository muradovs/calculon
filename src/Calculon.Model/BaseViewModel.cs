// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model
{
  using System.ComponentModel;
  using System.Runtime.CompilerServices;

  /// <summary>
  /// The base view model.
  /// </summary>
  public class BaseViewModel : INotifyPropertyChanged
  {
    /// <summary>
    /// The property changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// The on property changed.
    /// </summary>
    /// <param name="propertyName">
    /// The property name.
    /// </param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = this.PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}