using System;
using System.Collections.Generic;

namespace code_refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            //NOTE: See explanations inside each Handler implementation.

            Console.WriteLine("Original implementation");
            ExecuteOriginal();

            Console.WriteLine();

            Console.WriteLine("Interface implementation");
            ExecuteInterfaceRefactor();

            Console.WriteLine();

            Console.WriteLine("Abstract implementation");
            ExecuteAbstractRefactor();

            Console.ReadLine();
        }

        private static void ExecuteOriginal()
        {
            var messageList = new List<object>
            {
                new Original.MessageA(),
                new Original.MessageB(),
                new Original.MessageC()
            };

            var messageHandler = new Original.MessageHandler();
            messageList.ForEach(messageHandler.Handle);
        }

        private static void ExecuteInterfaceRefactor()
        {
            var messageList = new List<Interface.IMessage>
            {
                new Interface.MessageA(),
                new Interface.MessageB(),
                new Interface.MessageC()
            };

            var messageHandler = new Interface.MessageHandler();
            messageList.ForEach(messageHandler.Handle);
        }

        private static void ExecuteAbstractRefactor()
        {
            var messageList = new List<Abstract.BaseMessage>
            {
                new Abstract.MessageA(),
                new Abstract.MessageB(),
                new Abstract.MessageC()
            };

            var messageHandler = new Abstract.MessageHandler();
            messageList.ForEach(messageHandler.Handle);
        }

    }
}
