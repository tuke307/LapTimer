﻿namespace LapTimer.Forms.UI
{
    public partial class FormsApp : Xamarin.Forms.Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormsApp" /> class.
        /// </summary>
        public FormsApp()
        {
            XF.Material.Forms.Material.Init(this);

            this.InitializeComponent();

            XF.Material.Forms.Material.Use("Material.Configuration");
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}