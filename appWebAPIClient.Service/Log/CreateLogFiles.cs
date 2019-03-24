using Newtonsoft.Json;
using System;
using System.IO;

namespace appWebAPIClient.Service.Log
{
    public class CreateLogFiles
    {
        private readonly string logFormat;
        private readonly string time;
        private readonly string root;

        public CreateLogFiles()
        {
            logFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            time = sYear + sMonth + sDay;

            var path = System.AppDomain.CurrentDomain.BaseDirectory;

            root = path + "/Logs/";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        public void ErrorLog(string errMsg, dynamic obj = null)
        {
            var json = string.Empty;

            if (obj != null)
            {
                json = " ==> Json: " + JsonConvert.SerializeObject(obj);
            }

            StreamWriter sw = new StreamWriter(root + time + ".txt", true);
            sw.WriteLine("Error: " + logFormat + errMsg + json);
            sw.Flush();
            sw.Close();
        }

        public void Log(string msg, dynamic obj = null)
        {
            var json = string.Empty;

            if (obj != null)
            {
                json = " ==> Json: " + JsonConvert.SerializeObject(obj);
            }

            StreamWriter sw = new StreamWriter(root + time + ".txt", true);
            sw.WriteLine(logFormat + msg + json);
            sw.Flush();
            sw.Close();
        }
    }
}
