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
using static FinalProject.TheGame;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game2 : Page
    {
        //עמוד הוראות לקראת המשחק
        WebService1SoapClient ws = new WebService1SoapClient();
        internal static string color;

        public Game2()
        {
            this.InitializeComponent();
            //הכנסת הצבעים לרשימה הנגללת
            GetColors();
            List<string> color= ws.GetAllColorsAsync().Result.Body.GetAllColorsResult.ToList();
            foreach (var item in color)
            {
                cb2.Items.Add(item);
            }
        }

        public async void GetColors()
        {
            //פעולה המאחזרת את הצבעים של הכדור מטבלת הצבעים
            var gp = await ws.GetAllColorsAsync();
            cb2.ItemsSource = gp.Body.GetAllColorsResult.ToList();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //כפתור התחלת המשחק שמעביר את המשתמש לדף המשחק
            string username = LogIn.uname.ToString();
            //MessageDialog ms = new MessageDialog("Instructions: The purpose of the game is to hit as many bricks possible. Each brick color has a different score. You are allowed 3 strikes. Each strike will reduce scores. In order to aim- moove the block on the bottom of the screen.");
            //await ms.ShowAsync();

            //var dialog = new Windows.UI.Popups.MessageDialog("Choose your color");
            //ComboBox cb = Menahel.cob;
            //foreach (var item in cb.Items)
            //{
            //    dialog.Commands.Add(new Windows.UI.Popups.UICommand(item.ToString()) { Id = 0 });
            //}
            string color = cb2.Text;
            //dialog.Commands.Add(new Windows.UI.Popups.UICommand("gray") { Id = 0 });
            //dialog.Commands.Add(new Windows.UI.Popups.UICommand("blue") { Id = 1 });
            //dialog.Commands.Add(new Windows.UI.Popups.UICommand("green") { Id = 2 });
            //dialog.CancelCommandIndex = 0;
            //dialog.CancelCommandIndex = 1;
            //dialog.CancelCommandIndex = 2;
            //var result = await dialog.ShowAsync();
            ////await ws.AddColorAsync(result.Label, username);
            // res = result.Label;
            ////var color = new color();
            ////color.r = result.Label;
            ////var btn = sender as Button;
            ////btn.Content = $"Your color is {result.Label} ({result.Id})";

            Frame.Navigate(typeof(TheGame));
            Window.Current.Content = Frame;
            Window.Current.Activate();

        }

        //private async System.Threading.Tasks.Task Update_ClickAsync(object sender, RoutedEventArgs e)
        //{            //כפתור המעביר את המשתמש לעמוד העריכה

        //    if (LogIn.uname=="shira"&&LogIn.password=="shira")
        //    {//אי אפשר לערוך את המנהל
        //        MessageDialog ms = new MessageDialog("Admin is not editable");
        //        await ms.ShowAsync();
        //    }
        //    else
        //    {//מעבר לדף העריכה
        //        Frame.Navigate(typeof(Edit));
        //        Window.Current.Content = Frame;
        //        Window.Current.Activate();
        //    }
        //}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(LogIn.uname=="shira")
            {
                //חזרה לדף מנהל
                Frame.Navigate(typeof(Menahel));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            else
            {
                //כפתור חזור לעמוד הראשי והתנתקות
                LogIn.uname = null;
                LogIn.password = null;
                Buy.isPaid = false;
                Frame.Navigate(typeof(MainPage));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
        }

        private void Cb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//רשימה נגללת
            if (Buy.isPaid == true||(LogIn.uname=="shira"))//בדיקה האם המשתמש שילם או אם הוא מנהל
                color = cb2.SelectedItem.ToString();//הצגת הצבעים
            else
            {//מעבר לדף הקנייה
                Frame.Navigate(typeof(Buy));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
        }

        private void Strikes_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המשתמש לעמוד הפסילות, שבו יוכל לראות את הפסילות שלו
            Frame.Navigate(typeof(Strike));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private void LogInHiss_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המשתמש לעמוד היסטוריית ההתחברות, שבו יוכל לראות את היסטוריית ההתחברות שלו
            Frame.Navigate(typeof(LogInHist));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private void Accomplishments_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המשתמש לעמוד ההישגים, שבו יוכל לראות את הישגיו
            Frame.Navigate(typeof(accomplishments));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {//כפתור המעביר את המשתמש לדף העזרה
            Frame.Navigate(typeof(Help));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המשתמש לעמוד העריכה

            if (LogIn.uname == "shira" && LogIn.password == "shira")
            {//אי אפשר לערוך את המנהל
                MessageDialog ms = new MessageDialog("Admin is not editable");
                await ms.ShowAsync();
            }
            else
            {//מעבר לדף העריכה
                Frame.Navigate(typeof(Edit));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
        }
    }
}