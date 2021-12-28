using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for CreditC
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreditC : System.Web.Services.WebService
    {
        //כרטיס אשראי

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //פעולה המוסיפה כרטיס למסד הנתונים
        [WebMethod]
        public void AddCard(string cardNum, string expired, int cvv)
        {
            string sql = "INSERT INTO Cards (CardNum,Expired, Cvv) VALUES ('" + cardNum + "','" + expired + "','" + cvv + "')";
            CardsConnection.Update(sql);
        }

        //פעולה הבודקת האם הכרטיס קיים
        [WebMethod]
        public bool IsCardExists(string cardNum, string expired, int cvv)
        {
            string sql = "SELECT * FROM Cards WHERE CardNum='" + cardNum + "' AND Expired='" + expired + "' AND Cvv='" + cvv + "'";
            DataTable dt = CardsConnection.Select(sql);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //פעולה הבודקת האם המספר כרטיס קיים
        [WebMethod]
        public bool IsAddable(string cardNum)
        {
            string sql = "SELECT * FROM Cards WHERE CardNum='" + cardNum + "'";
            DataTable dt = CardsConnection.Select(sql);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        [WebMethod]
        //פעולה המחייבת את כרטיס האשראי
        public void hiuv(string cardNum, string expierd, int cvv)
        {
            CreditCard c = new CreditCard();
            c.CreditNum = cardNum;
            c.Expiared = expierd;
            c.Cvv = cvv;
            c.hiuv();
        }

        [WebMethod]
        //פעולה המבטלת חיוב של כרטיס אשראי
        public void cancel(string cardNum, string expierd, int cvv)
        {
            CreditCard c = new CreditCard();
            c.CreditNum = cardNum;
            c.Expiared = expierd;
            c.Cvv = cvv;
            c.cancel();
        }
    }
}
