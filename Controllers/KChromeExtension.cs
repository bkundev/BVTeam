using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKToolSpamVIP.Controllers
{
    class KChromeExtension
    {
        List<string> lstGroup = new List<string>();
        public KChromeExtension()
        {

            try
            {
                foreach (var grx in System.IO.File.ReadAllLines(Application.StartupPath + "\\lib\\listgroup.txt"))
                {
                    lstGroup.Add(grx.Trim());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy list group spam");
            }
        }
        #region Declare Function Selenium
        public string GetCookieBrowser(ChromeDriver ch)
        {
            string ck = "";
            string c = "", xs = "";
            foreach (var item in ch.Manage().Cookies.AllCookies.ToArray())
            {
                if (item.Name == "c_user")
                {
                    c = "c_user=" + Uri.UnescapeDataString(item.Value) + ";";
                }
                else if (item.Name == "xs")
                {
                    xs = "xs=" + Uri.UnescapeDataString(item.Value) + ";";
                }
                else
                {
                    ck += item.Name + "=" + Uri.UnescapeDataString(item.Value) + ";";
                }

            }
            return c + xs + ck;
        }
        public ChromeOptions LoadOptionChrome(string pathDir)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("disable-infobars");
            options.AddArgument("--disable-bundled-ppapi-flash");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--user-data-dir=" + pathDir);
            options.AddArgument("--lang=en-US");
            //options.AddArgument("window-size=360,800");
            // options.AddArgument("--start-maximized");




            if (Program.disableImagesSelenium) options.AddExtension(Application.StartupPath + "\\lib\\ext\\block_image.crx");

            options.AddExtension(Application.StartupPath + "\\lib\\ext\\xpath.crx");

            return options;
        }
        public void GotoUrl(ChromeDriver ch, string url)
        {
            try
            {
                ch.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi tải url: {url} =>{ex.Message.ToString()} \n Reset IP & Reload Page để tải lại !");
                GotoUrl(ch, url);
            }
        }
        public bool IsElementPresent(ChromeDriver ch, By by)
        {
            try
            {
                ch.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void ClickAndWaitForPageToLoad(ChromeDriver ch, IWebElement element, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(ch, TimeSpan.FromSeconds(timeout));

                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Element with locator:  was not found in current context page.");
                if (Program.showErrorMessage)
                    MessageBox.Show($"Lỗi Click =>{ex.Message.ToString()}");
            }
        }
        public IWebElement waitForPageElementIsVisible(ChromeDriver ch, By by, int maxTime = 30)
        {

            try
            {
                //return new WebDriverWait(ch, TimeSpan.FromSeconds(maxTime)).Until(c=> c.FindElement(by));
                return new WebDriverWait(ch, TimeSpan.FromSeconds(maxTime)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IWebElement GetElementAndScrollTo(IWebDriver driver, IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            try
            {
                int load = 0;
            scroll:
                if (load >= 3) return null;
                if (element.Location.Y > 200)
                {
                    string s = $"window.scrollTo({0}, {element.Location.Y - 200 })";
                    Debug.WriteLine(s);
                    js.ExecuteScript(s);
                }
                Thread.Sleep(1000);
                if (!element.Displayed)
                {
                    Debug.WriteLine("Vẫn chưa scroll đến element được scroll lại nè ");
                    Thread.Sleep(1000);
                    load++;
                    goto scroll;
                }
                else
                {
                    return element;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        public JObject LoginFacebookByUserAndPassword(ChromeDriver ch, string uid, string password)
        {
            IJavaScriptExecutor jsRun = (IJavaScriptExecutor)ch;
            JObject o = new JObject();
            string currentUrl = "";
            string cquick_token = "";
            int nLoad = 0;
            ch.Navigate().GoToUrl("https://www.facebook.com/");
            currentUrl = ch.Url;
            if (IsElementPresent(ch, By.Name("email"))) // Login user pass;
            {
                ch.FindElementByName("email").SendKeys(uid);
                ch.FindElementByName("pass").SendKeys(password);
                //ch.FindElementByXPath("//button[@name='login']").Click();
                ClickAndWaitForPageToLoad(ch, ch.FindElementByName("login"));
                while (currentUrl == ch.Url)
                {
                    Thread.Sleep(1000);
                    nLoad++;
                    if (nLoad >= 10) break;
                }


            }
            else
            {
                /// load profile đã có nick login rồi
                Debug.WriteLine($"{uid} => login sẵn rồi");
            }

            try
            {
                bool newSkin = false;
                string fb_dtsg = Regex.Match(ch.PageSource, @"fb_dtsg"" value=""(.*?)""").Groups[1].Value;
                Debug.WriteLine(fb_dtsg);
                if (string.IsNullOrEmpty(fb_dtsg))
                {
                    newSkin = true;
                    fb_dtsg = Regex.Match(ch.PageSource, @"name"":""fb_dtsg"",""value"":""(.*?)""").Groups[1].Value;
                }
                string name = Regex.Match(ch.PageSource, @"""NAME"":""(.*?)""").Groups[1].Value;

                if (ch.Url.Contains("login") || ch.Url.Contains("confirmemail") || ch.Url.Contains("checkpoint") || string.IsNullOrEmpty(fb_dtsg))
                {
                    Thread.Sleep(2000);
                    Debug.WriteLine("login thất bại rồi");
                }
                else
                {
                    Debug.WriteLine("login success " + uid);

                    string locate = fb_dtsg = Regex.Match(ch.PageSource, @"locale"":""(.*?)""").Groups[1].Value;
                    if (locate != "en_US") // đổi về giao diện tiếng anh
                    {
                        Debug.WriteLine("Cần đổi ngôn ngữ");

                        ch.Navigate().GoToUrl("https://www.facebook.com/settings?tab=language&section=account&view");

                        cquick_token = Regex.Match(ch.PageSource, @"compat_iframe_token"":""(.*?)""").Groups[1].Value;

                        ch.Navigate().GoToUrl("https://www.facebook.com/settings?tab=language&section=account&view&cquick=jsc_c_e&cquick_token=" + cquick_token + "&ctarget=https%3A%2F%2Fwww.facebook.com");
                        // select the drop down list
                        var education = waitForPageElementIsVisible(ch, By.Name("new_language"));
                        //create select element object 
                        var selectElement = new SelectElement(education);

                        //select by value
                        selectElement.SelectByValue("en_US");
                        // select by text
                        ch.FindElementByXPath("//input[@type='submit']").Click();
                        Thread.Sleep(3000);
                    }

                    if (newSkin)  // nếu ra giao diện mới thì cho nó về giao diện cũ
                    {
                        Debug.WriteLine("Cần đổi về giao diện cũ");
                    }

                    o["success"] = true;
                    o["newskin"] = newSkin;
                    o["fb_dtsg"] = fb_dtsg;
                    o["name"] = name;
                    o["cookie"] = GetCookieBrowser(ch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                if (Program.showErrorMessage)
                    MessageBox.Show(ex.Message.ToString());
                o["errorSocket"] = true;
            }


            return o;

        }
    }
}
