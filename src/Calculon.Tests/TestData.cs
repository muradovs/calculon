// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestData.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the TestData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Tests
{
  using System.Collections.Generic;

  /// <summary>
  /// The test data.
  /// </summary>
  public class TestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestData"/> class.
    /// </summary>
    public TestData()
    {
      this.Data = new Dictionary<string, double>
                    {
                      { " 8 + (-  1 ) ", 7 },
                      { " - 8 +   1 ", -7 },
                      { " - 8 ", -8 },
                      { " -8 ", -8 },
                      { "-8", -8 },
                      { "123+22", 145 },
                      { "12+log(log(log(65536,2),2),2)-12", 2 },
                      { "log(sqrt(sin(pi/2)+sin(pi/2)+sin(pi/2)+sin(pi/2)),4)", 0.5 },
                      { "max(max(max(34,23),15),20)", 34 },
                     // { "12-|-7+11-|-44+34|+2-6|+8", 10 },
                     // { "|||34-45+|11+16|-12+5|||", 9 },
                     // { "|||34-45|+11+16-5||", 33 },
                     // { "||34-45+|11+16-5|||", 11 },
                      
                    };
    } 

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public Dictionary<string, double> Data { get; set; }
  }
}