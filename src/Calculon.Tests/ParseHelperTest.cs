// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParseHelperTest.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the ParseHelperTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Tests
{
  using Calculon.Math.Utilities;

  using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

  /// <summary>
  /// The parse helper test.
  /// </summary>
  [TestClass]
  public class ParseHelperTest
  {
    /// <summary>
    /// The try parse test.
    /// </summary>
    [TestMethod]
     public void TryParseTest()
     {
       double result;
       var res = "-9.0".TryParseAnyway(out result);
       Assert.IsTrue(res);
       Assert.AreEqual(-9, result);
     }
  }
}