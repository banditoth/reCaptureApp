using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using Xamarin.Forms;

namespace reCaptureApp.ViewModels
{
    public class MainScreenViewModel : BaseViewModel
    {
        private double _overlayImageOpacity;
        public double OverlayImageOpacity
        {
            get => _overlayImageOpacity;
            set => SetProperty(ref _overlayImageOpacity, value, nameof(OverlayImageOpacity));
        }

        private string _overlayImageSource;
        public string OverlayImageSource
        {
            get => _overlayImageSource;
            set => SetProperty(ref _overlayImageSource, value, nameof(OverlayImageSource));
        }

        private Command _shutterCommand;
        public Command ShutterCommand
        {
            get => _shutterCommand;
            set => SetProperty(ref _shutterCommand, value, nameof(ShutterCommand));
        }

        private Command _browseOverlayImageCommmand;
        public Command BrowseOverlayImageCommmand
        {
            get => _browseOverlayImageCommmand ?? (_browseOverlayImageCommmand = new Command(() => _ = BrowserOverlayImage(), () => true));
        }

        private async Task BrowserOverlayImage()
        {
            var result = await Plugin.Media.CrossMedia.Current.PickPhotoAsync();
            if(result != null)
            {
                OverlayImageSource = result.Path;
            }
        }

        private void ShutterCamera()
        {
            
        }

        public MainScreenViewModel()
        {
        }

        public void Initalize()
        {

        }
    }
}
