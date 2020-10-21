using Leaf.xNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKToolSpamVIP.Libs
{
    
    class KResetIP
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        const int WM_KEYDOWN = 0x100;
        public string resetIPHotspot()
        {
            IntPtr zero = IntPtr.Zero;
            for (int i = 0; (i < 60) && (zero == IntPtr.Zero); i++)
            {
                Thread.Sleep(500);
                zero = FindWindow(null, "Hotspot Shield");
            }
            if (zero != IntPtr.Zero)
            {
                
            reConnectHotspot:
                SetForegroundWindow(zero);
                SendKeys.SendWait("^+c");
                Thread.Sleep(3000);
                SendKeys.SendWait("^+c");
                SendKeys.Flush();
            reGetIP:
                JObject o = GetIP();
                int errIpVN = 0;
                if (!o.ContainsKey("country") || (string)o["country"] == "VN")
                {
                    errIpVN++;
                    if (errIpVN >= 3)
                    {
                        goto reConnectHotspot;
                    }
                    else
                    {
                        Thread.Sleep(3000);
                        goto reGetIP;
                    }
                }
                else
                {
                    
                    return (string)o["ip"];
                }
                
            }
        }
        public JObject GetIP()
        {
            JObject res = new JObject();
            using (var request = new HttpRequest())
            {
                try
                {
                    string html = request.Get("http://45.32.112.67/ip").ToString();
                    
                    res = JObject.Parse(html);
                    Debug.WriteLine(res["ip"].ToString());
                    return res;
                }
                catch (Exception ex)
                {
                    res["ip"] = "";
                    res["country"] = "";
                    return res;
                }


            }
        }

    }
}
