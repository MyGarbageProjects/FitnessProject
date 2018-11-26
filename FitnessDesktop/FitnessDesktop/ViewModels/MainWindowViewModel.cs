using FitnessDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

//Open CV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ZXing.QrCode;
using ZXing.Common;
using ZXing;

namespace FitnessDesktop.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        //Button
        private RelayCommand _startCamera;
        public RelayCommand StartCamera
        {
            get
            {
                return _startCamera ?? (_startCamera = new RelayCommand(startCamera, o=>!isCameraStart));
            }
        }
        private Boolean isCameraStart = false;
        
        //

        //Global variable
        private VideoCapture camera = null;
        private Mat _frame;
        BarcodeReader qrDecode;
        Result qrCodeElement;
        //

        //Global GUI variable
        private BitmapSource cameraFrame;
        public BitmapSource CameraFrame
        {
            get
            {
                return cameraFrame;
            }
            set
            {
                if(cameraFrame!= value)
                {
                    cameraFrame = value;
                    base.RaisePropertyChanged(nameof(CameraFrame));
                }
                
            }
        }
        public BitmapSource CameraFrame2 {get;set;}
        //
        public int clicks { get; set; }
        public MainWindowViewModel()
        {
            _frame = new Mat();
            qrDecode = new BarcodeReader();
            clicks = 0;
        }

        private void startCamera(object obj)
        {
            try
            {
                isCameraStart = true;
                camera = new VideoCapture();
                //camera.FlipHorizontal = true;
                camera.ImageGrabbed += ProcessFrame;
            }
            catch (Exception ex)
            {
                Notifications.MessageBox(ex.Message);
            }
            camera.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (camera != null && camera.Ptr != IntPtr.Zero)
            {
                camera.Retrieve(_frame, 1);


                qrCodeElement =  qrDecode.Decode(_frame.Bitmap);
                if (qrCodeElement != null)
                {
                    try
                    {
                        var asd = qrCodeElement.ResultPoints[0];
                        System.Drawing.Point[] p = new System.Drawing.Point[4];
                        p[0] = new System.Drawing.Point((Int32)qrCodeElement.ResultPoints[0].X-20, (Int32)qrCodeElement.ResultPoints[0].Y+20);//left bottom
                        p[1] = new System.Drawing.Point((Int32)qrCodeElement.ResultPoints[1].X-20, (Int32)qrCodeElement.ResultPoints[1].Y-20);//left top
                        p[2] = new System.Drawing.Point((Int32)qrCodeElement.ResultPoints[2].X+20, (Int32)qrCodeElement.ResultPoints[2].Y-20);//right top
                        //p[3] = new System.Drawing.Point((Int32)qrCodeElement.ResultPoints[2].X + 20, (Int32)qrCodeElement.ResultPoints[0].Y + 20);//right bottom
                        p[3] = new System.Drawing.Point((Int32)qrCodeElement.ResultPoints[3].X + 50, (Int32)qrCodeElement.ResultPoints[3].Y + 50);//right bottom
                        VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint(new VectorOfPoint(p));
                        CvInvoke.DrawContours(_frame, contours, -1, new MCvScalar(0, 255, 0), 4, LineType.AntiAlias);
                    }
                    catch (Exception)
                    {
                        //ignore
                    }

                    //Notifications.MessageBox(qrCodeElement.Text);
                }

                

                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    //CameraFrame = BitmapSourceConvert.ToBitmapSource(_frame);
                    try
                    {
                        CameraFrame = Bitmap2ImageSource(_frame.Bitmap);
                    }
                    catch (Exception)
                    {
                        //ignore
                        clicks++;
                        base.RaisePropertyChanged(nameof(clicks));
                    }

                }), System.Windows.Threading.DispatcherPriority.Background);
                Task.Delay(100).Wait();
            }
        }
        BitmapImage Bitmap2ImageSource(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                try
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();
                    return bitmapimage;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }


            }
        }

    }
}
