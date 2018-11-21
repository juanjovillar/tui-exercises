using System;
using System.Reflection;

namespace code_refactor.Original
{
    public class MessageC
    {
        public void MyCustomMethodOnC()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }
    }
}
