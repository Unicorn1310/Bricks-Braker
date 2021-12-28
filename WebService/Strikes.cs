using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Strikes
    {
        //מחלקת פסילות
        private int StrikeId; //הID של הפסילות
        private int StrikeNum; //מספר הפסילה
        private int ScoreId; //הID של התוצאות

        public Strikes()
        {

        }

        public int strikeId //הID של הפסילות
        {
            set
            {
                this.StrikeId = value;
            }
            get
            {
                return this.StrikeId;
            }
        }

        public int strikeNum //מספר הפסילה
        {
            set
            {
                this.StrikeNum = value;
            }
            get
            {
                return this.StrikeNum;
            }
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
    }
}