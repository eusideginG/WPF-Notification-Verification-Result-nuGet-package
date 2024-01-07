using System.Windows;

namespace UIMessage
{
    /// <summary>
    /// A class uesd to create a notification popup window
    /// </summary>
    public class Notify
    {
        /// <summary>
        /// A static method that handles the parameters and dislays the popup window
        /// </summary>
        /// <param name="type">ENotificationTypes enum</param>
        /// <param name="title">Title of the popup window</param>
        /// <param name="message">Message of the popup window</param>
        /// <param name="position">ENotificationPositions enum of the popu window</param>
        /// <param name="miliseconts">Notification popup window display time in miliseconts</param>
        public static void Show(ENotificationTypes type, string title = "", string message = "", ENotificationPositions position = ENotificationPositions.BottomRight, int miliseconts = 2000)
        {
            NotifyPopUp popup = new NotifyPopUp(type, title, message, miliseconts);
            (popup.Top, popup.Left) = SetPosition(position);
            popup.ShowInTaskbar = false;
            popup.Show();
        }

        /// <summary>
        /// Sets the notification popup window position based on the ENotificationositions provided from the Show() method, default position: BottomRight
        /// </summary>
        /// <param name="position">ENotificationPositions enum</param>
        /// <returns>Two double values, Height and Width of the popup notification window</returns>
        private static (double Height, double Width) SetPosition(ENotificationPositions position)
        {
            switch (position)
            {
                case ENotificationPositions.TopLeft:
                    return (Height: SystemParameters.FullPrimaryScreenHeight - (SystemParameters.FullPrimaryScreenHeight - 4), Width: SystemParameters.FullPrimaryScreenWidth - (SystemParameters.FullPrimaryScreenWidth - 4));
                case ENotificationPositions.TopRight:
                    return (Height: SystemParameters.FullPrimaryScreenHeight - (SystemParameters.FullPrimaryScreenHeight - 4), Width: SystemParameters.FullPrimaryScreenWidth - 404);
                case ENotificationPositions.BottomLeft:
                    return (Height: SystemParameters.FullPrimaryScreenHeight - 80, Width: SystemParameters.FullPrimaryScreenWidth - (SystemParameters.FullPrimaryScreenWidth - 4));
                case ENotificationPositions.BottomRight:
                    return (Height: SystemParameters.FullPrimaryScreenHeight - 80, Width: SystemParameters.FullPrimaryScreenWidth - 404);
            }
            return (Height: SystemParameters.FullPrimaryScreenHeight - 80, Width: SystemParameters.FullPrimaryScreenWidth - 404);
        }
    }
}
