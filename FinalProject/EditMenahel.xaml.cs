using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class EditMenahel : Page
    {
        //עמוד עריכה למנהל
        WebService1SoapClient ws = new WebService1SoapClient();
        public EditMenahel()
        {
            this.InitializeComponent();
            //הדפסת הנתונים הקיימים בתיבות הטקסט

            Users u = Menahel.user;
            Password.Text = u.password;
            FirstName.Text = u.firstName;
            LastName.Text = u.lastName;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור לדף מנהל
            Frame.Navigate(typeof(Menahel));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            //כפתור עריכה
            string pass = Password.Text;
            string fn = FirstName.Text;
            string ln = LastName.Text;
            //var re = await ws.IsUserExistsAsync(user, pass);
            //if (re)
            //{

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

            Users u = Menahel.user;
                string un = u.userName;
            //עריכה במסד נתונים
                await ws.UpdateUserAsync(un, Password.Text, FirstName.Text, LastName.Text);
            //הודעה למנהל שהעריכה בוצעה בהצלחה
                MessageDialog ms = new MessageDialog("You have succesfuly edited");
                await ms.ShowAsync();
            //מעבר לדף מנהל
                Frame.Navigate(typeof(Menahel));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            //}
            //else
            //{
            //    MessageDialog ms = new MessageDialog("This user is not exist");
            //    await ms.ShowAsync();
            //}
        }
    }
}