// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathMuradTests.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the MathMuradTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Tests
{
  using System;

  using Calculon.Math.Murad;

  using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

  /// <summary>
  /// The math murad tests.
  /// </summary>
  [TestClass]
  public class MathMuradTests
  {
    /// <summary>
    /// The test.
    /// </summary>
    [TestMethod]
    public void Test()
    {
      var data = new TestData();

       foreach (var d in data.Data)
       {
         try
         {
           var expression = ExpressionParser.Parse(d.Key);
           Assert.AreEqual(d.Value, expression.Result(), d.Key);
         }
         catch (Exception ex)
         {
           Assert.IsTrue(false, d.Key + "=" + d.Value + " " + ex.Message + " " + ex.StackTrace);
         }
       }
    }
  }
}