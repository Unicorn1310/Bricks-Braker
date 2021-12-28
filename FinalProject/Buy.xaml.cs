using FinalProject.ServiceReference3;
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
    public sealed partial class Buy : Page
    {
        //עמוד קנייה
        CreditCSoapClient ws = new CreditCSoapClient();
        public Buy()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        { //כפתור חזור המחזיר את המשתמש לדף ההוראות
            Frame.Navigate(typeof(Game2));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }

        private bool isDigit(char c)
        {//פעולה הבודקת האם התו הוא סיפרה
            if (c >= 48 && c <= 57)
                return true;
            return false;
        }

        private bool isAllDigits(string n)
        {//פעולה הבודקת האם כל התווים במחרוזת הם סיפרה
            bool result = true;
            for(int i=0;i<n.Length;i++)
            {
                if (isDigit(n[i]) == false)
                    result = false;
            }
            return result;
        }

        public static bool isPaid = false;
        private async void Buy_Click(object sender, RoutedEventArgs e)
        {
            //בדיקות אימות
            if (cardNum == null || cardNum.Text == " ")//אם מספר כרטיס ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (מספר כרטיס ריק)
                MessageDialog ms1 = new MessageDialog("Card number can not be empty");
                await ms1.ShowAsync();
                return;
            }
            if (cardNum.Text.Length != 16)//אם במספר כרטיס אשראי אין 16 תווים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (במספר כרטיס אשראי אין 16 תווים)
                MessageDialog ms4 = new MessageDialog("Card number must be 16 characters long");
                await ms4.ShowAsync();
                return;
            }
            if (isAllDigits(cardNum.Text) == false)//אם לא כל התווים במספר כרטיס הם ספרות
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (יש תו שהוא לא ספרה במספר כרטיס אשראי)
                MessageDialog ms6 = new MessageDialog("Card number must be numbers only");
                await ms6.ShowAsync();
                return;
            }
            if (expierd == null || expierd.Text == "")//אם תאריך תפוגה ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (תאריך תפוגה ריק)
                MessageDialog ms2 = new MessageDialog("Expiration date can not be empty");
                await ms2.ShowAsync();
                return;
            }
            if (expierd.Text.Length !=5)//אם בתאריך תפוגה אין חמישה תווים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (בתאריך תפוגה אין חמישה תווים)
                MessageDialog ms5 = new MessageDialog("Expiration date must be 5 characters long");
                await ms5.ShowAsync();
                return;
            }
            //int str = int.Parse(expierd.Text[4]) + int.Parse(expierd.Text[5]);
            if (expierd.Text[2] != '/')//אם בתאריך תפוגה אין סלאש
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (בתאריך תפוגה אין סלאש)
                MessageDialog ms5 = new MessageDialog("Expiration date must contain '/' . For example: 00/00");
                await ms5.ShowAsync();
                return;
            }
            string str = expierd.Text.Substring(3);
            int checkYear = int.Parse(str);
            string str2 = expierd.Text.Substring(0, 2);
            int checkMonth = int.Parse(str2);
            int thisYear = 21;
            int thisMonth = 6;
            if(checkYear<thisYear)//אם השנה בתאריך תפוגה עברה
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (תאריך תפוגה עבר)
                MessageDialog ms5 = new MessageDialog("Expiration date has passed");
                await ms5.ShowAsync();
                return;
            }
            if (checkYear==thisYear)//אם התאריך תפוגה בשנה הנוכחית
            {
                if(checkMonth<=thisMonth)//בדיקת חודש
                {
                    //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (תאריך תפוגה עבר)
                    MessageDialog ms5 = new MessageDialog("Expiration date has passed");
                    await ms5.ShowAsync();
                    return;
                } 
            }
            
            if (isDigit(expierd.Text[0]) == false && isDigit(expierd.Text[1]) == false && isDigit(expierd.Text[3]) == false && isDigit(expierd.Text[4]) == false)//אם התווים שהם לא סלאש הם לא מספרים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (המספרים שאינם סלאש הם לא מספרים)
                MessageDialog ms6 = new MessageDialog("Expiration date must be in this structure: 00/00");
                await ms6.ShowAsync();
                return;
            }
            if (cvv == null || cvv.Text == "")//אם מספר בגב הכרטיס ריק
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (מספר בגב הכרטיס ריק)
                MessageDialog ms3 = new MessageDialog("Cvv can not be empty");
                await ms3.ShowAsync();
                return;
            }
            if (cvv.Text.Length != 3)//אם במספר בגב הכרטיס אין שלושה תווים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (במספר בגב הכרטיס אין שלושה תווים)
                MessageDialog ms6 = new MessageDialog("Cvv must be 3 characters long");
                await ms6.ShowAsync();
                return;
            }
            if(isAllDigits(cvv.Text)==false)//אם לא כל התווים הם מספרים
            {
                //הודעה למשתמש שאומרת לו מה לא בסדר בשדה שהכניס (המספר בגב הכרטיס לא מכיל רק מספרים)
                MessageDialog ms6 = new MessageDialog("Cvv must be numbers only");
                await ms6.ShowAsync();
                return;
            }



            //חיוב כרטיס האשראי
            var re=await ws.IsCardExistsAsync(cardNum.Text,expierd.Text,int.Parse(cvv.Text));
            if(re.Body.IsCardExistsResult==false)
            {
                var res = await ws.IsAddableAsync(cardNum.Text);
                if (res.Body.IsAddableResult == true)
                    await ws.AddCardAsync(cardNum.Text, expierd.Text, int.Parse(cvv.Text));
                else
                {
                    MessageDialog ms1 = new MessageDialog("This card number is already taken");
                    await ms1.ShowAsync();
                    return;
                }
            }
            await ws.hiuvAsync(cardNum.Text, expierd.Text, int.Parse(cvv.Text));
            isPaid = true;
            //הודעה למשתמש שאומרת שהקנייה התבצעה בהצלחה
            MessageDialog ms = new MessageDialog("Your purchase was successful");
            await ms.ShowAsync();
            //מעבר לדף ההוראות
            Frame.Navigate(typeof(Game2));
            Window.Current.Content = Frame;
            Window.Current.Activate();
        }
    }
}