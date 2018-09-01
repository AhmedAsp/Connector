using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;


namespace Connector
{
    class API
    {
        public string info { get; set; }
        System.Net.WebClient WebC = new System.Net.WebClient();
        public int _ProductID { get; set; }
        public string _ProductName { get; set; }
        public double _Price { get; set; }
 
        string APILink = "http://suiteinn.net/ApiReceiving.aspx?username=suiteinnhotel&password=01096812667";
        string Param = "&ProductID=_ProductID&ProductName=_ProductName&Price=_Price";
        public void SendData()
        {
            Param = Param.Replace("_ProductID", _ProductID.ToString());
            Param = Param.Replace("_ProductName", _ProductName);
            Param = Param.Replace("_Price", _Price.ToString());
            APILink += Param;
            //
            WebC.DownloadString(APILink);
            // var str = System.Text.Encoding.Default.GetString(WebC.DownloadData(APILink));


        }


 

    }
}
