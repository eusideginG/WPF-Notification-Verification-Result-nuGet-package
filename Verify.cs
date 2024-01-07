using System.Windows.Markup;
using System.Windows.Media;

namespace UIMessage
{
    /// <summary>
    /// Verification - result popup window
    /// </summary>
    public class Verify
    {
        /// <summary>
        /// A static method to set all the necessary parameters and open a verifiation ressult popup window (Window Topmost = true)
        /// </summary>
        /// <param name="result">EVerifyTypes enum type</param>
        /// <param name="title">Title of the popup window</param>
        /// <param name="message">Mesage of the popup windo</param>
        /// <param name="confirmText">Confirm button text of the popup windo</param>
        /// <param name="cancelText">Cansel text of the popup windo</param>
        /// <param name="backgroundColor">Background color of the popup</param>
        /// <param name="textColor">Text color of the popup</param>
        /// <param name="confirmBtnTextColor">Text color of the confirm button</param>
        /// <param name="cancelBtnTextColor">Text color of the cancel button</param>
        /// <param name="confirmButtonColor">Background color of the confirm button</param>
        /// <param name="cancelButtonColor">Background color of the cancel button</param>
        /// <param name="closeButtonColor">Background color of the exit button (X)</param>
        /// <returns></returns>
        public static EVerifyResults Show(EVerifyTypes result, string? title = null, string? message = null, string? confirmText = null, string? cancelText = null, Brush? backgroundColor = null, Brush? textColor = null, Brush? confirmBtnTextColor = null, Brush? cancelBtnTextColor = null, Brush? confirmButtonColor = null, Brush? cancelButtonColor = null, Brush? closeButtonColor = null)
        {
            switch (result)
            {
                case EVerifyTypes.OK:
                    title ??= string.Empty;
                    message ??= string.Empty;
                    confirmText ??= "OK";
                    cancelText ??= "Cancel";
                    break;
                case EVerifyTypes.CONFIRM:
                    title ??= string.Empty;
                    message ??= string.Empty;
                    confirmText ??= "Confirm";
                    cancelText ??= "Cancel";
                    break;
                case EVerifyTypes.YESNO:
                    title ??= string.Empty;
                    message ??= string.Empty;
                    confirmText ??= "Yes";
                    cancelText ??= "No";
                    break;
                default:
                    break;
            }

            VerifyPopUp verifyPopUp = new VerifyPopUp
            (
                result,
                title ?? "",
                message ?? "",
                confirmText ?? "",
                cancelText ?? "",
                backgroundColor ?? new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                textColor ?? new SolidColorBrush(Color.FromRgb(10, 10, 10)),
                confirmBtnTextColor ?? new SolidColorBrush(Color.FromRgb(10, 10, 10)),
                cancelBtnTextColor ?? new SolidColorBrush(Color.FromRgb(10, 10, 10)),
                confirmButtonColor ?? new SolidColorBrush(Color.FromRgb(100, 240, 100)),
                cancelButtonColor ?? new SolidColorBrush(Color.FromRgb(240, 100, 100)),
                closeButtonColor ?? new SolidColorBrush(Colors.Transparent)
            );

            verifyPopUp.ShowInTaskbar = false;
            verifyPopUp.Topmost = true;
            verifyPopUp.ShowDialog();

            return (EVerifyResults)verifyPopUp.Result;

        }
    }
}
