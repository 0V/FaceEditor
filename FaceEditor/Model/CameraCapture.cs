using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenCvSharp;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using OpenCvSharp.Extensions;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading;

namespace AvalonEdit.Sample.Model
{
    public class CameraCapture : ViewModel.ViewModelBase
    {
        private DispatcherTimer cameraTimer;
        private CvCapture capture;
//        public WriteableBitmap Capture { get; set; }

        private WriteableBitmap _capture;
        public WriteableBitmap Capture
        {
            get { return _capture; }
            set
            {
                _capture = value;
                OnPropertyChanged("Capture");
            }
        }
        public void Start(int cameraIndex){
            this.Start(cameraIndex,10);
        }

        public void Start(int cameraIndex,int timeSpan)
        {
            try
            {
                capture = Cv.CreateCameraCapture(cameraIndex);
            }
            catch (Exception e)
            {
                App.ShowErrorMessage("カメラを認識できませんでした。");
                return;
            }
            var wb = new WriteableBitmap(capture.FrameWidth, capture.FrameHeight, 96, 96, PixelFormats.Bgr24, null);
            cameraTimer = new DispatcherTimer(DispatcherPriority.Background);
            cameraTimer.Interval = TimeSpan.FromMilliseconds(timeSpan);
            cameraTimer.Tick += ((sender, e) =>
            {
                WriteableBitmapConverter.ToWriteableBitmap(capture.QueryFrame(), wb);
                Capture = wb;
            });
            cameraTimer.Start();
        }
        public void Stop()
        {
            cameraTimer.Stop();
            capture.Dispose();
        }

        public void ReStart()
        {
            cameraTimer.Start();
        }
    }
}
