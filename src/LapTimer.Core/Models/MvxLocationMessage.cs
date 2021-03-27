namespace LapTimer.Core.Models
{
    using MvvmCross.Plugin.Location;
    using MvvmCross.Plugin.Messenger;

    public class MvxLocationMessage
            : MvxMessage
    {
        public MvxCoordinates MvxCoordinates { get; private set; }

        public MvxLocationMessage(object sender, MvxCoordinates mvxCoordinates)
                                     : base(sender)
        {
            this.MvxCoordinates = mvxCoordinates;
        }
    }
}