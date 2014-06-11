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
using NorthwindSystem.Entities;

namespace DesktopApp
{
    public partial class ViewShippers : Form
    {
        public ViewShippers()
        {
            InitializeComponent();
        }

        private void btnLookupShipper_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboShippers.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a shipper before clicking [Lookup]");
                }
                else
                {
                    int shipperId = Convert.ToInt32(cboShippers.SelectedValue);
                    NorthwindManager mgr = new NorthwindManager();
                    Shipper data = mgr.GetShipper(shipperId);

                    // Unpack the data
                    lblShipperID.Text = data.ShipperID.ToString();
                    txtCompanyName.Text = data.CompanyName;
                    txtPhone.Text = data.Phone;
                    
                }
            }
            catch (Exception ex)
            {
                // TODO: log exception
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddShipper_Click(object sender, EventArgs e)
        {
            try
            {
                Shipper item = new Shipper()
                {
                    CompanyName = txtCompanyName.Text,
                    Phone = txtPhone.Text
                };
                var mgr = new NorthwindManager();
                item.ShipperID = mgr.AddShipper(item);
                // Give some feedback to the user...
                // - Update my ComboBox
                PopulateShippersComboBox();
                // - My ComboBox has the right shipper selected
                cboShippers.SelectedValue = item.ShipperID;
                // - Display the id of the added shipper
                lblShipperID.Text = item.ShipperID.ToString();
            }
            catch (Exception ex)
            {
                // TODO: log exception
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateShipper_Click(object sender, EventArgs e)
        {
            try
            {
                int shipperId;
                if (int.TryParse(lblShipperID.Text, out shipperId))
                {
                    var info = new Shipper()
                    {
                        ShipperID = shipperId,
                        CompanyName = txtCompanyName.Text,
                        Phone = txtPhone.Text
                    };
                    var mgr = new NorthwindManager();
                    mgr.UpdateShipper(info);
                    PopulateShippersComboBox();
                    cboShippers.SelectedValue = info.ShipperID;
                    // Maybe there should be some indication to the user that the update was successful. MessageBox? Label?
                }
                else
                {
                    MessageBox.Show("Please lookup a shipper before trying to update.");
                }
            }
            catch (Exception ex)
            {
                // TODO: log exception
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteShipper_Click(object sender, EventArgs e)
        {
            try
            {
                int temp;
                if (int.TryParse(lblShipperID.Text, out temp))
                {
                    var info = new Shipper() { ShipperID = temp };
                    var mgr = new NorthwindManager();
                    mgr.DeleteShipper(info);
                    // Feedback to user
                    PopulateShippersComboBox();
                    // clear the form textboxes
                    Clear();

                }
                else
                {
                    MessageBox.Show("Please lookup a shipper before trying to delete.");
                }
            }
            catch (Exception ex)
            {
                // TODO: log exception
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            lblShipperID.Text = "";
            txtCompanyName.Text = "";
            txtPhone.Text = "";
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Clear();
        }

        // TODO: remove this and its link
        private void cboShippers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewShippers_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox
            try
            {
                PopulateShippersComboBox();
            }
            catch (Exception ex)
            {
                // TODO: Log the exception
                MessageBox.Show("Error: " + ex.Message, "Error Loading Form", MessageBoxButtons.OK);
            }

        }

        private void PopulateShippersComboBox()
        {
            NorthwindManager manager = new NorthwindManager();
            var data = manager.ListShippers();
            // Use a "fake" data item at the top of the list for the message
            data.Insert(0, new Shipper() { ShipperID = -1, CompanyName = "[Select a Shipper]" });
            cboShippers.DataSource = data;
            cboShippers.DisplayMember = "CompanyName"; // CompanyName is a property of the Shipper class
            cboShippers.ValueMember = "ShipperID"; // ShipperID is the property that represents the Primary Key
            cboShippers.SelectedIndex = 0; // the first item in the ComboBox
        }
    }
}
