using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BKToolSpamVIP.Libs;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace BKToolSpamVIP.Views
{
    public partial class ucImportAccount : UserControl
    {
        List<Thread> lstThread = new List<Thread>();
        List<string> lstProfileDelete = new List<string>();
        private static ucImportAccount _instance;
        public static ucImportAccount Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucImportAccount();
                }
                return _instance;
            }
        }
        public ucImportAccount()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                dataGridViewImport.Rows.Add(i, "1", "1", "1");
            }
            
        }

        private void btnLoadDataToGridView_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string fileName;
                fileName = openFileDialog1.FileName;
                string[] s = System.IO.File.ReadAllLines(fileName);
                if (s != null && s.Length > 0)
                {

                    //int posCk = int.Parse(txtLoginCookiePosition.Text);
                    dataGridViewImport.Rows.Clear();
                    
                    
                    foreach (var item in s)
                    {
                        string[] acc = item.Split('|');
                        if (!string.IsNullOrEmpty(item) && acc.Length > 1)
                        {
                            int rowId = dataGridViewImport.Rows.Add();
                            DataGridViewRow row = dataGridViewImport.Rows[rowId];
                            row.Cells["stt"].Value = (rowId + 1).ToString();
                            row.Cells["uid"].Value = acc[0];
                            row.Cells["password"].Value = acc[1];
                            row.Cells["tfa"].Value = "None";
                            row.Cells["message"].Value = "Chờ đăng nhập";
                            

                        }
                    }

                }

            }
        }

        private void btnStartChangeInfo_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(StartImport);
            th.IsBackground = true;
            th.Start();
        }
        private void StartImport()
        {
            
            
            
        }
        private ThreadStart LoginAndChangeInfo(DataGridViewRow row, string nowIP)
        {
            return (ThreadStart)(() => {
                string uid = row.Cells["uid"].Value.ToString();
                string password = row.Cells["password"].Value.ToString(); ;
                string passNew = txtPassNew.Text.Trim();
                string html;
                
                ProfileInfo profileInfo = new ProfileInfo();
                JObject o = new JObject();
                string profilePathStore = Application.StartupPath + "/profiles/" + profileInfo.uid;
                profileInfo.uid = uid;
                profileInfo.password = password;
                
                row.Cells["message"].Value = "Đang chờ đăng nhập !";

                Controllers.KChromeExtension kChromeExtension = new Controllers.KChromeExtension();
                ChromeOptions options = kChromeExtension.LoadOptionChrome(profilePathStore);

                ChromeDriver ch = new ChromeDriver(options);
                IJavaScriptExecutor jsRun = (IJavaScriptExecutor)ch;

                o = kChromeExtension.LoginFacebookByUserAndPassword(ch, uid, password);
                if (!o.ContainsKey("success"))
                {
                    row.Cells["message"].Value = "Sai mật khẩu hoặc checkpoint rồi";
                    ch.Close();
                    ch.Quit();
                    return;
                }
                else
                {
                    profileInfo.cookie = o["cookie"].ToString();
                    profileInfo.status = 1;
                    profileInfo.name = o["name"].ToString();

                    System.IO.File.WriteAllText($"{Application.StartupPath}\\profiles\\{profileInfo.uid}\\info.txt", JsonConvert.SerializeObject(profileInfo));


                    if (cbChangePass.Checked)
                    {
                        if ((bool)o["newskin"])
                        {

                            NewSkinChangePass(ch, profileInfo, kChromeExtension);
                            Debug.WriteLine(o["cquick_token"].ToString());
                        }

                        profileInfo.password_old = password;
                        profileInfo.password = txtPassNew.Text.Trim();
                    }
                }
                Debug.WriteLine(profileInfo.name);


            });
        }
        private void NewSkinChangePass(ChromeDriver ch, ProfileInfo profileInfo, Controllers.KChromeExtension kChromeExtension)
        {
            string passNew = txtPassNew.Text.Trim();
            ch.Navigate().GoToUrl("https://www.facebook.com/settings?tab=security");
            string cquick_token = Regex.Match(ch.PageSource, @"compat_iframe_token"":""(.*?)""").Groups[1].Value;


            ch.Navigate().GoToUrl("https://www.facebook.com/settings?tab=security&section=password&view&cquick=jsc_c_e&cquick_token=" + cquick_token + "&ctarget=https%3A%2F%2Fwww.facebook.com");
            //ch.FindElementByName("password_old").SendKeys(profileInfo.password);
            kChromeExtension.waitForPageElementIsVisible(ch, By.Name("password_old")).SendKeys(profileInfo.password);
            System.Threading.Thread.Sleep(100);
            ch.FindElementByName("password_new").SendKeys(passNew);
            System.Threading.Thread.Sleep(100);
            ch.FindElementByName("password_confirm").SendKeys(passNew);
            System.Threading.Thread.Sleep(100);
            ch.FindElementByXPath("//input[@type='submit']").Click();
        }

    }
}
