using System;
using System.Reflection;

namespace code_refactor.Interface
{
    public class MessageA : IMessage
    {
        public void CustomMethod()
        {
            MyCustomMethodOnA();
        }

        private void MyCustomMethodOnA()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }
    }
}
