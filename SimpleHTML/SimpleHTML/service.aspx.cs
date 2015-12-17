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
            DmsConnector connector = new DmsConnector(DokmeeApplication.DokmeeWeb);
            var connection = connector.GetConnectionFromConfig<string>();
            //if conn dne then make conn
            if (connection == "")
            {
                connector.RegisterConnection<string>("http://localhost/dokmee");
                //connector.SaveConnectionToConfig<string>("http://localhost/dokmee");
            }
            try
            {
                var cabinets = connector.Login(new LogonInfo { Username = "admin", Password = "admin" });
            }
            catch
            {
                return "not found";
            }
            return connection;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}