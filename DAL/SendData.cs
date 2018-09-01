using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Connector
{
    class SendData
    {
         public void SendMyData(string UserName, string Password , string data)
        {
             new WebClient().DownloadString("http://City2Day.com/SendData.aspx?" + "UserName=" + UserName + "&Password=" + Password + "&data=" + data);
        }
    }
}
