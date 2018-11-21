using System;
using System.Reflection;

namespace code_refactor.Original
{
    public class MessageB
    {
        public void MyCustomMethodOnB()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }

        public void SomeAdditionMethodOnB()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }
    }
}
