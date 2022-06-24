using System;
using System.Windows.Forms;

namespace OOPCourseProj
{
    /// <summary>
    /// Welcome message form
    /// </summary>
    public partial class Welcome_form : Form
    {
        public Welcome_form()
        {
            InitializeComponent();
        }

        public Welcome_form(MainForm f)
        {
            InitializeComponent();
        }
        /// <summary>
        /// Show main form button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void welcomeButton(object sender, EventArgs e)
        {
            MainForm newForm = new MainForm();
            newForm.Show();
            Hide();
        }
    }
}
