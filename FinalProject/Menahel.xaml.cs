using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed partial class Menahel : Page, INotifyPropertyChanged
    {
        //עמוד מנהל
        WebService1SoapClient ws = new WebService1SoapClient();
        internal static string color;
        //internal static string color0;
        public static ComboBox cob;
        //WebService1SoapClient ws = new WebService1SoapClient();
        private ObservableCollection<string> the_colors = new ObservableCollection<string>();
        public ObservableCollection<string> The_colors
        {
            get
            {
                return the_colors;
            }
            set
            {
                the_colors = value;
                NotifyPropertyChanged("The_colors");
            }
        }
        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Menahel()
        {
            this.InitializeComponent();
            DataContext = this;
            GetUsersTable();
            cob = cb;
            //הצגת הצבעים ברשימה הנגללת
            GetColors();
            List<string> color = ws.GetAllColorsAsync().Result.Body.GetAllColorsResult.ToList();
            foreach (var item in color)
            {
                //cb.Items.Add(item);
                The_colors.Add(item);
            }
        }

        public async void GetColors()
        {
            //פעולה המאחזרת את הצבעים מטבלת הצבעים
            var gp = await ws.GetAllColorsAsync();
            cb.ItemsSource = gp.Body.GetAllColorsResult.ToList();
        }

        public async void GetUsersTable()
        {
            //פעולה המאחזרת את המשתמשים
            var gp = await ws.GetAllUsersAsync();
            // gv.DataContext = gp.ToList();
            gv.ItemsSource = gp.Body.GetAllUsersResult.ToList();
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המנהל לדף העריכה

            Users u = user;
            if(u==null)//אם לא נלחץ משתמש
            {
                //הודעה למנהל שאומרת לו שהוא לא לחץ על משתמש
                MessageDialog ms = new MessageDialog("Click a user");
                await ms.ShowAsync();
            }
            else
            {
                if(LogIn.uname=="shira"&&u.password=="shira"&&u.firstName=="shira"&&u.lastName=="shira")//אם המשתמש שנלחץ הוא המנהל
                {
                    //הודעה למנהל שאומרת לו שאי אפשר לערוך את המנהל
                    MessageDialog ms = new MessageDialog("Admin is not editable");
                    await ms.ShowAsync();
                }
                else//אם המשתמש שנלחץ הוא משתמש רגיל
                {
                    //מעבר לדף העריכה
                    Frame.Navigate(typeof(EditMenahel));
                    Window.Current.Content = Frame;
                    Window.Current.Activate();
                }
            }

           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור המעביר את המנבל לדף הראשי+ התנתקות
            LogIn.uname = null;
            LogIn.password = null;
            Frame.Navigate(typeof(MainPage));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
        //internal static string res;
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המנהל לדף ההוראות
            //string username = LogIn.uname.ToString();
            //MessageDialog ms = new MessageDialog("Instructions: The purpose of the game is to hit as many bricks possible. Each brick color has a different score. You are allowed 3 strikes. Each strike will reduce scores. In order to aim- moove the block on the bottom of the screen.");
            //await ms.ShowAsync();

            ////var dialog = new Windows.UI.Popups.MessageDialog("Choose your color");
            //////dialog.Commands.Add(new Windows.UI.Popups.UICommand("gray") { Id = 0 });
            //////dialog.Commands.Add(new Windows.UI.Popups.UICommand("blue") { Id = 1 });
            //////dialog.Commands.Add(new Windows.UI.Popups.UICommand("green") { Id = 2 });
            //////dialog.CancelCommandIndex = 0;
            //////dialog.CancelCommandIndex = 1;
            //////dialog.CancelCommandIndex = 2;
            ////var result = await dialog.ShowAsync();
            //////await ws.AddColorAsync(result.Label, username);
            ////Game2.res = result.Label;
            string color = cb.Text;
            Frame.Navigate(typeof(TheGame));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }


        //void F()
        //{
        //    string test = tb.Text;
        //    cb.Items.Add("pi");
        //}
        private async void AddColor_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המוסיף את הצבע שהמנהל הוסיף לטבלת הצבעים
            // F();
            // string test = tb.Text;
            //cb.Items.Add(tb.Text);
            The_colors.Add(tb.Text);
            NotifyPropertyChanged("The_colors");
            var HisId = await ws.GetLastHisIdAsync(LogIn.uname);
            await ws.AddColorAsync(tb.Text, HisId.Body.GetLastHisIdResult);
            tb.Text = "";
            MessageDialog ms = new MessageDialog("You have succesfully added a color");
            await ms.ShowAsync();
        }

        private void Gv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//הצגת הצבעים
            GridView gv = sender as GridView;
            var t = gv.Items.ToList();
            int index=  gv.SelectedIndex;
            user = (Users)t[index];
            color= color = cb.Text;
        }

        public static Users user;

        //public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המנהל לעמוד הסטטיסטיקה
            Frame.Navigate(typeof(statistics));
            Window.Current.Content = Frame;
            Window.Current.Activate();  
        }

        private async void Accomplishments_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המנהל לעמוד ההיגשים
            Users u = user;
            if (u == null)//אם לא נלחץ משתמש
            {
                //הודעה למנהל שאומרת לו שהוא צריך ללחוץ על משתמש
                MessageDialog ms = new MessageDialog("Click a user");
                await ms.ShowAsync();
            }
            else//אם נלחץ משתמש
            {
                //מעבר לדף ההישגים
                Frame.Navigate(typeof(accomplishments));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            
        }

        private async void LogInHisto_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המנהל לעמוד היסטוריית ההתחברות
            Users u = user;
            if (u == null)//אם לא נלחץ משתמש
            {
                //הודעה למנהל שאומרת לו שהוא לא לחץ על משתמש
                MessageDialog ms = new MessageDialog("Click a user");
                await ms.ShowAsync();
            }
            else//אם נלחץ משתמש
            {
                //מעבר לדף היסטוריית ההתחברות
                Frame.Navigate(typeof(LogInHist));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            
        }

        private async void Strikes_Click(object sender, RoutedEventArgs e)
        {
            //כפתור המעביר את המנהל לעמוד הפסילות
            Users u = user;
            if (u == null)//אם לא נלחץ משתמש
            {
                //הודעה למנהל שהוא לא לחץ על משתמש
                MessageDialog ms = new MessageDialog("Click a user");
                await ms.ShowAsync();
            }
            else//אם נלחץ משתמש
            {
                //מעבר לדף הפסילות
                Frame.Navigate(typeof(Strike));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            
        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            color = cb.SelectedItem.ToString();
        }
    }
}