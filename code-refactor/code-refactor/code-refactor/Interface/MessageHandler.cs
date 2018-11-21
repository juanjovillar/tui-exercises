namespace code_refactor.Interface
{
    public class MessageHandler
    {
        // One of the best ways to cope with this problem will be the use of inheritance and polymorphism.  
        // By defining a base class or a common interface to be implemented by the different messages we can 
        // decouple the Handler logic from the specific Message implementation, in this way we can extend the 
        // functionality by simply creating new types of Messages as long as they inherit from the same Parent class. 

        // Depending on the need of providing a base implementation or not we could use:
        // - A Abstract Base class with abstract methods to be implemented and common implementations if needed
        // - An Interface providing a pecification.

        // The current implementation follows the second approach.

        public void Handle(IMessage message)
        {
            message.CustomMethod();
        }
    }
}
