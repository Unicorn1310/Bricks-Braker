using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class LogInHist : Page
    {
        //עמוד היסטוריית ההתחברות
        WebService1SoapClient ws = new WebService1SoapClient();
        public LogInHist()
        {
            this.InitializeComponent();
            //כותרת העמוד
            GetLogInHisTable();
            if (LogIn.uname == "shira")
                tb.Text = Menahel.user.userName;
            else
                tb.Text = LogIn.uname;
        }

        public async void GetLogInHisTable()
        {
            //פעולה המאחזרת את היסטוריית ההתחברות של המשתמש הרצוי
            string name = "";
            if (LogIn.uname != "shira")
                name = LogIn.uname;
            else
            {
                if (Menahel.user.userName == null || Menahel.user.userName == " ")
                    name = LogIn.uname;
                else
                    name = Menahel.user.userName;
            }
                

            var gp = await ws.GetLogInHisAsync(name);
            // gv.DataContext = gp.ToList();
            gv.ItemsSource = gp.Body.GetLogInHisResult.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור לעמוד מנהל/לעמוד הוראות
            if (LogIn.uname == "shira")
            {
                Frame.Navigate(typeof(Menahel));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            else
            {
                Frame.Navigate(typeof(Game2));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
        }
    }
}