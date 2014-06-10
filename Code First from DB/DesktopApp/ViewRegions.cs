using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthwindSystem.BLL;

namespace DesktopApp
{
    public partial class ViewRegions : Form
    {
        public ViewRegions()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewRegions_Load(object sender, EventArgs e)
        {
            //Populate the Combobox
            NorthwindManager manager = new NorthwindManager();
            var data = manager.GetRegions();
            cboRegions.DataSource = data;
            cboRegions.DisplayMember = "RegionDescription";
            cboRegions.ValueMember = "RegionID";
        }

        private void cboRegions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
