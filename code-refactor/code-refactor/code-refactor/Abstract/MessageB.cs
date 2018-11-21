using System;
using System.Reflection;

namespace code_refactor.Abstract
{
    public class MessageB : BaseMessage
    {
        public override void CustomMethod()
        {
            MyCustomMethodOnB();
            SomeAdditionMethodOnB();
        }

        private void MyCustomMethodOnB()
        {
            base.LogMehodName(GetType().FullName, MethodBase.GetCurrentMethod().Name);
        }

        private void SomeAdditionMethodOnB()
        {
            base.LogMehodName(GetType().FullName, MethodBase.GetCurrentMethod().Name);
        }
    }
}
