using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculon.Math.Murad
{
    public class Singleton<T> where T: new()
    {
        protected Singleton()
      {

      }

      public static T Instance { get { return Creator.Instance; } }

      private sealed class Creator
      {
          private static readonly T instance = new T();
          public static T Instance { get { return instance; } }
      }
    }
}
