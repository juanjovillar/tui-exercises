using System;
using System.Reflection;

namespace code_refactor.Original
{
    public class MessageA
    {
        public void MyCustomMethodOnA()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }
    }
}
