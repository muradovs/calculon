// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BracketCheckerTest.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BracketCheckerTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Tests
{
  using Calculon.Math.Utilities;

  using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

  /// <summary>
  /// The bracket checker test.
  /// </summary>
  [TestClass]
  public class BracketCheckerTest
  {
    /// <summary>
    /// The test 1.
    /// </summary>
    [TestMethod]
    public void Test1()
    {
      Assert.IsFalse(BracketChecker.CheckCorrectBrackets('(', ')', "sin(pi))"));
      Assert.IsFalse(BracketChecker.CheckCorrectBrackets('(', ')', "sin(((pi))"));
      Assert.IsTrue(BracketChecker.CheckCorrectBrackets('(', ')', "sin(pi)"));
    }
  }
}
