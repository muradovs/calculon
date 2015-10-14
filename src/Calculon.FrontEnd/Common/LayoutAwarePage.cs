// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutAwarePage.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Typical implementation of Page that provides several important conveniences:
//   <list type="bullet">
//   <item>
//   <description>Application view state to visual state mapping</description>
//   </item>
//   <item>
//   <description>GoBack, GoForward, and GoHome event handlers</description>
//   </item>
//   <item>
//   <description>Mouse and keyboard shortcuts for navigation</description>
//   </item>
//   <item>
//   <description>State management for navigation and process lifetime management</description>
//   </item>
//   <item>
//   <description>A default view model</description>
//   </item>
//   </list>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.FrontEnd.Common
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;

  using Windows.Foundation.Collections;
  using Windows.UI.Core;
  using Windows.UI.ViewManagement;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;

  /// <summary>
  /// Typical implementation of Page that provides several important conveniences:
  /// <list type="bullet">
  /// <item>
  /// <description>Application view state to visual state mapping</description>
  /// </item>
  /// <item>
  /// <description>GoBack, GoForward, and GoHome event handlers</description>
  /// </item>
  /// <item>
  /// <description>Mouse and keyboard shortcuts for navigation</description>
  /// </item>
  /// <item>
  /// <description>State management for navigation and process lifetime management</description>
  /// </item>
  /// <item>
  /// <description>A default view model</description>
  /// </item>
  /// </list>
  /// </summary>
  [Windows.Foundation.Metadata.WebHostHidden]
  public class LayoutAwarePage : Page
  {
    /// <summary>
    /// Identifies the <see cref="DefaultViewModel"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty DefaultViewModelProperty = DependencyProperty.Register(
      "DefaultViewModel", typeof(IObservableMap<String, Object>), typeof(LayoutAwarePage), null);

    /// <summary>
    /// The _layout aware controls.
    /// </summary>
    private List<Control> _layoutAwareControls;

    /// <summary>
    /// Initializes a new instance of the <see cref="LayoutAwarePage"/> class.
    /// </summary>
    public LayoutAwarePage()
    {
      if (Windows.ApplicationModel.DesignMode.DesignModeEnabled) return;

      // Create an empty default view model
      this.DefaultViewModel = new ObservableDictionary<String, Object>();

      // When this page is part of the visual tree make two changes:
      // 1) Map application view state to visual state for the page
      // 2) Handle keyboard and mouse navigation requests
      this.Loaded += this.StartLayoutUpdates;

      // Undo the same changes when the page is no longer visible
      this.Unloaded += this.StopLayoutUpdates;
    }

    /// <summary>
    /// An implementation of <see cref="IObservableMap&lt;String, Object&gt;"/> designed to be
    /// used as a trivial view model.
    /// </summary>
    protected IObservableMap<String, Object> DefaultViewModel
    {
      get
      {
        return this.GetValue(DefaultViewModelProperty) as IObservableMap<String, Object>;
      }

      set
      {
        this.SetValue(DefaultViewModelProperty, value);
      }
    }

    #region Navigation support

    /// <summary>
    /// Invoked as an event handler to navigate backward in the page's associated
    /// <see cref="Frame"/> until it reaches the top of the navigation stack.
    /// </summary>
    /// <param name="sender">Instance that triggered the event.</param>
    /// <param name="e">Event data describing the conditions that led to the event.</param>
    protected virtual void GoHome(object sender, RoutedEventArgs e)
    {
      // Use the navigation frame to return to the topmost page
      if (this.Frame != null)
      {
        while (this.Frame.CanGoBack) this.Frame.GoBack();
      }
    }

    /// <summary>
    /// Invoked as an event handler to navigate backward in the navigation stack
    /// associated with this page's <see cref="Frame"/>.
    /// </summary>
    /// <param name="sender">Instance that triggered the event.</param>
    /// <param name="e">Event data describing the conditions that led to the
    /// event.</param>
    protected virtual void GoBack(object sender, RoutedEventArgs e)
    {
      // Use the navigation frame to return to the previous page
      if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
    }
   
    #endregion

    #region Visual state switching

    /// <summary>
    /// Invoked as an event handler, typically on the <see cref="FrameworkElement.Loaded"/>
    /// event of a <see cref="Control"/> within the page, to indicate that the sender should
    /// start receiving visual state management changes that correspond to application view
    /// state changes.
    /// </summary>
    /// <param name="sender">Instance of <see cref="Control"/> that supports visual state
    /// management corresponding to view states.</param>
    /// <param name="e">Event data that describes how the request was made.</param>
    /// <remarks>The current view state will immediately be used to set the corresponding
    /// visual state when layout updates are requested.  A corresponding
    /// <see cref="FrameworkElement.Unloaded"/> event handler connected to
    /// <see cref="StopLayoutUpdates"/> is strongly encouraged.  Instances of
    /// <see cref="LayoutAwarePage"/> automatically invoke these handlers in their Loaded and
    /// Unloaded events.</remarks>
    /// <seealso cref="DetermineVisualState"/>
    /// <seealso cref="InvalidateVisualState"/>
    public void StartLayoutUpdates(object sender, RoutedEventArgs e)
    {
      var control = sender as Control;
      if (control == null) return;
      if (this._layoutAwareControls == null)
      {
        // Start listening to view state changes when there are controls interested in updates
        Window.Current.SizeChanged += this.WindowSizeChanged;
        this._layoutAwareControls = new List<Control>();
      }
      this._layoutAwareControls.Add(control);

      // Set the initial visual state of the control
      VisualStateManager.GoToState(control, DetermineVisualState(ApplicationView.Value), false);
    }

    private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
    {
      this.InvalidateVisualState();
    }

    /// <summary>
    /// Invoked as an event handler, typically on the <see cref="FrameworkElement.Unloaded"/>
    /// event of a <see cref="Control"/>, to indicate that the sender should start receiving
    /// visual state management changes that correspond to application view state changes.
    /// </summary>
    /// <param name="sender">Instance of <see cref="Control"/> that supports visual state
    /// management corresponding to view states.</param>
    /// <param name="e">Event data that describes how the request was made.</param>
    /// <remarks>The current view state will immediately be used to set the corresponding
    /// visual state when layout updates are requested.</remarks>
    /// <seealso cref="StartLayoutUpdates"/>
    public void StopLayoutUpdates(object sender, RoutedEventArgs e)
    {
      var control = sender as Control;
      if (control == null || this._layoutAwareControls == null) return;
      this._layoutAwareControls.Remove(control);
      if (this._layoutAwareControls.Count == 0)
      {
        // Stop listening to view state changes when no controls are interested in updates
        this._layoutAwareControls = null;
        Window.Current.SizeChanged -= this.WindowSizeChanged;
      }
    }

    /// <summary>
    /// Translates <see cref="ApplicationViewState"/> values into strings for visual state
    /// management within the page.  The default implementation uses the names of enum values.
    /// Subclasses may override this method to control the mapping scheme used.
    /// </summary>
    /// <param name="viewState">View state for which a visual state is desired.</param>
    /// <returns>Visual state name used to drive the
    /// <see cref="VisualStateManager"/></returns>
    /// <seealso cref="InvalidateVisualState"/>
    protected virtual string DetermineVisualState(ApplicationViewState viewState)
    {
      return viewState.ToString();
    }

    /// <summary>
    /// Updates all controls that are listening for visual state changes with the correct
    /// visual state.
    /// </summary>
    /// <remarks>
    /// Typically used in conjunction with overriding <see cref="DetermineVisualState"/> to
    /// signal that a different value may be returned even though the view state has not
    /// changed.
    /// </remarks>
    public void InvalidateVisualState()
    {
      if (this._layoutAwareControls != null)
      {
        string visualState = DetermineVisualState(ApplicationView.Value);
        foreach (var layoutAwareControl in this._layoutAwareControls)
        {
          VisualStateManager.GoToState(layoutAwareControl, visualState, false);
        }
      }
    }

    #endregion

    /// <summary>
    /// Implementation of IObservableMap that supports reentrancy for use as a default view
    /// model.
    /// </summary>
    private class ObservableDictionary<K, V> : IObservableMap<K, V>
    {
      /// <summary>
      /// The observable dictionary changed event args.
      /// </summary>
      private class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<K>
      {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableDictionaryChangedEventArgs"/> class.
        /// </summary>
        /// <param name="change">
        /// The change.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        public ObservableDictionaryChangedEventArgs(CollectionChange change, K key)
        {
          this.CollectionChange = change;
          this.Key = key;
        }

        /// <summary>
        /// Gets the collection change.
        /// </summary>
        public CollectionChange CollectionChange { get; private set; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        public K Key { get; private set; }
      }

      /// <summary>
      /// The _dictionary.
      /// </summary>
      private Dictionary<K, V> _dictionary = new Dictionary<K, V>();

      /// <summary>
      /// The map changed.
      /// </summary>
      public event MapChangedEventHandler<K, V> MapChanged;

      /// <summary>
      /// The invoke map changed.
      /// </summary>
      /// <param name="change">
      /// The change.
      /// </param>
      /// <param name="key">
      /// The key.
      /// </param>
      private void InvokeMapChanged(CollectionChange change, K key)
      {
        var eventHandler = MapChanged;
        if (eventHandler != null)
        {
          eventHandler(this, new ObservableDictionaryChangedEventArgs(change, key));
        }
      }

      /// <summary>
      /// The add.
      /// </summary>
      /// <param name="key">
      /// The key.
      /// </param>
      /// <param name="value">
      /// The value.
      /// </param>
      public void Add(K key, V value)
      {
        this._dictionary.Add(key, value);
        this.InvokeMapChanged(CollectionChange.ItemInserted, key);
      }

      /// <summary>
      /// The add.
      /// </summary>
      /// <param name="item">
      /// The item.
      /// </param>
      public void Add(KeyValuePair<K, V> item)
      {
        this.Add(item.Key, item.Value);
      }

      /// <summary>
      /// The remove.
      /// </summary>
      /// <param name="key">
      /// The key.
      /// </param>
      /// <returns>
      /// The <see cref="bool"/>.
      /// </returns>
      public bool Remove(K key)
      {
        if (this._dictionary.Remove(key))
        {
          this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
          return true;
        }
        return false;
      }

      /// <summary>
      /// The remove.
      /// </summary>
      /// <param name="item">
      /// The item.
      /// </param>
      /// <returns>
      /// The <see cref="bool"/>.
      /// </returns>
      public bool Remove(KeyValuePair<K, V> item)
      {
        V currentValue;
        if (this._dictionary.TryGetValue(item.Key, out currentValue) &&
            Equals(item.Value, currentValue) && this._dictionary.Remove(item.Key))
        {
          this.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key);
          return true;
        }
        return false;
      }

      /// <summary>
      /// The this.
      /// </summary>
      /// <param name="key">
      /// The key.
      /// </param>
      /// <returns>
      /// The <see cref="V"/>.
      /// </returns>
      public V this[K key]
      {
        get
        {
          return this._dictionary[key];
        }
        set
        {
          this._dictionary[key] = value;
          this.InvokeMapChanged(CollectionChange.ItemChanged, key);
        }
      }

      /// <summary>
      /// The clear.
      /// </summary>
      public void Clear()
      {
        var priorKeys = this._dictionary.Keys.ToArray();
        this._dictionary.Clear();
        foreach (var key in priorKeys)
        {
          this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
        }
      }

      /// <summary>
      /// Gets the keys.
      /// </summary>
      public ICollection<K> Keys
      {
        get { return this._dictionary.Keys; }
      }

      /// <summary>
      /// The contains key.
      /// </summary>
      /// <param name="key">
      /// The key.
      /// </param>
      /// <returns>
      /// The <see cref="bool"/>.
      /// </returns>
      public bool ContainsKey(K key)
      {
        return this._dictionary.ContainsKey(key);
      }

      /// <summary>
      /// The try get value.
      /// </summary>
      /// <param name="key">
      /// The key.
      /// </param>
      /// <param name="value">
      /// The value.
      /// </param>
      /// <returns>
      /// The <see cref="bool"/>.
      /// </returns>
      public bool TryGetValue(K key, out V value)
      {
        return this._dictionary.TryGetValue(key, out value);
      }

      /// <summary>
      /// Gets the values.
      /// </summary>
      public ICollection<V> Values
      {
        get { return this._dictionary.Values; }
      }

      /// <summary>
      /// The contains.
      /// </summary>
      /// <param name="item">
      /// The item.
      /// </param>
      /// <returns>
      /// The <see cref="bool"/>.
      /// </returns>
      public bool Contains(KeyValuePair<K, V> item)
      {
        return this._dictionary.Contains(item);
      }

      /// <summary>
      /// Gets the count.
      /// </summary>
      public int Count
      {
        get { return this._dictionary.Count; }
      }

      /// <summary>
      /// Gets a value indicating whether is read only.
      /// </summary>
      public bool IsReadOnly
      {
        get { return false; }
      }

      /// <summary>
      /// The get enumerator.
      /// </summary>
      /// <returns>
      /// The <see cref="IEnumerator"/>.
      /// </returns>
      public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
      {
        return this._dictionary.GetEnumerator();
      }

      /// <summary>
      /// The get enumerator.
      /// </summary>
      /// <returns>
      /// The <see cref="IEnumerator"/>.
      /// </returns>
      IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return this._dictionary.GetEnumerator();
      }

      /// <summary>
      /// The copy to.
      /// </summary>
      /// <param name="array">
      /// The array.
      /// </param>
      /// <param name="arrayIndex">
      /// The array index.
      /// </param>
      public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
      {
        int arraySize = array.Length;
        foreach (var pair in this._dictionary)
        {
          if (arrayIndex >= arraySize)
          {
            break;
          }

          array[arrayIndex++] = pair;
        }
      }
    }
  }
}
