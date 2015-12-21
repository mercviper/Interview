using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dokmee.Dms.Connector;
using Dokmee.Dms.Connector.Extension;
using Dokmee.Dms.Connector.Data;
using System.Web.Services;
using System.Web.Http;
using System.Net;

namespace SimpleHTML
{
    public partial class service : System.Web.UI.Page
    {
        [WebMethod]
        public static string GetFileSystem()
        {
            DmsConnector connector = new DmsConnector(DokmeeApplication.DokmeeCloud);
            string cabs = "";
            //var connection = connector.GetConnectionFromConfig<string>();
            //if conn dne then make conn
            //if (connection == "")
            //{
            //    connector.RegisterConnection<string>("http://localhost/");
            //    //connector.SaveConnectionToConfig("http://localhost/");
            //}
           // try
            //{
                var cabinets = connector.Login(new LogonInfo { Username = "chrischan86@gmail.com", Password = "pqlskxin" });
           // }
            //catch
            //{
             //   return "Connection Failed";
           // }
            foreach(DokmeeCabinet c in cabinets.DokmeeCabinets)
            {
                cabs += "test" + c.CabinetName + "<br>";
                cabs += "test" + c.CabinetName + "<br>";
            }
            return cabs;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}