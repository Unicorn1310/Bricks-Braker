using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class LogIn : Page
    {
        //עמוד התחברות
        WebService1SoapClient ws = new WebService1SoapClient();
        public LogIn()
        {
            this.InitializeComponent();
        }

        //private void LogIn_Click(object sender, RoutedEventArgs e)
        //{

        //}
        public static string uname;

        public static string password;
        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string user = UserName.Text;
            uname = user;
            string pass = Password.Text;
            var re = await ws.IsUserExistsAsync(user, pass); //בדיקה האם המשתמש כבר קיים

            //var re2 = await ws.IsScoreExistsAsync(user);
            //if (re2.Body.IsScoreExistsResult == false)
            //{
            //    await ws.InsertFirstScoresAsync(user);
            //}

            if (user == "shira" && pass == "shira") //בדיקה אם המשתמש הוא המנהל
            {
                //הודעה למשתמש שאומרת שהוא המנהל
                MessageDialog ms = new MessageDialog("You are the admin");
                await ms.ShowAsync();
                //הוספת הנתונים של ההתחברות לטבלת היסטוריית ההתחברות
                DateTime d = DateTime.Now;
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                string time = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone).ToString("HH:mm:ss");
                string date = d.Year + "-" + d.Month + "-" + d.Day;
                await ws.LogInHitAsync(user, date, time);
                //מעבר לדף מנהל
                Frame.Navigate(typeof(Menahel));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            else
            {
                if (re.Body.IsUserExistsResult) //אם המשתמש לא מנהל וקיים
                {
                    //הוספת הנתונים של ההתחברות לטבלת היסטוריית ההתחברות
                    DateTime d = DateTime.Now;
                    // DateTime d_out;
                    // bool b=DateTime.TryParseExact(d.ToString(), "yyyy-MM-dd", null, DateTimeStyles.None, out d_out);
                    var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    string time = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone).ToString("HH:mm:ss");
                    //string time = d.Hour + ":" + d.Minute + ":" + d.Second;
                    string date = d.Year + "-" + d.Month + "-" + d.Day;
                    //INSERT INTO [Gamee].[dbo].[LogInHis] (Date,Time,UserName) VALUES ('2020-12-03','22:23:44','a');
                    await ws.LogInHitAsync(user, date, time);
                    //הודעה למשתמש שהתחבר בהצלחה
                    MessageDialog ms = new MessageDialog("You have succesfuly loged in");
                    await ms.ShowAsync();
                    //מעבר לדף ההוראות
                    Frame.Navigate(typeof(Game2));
                    Window.Current.Content = Frame;
                    Window.Current.Activate();
                    uname = user;
                    password = pass;
                }
                else //אם המשתמש לא מנהל ולא קיים
                {
                    //הודעה למשתמש שהוא לא קיים
                    MessageDialog ms = new MessageDialog("This user does not exist");
                    await ms.ShowAsync();
                    //מעבר לדף ההרשמה
                    Frame.Navigate(typeof(Register));
                    Window.Current.Content = Frame;
                    Window.Current.Activate();
                }
            }

            


            //    string userN = this.Username.Text;
            //    string passW = this.passWord.Text;
            //    ServiceReference1.WebService1SoapClient s = new ServiceReference1.WebService1SoapClient();
            //    ServiceReference1.Users X = new ServiceReference1.Users();
            //    X.userName = userN;
            //    X.password = passW;
            //    string result = await s.LogInAsync(X);
            //    MessageDialog ms = new MessageDialog(result);
            //    await ms.ShowAsync();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור לדף הראשי והתנתקות
            uname = null;
            password = null;

            Frame.Navigate(typeof(MainPage));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
    }
}