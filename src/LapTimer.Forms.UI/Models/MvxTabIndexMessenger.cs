using MvvmCross.Plugin.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace LapTimer.Forms.UI.Models
{
    public class MvxTabIndexMessenger : MvxMessage
    {
        public int TabIndex
        {
            get;
            private set;
        }

        public MvxTabIndexMessenger(object sender, int tabIndex)
               : base(sender)
        {
            TabIndex = tabIndex;
        }
    }
}