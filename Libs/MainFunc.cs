using Leaf.xNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKToolSpamVIP.Libs
{
    class MainFunc
    {

        public string RunCMD(string cmd)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + cmd;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string end = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (string.IsNullOrEmpty(end))
                    return "";
                return end;
            }
            catch (Exception Ex)
            {

                return Ex.Message.ToString();
            }


        }
        public JObject GetPossitionChrome(int possition)
        {
            JObject jOptions = new JObject();
            double ScreenX = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ScreenY = System.Windows.SystemParameters.PrimaryScreenHeight;
            int width = 380;
            int ScreenRow = (int)(System.Windows.SystemParameters.PrimaryScreenWidth / width);
            int x = possition * width;
            int y = 0;
            if (possition >= ScreenRow)
            {
                x = (possition - ScreenRow) * width;
                y = 500;
            }
            jOptions["possition"] = true;
            jOptions["x"] = x;
            jOptions["y"] = y;
            return jOptions;
        }
        public ProfileInfo loadInfo(string path)
        {
            Debug.WriteLine(path);
            ProfileInfo profileInf = new ProfileInfo();
            try
            {
                JObject o = JObject.Parse(System.IO.File.ReadAllText(path + "\\info.txt"));
                profileInf.name = (string)o["name"];
                profileInf.uid = (string)o["uid"];
                profileInf.password = (string)o["password"];
                profileInf.group = (int)o["group"];
                profileInf.cookie = (string)o["cookie"];
                profileInf.status = (int)o["status"];
                profileInf.tFaCode = (string)o["tFaCode"];
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            return profileInf;
        }

    }
}
