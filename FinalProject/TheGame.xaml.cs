using FinalProject.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TheGame : Page
    {
        //עמוד המשחק
        WebService1SoapClient ws = new WebService1SoapClient();
        //WebService1SoapClient ws = new WebService1SoapClient();

        DispatcherTimer timer = new DispatcherTimer();

        Random rnd = new Random();

        private  static Rectangle[,] rectangles = new Rectangle[3, 10];
        public TheGame()
        {
            this.InitializeComponent();
            //יצירת הלבנים בחלקו העליון של המסך
            for (int i = 0; i < 3; i++)
            {
                StackPanel s = new StackPanel();
                s.Orientation = Orientation.Horizontal;
                sp.Children.Add(s);
                for (int j = 0; j < 10; j++)
                {
                    Rectangle r = new Rectangle();
                    r.Height = 85;
                    r.Width = 130;
                    r.Name = (j + 1) * 130 + "," + (i + 1) * 85; 


                    if (i % 2 == 0 && j % 2 == 0)
                        r.Fill = new SolidColorBrush(Colors.AliceBlue);
                    if (i % 2 == 0 && j % 2 != 0)
                        r.Fill = new SolidColorBrush(Colors.LightBlue);
                    if (i % 2 != 0 && j % 2 == 0)
                        r.Fill = new SolidColorBrush(Colors.LightBlue);
                    if (i % 2 != 0 && j % 2 != 0)
                        r.Fill = new SolidColorBrush(Colors.AliceBlue);
                    rectangles[i, j] = r;
                    s.Children.Add(r);
                }
            }
            //צבע הכדור
            if (LogIn.uname == "shira")
                ball.Fill = getColor(Menahel.color);
            else
                ball.Fill = getColor(Game2.color);
            //if (Game2.res == "red")
            //    ball.Fill = new SolidColorBrush(Colors.PaleVioletRed);
            //if (Game2.res == "blue")
            //    ball.Fill = new SolidColorBrush(Colors.CornflowerBlue);
            //if (Game2.res == "green")
            //    ball.Fill = new SolidColorBrush(Colors.Green);
            //for (int i = 0; i < rectangles.GetLength(0); i++)
            //{
            //    for (int j = 0; j < rectangles.GetLength(1); j++)
            //    {
            //        rectangles[i, j].Tag = "not marked";
            //    }
            //}
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(1000000);
            timer.Start();


        }

        private SolidColorBrush getColor(string color)
        {
            //פעולה המקבלת את הצבע שנבחר ומחזירה אותו
            if (color == null)
                return new SolidColorBrush(Colors.LightGray);
            color = color.ToLower();
            if (color == "red")
                return new SolidColorBrush(Colors.Red);
            if (color == "blue")
                return new SolidColorBrush(Colors.CornflowerBlue);
            if (color == "yellow")
                return new SolidColorBrush(Colors.LightGoldenrodYellow);
            if (color == "green")
                return new SolidColorBrush(Colors.PaleGreen);
            if (color == "purple")
                return new SolidColorBrush(Colors.Lavender);
            if (color == "pink")
                return new SolidColorBrush(Colors.LavenderBlush);
            if (color == "orange")
                return new SolidColorBrush(Colors.PapayaWhip);
            if (color == "gray")
                return new SolidColorBrush(Colors.DarkGray);
            if (color == "brown")
                return new SolidColorBrush(Colors.SaddleBrown);
            if (color == "black")
                return new SolidColorBrush(Colors.Black);
            if (color == "white")
                return new SolidColorBrush(Colors.LightGray);
            if (color == "cyan")
                return new SolidColorBrush(Colors.LightCyan);
            if (color == "burgundy")
                return new SolidColorBrush(Colors.DarkRed);
            if (color == "gold")
                return new SolidColorBrush(Colors.PaleGoldenrod);
            if (color == "silver")
                return new SolidColorBrush(Colors.Silver);
            if (color == "turquoise")
                return new SolidColorBrush(Colors.PaleTurquoise);
            if (color == "teal")
                return new SolidColorBrush(Colors.Teal);
            else
                return new SolidColorBrush(Colors.Gainsboro);
        }

        int stepX = 20;//התקדמות בציר איקס
        int stepY = 20;//התקדמות בציר וואי
        bool onceY = true;
        bool onceTop = true;
        bool onceX = true;
        bool oncePlayer = true;
        bool onceNipsal = true;
        bool onceAll = true;
        int score = 0;//תוצאה
        int strike = 0;//פסילה
        int count = 0;//מונה שבודק בכמה לבנים פגע הכדור בכל "זריקה"
        List<string> li = new List<string>();
        
        private async void Timer_Tick(object sender, object e)
        {
            tb2.Text = "Score: "+score.ToString();
            //var a = 0;
            //      throw new NotImplementedException();
            Canvas.SetLeft(ball, Canvas.GetLeft(ball) - stepX);
            Canvas.SetTop(ball, Canvas.GetTop(ball) - stepY);
            var r1 = ball.ActualWidth / 2;
            var x1 = Canvas.GetLeft(ball) + r1;
            var y1 = Canvas.GetTop(ball) + r1;
            //פגיעה בקצוות המסך, שינוי התנועה של הכדור בהתאם והוספת 2 נקודות
            if (x1 < 35 || x1 > 1260)
            {
                stepX = stepX * (-1);
                onceX = true;
                onceY = true;
                onceTop = true;
                score = score + 2;
            }
            if (y1 < 35 && onceTop == true)
            {
                stepY = stepY * (-1);
                onceX = true;
                onceY = true;
                onceTop = false;
                score = score + 2;
            }

            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                for (int j = 0; j < rectangles.GetLength(1); j++)
                {
                    if ((string)rectangles[i, j].Tag != "marked" && hitY(rectangles[i, j], ball) == true && onceY)
                    {
                        //התנגשות עם לבנה מלמעלה/מלמטה
                        //שינוי התנועה של הכדור בהתאם
                        stepY = stepY * (-1);
                        //stepX = stepX * (-1);
                        onceY = false;
                        //הפיכת הלבנה ל"שקופה" וסימונה
                        rectangles[i, j].Fill = new SolidColorBrush(Colors.White);
                        rectangles[i, j].Tag = "marked";
                        count++;//הוספת 1 למונה
                        oncePlayer = true;
                        onceX = true;
                        onceTop = true;
                        //הוספת 50 נקודות
                        score = score + 50;

                    }
                    if ((string)rectangles[i, j].Tag != "marked" && hitX(rectangles[i, j], ball) == true && onceX)
                    {
                        //התנגשות עם לבנה מהצדדים
                        //שינוי התנועה של הכדור בהתאם
                        stepX = stepX * (-1);
                        onceX = false;
                        //הפיכת הלבנה ל"שקופה" וסימונה
                        rectangles[i, j].Fill = new SolidColorBrush(Colors.White);
                        rectangles[i, j].Tag = "marked";
                        count++;//הוספת 1 למונה
                        oncePlayer = true;
                        onceY = true;
                        onceTop = true;
                        //הוספת 70 נקודות
                        score = score + 70;

                    }

                }
            }

            

            if (hitPlayer(ball) && oncePlayer == true)
            {
                //התנגשות של הכדור עם בלנה בחלקו התחתון של המשחק (שהשחקן מפעיל)
                oncePlayer = false;
                //שינוי תנועת הכדור בהתאם
                //stepX = stepX * (-1);
                stepY = stepY * (-1);
                onceX = true;
                onceY = true;
                onceTop = true;
                //הוספת 5 נקודות
                score = score + 5;
                count = 0;//איפוס המונה
            }

            if (strike == 0)//הצגת מספר הפסילות
                tb.Text = "Strikes: 0";
            //בדיקה האם כל הלבנים "נעלמו", כלומר כולן שקופות
            bool t = allMarked();
            if ( t&& onceAll)//אם לא נשארו לבנים
            {
                onceAll = false;
                Game2.color = null;
                timer.Stop();//עצירת הטיימר
                if (strike == 0)//אם השחקן לא נפסל
                {
                    var re = await ws.IsScoreExistsAsync(LogIn.uname);
                    if (re.Body.IsScoreExistsResult == false)//אם לשחקן אין תוצאת משחק, כלומר לא שיחק אף פעם
                    {
                        //הכנסת התוצאה למסד הנתונים
                        await ws.InsertScoreAsync(score, score, LogIn.uname);
                        //הכנסת הפסילות למסד הנתונים
                        int l = await ws.GetLastScoreIdAsync();
                        await ws.InsertStrikesAsync(strike, l);
                        //הודעה למשתמש שאומרת ששבר את השיא ומציגה בפניו אותו
                        MessageDialog ms = new MessageDialog("New record!" + score);
                        await ms.ShowAsync();
                    }
                    else//אם השחקן שיחק כבר לפחות משחק אחד
                    {
                        var record = await ws.GetRecordAsync(LogIn.uname);
                        if (score > record.Body.GetRecordResult)//אם השחקן שבר שיא
                        {
                            //הוספת התוצאה שלו למסד הנתונים
                            await ws.InsertScoreAsync(score, score, LogIn.uname);
                            //הוספת הפסילות שלו למסד הנתונים
                            int l = await ws.GetLastScoreIdAsync();
                            await ws.InsertStrikesAsync(strike, l);
                            //הודעה למשתמש שאומרת ששבר שיא ומציגה אותו בפניו
                            MessageDialog ms = new MessageDialog("New record!" + score);
                            await ms.ShowAsync();
                        }
                        else//אם השחקן לא שבר שיא
                        {
                            //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                            //הוספת התוצאה שלו למסד הנתונים
                            await ws.InsertScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                            //הוספת הפסילות שלו למסד הנתונים
                            int l = await ws.GetLastScoreIdAsync();
                            await ws.InsertStrikesAsync(strike, l);
                            //הודעה למשתמש שמציגה בפניו את תוצאת המשחק שלו ואת השיא שלו
                            MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                            await ms.ShowAsync();
                        }
                    }
                }
                else//אם השחקן נפסל לפחות פעם אחת 
                {
                    var record = await ws.GetRecordAsync(LogIn.uname);
                    if (score > record.Body.GetRecordResult)//אם השחן שבר שיא
                    {
                        //עדכון התוצאה של השחקן במסד הנתונים
                        await ws.UpdateScoreAsync(score, score, LogIn.uname);
                        //הוספת הפסילות של השחקן למסד הנתונים
                        int l = await ws.GetLastScoreIdAsync();
                        await ws.InsertStrikesAsync(strike, l);
                        //הודעה למשתמש שאומרת שהוא שבר שיא ומציגה אותו בפניו
                        MessageDialog ms = new MessageDialog("New record!" + score);
                        await ms.ShowAsync();
                    }
                    else//אם השחקן לא שבר שיא
                    {
                        //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                        //עדכון התוצאה במסד הנתונים 
                        await ws.UpdateScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                        //הוספת הפסילות למסד הנתונים
                        int l = await ws.GetLastScoreIdAsync();
                        await ws.InsertStrikesAsync(strike, l);
                        //הודעה למשתמש שמציגה בפניו את התוצאה שלו ואת השיא
                        MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                        await ms.ShowAsync();
                    }
                }
                if(LogIn.uname=="shira")
                {//מעבר לדף מנהל
                    Frame.Navigate(typeof(Game2));
                    Window.Current.Content = Frame;
                    Window.Current.Activate();
                }
                else
                {
                    //מעבר לדף ההוראות
                    Frame.Navigate(typeof(Game2));
                    Window.Current.Content = Frame;
                    Window.Current.Activate();
                }
            }

            if (nifsal(ball) && onceNipsal)//אם השחקן נפסל
            {
                onceNipsal = false;
                strike++;//הוספת פסילה
                if (count == 0)//אם הכדור לא פגע באף לבנה (ב"זריקה" הזאת)
                {
                    strike--;
                    score += 5;
                    stepY = stepY * (-1);
                }
                else//אם השחקן באמת נפסל
                {
                    if (strike < 3)//אם המשחק לא נגמר (נשארו לשחקן עוד פסילות)
                    {
                        //הורדת 100 נקודות
                        score = score - 100;
                        //שינוי תנועת הכדור בהתאם
                        //stepX = stepX * (-1);
                        stepY = stepY * (-1);
                        Canvas.SetLeft(ball, 735);
                        Canvas.SetTop(ball, 480);

                        //הצגת מספר הפסילות למשתמש
                        if (strike == 1)
                            tb.Text = "Strikes: 1";
                        if (strike == 2)
                            tb.Text = "Strikes: 2";
                        if (strike == 3)
                            tb.Text = "Strikes: 3";



                        if (strike == 1)//אם יש פסילה אחת
                        {
                            var re = await ws.IsScoreExistsAsync(LogIn.uname);
                            if (re.Body.IsScoreExistsResult == false)//אם זה המשחק הראשון של השחקן
                            {
                                //הוספת התוצאה של השחקן למסד הנתונים
                                await ws.InsertScoreAsync(score, score, LogIn.uname);
                                //הוספת הפסילות למסד הנתונים
                                int l = await ws.GetLastScoreIdAsync();
                                await ws.InsertStrikesAsync(strike, l);
                                //MessageDialog ms = new MessageDialog("New record!" + score);
                                //await ms.ShowAsync();
                            }
                            else//אם זה לא המשחק הראשון של השחקן
                            {
                                var record = await ws.GetRecordAsync(LogIn.uname);
                                if (score > record.Body.GetRecordResult)//אם הוא שבר/שובר שיא
                                {
                                    //הוספת התוצאה שלו למסד הנתונים
                                    await ws.InsertScoreAsync(score, score, LogIn.uname);
                                    //הוספת הפסילות שלו למסד הנתונים
                                    int l = await ws.GetLastScoreIdAsync();
                                    await ws.InsertStrikesAsync(strike, l);
                                    //MessageDialog ms = new MessageDialog("New record!" + score);
                                    //await ms.ShowAsync();
                                }
                                else//אם השחקן לא שבר/שובר שיא
                                {
                                    //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                                    //הוספת התוצאה למסד הנתונים
                                    await ws.InsertScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                                    //הוספת הפסילות למסד הנתונים
                                    int l = await ws.GetLastScoreIdAsync();
                                    await ws.InsertStrikesAsync(strike, l);
                                    //MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                                    //await ms.ShowAsync();
                                }
                            }

                        }
                        else//אם לשחקן יש מספר פסילות שונה מאחד
                        {
                            var record = await ws.GetRecordAsync(LogIn.uname);
                            if (score > record.Body.GetRecordResult)//אם השחקן שבר/שובר שיא
                            {
                                //עדכון התוצאה שלו במסד הנתונים
                                await ws.UpdateScoreAsync(score, score, LogIn.uname);
                                //הוספת הפסילות שלו למסד הנתונים
                                int l = await ws.GetLastScoreIdAsync();
                                await ws.InsertStrikesAsync(strike, l);
                                //MessageDialog ms = new MessageDialog("New record!" + score);
                                //await ms.ShowAsync();
                            }
                            else//אם השחקן לא שבר/שובר שיא
                            {
                                //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                                //עדכון התוצאה שלו במסד הנתונים
                                await ws.UpdateScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                                //הוספת הפסילות שלו למסד הנתונים
                                int l = await ws.GetLastScoreIdAsync();
                                await ws.InsertStrikesAsync(strike, l);
                                //MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                                //await ms.ShowAsync();
                            }
                        }
                        
                    }
                    else//אם המשחק נגמר (לא נשארו לשחקן עוד פסילות)
                    {
                        var record = await ws.GetRecordAsync(LogIn.uname);
                        if (score > record.Body.GetRecordResult)//אם השחקן שבר שיא
                        {
                            //עדכון התוצאה של השחקן במסד הנתונים
                            await ws.UpdateScoreAsync(score, score, LogIn.uname);
                            //הוספת הפסילות של השחקן למסד הנתונים
                            int l = await ws.GetLastScoreIdAsync();
                            await ws.InsertStrikesAsync(strike, l);
                            //הודעה למשתמש שאומרת שהוא שבר שיא ומציגה אותו בפניו
                            MessageDialog ms = new MessageDialog("New record!" + score);
                            await ms.ShowAsync();
                        }
                        else//אם השחקן לא שבר שיא
                        {
                            //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                            //עדכון התוצאה שלו במסד הנתנונים
                            await ws.UpdateScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                            //הוספת הפסילות שלו למסד הנתונים
                            int l = await ws.GetLastScoreIdAsync();
                            await ws.InsertStrikesAsync(strike, l);
                            //הודעה למשתמש המציגה בפניו את התוצאה שלו ואת השיא
                            MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                            await ms.ShowAsync();
                        }


                        //var re = await ws.IsScoreExistsAsync(LogIn.uname);
                        //var record = await ws.GetRecordAsync(LogIn.uname);
                        //if (score > record.Body.GetRecordResult|| re.Body.IsScoreExistsResult == false)
                        //{
                        //    //await ws.UpdateScoreAsync(score, score, LogIn.uname);
                        //    await ws.InsertScoreAsync(score, score, LogIn.uname);
                        //    int l=await ws.GetLastScoreIdAsync();
                        //    await ws.InsertStrikesAsync(strike, l);
                        //    MessageDialog ms = new MessageDialog("New record!" + score);
                        //    await ms.ShowAsync();
                        //}
                        //else
                        //{
                        //    //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                        //    await ws.InsertScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                        //    int l = await ws.GetLastScoreIdAsync();
                        //    await ws.InsertStrikesAsync(strike, l);
                        //    MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                        //    await ms.ShowAsync();
                        //}

                        timer.Stop();
                        Game2.color = null;
                        //מעבר לדף ההוראות
                        Frame.Navigate(typeof(Game2));
                        Window.Current.Content = Frame;
                        Window.Current.Activate();
                    }
                }

                onceNipsal = true;
            }

        }

        private bool hitY(Rectangle r, Ellipse ball)
        {
            //פעולה הבודקת התנגשות בין הכדור לבין הלמטה/הלמעלה של הלבנה
            var xL_ball = Canvas.GetLeft(ball) + 130;
            var xR_ball = Canvas.GetLeft(ball) + 60 + 130;
            var yT_ball = Canvas.GetTop(ball) + 85;
            var yB_ball = Canvas.GetTop(ball) + 60 + 85;

            var xL_rec = int.Parse(r.Name.Split(',')[0]);
            var xR_rec = int.Parse(r.Name.Split(',')[0]) + 130;
            var yT_rec = int.Parse(r.Name.Split(',')[1]);
            var yB_rec = int.Parse(r.Name.Split(',')[1]) + 85;

            //if (y_ball <= (y_rec+50) && x_ball >= x_rec && x_ball <= (x_rec + 150))
            //    return true;
            if (yT_ball <= yB_rec && yB_ball >= yT_rec && xL_ball >= xL_rec && xL_ball <= xR_rec)
                return true;
            return false;
        }

        private bool hitX(Rectangle r, Ellipse ball)
        {
            //פעולה הבודקת התנגשות בין הכדור לבין הצדדים של הלבנה
            //var r1 = ball.ActualWidth / 2;
            var xL_ball = Canvas.GetLeft(ball) + 130;
            var xR_ball = Canvas.GetLeft(ball) + 60 + 130;
            var yT_ball = Canvas.GetTop(ball) + 85;
            var yB_ball = Canvas.GetTop(ball) + 60 + 85;

            var xL_rec = int.Parse(r.Name.Split(',')[0]);
            var xR_rec = int.Parse(r.Name.Split(',')[0]) + 130;
            var yT_rec = int.Parse(r.Name.Split(',')[1]);
            var yB_rec = int.Parse(r.Name.Split(',')[1]) + 85;

            //if (Math.Abs(x_ball - x_rec) < 1 && y_ball >= y_rec && y_ball <= (y_rec + 90))
            //    return true;
            //if (((x_ball+60)==x_rec||x_ball==(x_rec+370)) && y_ball == y_rec && y_ball == (y_rec + 90))
            //    return true;
            //if (x_ball >= x_rec && x_ball <= (x_rec + 370) && y_ball==(x_rec+50)) 
            //    return true;
            if ((Math.Abs(xL_ball - xR_rec) < 7 || Math.Abs(xR_ball - xL_rec) < 7) && yT_ball <= yB_rec && yT_ball >= yT_rec)
                return true;
            //if (Math.Abs(xL_ball - xL_rec) < 1 && yT_ball <= yB_rec && yT_ball >= yT_rec)
            //    return true;
            return false;
        }

        //private void lOrR()
        //{
        //    var xL_ball = Canvas.GetLeft(ball) + 150;
        //    var xR_ball = Canvas.GetLeft(ball) + 60 + 150;
        //    var yT_ball = Canvas.GetTop(ball) + 90;
        //    var yB_ball = Canvas.GetTop(ball) + 60 + 90;

        //    var xL_rec = int.Parse(r.Name.Split(',')[0]);
        //    var xR_rec = int.Parse(r.Name.Split(',')[0]) + 150;
        //    var yT_rec = int.Parse(r.Name.Split(',')[1]);
        //    var yB_rec = int.Parse(r.Name.Split(',')[1]) + 90;

        //    if(xL_ball>xL_rec&&xL_ball<(xL_rec+75))
        //    {
        //        stepY = stepY * (-1);
                
        //    }

        //}

        private bool hitPlayer(Ellipse ball)
        {
            //פעולה הבודקת התנגשות בין הכדור ללבנה בתחתית המסך, שמפעיל השחקן
            var x_ball = Canvas.GetLeft(ball);
            var y_ball = Canvas.GetTop(ball);
            var x_rec = Canvas.GetLeft(mainRe);
            var y_rec = Canvas.GetTop(mainRe);
            //if (y_rec == (y_ball + 60) && x_rec < x_ball && (x_rec + 370) > x_ball)
            if (Math.Abs(y_rec - (y_ball + 60)) < 15 && x_rec < x_ball && (x_rec + 370) > x_ball) 
            {
                //y_ball -= 10;
                return true;
            }

            //}
            return false;
        }

        private bool nifsal(Ellipse ball)
        {
            //פעולה הבודקת האם השחקן נפסל
            var x_ball = Canvas.GetLeft(ball);
            var y_ball = Canvas.GetTop(ball);
            var x_rec = Canvas.GetLeft(mainRe);
            var y_rec = Canvas.GetTop(mainRe);

            if (y_rec < (y_ball + 60))
                return true;
            return false;
        }

        private bool allMarked()
        {
            //פעולה הבודקת האם כל הלבנים נגמרו
            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                for (int j = 0; j < rectangles.GetLength(1); j++)
                {
                    if ((string)rectangles[i, j].Tag == null || (string)rectangles[i, j].Tag != "marked")
                   // SolidColorBrush b = rectangles[i, j].Fill as SolidColorBrush;
                  //  if (b==null|| b.Color!=Colors.White)
                    {
                       // li.Add( $"i: {i}, j:{j} ,{DateTime.Now} , Tag: {rectangles[i, j].Tag.ToString()}");
                        
                        return false;
                    }
                        
                }
            }
            return true;
        }

        private async void Back_Click(object sender, RoutedEventArgs e)
        {
            //כפתור חזור

            //עצירת הטיימר
            timer.Stop();

            if (strike == 0)//אם השחקן לא נפסל
            {
                var re = await ws.IsScoreExistsAsync(LogIn.uname);
                if (re.Body.IsScoreExistsResult == false)//אם זה המשחק הראשון של המשתמש
                {
                    //הוספת התוצאה של השחקן למסד הנתונים
                    await ws.InsertScoreAsync(score, score, LogIn.uname);
                    //הוספת הפסילות של השחקן למסד הנתונים
                    int l = await ws.GetLastScoreIdAsync();
                    await ws.InsertStrikesAsync(strike, l);
                    //הודעה למשתמש שאומרת שהוא שבר שיא ומציגה אותו בפניו
                    MessageDialog ms = new MessageDialog("New record!" + score);
                    await ms.ShowAsync();
                }
                else//אם זה לא המשחק הראשון של השחקן
                {
                    var record = await ws.GetRecordAsync(LogIn.uname);
                    if (score > record.Body.GetRecordResult)//אם השחקן שבר שיא
                    {
                        //הוספת התוצאה שלו למסד הנתונים
                        await ws.InsertScoreAsync(score, score, LogIn.uname);
                        //הוספת הפסילות שלו למסד הנתונים
                        int l = await ws.GetLastScoreIdAsync();
                        await ws.InsertStrikesAsync(strike, l);
                        //הודעה למשתמש שאומרת שהוא שבר שיא ומציגה אותו בפניו
                        MessageDialog ms = new MessageDialog("New record!" + score);
                        await ms.ShowAsync();
                    }
                    else//אם השחקן לא שבר שיא
                    {
                        //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                        //הוספת התוצאה שלו למסד הנתונים
                        await ws.InsertScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                        //הוספת הפסילות שלו למסד הנתונים
                        int l = await ws.GetLastScoreIdAsync();
                        await ws.InsertStrikesAsync(strike, l);
                        //הודעה למשתמש שמציגה בפניו את התוצאה ואת השיא שלו
                        MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                        await ms.ShowAsync();
                    }
                }
            }
            else//אם לשחקן יש לפחות פסילה אחת
            {
                var record = await ws.GetRecordAsync(LogIn.uname);
                if (score > record.Body.GetRecordResult)//אם השחקן שבר שיא
                {
                    //עדכון התוצאה שלו במסד הנתונים
                    await ws.UpdateScoreAsync(score, score, LogIn.uname);
                    //הוספת הפסילות שלו למסד הנתונים
                    int l = await ws.GetLastScoreIdAsync();
                    await ws.InsertStrikesAsync(strike, l);
                    //הודעה למשתמש שאומרת לו ששבר שיא ומציגה אותו בפניו
                    MessageDialog ms = new MessageDialog("New record!" + score);
                    await ms.ShowAsync();
                }
                else//אם השחקן לא שבר שיא
                {
                    //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
                    //עדכון התוצאה שלו במסד הנתונים
                    await ws.UpdateScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
                    //הוספת הפסילות שלו למסד הנתונים
                    int l = await ws.GetLastScoreIdAsync();
                    await ws.InsertStrikesAsync(strike, l);
                    //הודעה למשתמש שמציגה בפניו את התוצאה שלו ואת השיא שלו
                    MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
                    await ms.ShowAsync();
                }
            }

            //var re = await ws.IsScoreExistsAsync(LogIn.uname);
            //if (re.Body.IsScoreExistsResult == false)
            //{
            //    await ws.InsertScoreAsync(score, score, LogIn.uname);
            //    int l = await ws.GetLastScoreIdAsync();
            //    await ws.InsertStrikesAsync(strike, l);
            //    MessageDialog ms = new MessageDialog("New record!" + score);
            //    await ms.ShowAsync();
            //}
            //else
            //{
            //    var record = await ws.GetRecordAsync(LogIn.uname);
            //    if (score > record.Body.GetRecordResult)
            //    {
            //        await ws.InsertScoreAsync(score, score, LogIn.uname);
            //        int l = await ws.GetLastScoreIdAsync();
            //        await ws.InsertStrikesAsync(strike, l);
            //        MessageDialog ms = new MessageDialog("New record!" + score);
            //        await ms.ShowAsync();
            //    }
            //    else
            //    {
            //        //await ws.UpdateScoreAsync(score, 0, LogIn.uname);
            //        await ws.InsertScoreAsync(score, record.Body.GetRecordResult, LogIn.uname);
            //        int l = await ws.GetLastScoreIdAsync();
            //        await ws.InsertStrikesAsync(strike, l);
            //        MessageDialog ms = new MessageDialog("Your score is" + " " + score + "   " + "Your record is" + " " + record.Body.GetRecordResult);
            //        await ms.ShowAsync();
            //    }
            //}
            //התנתקות
            //LogIn.uname = null;
            //LogIn.password = null;
            Game2.color = null;
            //ball.Fill = getColor(null);
            if(LogIn.uname=="shira") //חזרה לדף מנהל
            {
                Frame.Navigate(typeof(Menahel));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }
            else             //מעבר לדף ההוראות
            {
                Frame.Navigate(typeof(Game2));
                Window.Current.Content = Frame;
                Window.Current.Activate();
            }

        }

        private void Canvas_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //שליטה בלבנה של השחקן דרך המקלדת
            var k = e.Key.ToString();
            if (k == "Left")
            {
                Canvas.SetLeft(mainRe, Canvas.GetLeft(mainRe) - 10);
            }
            if (k == "Right")
            {
                Canvas.SetLeft(mainRe, Canvas.GetLeft(mainRe) + 10);
            }
        }
    }
}
