using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class BallColors
    {
        //מחלקת צבע כדור
        private int BallColorId; // הID של צבע הכדור
        private string BallColor; //צבע הכדור
        private int LogInHisId; //הID של היסטוריית ההתחברות

        public BallColors()
        {

        }

        public int ballColorId // הID של צבע הכדור
        {
            set
            {
                this.BallColorId = value;
            }
            get
            {
                return this.BallColorId;
            }
        }

        public string ballColor //צבע הכדור
        {
            set
            {
                this.BallColor = value;
            }
            get
            {
                return this.BallColor;
            }
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
    }
}