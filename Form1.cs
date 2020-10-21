using BKToolSpamVIP.Libs;
using BKToolSpamVIP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKToolSpamVIP
{
    public partial class Form1 : Form
    {

        // fields menu

        private Button currentButton;
        private Random rnd = new Random();
        private int tempIndex;
        public Form1()
        {
            InitializeComponent();
            if (!panelContainer.Controls.Contains(ucImportAccount.Instance))
            {
                panelContainer.Controls.Add(ucImportAccount.Instance);
                ucImportAccount.Instance.Dock = DockStyle.Fill;
            }
            ucImportAccount.Instance.BringToFront();
        }
        private Color SelectThemeColor()
        {
            int index = rnd.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
                index = rnd.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            return ColorTranslator.FromHtml(ThemeColor.ColorList[tempIndex]);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previusBtn in panelMenu.Controls)
            {
                if(previusBtn.GetType() == typeof(FontAwesome.Sharp.IconButton))
                {
                    previusBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previusBtn.ForeColor = Color.Gainsboro;
                    previusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            
        }

        private void btnImportAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (!panelContainer.Controls.Contains(ucImportAccount.Instance))
            {
                panelContainer.Controls.Add(ucImportAccount.Instance);
                ucImportAccount.Instance.Dock = DockStyle.Fill;
            }
            ucImportAccount.Instance.BringToFront();
            
        }

        private void btnCareAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (!panelContainer.Controls.Contains(ucCareAccount.Instance))
            {
                panelContainer.Controls.Add(ucCareAccount.Instance);
                ucCareAccount.Instance.Dock = DockStyle.Fill;
            }
            ucCareAccount.Instance.BringToFront();
        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnSpamPro_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }


        //Drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
       
    }
}
