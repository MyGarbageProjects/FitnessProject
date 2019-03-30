using FitnessDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

//Open CV
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using FitnessDatabase;

//QR код
using QRCodeEncoderDecoderLibrary;

//БД
namespace FitnessDesktop.ViewModels
{
    /// <summary>
    /// Параметры окна относящиеся ко всем разделам
    /// </summary>
    partial class MainWindowViewModel : NotificationObject
    {
        /// <summary>
        /// Состояние окна
        /// </summary>
        public WindowState CurrentWindowState { get; set; }

        public MainWindowViewModel()
        {
            CurrentWindowState = WindowState.Maximized;

            ConstructorsClassCheckClient();
            ConstructorsClassPersonnel();
        }

        partial void ConstructorsClassCheckClient();
        partial void ConstructorsClassPersonnel();
    }

    /// <summary>
    /// Раздел "Персонал"
    /// </summary>
    partial class MainWindowViewModel
    {
        partial void ConstructorsClassPersonnel()
        {
            //тут конструктор
            LocalDatabase.LDatabase.UpdateDataInfo.Load();
        }

        private RelayCommand _openHyperlinkCommand;
        public RelayCommand OpenHyperlinkCommand
        {
            get
            {
                return _openHyperlinkCommand ?? (_openHyperlinkCommand = new RelayCommand(ExecuteHyperlink));
            }
        }

        private async void ExecuteHyperlink(object obj)
        {
            WindowState lastState = CurrentWindowState;//Запоминаем состояние главного окна
            CurrentWindowState = WindowState.Minimized;//Минимизируем
            base.RaisePropertyChanged(nameof(CurrentWindowState));//Биндим состояние

            DisplayRootRegistry displayRootRegistry = (Application.Current as App)?.displayRootRegistry;//Получем объект класса DisplayRootRegistry
            StaffEditingWindowViewModel staffEditing = new StaffEditingWindowViewModel();//Создаем экземпляр класса для редактирования персонала
            if (displayRootRegistry != null)
                await displayRootRegistry.ShowModalPresentation(staffEditing);//Открывам окно

            CurrentWindowState = lastState;//Возвращаем предыдущее состояние до открытия окна редактирования
            base.RaisePropertyChanged(nameof(CurrentWindowState));//Биндим состояние
        }

        private RelayCommand _deletePerson;
        public RelayCommand DeletePerson
        {
            get
            {
                return _deletePerson ?? (_deletePerson = new RelayCommand(ExecuteDeletePerson));
            }
        }

        private void ExecuteDeletePerson(object obj)
        {
            //Person per = obj as Person;

            //if (per != null && Person_List.Contains(per))
            //{
            //    if (Notifications.MessageQuestion($"Вы уверены что хотите уволить \r\n{per.Name}?", ""))
            //    {
            //        Person_List.Remove(per);
            //    }
            //}
        }
    }

    /// <summary>
    /// Раздел "Отметить клиента"
    /// </summary>
    partial class MainWindowViewModel
    {
        partial void ConstructorsClassCheckClient()
        {
            _frame = new Mat();
            clicks = 0;
        }

        //Global variable
        private VideoCapture camera = null;
        private Mat _frame;

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
                if (cameraFrame != value)
                {
                    cameraFrame = value;
                    base.RaisePropertyChanged(nameof(CameraFrame));
                }

            }
        }

        //Button
        private RelayCommand _startCamera;
        public RelayCommand StartCamera
        {
            get
            {
                return _startCamera ?? (_startCamera = new RelayCommand(startCamera, o => !isCameraStart));
            }
        }
        private Boolean isCameraStart = false;

        public int clicks { get; set; }

        private void startCamera(object obj)
        {
            try
            {
                isCameraStart = true;
                camera = new VideoCapture();
                //decoder = new QRCodeDecoder();
                Decoder = new QRDecoder();
                //camera.FlipHorizontal = true;
                camera.ImageGrabbed += ProcessFrame;
                if (camera.Height == 0 || camera.Width == 0)
                    throw new NullReferenceException("Камера не обнаружена");
            }
            catch (Exception ex)
            {
                Notifications.MessageError(ex.Message);
                isCameraStart = false;
                return;
            }
            camera.Start();

        }

        //private QRCodeDecoder decoder;
        //private QRCodeBitmapImage qrbi;
        private QRDecoder Decoder;
        private byte[][] DataByteArray;
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (camera != null && camera.Ptr != IntPtr.Zero)
            {
                camera.Retrieve(_frame, 0);
                try
                {
                    Bitmap asdas = _frame.Bitmap;
                    DataByteArray = Decoder.ImageDecoder(asdas);
                    string Text = QRDecoder.QRCodeResult(DataByteArray);
                    if (DataByteArray != null)
                    {

                        Console.WriteLine(Text);
                        for (int i = 0; i < Decoder.resultPoints.Count; i++)
                        {
                            CvInvoke.Line(_frame, Decoder.resultPoints[i].BigSquareLT, new System.Drawing.Point(Decoder.resultPoints[i].BigSquareRB.X, Decoder.resultPoints[i].BigSquareLT.Y), new MCvScalar(0, 255, 0));
                            CvInvoke.Line(_frame, new System.Drawing.Point(Decoder.resultPoints[i].BigSquareRB.X, Decoder.resultPoints[i].BigSquareLT.Y), Decoder.resultPoints[i].BigSquareRB, new MCvScalar(0, 255, 0));
                            CvInvoke.Line(_frame, Decoder.resultPoints[i].BigSquareRB, new System.Drawing.Point(Decoder.resultPoints[i].BigSquareLT.X, Decoder.resultPoints[i].BigSquareRB.Y), new MCvScalar(0, 255, 0));
                            CvInvoke.Line(_frame, new System.Drawing.Point(Decoder.resultPoints[i].BigSquareLT.X, Decoder.resultPoints[i].BigSquareRB.Y), Decoder.resultPoints[i].BigSquareLT, new MCvScalar(0, 255, 0));

                            CvInvoke.Line(_frame, Decoder.resultPoints[i].SmallSquareLT, Decoder.resultPoints[i].SmallSquareRB, new MCvScalar(0, 255, 0));
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Console.WriteLine(exception);
                    throw;
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
                        //clicks++;
                        //base.RaisePropertyChanged(nameof(clicks));
                    }

                }), System.Windows.Threading.DispatcherPriority.Background);

                //Task.Delay(100).Wait();
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
