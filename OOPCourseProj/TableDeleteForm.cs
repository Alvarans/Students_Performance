using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OOPCourseProj
{
    /// <summary>
    /// Table delete form
    /// </summary>
    public partial class TableDeleteForm : Form
    {
        public TableDeleteForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Table Delete button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableDelButtonConfirm_Click(object sender, EventArgs e)
        {
            string tableName = TableDelTextBox.Text;
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + tableName + ".json"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\" + tableName + ".json");
                MessageBox.Show("Таблица успешно удалена");
                string Path = Directory.GetCurrentDirectory() + "/Faculties.txt";
                string[] temp = File.ReadAllLines(Path, Encoding.Default);
                string[] vs = new string[temp.Length - 1];
                int k = 0;
                for (int i = 0; i < temp.Length; i++)
                    if (temp[i] != tableName + ".json")
                    {
                        vs[k] = temp[i];
                        k++;
                    }
                File.WriteAllLines(Path, vs);
                Close();
            }
            else
            {
                MessageBox.Show("Таблицы с таким именем не существует!");
            }
            
        }
        /// <summary>
        /// Cancel button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableDelButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
