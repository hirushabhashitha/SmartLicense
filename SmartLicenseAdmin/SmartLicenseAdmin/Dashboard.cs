using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLicenseAdmin
{
    public partial class Dashboard : Form
    {
        

        public Dashboard()
        {
            InitializeComponent();
        }

        private void dashboardComponent1_Load(object sender, EventArgs e)
        {

        }

        private void addLicenseComponent1_Load(object sender, EventArgs e)
        {

        }

        private void addschoolcomponents1_Load(object sender, EventArgs e)
        {

        }

        private void addschoolcomponents1_Load_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {
            dashboardcomponent1.Visible = false;
            addschoolcomponents1.Visible = false;
            licenseapplication1.Visible = true;
            paymentcomponent1.Visible = false;
            applicationFeeComponents1.Visible = false;

        }


        private void lblDrivingSchool_Click_(object sender, EventArgs e)
        {
            dashboardcomponent1.Visible = false;
            addschoolcomponents1.Visible = true;
            licenseapplication1.Visible = false;
            paymentcomponent1.Visible = false;
            applicationFeeComponents1.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

            dashboardcomponent1.Visible = true;
            addschoolcomponents1.Visible = false;
            licenseapplication1.Visible = false;
            paymentcomponent1.Visible = false;
            applicationFeeComponents1.Visible = false;
        }

        private void payments_Click(object sender, EventArgs e)
        {
            dashboardcomponent1.Visible = false;
            addschoolcomponents1.Visible = false;
            licenseapplication1.Visible = false;
            paymentcomponent1.Visible = true;
            applicationFeeComponents1.Visible = false;

        }

        private void dashboardcomponent1_Load_1(object sender, EventArgs e)
        {

        }

        private void paymentcomponent1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dashboardcomponent1_Load_2(object sender, EventArgs e)
        {

        }

        private void licenseapplication1_Load(object sender, EventArgs e)
        {

        }

        private void addschoolcomponents1_Load_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            dashboardcomponent1.Visible = false;
            addschoolcomponents1.Visible = false;
            licenseapplication1.Visible = false;
            paymentcomponent1.Visible = false;
            applicationFeeComponents1.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
