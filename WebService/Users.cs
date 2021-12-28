using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Users
    {
        //מחלקת משתמשים
        private int UserId; //הID של המשתמש
        private string UserName; //שם משתמש
        private string Password; //סיסמא
        private string FirstName; //שם פרטי
        private string LastName; //שם משפחה

        public Users()
        {

        }

        public int userId //הID של המשתמש
        {
            set
            {
                this.UserId = value;
            }
            get
            {
                return this.UserId;
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

        public string password //סיסמא
        {
            set
            {
                this.Password = value;
            }
            get
            {
                return this.Password;
            }
        }

        public string firstName //שם פרטי
        {
            set
            {
                this.FirstName = value;
            }
            get
            {
                return this.FirstName;
            }
        }

        public string lastName //שם משפחה
        {
            set
            {
                this.LastName = value;
            }
            get
            {
                return this.LastName;
            }
        }
    }
}