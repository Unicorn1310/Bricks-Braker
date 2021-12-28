using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
//using System.Web.UI;
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
    public sealed partial class Register : Page
    {
        //עמוד הרשמה
        WebService1SoapClient ws = new WebService1SoapClient();

        public Register()
        {
            this.InitializeComponent();
        }
        public static string uname;
        public static string password;
        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            //כפתור ההרשמה הרושם את המשתמש
            string user = UserName.Text;
            string user2 = UserName2.Text;
            LogIn.uname = user;
            string pass = Password.Text;
            LogIn.password = pass;
            string fn = FirstName.Text;
            string ln = LastName.Text;
            //בדיקות אימות
            if(user==null||user=="")//אם שם המשתמש ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (שם משתמש ריק)
                MessageDialog ms = new MessageDialog("User name can not be empty");
                await ms.ShowAsync();
                return;
            }
            if(user!=user2) //אם אימות שם המשתמש שונה משם המשתמש
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (שם משתמש שונה מאימות שם המשתמש)
                MessageDialog ms = new MessageDialog("You typed two different user names");
                await ms.ShowAsync();
                return;
            }
            if (user == "shira")//אם שם המשתמש זהה למנהל
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (שם משתמש זהה למנהל)
                MessageDialog ms = new MessageDialog("User name can not 'shira'");
                await ms.ShowAsync();
                return;
            }
            if (pass == null || pass == "") //אם הסיסמא ריקה
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (סיסמא ריקה)
                MessageDialog ms = new MessageDialog("Password can not be empty");
                await ms.ShowAsync();
                return;
            }
            if (pass.Length < 3)//אם בסיסמא יש פחות משלושה תווים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (בסיסמא יש פחות משלושה תווים)
                MessageDialog ms = new MessageDialog("The password must be at least 3 characters long");
                await ms.ShowAsync();
                return;
            }
            if (fn == null || fn == "") //אם שם פרטי ריק
            {
                //הודעה שאומרת למשתמש מה לא בסדר בשדה שהכניס (שם פרטי ריק)
                MessageDialog ms = new MessageDialog("First name can not be empty");
                await ms.ShowAsync();
                return;
            }
            if (ln == null || ln == "") //אם שם משפחה ריק
            {
                //הודעה שאומרת למשתמש מה לא בסדר בשדה שהכניס (שם משפחה ריק)
                MessageDialog ms = new MessageDialog("Last name can not be empty");
                await ms.ShowAsync();
                return;
            }
            //בדיקה האם המשתמש קיים
            var re = await ws.IsUserExistsAsync(user, pass);
            if (re.Body.IsUserExistsResult)//אם הוא קיים
            {
                //הודעה למשתמש שאומרת לו שהוא כבר קיים
                MessageDialog ms = new MessageDialog("This user alrady exists");
                await ms.ShowAsync();
                //מעבר לדף ההתחברות
                Frame.Navigate(typeof(LogIn));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            else//אם הוא לא קיים
            {
                //הוספת המשתמש
                await ws.AddUserAsync(UserName.Text, Password.Text, FirstName.Text, LastName.Text);
                //הודעה למשתמש שאומרת שהוא נרשם בהצלחה
                MessageDialog ms = new MessageDialog("You have succesfuly registered");
                await ms.ShowAsync();
                //הוספת היסטוריית התחברות של המשתמש
                DateTime d = DateTime.Now;
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                string time = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone).ToString("HH:mm:ss");
                string date = d.Year + "-" + d.Month + "-" + d.Day;
                await ws.LogInHitAsync(user, date, time);
                //מעבר לדף ההוראות
                Frame.Navigate(typeof(Game2));
                Window.Current.Content = Frame;
                Window.Current.Activate();
                uname = user;
                password = pass;

                //var re2 = await ws.IsScoreExistsAsync(user);
                //if (re2.Body.IsScoreExistsResult == false)
                //{
                //    await ws.InsertFirstScoresAsync(user);
                //}

            }
            // ws.AddUserAsync(100, UserName.Text,Password.Text,FirstName.Text,LastName.Text);

            //Frame.Navigate(typeof(Game));
            //Window.Current.Content = Frame;
            //Window.Current.Activate();
            //string userName = UserName.Text;
            //string password = Password.Text;
            //string firstName = FirstName.Text;
            //string lastName = LastName.Text;
            //ServiceReference1.WebService1SoapClient s = new ServiceReference1.WebService1SoapClient();
            //ServiceReference1.Users user = new ServiceReference1.Users();
            //user.UserName = userName;
            //user.Password = password;
            //user.FirstName = firstName;
            //user.LastName = lastName;
            //string result = await s.AddUserAsync(user);
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור המעביר את המשתמש לדף הראשי + התנתקות
            uname = null;
            password = null;
            Frame.Navigate(typeof(MainPage));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
    }
}