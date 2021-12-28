using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Scores
    {
        //מחלקת תוצאות
        private int ScoreId; //הID של התוצאות
        private int Score; //תוצאה
        private int Record; //שיא
        private string UserName; //שם משתמש

        public Scores()
        {

        }

        public int scoreId //הID של התוצאות
        {
            set
            {
                this.ScoreId = value;
            }
            get
            {
                return this.ScoreId;
            }
        }

        public int score //תוצאה
        {
            set
            {
                this.Score = value;
            }
            get
            {
                return this.Score;
            }
        }

        public int record //שיא
        {
            set
            {
                this.Record = value;
            }
            get
            {
                return this.Record;
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
    }
}