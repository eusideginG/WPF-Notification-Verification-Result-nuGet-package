
# WPF Notification and Verification - Result UI

### HOW TO USE:
> #### Download the package from .NET CLI:  
>     dotnet add package UIMessage --version 1.0.0
> 
> #### NuGet link:
>     https://www.nuget.org/packages/UIMessage
>
> ### Add "using UIMessage;" for easy use.
>
> ### Notification UI window - popup (return type: void):
> 
> > `Notify.Show();` 1 required parameter:
> > - ENotificationTypes (Type of the notification popup)
> > 
> > #### Available ENotificationTypes:
> > - `ENotificationTypes.Notifications`
> > - `ENotificationTypes.Success`
> > - `ENotificationTypes.Warning`
> > - `ENotificationTypes.Error`
> >
> > #### Example:
> >
> > ```
> > Notify.Show(ENotificationTypes.Notifications)
> > ```
> >
> > `Notify.Show();` 4 optional parameters:
> > 
> > - title (Title of the notification popup), Default value: (Depends on ENotificationTypes)
> > - message (Message of the notificcation popup), Default value: `""` (Empty string)
> > - ENotificationPositions (Position of the popup window), Default value: `ENotificationPositions.BottomRight`
> > - milliseconds (Display time of the popup), Default value: `2000`
> >
> > #### Available ENotificationPositions:
> > - `ENotificationPositions.TopRight`
> > - `ENotificationPositions.BottomRight`
> > - `ENotificationPositions.TopLeft`
> > - `ENotificationPositions.BottomLeft`
> >
> > #### Example:
> >
> > ```
> > Notify.Show(ENotificationTypes.Notifications, "Hello", "This is a message", ENotificationPositions.TopRight, 5000);
> > ```
>
> ### Verification - Result UI window - popup (return type: EVerifyResults):
> 
> > #### Available EVerifyResults:
> > - `EVerifyResults.OK`
> > - `EVerifyResults.CONFIRM`
> > - `EVerifyResults.YES`
> > - `EVerifyResults.NO`
> > - `EVerifyResults.CANSEL`
> > - `EVerifyResults.CLOSED`
> > 
> > `Verify.Show();` 1 required parameter:
> > - EVerifyTypes (Type of the verification popup)
> >
> > #### Available EVerifyTypes:
> > - `EVerifyTypes.OK`
> > - `EVerifyTypes.CONFIRM`
> > - `EVerifyTypes.YESNO`
> >
> > #### Example:
> >
> > ```
> > EVerifyResults result = Verify.Show(EVerifyTypes.YESNO);
> > ```
> >
> > `Verify.Show();` 11 optional parameters:
> >
> > - title (Title of the window) Default value: `""` (Empty string)
> > - message (Message of the window) Default value: `""` (Empty string)
> > - confirmText (Text of the confirm button of the window) Default value: (Depends on EVerifyTypes)
> > - cancelText (Text of the cancel button of the window) Default value: (Depends on EVerifyTypes)
> > - backgroundColor (Background color of the window) Default value: `new SolidColorBrush(Color.FromRgb(240, 240, 240))`
> > - textColor (Text color of the window) Default value: `new SolidColorBrush(Color.FromRgb(10, 10, 10))`
> > - confirmBtnTextColor (Confirm button text color of the window) Default value: `new SolidColorBrush(Color.FromRgb(10, 10, 10))`
> > - cancelBtnTextColor (Cancel button text color of the window) Default value: `new SolidColorBrush(Color.FromRgb(10, 10, 10))`
> > - confirmButtonColor (Confirm button color of the window) Default value: `new SolidColorBrush(Color.FromRgb(100, 240, 100))`
> > - cancelButtonColor (Cancel button color of the window) Default value: `new SolidColorBrush(Color.FromRgb(240, 100, 100))`
> > - closeButtonColor (Sloce button color of the window [X]) Default value: `new SolidColorBrush(Colors.Transparent))`
> >
> > #### Example:
> >
> > ```
> > EVerifyResults result = Verify.Show(
> >   EVerifyTypes.YESNO, 
> >   "Warnging", 
> >   "Do you want to delete this item ?",
> >   backgroundColor: new SolidColorBrush(Colors.Aqua),
> >   textColor: new SolidColorBrush(Colors.Black));
> > ```


