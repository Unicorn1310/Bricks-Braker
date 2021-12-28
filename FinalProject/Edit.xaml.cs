using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Edit : Page
    {
        //עמוד עריכה למשתמש
        WebService1SoapClient ws = new WebService1SoapClient();
        public Edit()
        {
            this.InitializeComponent();
            //הדפסת הנתונים הקיימים בתיבות הטקסט
            var user = ws.GetUserAsync(LogIn.uname, LogIn.password);
            Users u=user.Result.Body.GetUserResult;
            Password.Text = u.password;
            FirstName.Text = u.firstName;
            LastName.Text = u.lastName;

            //if (LogIn.uname != null && LogIn.uname != "" && LogIn.password != null && LogIn.password != "")
            //{
            //    GetUserResponseGetUserResult dt = ws.GetUserAsync(LogIn.uname, LogIn.password).Result;
            //    // UserName.Text = dt.Any.
            //  var x=  dt.Any1.FirstNode.ToString();
            //    int indexUn = x.IndexOf("<UserName>");
            //    int indexUnU = x.IndexOf("<UserName>");
            //    string uname;


            //}
        }

        //private void BackEdit_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            //כפתור עריכה
            //string user = UserName.Text;
            string user = LogIn.uname;
            string pass = Password.Text;
            string fn = FirstName.Text;
            string ln = LastName.Text;
            //בדיקות אימות
            if (pass == null || pass == "") //אם הסיסמא ריקה
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (סיסמא ריקה)
                MessageDialog ms1 = new MessageDialog("Password can not be empty");
                await ms1.ShowAsync();
                return;
            }
            if (pass.Length < 3)//אם בסיסמא יש פחות משלושה תווים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (בסיסמא יש פחות משלושה תווים)
                MessageDialog ms2 = new MessageDialog("The password must be at least 3 characters long");
                await ms2.ShowAsync();
                return;
            }
            if (fn == null || fn == "") //אם שם פרטי ריק
            {
                //הודעה שאומרת למשתמש מה לא בסדר בשדה שהכניס (שם פרטי ריק)
                MessageDialog ms3 = new MessageDialog("First name can not be empty");
                await ms3.ShowAsync();
                return;
            }
            if (ln == null || ln == "") //אם שם משפחה ריק
            {
                //הודעה שאומרת למשתמש מה לא בסדר בשדה שהכניס (שם משפחה ריק)
                MessageDialog ms4 = new MessageDialog("Last name can not be empty");
                await ms4.ShowAsync();
                return;
            }
            //var re = await ws.IsUserExistsAsync(user, pass);
            //if (re)
            //{
            //עדכון במסד נתנים
            await ws.UpdateUserAsync(user, Password.Text, FirstName.Text, LastName.Text);
            //הודעה למשתמש שעודכן בהצלחה
                MessageDialog ms = new MessageDialog("You have succesfuly edited");
                await ms.ShowAsync();
            //מעבר לדף ההוראות
                Frame.Navigate(typeof(Game2));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            //}
            //else
            //{
                //MessageDialog ms2 = new MessageDialog("This user does not exist");
                //await ms.ShowAsync();
            //}
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור לדף ההוראות
            Frame.Navigate(typeof(Game2));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
    }
}