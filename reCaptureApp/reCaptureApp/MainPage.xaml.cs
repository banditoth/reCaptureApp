using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace reCaptureApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _ = RequestCameraPermissionAndAddCameraView();
        }

        public async Task RequestCameraPermissionAndAddCameraView()
        {
            try
            {
                PermissionStatus status = await Permissions.RequestAsync<Permissions.Camera>();
                if(status == PermissionStatus.Granted)
                {
                    CameraView viewToAdd = new CameraView();
                    viewToAdd.CameraOptions = CameraOptions.Back;
                    MainPageInstance.Content = viewToAdd;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
