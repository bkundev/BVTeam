using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKToolSpamVIP.Views
{
    public partial class ucCareAccount : UserControl
    {
        private static ucCareAccount _instance;
        public static ucCareAccount Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucCareAccount();
                }
                return _instance;
            }
        }
        public ucCareAccount()
        {
            InitializeComponent();
        }
    }
}
