using System;
using banditoth.Forms.RecurrenceToolkit.Multilanguage;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using reCaptureApp.Resources;
using reCaptureApp.ViewModels;
using reCaptureApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace reCaptureApp
{
    public partial class App : Application
    {
        private static bool _isInitalized = false;

        public App()
        {
            InitializeComponent();

            if (_isInitalized == false)
            {
                _isInitalized = true;

                Connector.Register(typeof(LoadingViewModel), typeof(LoadingView));
                Connector.Register(typeof(MainScreenViewModel), typeof(MainScreenView));

                TranslationProvider.Initalize(new System.Globalization.CultureInfo("en-US"), Translations.ResourceManager);

                Navigator.Instance.SetRoot(Connector.CreateInstance<MainScreenViewModel>((vm, v) => { vm.Initalize(); }));
            }
            else
            {
                Navigator.Instance.SetRoot(Navigator.Instance.GetRoot());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
