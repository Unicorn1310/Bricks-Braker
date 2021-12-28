using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CreditCard
    {
        //מחלקת כרטיס אשראי
        private string cardNum; //מספר כרטיס אשראי מטיפוס מחרוזת
        private string expiared; //תאריך תפוגה מטיפוס מחרוזת
        private int cvv; //מספר בגב הכרטיס מטיפוס שלם

        public string CreditNum //מספר כרטיס אשראי
        {
            get            {                return cardNum;            }            set            {                if(value!=null)
                {
                    if (value.Length != 16) //אם האורך הוא לא 16
                        cardNum = "0000000000000000";
                    else
                        cardNum = value;
                    bool flag = true;
                    for (int i = 0; i < cardNum.Length; i++)
                    {
                        if (cardNum[i] < 48 || cardNum[i] > 57) //אם הערכים במספר הכרטיס הם לא מספרים
                            flag = false;
                    }
                    if (flag == false)
                        cardNum = "0000000000000000";
                }                            }
        }

        private bool isDigit(char c)
        {
            //פעולה המחזירה אמת אם התו שהתקבל הוא ספרה, שקר אחרת
            if (c >= 48 && c <= 57)
                return true;
            return false;
        }

        public string Expiared //תאריך תפוגה
        {
            get
            {
                return expiared;
            }
            set
            {
                if (value.Length != 5) //אם אורך התווים הוא לא 5
                    expiared = "00/00";
                else
                {
                    bool flag = true;
                    for(int i=0;i<value.Length;i++)
                    {
                        if (i != 2 && isDigit(value[i]) == false) //אם המספרים בתאריך אינם מספרים
                            flag = false;
                        else if(i==2&&value[i]!='/') //אם התו האמצעי אינו סלאש
                        {
                            flag = false;
                        }       
                    }
                    if (flag == true)
                    {
                        string m = value[0] + value[1] + "";
                        int month = int.Parse(m);
                        if (!(month > 1 && month < 12))//אם החודש הוא לא בין ינואר לדצמבר
                            flag = false;
                    }
                    if (flag == false)
                        expiared = "00/00";
                }
            }
        }
        public int Cvv //מספר בגב הכרטיס
        {
            get
            {
                return cvv;
            }
            set
            {
                if (value < 100 || value > 999) //אם המספר הוא לא תלת ספרתי
                    cvv = -1;
            }
        }

        public bool hiuv()
        {
            //פעולה המחייבת את כרטיס האשראי
            if (this.cardNum == "0000000000000000")
                return false;
            if (this.expiared == "00/00")
                return false;
            if (this.cvv == (-1))
                return false;
            return true;
        }

        public string cancel()
        {
            //פעולה המבטלת את חיוב כרטיס האשראי
            if (this.cardNum == "0000000000000000")
                return "false";
            if (this.expiared == "00/00")
                return "false";
            if (this.cvv == (-1))
                return "false";
            return "true";
        }
    }
}