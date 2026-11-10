using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System
{
    public partial class ShowUserDetails : Form
    {
        int _PersonID;
       
        public ShowUserDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void ShowUserDetails_Load(object sender, EventArgs e)
        {
            pepoelInfoControl1.ShowCloseButton = false;
            pepoelInfoControl1.LoadPerson(_PersonID);

            labelResultUserID.Text = clsGlobal.CurrentUser.UserID.ToString();
            labelResultUserName.Text = clsGlobal.CurrentUser.UserName;
            if (clsGlobal.CurrentUser.IsActive == true)
            {
                labelResultStatus.Text = "Active";
            }
            else
            {
                labelResultStatus.Text = "Deactive";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
