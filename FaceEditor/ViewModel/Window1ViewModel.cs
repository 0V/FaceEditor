using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using AvalonEdit.Sample.Model;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AvalonEdit.Sample.ViewModel
{
    public class Window1ViewModel : ViewModelBase
    {

        private WriteableBitmap _capture;
        public WriteableBitmap CaptureImage
        {
            get { return _capture; }
            set
            {
                _capture = value;
                OnPropertyChanged("CaptureImage");
            }
        }
        private CameraCapture _camera;
        public CameraCapture Camera
        {
            get
            {
                return _camera ?? (_camera = new CameraCapture());

            }
            set { _camera = value; }
        }

        private RelayCommand _cameraCommand;
        public RelayCommand CameraCommand
        {
            get { return _cameraCommand ?? (_cameraCommand = new RelayCommand(CaptureStart)); }
            set { _cameraCommand = value; }
        }

        public void CaptureStart(object obj)
        {
            Camera.PropertyChanged += (_sender,_e) =>
            {
                var cc = (CameraCapture)_sender;
                switch (_e.PropertyName)
                {
                    case "Capture":
                        CaptureImage = cc.Capture;
                        break;
                    default:
                        break;
                }

            };
            Camera.Start(0,1);
        }

        public void CaptureStop()
        {
            Camera.Stop();
        }
    }
}
