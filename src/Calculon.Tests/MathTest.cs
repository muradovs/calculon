// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathTest.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IntegraTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Tests
{
  using System;
  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.RecognizerProviders;
  using Calculon.Math.Recognizers;

  using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

  /// <summary>
  /// The integra test.
  /// </summary>
  [TestClass]
  public class MathTest
  {
    /// <summary>
    /// The test 1.
    /// </summary>
    [TestMethod]
    public void Test1()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("1+2", oex);
      Assert.AreEqual(3, ex.Value);

      ex = Expression.Create("1+2+3+4+5+6+7", oex);
      Assert.AreEqual(28, ex.Value);
    }

    /// <summary>
    /// The test 2.
    /// </summary>
    [TestMethod]
    public void Test2()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("1+2+(3+4)", oex);
      Assert.AreEqual(10, ex.Value);
    }

    /// <summary>
    /// The test 3.
    /// </summary>
    [TestMethod]
    public void Test3()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("1+2*2+(3+4*4)*2", oex);
      Assert.AreEqual(43, ex.Value);
    }

    /// <summary>
    /// The test 4.
    /// </summary>
    [TestMethod]
    public void Test4()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("(3+4)", oex);
      Assert.AreEqual(7, ex.Value);
    }

    /// <summary>
    /// The test 5.
    /// </summary>
    [TestMethod]
    public void Test5()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("1+9-3*(43+2)+(-9)+3", oex);
      Assert.AreEqual(-131, ex.Value);
    }

    /// <summary>
    /// The test 6.
    /// </summary>
    [TestMethod]
    public void Test6()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("1+9-3*(43+2)-9+3", oex);
      Assert.AreEqual(-131, ex.Value);
    }

    /// <summary>
    /// The test 7.
    /// </summary>
    [TestMethod]
    public void Test7()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var sub = new BinaryOperationRecognizer("-", new LambdaBinaryOperationProvider((x, y) => x - y));
      var add = new BinaryOperationRecognizer("+", new LambdaBinaryOperationProvider((x, y) => x + y));

      var index = sub.Index("135-9+3", oex);
      Assert.AreEqual(3, index);

      index = add.Index("135-9+3", oex);
      Assert.AreEqual(5, index);

      var ex = Expression.Create("1+9-3*(43+2)-9+3", oex);
      Assert.AreEqual(-131, ex.Value);
    }

    /// <summary>
    /// The test 8.
    /// </summary>
    [TestMethod]
    public void Test8()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ex = Expression.Create("135-9+3", oex);
      Assert.AreEqual(129, ex.Value);
    }

    /// <summary>
    /// The test 9.
    /// </summary>
    [TestMethod]
    public void Test9()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());
      var ab = new AbsoluteBracketsOperationRecognizer(new LambdaUnaryOperationProvider(Math.Abs));

      var op = ab.Recognize("|-9|", oex);
      Assert.AreEqual(9, op.Value);

      var sub = new BinaryOperationRecognizer("-", new LambdaBinaryOperationProvider((x, y) => x - y));
      var ind = sub.Index("|-9|", oex);
      Assert.AreEqual(-1, ind);
    }

    /// <summary>
    /// The test 10.
    /// </summary>
    [TestMethod]
    public void Test10()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("3*(43+2)+(-9)", oex);
      Assert.AreEqual(126, ex.Value);
    }

    /// <summary>
    /// The test 11.
    /// </summary>
    [TestMethod]
    public void Test11()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("3*(43+2)+(-9)/3", oex);

      Assert.AreEqual(132, ex.Value);
    }

    /// <summary>
    /// The test 12.
    /// </summary>
    [TestMethod]
    public void Test12()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("pi", oex);
      Assert.AreEqual(Math.PI.ToString(), ex.Value.ToString());
    }

    /// <summary>
    /// The test 13.
    /// </summary>
    [TestMethod]
    public void Test13()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("sin(pi/2)+1+e", oex);
      Assert.AreEqual((Math.Sin(Math.PI / 2d) + 1d + Math.E).ToString().Substring(0, 10), ex.Value.ToString().Substring(0, 10));
    }

    /// <summary>
    /// The test 14.
    /// </summary>
    [TestMethod]
    public void Test14()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("3.5+4^(1+2)", oex);
      Assert.AreEqual(67.5, ex.Value);
    }

    /// <summary>
    /// The test 15.
    /// </summary>
    [TestMethod]
    public void Test15()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("sqrt(sin(pi/2)+sin(pi/2)+sin(pi/2)+sin(pi/2))", oex);
      Assert.AreEqual(2, ex.Value);
    }

    /// <summary>
    /// The test 15.
    /// </summary>
    [TestMethod]
    public void Test16()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("log(sqrt(sin(pi/2)+sin(pi/2)+sin(pi/2)+sin(pi/2)),4)", oex);
      Assert.AreEqual(0.5, ex.Value);

      ex = Expression.Create("log(2,4)", oex);
      Assert.AreEqual(0.5, ex.Value);

      ex = Expression.Create("log(4,2)", oex);
      Assert.AreEqual(2, ex.Value);
    }

    /// <summary>
    /// The test 15.
    /// </summary>
    [TestMethod]
    public void Test17()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var ex = Expression.Create("12+log(log(log(65536,2),2),2)-12", oex);
      Assert.AreEqual(2, ex.Value);
    }

    /// <summary>
    /// The test 15.
    /// </summary>
    [TestMethod]
    public void Test18()
    {
      var oex = new OperationExecutor(new OperationRecognizerProvider());

      var data = new TestData();

      foreach (var d in data.Data)
      {
        var exp = Expression.Create(d.Key, oex);
        Assert.AreEqual(d.Value, exp.Value, d.Key);
      }
    }
  }
}
