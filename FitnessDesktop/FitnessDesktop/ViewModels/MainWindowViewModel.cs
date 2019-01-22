using FitnessDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

//QR код
using QRCodeEncoderDecoderLibrary;

namespace FitnessDesktop.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        public WindowState CurrentWindowState { get; set; }

        private RelayCommand _openHyperlinkCommand;
        public RelayCommand OpenHyperlinkCommand
        {
            get
            {
                return _openHyperlinkCommand ?? (_openHyperlinkCommand = new RelayCommand(ExecuteHyperlink));
            }
        }

        //private async void OpenRemoteControlWindow(object obj)
        //{
        //    if (true /*Если логин(id того к кому подключаемся) и пароль который я ввел есть на сервер то разрешаем подключение */)
        //    {
        //        CurWindowState = WindowState.Minimized;
        //        var displayRootRegistry = (Application.Current as App)?.displayRootRegistry;

        //        RemoteControlWindowViewModel rcwvm = new RemoteControlWindowViewModel();
        //        Setting.Add(rcwvm.GetHashCode(), ConnectionText);
        //        //await displayRootRegistry.ShowModalPresentation(rcwvm);
        //        if (displayRootRegistry != null) await displayRootRegistry.ShowModalPresentation(rcwvm);
        //        rcwvm.RdpManager.Disconnect();
        //        CurWindowState = WindowState.Normal;
        //    }
        //    else
        //    {
        //        Logger.MessageBox("Неверный пароль или ID или у партнера не запушенна программа");
        //    }
        //}


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

        public  ObservableCollection<Person> Person_List { get; set; }

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
            Person per = obj as Person;

            if (per != null && Person_List.Contains(per))
            {
                if (Notifications.MessageQuestion($"Вы уверены что хотите уволить \r\n{per.Name}?", ""))
                {
                    Person_List.Remove(per);
                }
            }
        }

        //Global variable
        private VideoCapture camera = null;
        private Mat _frame;
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
                if (cameraFrame!= value)
                {
                    cameraFrame = value;
                    base.RaisePropertyChanged(nameof(CameraFrame));
                }
                
            }
        }
        //
        public int clicks { get; set; }
        public MainWindowViewModel()
        {
            _frame = new Mat();
            clicks = 0;

            //Person_List = new ObservableCollection<Person>();
            //List<Dictionary<string, string>> personnel = LocalDatabase.ExecuteSelect($"SELECT personnel.id, personnel.name, personnel.surname, personnel.patronymic, personnel.birthday FROM personnel JOIN statuses ON personnel.status_id = statuses.id WHERE  statuses.name='Персонал активен' AND personnel.gym_id = {GlobalVar.GymID}");
            //List<Dictionary<string, string>> personnel_salary = LocalDatabase.ExecuteSelect($"SELECT personnel_salary.person_id, personnel_salary.salary, personnel_salary.salary_date FROM personnel_salary");


            //for (int i = 0; i < personnel.Count; i++)
            //{
                
            //    Person_List.Add(new Person() { Index = Convert.ToInt32(personnel[i]["id"]), Name = $"{personnel[i]["name"]} {personnel[i]["surname"]} {personnel[i]["patronymic"]}", LastSalary = "Выдач не было", Mail = "john@doe-family.com" });

            //}

                CurrentWindowState = WindowState.Maximized;
            //CameraFrame = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/photo_default.png"));
        }

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
