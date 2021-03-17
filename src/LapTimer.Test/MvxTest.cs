using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Tests;
using MvvmCross.Views;
using NUnit.Framework;
using System.IO;

namespace LapTimer.Test
{
    /// <summary>
    /// MvxTest.
    /// </summary>
    /// <seealso cref="MvvmCross.Tests.MvxIoCSupportingTest" />
    public class MvxTest : MvxIoCSupportingTest
    {
        protected MvxMockViewDispatcher MockDispatcher
        {
            get;
            private set;
        }

        /// <summary>
        /// Runs the before any tests.
        /// </summary>
        [SetUp]
        public virtual void SetupTest()
        {
            Setup();
        }

        /// <summary>
        /// Additionals the setup.
        /// </summary>
        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();

            MockDispatcher = new MvxMockViewDispatcher();
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);

            //this.Ioc.RegisterSingleton(Plugin.Settings.CrossSettings.Current);
            //this.Ioc.RegisterSingleton(MediaManager.CrossMediaManager.Current);
        }
    }
}