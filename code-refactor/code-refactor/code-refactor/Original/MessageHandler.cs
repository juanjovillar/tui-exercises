namespace code_refactor.Original
{
    public class MessageHandler
    {
        // Current implementation violates de Open-Close principle of SOLID that states that we have to define our
        // software entities in a way that are Open to extension but Close to modification. 

        // If we wanted to increase the ability of the handler to manage new Message types we will need to come to 
        // this Handler class (and any other class that operates with different types of messages) and add the new logic
        // as new if-else conditions. In case that we had several different types of messages this will soon become unmanegable 
        // and very error prone. Also note that this modifications will require a new compilation and deployment of the handler

        public void Handle(object message)
        {
            if (message is MessageA)
            {
                var messageA = message as MessageA;
                messageA?.MyCustomMethodOnA();
            }
            else if (message is MessageB)
            {
                var messageB = message as MessageB;
                messageB?.MyCustomMethodOnB();
                messageB?.SomeAdditionMethodOnB();
            }
            else if (message is MessageC)
            {
                var messageC = message as MessageC;
                messageC?.MyCustomMethodOnC();
            }
        }
    }
}
