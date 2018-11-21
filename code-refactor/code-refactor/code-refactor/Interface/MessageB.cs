using System;
using System.Reflection;

namespace code_refactor.Interface
{
    public class MessageB : IMessage
    {
        public void CustomMethod()
        {
            MyCustomMethodOnB();
            SomeAdditionMethodOnB();
        }

        private void MyCustomMethodOnB()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }

        private void SomeAdditionMethodOnB()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }
    }
}
