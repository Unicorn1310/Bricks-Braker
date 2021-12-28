using FinalProject.ServiceReference1;
using FinalProject.ServiceReference2;
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
    public sealed partial class Help : Page
    {
        //עמוד עזרה
        WebServiceEmailSoapClient ws = new WebServiceEmailSoapClient();
        public Help()
        {
            this.InitializeComponent();
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        { //כפתור השולח את המייל

            if(email.Text==null||email.Text==" ")//אם המייל ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (מייל ריק)
                MessageDialog ms6 = new MessageDialog("Email can not be empty");
                await ms6.ShowAsync();
                return;
            }
            if(email.Text.IndexOf('@')<0)//אם במייל אין @
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (אין @ במייל)
                MessageDialog ms6 = new MessageDialog("Email must contain '@'");
                await ms6.ShowAsync();
                return;
            }
            if (email.Text.IndexOf('.') < 0) //אם אין נקודה במייל
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (אין נקודה במייל)
                MessageDialog ms6 = new MessageDialog("Email must contain '.'");
                await ms6.ShowAsync();
                return;
            }
            if (subject.Text == null || subject.Text == " ")//אם הנושא ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (הנושא ריק)
                MessageDialog ms6 = new MessageDialog("Subject can not be empty");
                await ms6.ShowAsync();
                return;
            }
            if (Body.Text == null || Body.Text == " ")//אם גוף ההודעה ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (גוף ההודעה ריק)
                MessageDialog ms6 = new MessageDialog("Body can not be empty");
                await ms6.ShowAsync();
                return;
            }

            //זימון פעולה השולחת את המייל
            await ws.sendEmailAsync("bricksbraker@gmail.com", "bricksbraker@gmail.com", subject.Text+" -User name: "+LogIn.uname, Body.Text+" -Email: "+email.Text,"shira1310",email.Text);
            //הודעה למשתמש שאומרת לו ששליחת המייל התבצעה בהצלחה
            MessageDialog ms = new MessageDialog("Your massege was seccessfuly sent");
            await ms.ShowAsync();
            //חזרה לדף ההוראות
            Frame.Navigate(typeof(Game2));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {//כפתור חזור לדף ההוראות
            Frame.Navigate(typeof(Game2));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
    }
}