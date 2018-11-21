using System;
using System.Reflection;

namespace code_refactor.Abstract
{
    public class MessageC : BaseMessage
    {
        public override void CustomMethod()
        {
            MyCustomMethodOnC();
        }

        private void MyCustomMethodOnC()
        {
            base.LogMehodName(GetType().FullName, MethodBase.GetCurrentMethod().Name);
        }
    }
}
