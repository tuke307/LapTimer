namespace LapTimer.Core.Models
{
    using MvvmCross.Plugin.Messenger;

    public class MvxLocationMessage
            : MvxMessage
    {
        public double? Accuracy { get; private set; }

        public double? Altitude { get; private set; }

        public double? AltitudeAccuracy { get; private set; }

        public double? Heading { get; private set; }

        public double? HeadingAccuracy { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public double? Speed { get; private set; }

        public MvxLocationMessage(object sender, double latitude, double longitude, double? accuracy, double? altitude, double? altitudeAccuracy, double? heading, double? headingAccuracy, double? speed)
                                     : base(sender)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Accuracy = accuracy;
            this.Altitude = altitude;
            this.AltitudeAccuracy = altitudeAccuracy;
            this.Heading = heading;
            this.HeadingAccuracy = headingAccuracy;
            this.Speed = speed;
        }
    }
}