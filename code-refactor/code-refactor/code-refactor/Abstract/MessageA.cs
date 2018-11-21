using System;
using System.Reflection;

namespace code_refactor.Abstract
{
    public class MessageA : BaseMessage
    {
        public override void CustomMethod()
        {
            MyCustomMethodOnA();
        }

        private void MyCustomMethodOnA()
        {
            base.LogMehodName(GetType().FullName, MethodBase.GetCurrentMethod().Name);
        }
    }
}
