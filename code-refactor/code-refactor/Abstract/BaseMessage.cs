using System;

namespace code_refactor.Abstract
{
    public abstract class BaseMessage
    {
        public abstract void CustomMethod();

        public void LogMehodName(string className, string methodName)
        {
            Console.WriteLine($"This is {methodName} on {className}");
        }
    }
}
