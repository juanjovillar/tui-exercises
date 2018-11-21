namespace code_refactor.Abstract
{
    public class MessageHandler
    {
        // Implementation with abstract class

        public void Handle(BaseMessage message)
        {
            message.CustomMethod();
        }
    }
}
