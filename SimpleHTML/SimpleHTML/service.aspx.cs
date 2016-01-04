using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dokmee.Dms.Connector;
using Dokmee.Dms.Connector.Extension;
using Dokmee.Dms.Connector.Data;
using Dokmee.Dms.WebAccess.Data;
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
            string cabs = "{ \"cabinet\" : {";
            

            var cabinets = connector.Login(new LogonInfo { Username = "chrischan86@gmail.com", Password = "pqlskxin" });
            
            foreach (DokmeeCabinet c in cabinets.DokmeeCabinets)
            {
                cabs += " \"Name\" : \"" + c.CabinetName + "\", ";
                cabs += " \"ID\" : \"" + c.CabinetID + "\", ";
                cabs += "\"Folder Count\" : " + c.FolderCount + ", ";
                cabs += "\"File Count\" : " + c.FileCount + ", ";
                cabs += "\"Files\" : [";
                connector.RegisterCabinet(c.CabinetID);

                var ts = new System.Threading.ParameterizedThreadStart(o => {

                    var nodes = connector.GetFilesystem(SubjectTypes.DocumentOrFolder);
                    int count = 0;
                    foreach (DmsNode n in nodes)
                    {
                        if (count > 0)
                            cabs += ", ";
                        count++;
                        cabs += GetFilesFromNode(n);
                        //cabs += "{\"Name\" : \"" + n.Name + "\", \"Date Created\" : \"" + n.Created + "\", \"Date Modified\" : \"" + n.Modified + "\", \"Size\" : \"" + n.FileSize + "\"}";
                    }
                });
                var t = new System.Threading.Thread(ts);
                t.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                t.Start();
                t.Join();
                cabs +="]}}";
            }
            return cabs;
        }

        private static string GetFilesFromNode(DmsNode n)
        {
            string filesInNode = "";
            if (n.IsFolder)
            {
                foreach (DmsNode s in n.SubDmsNodes)
                {
                    filesInNode += GetFilesFromNode(s);
                }
            }
            else
            {
                filesInNode = "{\"Name\" : \"" + n.Name + "\", \"Date Created\" : \"" + n.Created + "\", \"Date Modified\" : \"" + n.Modified + "\", \"Size\" : \"" + n.FileSize + "\"}";
            }
            return filesInNode;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}