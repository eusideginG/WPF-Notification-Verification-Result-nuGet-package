using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UIMessage
{
    /// <summary>
    /// Notification popup window class
    /// </summary>
    public partial class NotifyPopUp : Window
    {
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="type">ENotificationTypes enum type</param>
        /// <param name="title">Title of the popup window</param>
        /// <param name="message">Message of the popup window</param>
        /// <param name="miliseconts">Display time of the popup window in miliseconts</param>
        public NotifyPopUp(ENotificationTypes type, string title, string message, int miliseconts)
        {
            this.NotificationIcon = new BitmapImage();
            this.NotificationTitle = title;
            this.NotificationMessage = message;
            this.NotificationColor = new SolidColorBrush();
            this.NotificationDisplayTime = miliseconts;

            buildUI(type);
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// Popup Icon
        /// </summary>
        public BitmapImage NotificationIcon { get; set; }

        /// <summary>
        /// Popup Title
        /// </summary>
        public string NotificationTitle { get; set; }

        /// <summary>
        /// Popup Background Color
        /// </summary>
        public Brush NotificationColor { get; set; }

        /// <summary>
        /// Popup Messsage
        /// </summary>
        public string NotificationMessage { get; set; }

        /// <summary>
        /// Popup Display time
        /// </summary>
        public int NotificationDisplayTime { get; set; }

        /// <summary>
        /// Ui builder, handles the ui popup parameters.
        /// Setss the icon, title, message and background color based on ENotificationTypes enum type.
        /// If only ENotificationTypes is passed, icon title and background color will be set with default values.
        /// </summary>
        /// <param name="type">ENotificationTypes enum type</param>
        /// <exception cref="ArgumentException">When the value passed in is not in ENotificationTypes enum</exception>
        private void buildUI(ENotificationTypes type)
        {
            if (!Enum.IsDefined(type)) throw new ArgumentException("Enum does not exist in NotificationType");

            string[] titles = { "Notifitation", "Success", "Warning", "Error" };
            
            switch (type)
            {
                case ENotificationTypes.Notifications:
                    NotificationIcon = new BitmapImage(new Uri("icons/notification.png", UriKind.Relative));
                    NotificationTitle = NotificationTitle == "" ? titles[0] : NotificationTitle;
                    NotificationMessage = NotificationMessage == "" ? "" : NotificationMessage;
                    NotificationColor = new SolidColorBrush(Color.FromRgb(25, 125, 255));
                    break;
                case ENotificationTypes.Success:
                    NotificationIcon = new BitmapImage(new Uri("icons/success.png", UriKind.Relative));
                    NotificationTitle = NotificationTitle == "" ? titles[1] : NotificationTitle;
                    NotificationMessage = NotificationMessage == "" ? "" : NotificationMessage;
                    NotificationColor = new SolidColorBrush(Color.FromRgb(0, 220, 0));
                    break;
                case ENotificationTypes.Warning:
                    NotificationIcon = new BitmapImage(new Uri("icons/warning.png", UriKind.Relative));
                    NotificationTitle = NotificationTitle == "" ? titles[2] : NotificationTitle;
                    NotificationMessage = NotificationMessage == "" ? "" : NotificationMessage;
                    NotificationColor = new SolidColorBrush(Color.FromRgb(255, 170, 15));
                    break;
                case ENotificationTypes.Error:
                    NotificationIcon = new BitmapImage(new Uri("icons/error.png", UriKind.Relative));
                    NotificationTitle = NotificationTitle == "" ? titles[3] : NotificationTitle;
                    NotificationMessage = NotificationMessage == "" ? "" : NotificationMessage;
                    NotificationColor = new SolidColorBrush(Color.FromRgb(255, 10, 10));
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Button event click lisstener, closes the window when the Exit button (X) is clicked
        /// </summary>
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Window loaded event, ussed to start a DispatherTimer,
        /// add display the fade in animation, 
        /// display the popu for a "NotificationDisplayTime" amount,
        /// add display the fade out animation
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(NotificationDisplayTime);
            timer.Tick += (sender, e) => { FadeOut(); timer.Stop(); };
            timer.Start();
            FadeIn();
        }

        /// <summary>
        /// Fade in animation for the popup window
        /// </summary>
        private void FadeIn()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(300)
            };
            this.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }

        /// <summary>
        /// Fade out animation for the popup window
        /// </summary>
        private void FadeOut()
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(300)
            };
            doubleAnimation.Completed += (o, e) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }
    }
}
