using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AVKit;
using Foundation;
using MediaManager;
using MediaManager.Library;
using MediaManager.Platforms.Ios.Video;
using PlayVideoInIOS.Interface;
using PlayVideoInIOS.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(PlayVideoFromLocalStorageService))]
namespace PlayVideoInIOS.iOS.Services
{
    public class PlayVideoFromLocalStorageService : IPlayVideoFromLocalStorage
    {
        private NSObject observer;
        AVPlayerViewController avpvc;
        UIViewController viewController;

        public void PlayVideoFromLocalStorage(string localFilePath)
        {
            try
            {
                viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                while (viewController.PresentedViewController != null)
                {
                    viewController = viewController.PresentedViewController;
                }
                IMediaItem item = new MediaItem();
                item.FileName = Path.GetFileName(localFilePath);
                item.MediaUri = "file://" + localFilePath;
                item.MediaLocation = MediaLocation.FileSystem;
                item.MediaType = MediaType.Video;

                VideoView videoView = new VideoView();
                videoView.PlayerViewController = new AVPlayerViewController();

                CrossMediaManager.Current.MediaPlayer.VideoView = videoView;
                CrossMediaManager.Current.MediaPlayer.ShowPlaybackControls = true;
                Device.BeginInvokeOnMainThread(() =>
                {
                    CrossMediaManager.Current.Play(item);
                });
                viewController.PresentViewController(videoView.PlayerViewController, true, null);
            }
            catch (Exception ex)
            {
            }
        }
    }
}