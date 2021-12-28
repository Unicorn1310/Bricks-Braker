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
    public sealed partial class statistics : Page
    {
        //עמוד סטטיסטיקה
        WebService1SoapClient ws = new WebService1SoapClient();
        
        public statistics()
        {
            this.InitializeComponent();

            
            GetTopScore();
            GetTopGames();
            GetLeastStrikes();
        }

        public async void GetTopScore()
        {
            //פעולה המוצאת את המשתמש עם התוצאה הכי גבוהה ואת התוצאה ומכניסה לקטע הטקסט המתאים
            var gp = await ws.TopScoreAsync();
            List<string> ls = gp.Body.TopScoreResult.ToList();
            tb1.Text = " " + "User name: " + ls[1] + ", Score: " + ls[0];
            //tb1.FontSize = 35;
        }

        public async void GetTopGames()
        {
            //פעולה המוצאת את המשתמש ששיחק הכי הרבה משחקים ואת מספר המשחקים ומכניסה לקטע הטקסט המתאים 
            var gp = await ws.TopGamesAsync();
            List<string> ls = gp.Body.TopGamesResult.ToList();
            tb2.Text = " " + "User name: " + ls[0] + ", Games: " + ls[1];
            //tb2.FontSize = 35;
        }

        public async void GetLeastStrikes()
        {
            //פעולה המוצאת את המשתמש עם הכי פחות פסילות ואת מספר הפסילות ומכניסה לקטע הטקסט המתאים 
            var gp = await ws.LeastStrikesAsync();
            List<string> ls = gp.Body.LeastStrikesResult.ToList();
            tb3.Text = "User name: " + ls[0] + ", Strikes: " + ls[1];
            //tb3.FontSize = 35;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור המעביר את המנהל לדף המנהל
            Frame.Navigate(typeof(Menahel));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
    }
}