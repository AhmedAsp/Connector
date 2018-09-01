using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Connector
{
    class GetData
    {
        public string info { get; set; }


        public List<GetData> GetMyData(string UserName, string Password)
        {
            List<GetData> currentlst = new  List<GetData>();
            info = new WebClient().DownloadString("http://City2Day.com/GetData.aspx?" + "UserName=" + UserName + "Password=" + Password);
            currentlst = JsonConvert.DeserializeObject<List<GetData>>(info);
            return currentlst;
        }
    }
}
