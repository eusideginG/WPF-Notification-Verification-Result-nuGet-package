using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UIMessage
{
    /// <summary>
    /// Verification - ressult popup window class
    /// </summary>
    public partial class VerifyPopUp : Window
    {
        #region Getters - Setters
        /// <summary>
        /// Verification type of the window
        /// </summary>
        public EVerifyTypes type { get; set; }

        /// <summary>
        /// Title of the window
        /// </summary>
        public string VerifyTitle { get; set; }

        /// <summary>
        /// Message of the window
        /// </summary>
        public string VerifyMessage { get; set; }

        /// <summary>
        /// Background color of the window
        /// </summary>
        public Brush VerifyBackgroundColor { get; set; }

        /// <summary>
        /// Text color of the window
        /// </summary>
        public Brush TextColor { get; set; }

        /// <summary>
        /// Confirm button text of the window
        /// </summary>
        public string TBConfirm { get; set; }

        /// <summary>
        /// ancel button text of the window
        /// </summary>
        public string TBCancel { get; set; }

        /// <summary>
        /// Confirm button text color of the window
        /// </summary>
        public Brush ConfirmBtnTextColor { get; set; }

        /// <summary>
        /// Cancel button text color of the window
        /// </summary>
        public Brush CancelBtnTextColor { get; set; }

        /// <summary>
        /// Confirm button color of the window
        /// </summary>
        public Brush ButtonConfirm { get; set; }

        /// <summary>
        /// Cancel button color of the window
        /// </summary>
        public Brush ButtonCancel { get; set; }

        /// <summary>
        /// Exit button (X) color of the window
        /// </summary>
        public Brush CloseButton { get; set; }

        /// <summary>
        /// Result of the window. (EVerifyResults enum)
        /// </summary>
        public EVerifyResults? Result { get; private set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">EVerifyTypes Type</param>
        /// <param name="title">Title of the verification popup window</param>
        /// <param name="message">Message of the verification popup window</param>
        /// <param name="confirmText">Confirm text of the verification popup window</param>
        /// <param name="cancelText">Cancel text of the verification popup window</param>
        /// <param name="backgroundColor">Background color of the verification popup window</param>
        /// <param name="textColor">Text color of the verification popup window</param>
        /// <param name="confirmBtnTextColor">Confirm button text color of the verification popup window</param>
        /// <param name="cancelBtnTextColor">Cancel button text color of the verification popup window</param>
        /// <param name="confirmButtonColor">Confirm button color of the verification popup window</param>
        /// <param name="cancelButtonColor">Cancel button color of the verification popup window</param>
        /// <param name="closeButtonColor">Close button (X) color of the verification popup window</param>
        public VerifyPopUp(EVerifyTypes type, string title, string message, string confirmText, string cancelText, Brush backgroundColor, Brush textColor, Brush confirmBtnTextColor, Brush cancelBtnTextColor, Brush confirmButtonColor, Brush cancelButtonColor, Brush closeButtonColor)
        {
            this.type = type;
            this.VerifyTitle = title;
            this.VerifyMessage = message;
            this.VerifyBackgroundColor = backgroundColor;
            this.TextColor = textColor;
            this.TBConfirm = confirmText;
            this.TBCancel = cancelText;
            this.ConfirmBtnTextColor = confirmBtnTextColor;
            this.CancelBtnTextColor = cancelBtnTextColor;
            this.ButtonConfirm = confirmButtonColor;
            this.ButtonCancel = cancelButtonColor;
            this.CloseButton = closeButtonColor;

            InitializeComponent();
            this.DataContext = this;
            this.Owner = Application.Current.MainWindow;
        }

        /// <summary>
        /// Exit button click listener, closes the window
        /// </summary>
        private void Button_Click_Exit(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// When the window is loaded, sets the focus and a fade in animation
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            DoubleAnimation doubleAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(300)
            };
            this.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
        }

        /// <summary>
        /// Confirm button listener.
        /// sets the result based on EVerifyTypes type
        /// </summary>
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case EVerifyTypes.OK:
                    Result = EVerifyResults.OK;
                    break;
                case EVerifyTypes.CONFIRM:
                    Result = EVerifyResults.CONFIRM;
                    break;
                case EVerifyTypes.YESNO:
                    Result = EVerifyResults.YES;
                    break;
                default:
                    break;
            }
            FadeOut();
        }

        /// <summary>
        /// Cancel button listener.
        /// sets the result based on EVerifyTypes type
        /// </summary>
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case EVerifyTypes.OK:
                    Result = EVerifyResults.CANSEL;
                    break;
                case EVerifyTypes.CONFIRM:
                    Result = EVerifyResults.CANSEL;
                    break;
                case EVerifyTypes.YESNO:
                    Result = EVerifyResults.NO;
                    break;
                default:
                    break;
            }
            FadeOut();
        }

        /// <summary>
        /// Fade out animation for the verification popup window
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

        /// <summary>
        /// Window closing litener.
        /// If the resoult don't have value set result = EVerifyResults.CLOSED
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Result ??= EVerifyResults.CLOSED;
        }

        /// <summary>
        /// Left mous button listener.
        /// Used to DragMove() the window
        /// </summary>
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
