// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceManager.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The base page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Lib
{
  using System;
  using System.Collections.Generic;

  using Windows.ApplicationModel.Resources;

  /// <summary>
  /// The base page.
  /// </summary>
  public sealed class ResourceManager
  {
    /// <summary>
    /// The lazy.
    /// </summary>
    private static readonly Lazy<ResourceManager> Lazy =
        new Lazy<ResourceManager>(() => new ResourceManager());

    /// <summary>
    /// The resources.
    /// </summary>
    private readonly Dictionary<string, ResourceLoader> resources = new Dictionary<string, ResourceLoader>();

    /// <summary>
    /// Gets the instance.
    /// </summary>
    private static ResourceManager Instance
    {
      get
      {
        return Lazy.Value;
      }
    }

    /// <summary>
    /// The get localized string.
    /// </summary>
    /// <param name="key">
    /// The key.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public static string GetLocalizedString(string key)
    {
      return Instance.GetLocalizedStringLocal(key);
    }

    /// <summary>
    /// The get localized string.
    /// </summary>
    /// <param name="key">
    /// The key.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    private string GetLocalizedStringLocal(string key)
    {
      return this.GetLocalizedStringLocal(string.Empty, key);
    }

    /// <summary>
    /// The get localized string local.
    /// </summary>
    /// <param name="source">
    /// The source.
    /// </param>
    /// <param name="key">
    /// The key.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    private string GetLocalizedStringLocal(string source, string key)
    {
      if (this.resources.ContainsKey(source))
      {
        return this.resources[source].GetString(key);
      }

      {
        try
        {
          if (!string.IsNullOrEmpty(source))
          {
            var loader = new ResourceLoader(source);
            this.resources.Add(source, loader);
            return loader.GetString(key);
          }
          else
          {
            var loader = new ResourceLoader();
            this.resources.Add(source, loader);
            return loader.GetString(key);
          }
        }
        catch (Exception ex)
        {
          Log.Error(ex);
          return string.Empty;
        }
      }
    }
  }
}