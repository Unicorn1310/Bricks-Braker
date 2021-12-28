using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using WSData;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //פעולה המוסיפה משתמש למסד הנתונים
        [WebMethod]
        public void AddUser(string userName, string password, string firstName, string lastName)
        {
            string sql = "INSERT INTO users (UserName,Password, FirstName, LastName) VALUES ('" + userName + "','" + password + "','" + firstName + "','" + lastName + "')";
            Connection.Update(sql);
        }

        //פעולה הבודקת האם המשתמש קיים
        [WebMethod]
        public bool IsUserExists(string userName, string password)
        {
            string sql = "SELECT * FROM users WHERE UserName='" + userName + "' AND Password='" + password + "'";
            DataTable dt = Connection.Select(sql);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //פעולה המוסיפה נתונים לטבלת היסטוריית ההתחברות
        [WebMethod]
        public void LogInHit(string UserName,string Date,string Time)
        {
            string sql = "INSERT INTO LogInHis (UserName,Date,Time) Values ('" + UserName + "','" + Date + "','" + Time + "')";
            Connection.Update(sql);
        }

        //טבלה המחזירה משתמש
        [WebMethod]
        public Users GetUser(string userName, string password)
        {
            string sql = "SELECT * FROM users WHERE UserName='" + userName + "' AND Password='" + password+"'";
            DataTable dt = Connection.Select(sql);
            //dt.TableName = "users";
            Users u = new Users();
            u.userName = userName;
            u.password = password;
            u.firstName = dt.Rows[0]["FirstName"].ToString();
            u.lastName = dt.Rows[0]["LastName"].ToString();
            return u;
        }

        //פעולה המעדכנת משתמש
        [WebMethod]
        public void UpdateUser(string userName, string password, string firstName, string lastName)
        {
            string sql = "UPDATE Users SET password='" + password + "', firstName='" + firstName + "', lastName='" + lastName + "' WHERE UserName='"+userName+"'";
            DataTable dt = Connection.Select(sql);
        }
        
        //פעולה המחזירה את כל המשתמשים
        [WebMethod]
        public List<Users> GetAllUsers()
        {
            List<Users> ls = new List<Users>();
            string sql = "SELECT * FROM Users";
            DataTable dt = Connection.Select(sql);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                DataRow dr = dt.Rows[i];
                Users u = new Users();
                u.userId =int.Parse(dr["UserId"].ToString());
                u.userName = dr["UserName"].ToString();
                u.password = dr["Password"].ToString();
                u.firstName = dr["FirstName"].ToString();
                u.lastName = dr["LastName"].ToString();
                ls.Add(u);
            }
            return ls;
        }

        //פעולה המוסיפה צבע לטבלת הצבעים
        [WebMethod]
        public void AddColor(string color, int logInHisId)
        {
            string sql = "INSERT INTO BallColors (BallColor, LogInHisId) VALUES ('" + color + "','" + logInHisId + "')";
            Connection.Update(sql);
        }

        //פעולה המחזירה את הID של היסטוריית ההתחברות האחרון שהתווסף
        [WebMethod]
        public int GetLastHisId(string userName)
        {
            string sql = "SELECT TOP 1 * FROM LogInHis ORDER BY UserName DESC";
            DataTable dt = Connection.Select(sql);
            string id = dt.Rows[0]["LogInHisId"].ToString();
            return int.Parse(id);
        }

        //פעולה המחזירה את כל הצבעים
        [WebMethod]
        public List<string> GetAllColors()
        {
            List<string> ls = new List<string>();
            string sql = "SELECT * FROM BallColors";
            DataTable dt = Connection.Select(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ls.Add(dr["BallColor"].ToString());
            }
            return ls;
        }

        //פעולה המוסיפה תוצאה ריקה לטבלת התוצאות
        [WebMethod]
        public void InsertFirstScores(string userName)
        {
            string sql = "INSERT INTO Scores (Score,Record,UserName) Values ('" + 0 + "','" + 0 + "','" + userName + "')";
            Connection.Update(sql);
        }

        //פעולה המוסיפה תוצאה לטבלת התוצאות
        [WebMethod]
        public void InsertScore(int score, int record, string userName)
        {
            string sql = "INSERT INTO Scores (Score,Record,UserName) Values ('" + score + "','" + record + "','" + userName + "')";
            Connection.Update(sql);
        }

        //פעולה המעדכנת את התוצאה
        [WebMethod]
        public void UpdateScore(int score, int record, string userName)
        {
            string sql = "SELECT max(ScoreId) AS max1 FROM Scores WHERE UserName='" + userName + "'";
            DataTable dt = Connection.Select(sql);
            int max = int.Parse(dt.Rows[0]["max1"].ToString());
            string sql2 = "UPDATE Scores SET Score='" + score + "', Record='" + record + "' WHERE UserName='" + userName + "' AND ScoreId='" + max + "'";
            Connection.Update(sql2);
        }

        //פעולה הסודקת אם המשתמש שיחק כבר
        [WebMethod]
        public bool IsScoreExists(string userName)
        {
            string sql = "SELECT * FROM Scores WHERE UserName='" + userName + "'";
            DataTable dt = Connection.Select(sql);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //פעולה המאחזרת את השיא מטבלת התוצאות
        [WebMethod]
        public int GetRecord(string userName)
        {
            string sql = "SELECT max(Record) FROM Scores WHERE UserName='" + userName + "'";
            int record = Connection.GetInt(sql);
            return record;
        }

        //פעולה המאחזרת את הID של התוצאות האחרון
        [WebMethod]
        public int GetLastScoreId()
        {
            string sql = "SELECT max(ScoreId) FROM Scores";
            int number = Connection.GetInt(sql);
            return number;
        }
        
        //פעולה המוסיפה פסילות לטבלת הפסילות
        [WebMethod]
        public void InsertStrikes(int strikeNum, int scoreId)
        {
            string sql = "INSERT INTO Strikes (StrikeNum,ScoreId) Values ('" + strikeNum + "','" + scoreId + "')";
            Connection.Update(sql);
        }

        //פעולה המחזירה את המשתמש עם התוצאה הכי גבוהה ואת התוצאה
        [WebMethod]
        public List<string> TopScore()
        {
            string sql = "SELECT UserName,Score FROM Scores WHERE Score=(SELECT max(Score) FROM Scores )";
            DataTable dt= Connection.Select(sql);
            List<string> ls = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ls.Add(dr["Score"].ToString());
                ls.Add(dr["UserName"].ToString());
            }
            return ls;
        }

        //פעולה המחזירה את המשתמש ששיחק הכי הרבה משחקים ואת מספר המשחקים שהוא שיחק
        [WebMethod]
        public List<string> TopGames()
        {
            string sql = "select TOP 1 username, count(*) Games from Scores group by username order by Games desc";
            DataTable dt = Connection.Select(sql);
            List<string> ls = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ls.Add(dr["UserName"].ToString());
                ls.Add(dr["Games"].ToString());
            }
            return ls;
        }

        //פעולה המחזירה את השחקן שנפסל הכי פחות פעמים ואת מספר הפסילות שלו
        [WebMethod]
        public List<string> LeastStrikes()
        {
            string sql = "SELECT UserName, sum1 FROM (SELECT SUM(StrikeNum) as sum1 ,UserName FROM (SELECT StrikeNum,UserName FROM Scores JOIN Strikes ON Scores.ScoreId=Strikes.ScoreId) as a GROUP BY UserName) as b WHERE  sum1=(SELECT min(sum1) FROM (SELECT SUM(StrikeNum) as sum1 ,UserName FROM (SELECT StrikeNum,UserName FROM Scores JOIN Strikes ON Scores.ScoreId=Strikes.ScoreId) as a GROUP BY UserName) as c)";
            DataTable dt = Connection.Select(sql);
            List<string> ls = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ls.Add(dr["UserName"].ToString());
                ls.Add(dr["sum1"].ToString());
            }
            return ls;
        }

        //פעולה המחזירה את כל התוצאות והשיאים
        [WebMethod]
        public List<Scores> GetScores(string userName)
        {
            string sql = "SELECT Score, Record From Scores WHERE UserName='" + userName + "'";
            DataTable dt = Connection.Select(sql);
            List<Scores> ls = new List<Scores>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Scores s = new Scores();
                DataRow dr = dt.Rows[i];
                s.score = int.Parse(dr["Score"].ToString());
                s.record= int.Parse(dr["Record"].ToString());
                ls.Add(s);
            }
            return ls;
        }

        //פעולה המחזירה את התאריך והשעה של כל ההתחברויות
        [WebMethod]
        public List<LogInHis> GetLogInHis(string userName)
        {
            string sql = "SELECT Date, Time From LogInHis WHERE UserName='" + userName + "'";
            DataTable dt = Connection.Select(sql);
            List<LogInHis> ls = new List<LogInHis>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LogInHis l = new LogInHis();
                DataRow dr = dt.Rows[i];
                l.date = dr["Date"].ToString();
                l.time = dr["Time"].ToString();
                ls.Add(l);
            }
            return ls;
        }

        //פעולה המחזירה את מספר המשחק והפסילה בכל המשחקים
        [WebMethod]
        public List<Strikes> GetStrikes(string userName)
        {
            string sql = "SELECT userName, StrikeNum,ScoreId From(SELECT StrikeNum,UserName, Scores.ScoreId FROM Scores JOIN Strikes ON Scores.ScoreId=Strikes.ScoreId) as a WHERE UserName='" + userName + "'";
            DataTable dt = Connection.Select(sql);
            List<Strikes> ls = new List<Strikes>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Strikes s = new Strikes();
                DataRow dr = dt.Rows[i];
                s.scoreId = int.Parse(dr["ScoreId"].ToString());
                s.strikeNum = int.Parse(dr["StrikeNum"].ToString());
                ls.Add(s);
            }
            return ls;
        }

        //public DataTable GetColor()
        //{
        //    string sql = "SELECT BallColor FROM BallColors";
        //    DataTable dt = Connection.Select(sql);
        //    dt.TableName = "BallColors";
        //    return dt;
        //}

        //[WebMethod]
        //public string LogIn(Users x)
        //{

        //    Connection cn = new Connection();
        //    string sql = "Select * FROM Users Where [UserName]='" + x.userName + "' and [Password]='" + x.password;
        //    DataSet dataset = cn.getDataSet(sql);
        //    DataTable dt = dataset.Tables[0];
        //    if (dt.Rows.Count > 0)
        //        return "you are connected!";
        //    return "you need to sign up";
        //}
    }
}