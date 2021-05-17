using System;
using System.Threading.Tasks;
using banditoth.Forms.RecurrenceToolkit.MVVM;
using Xamarin.Essentials;

namespace reCaptureApp.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        public void Initalize()
        {
            _ = StartApp();
        }

        private async Task StartApp()
        {
            try
            {
                await RequestPermissions();

                Navigator.Instance.SetRoot(Connector.CreateInstance<MainScreenViewModel>((vm, v) => { vm.Initalize(); }));
            }
            catch (Exception ex)
            {
                // TODO HANDLE
            }
        }

        private async Task RequestPermissions()
        {
            //var result = await Permissions.RequestAsync<Permissions.Photos>();
            //if (result != PermissionStatus.Granted)
            //    _ = RequestPermissions();
        }
    }
}
