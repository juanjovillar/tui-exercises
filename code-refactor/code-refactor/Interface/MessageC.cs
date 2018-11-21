using System;
using System.Reflection;

namespace code_refactor.Interface
{
    public class MessageC : IMessage
    {
        public void CustomMethod()
        {
            MyCustomMethodOnC();
        }

        private void MyCustomMethodOnC()
        {
            Console.WriteLine($"This is {MethodBase.GetCurrentMethod().Name} on {GetType().FullName}");
        }
    }
}
