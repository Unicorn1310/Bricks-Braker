using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class LogInHis
    {
        //מחלקת היסטוריית ההתחברות
        private int LogInHisId; //הID של היסטוריית ההתחברות
        private string UserName; //שם משתמש
        private string Date; //תאריך
        private string Time; //שעה

        public LogInHis()
        {

        }

        public int logInHisId //הID של היסטוריית ההתחברות
        {
            set
            {
                this.LogInHisId = value;
            }
            get
            {
                return this.LogInHisId;
            }
        }

        public string userName //שם משתמש
        {
            set
            {
                this.UserName = value;
            }
            get
            {
                return this.UserName;
            }
        }

        public string date //תאריך
        {
            set
            {
                this.Date = value;
            }
            get
            {
                return this.Date;
            }
        }

        public string time //שעה
        {
            set
            {
                this.Time = value;
            }
            get
            {
                return this.Time;
            }
        }
    }
}