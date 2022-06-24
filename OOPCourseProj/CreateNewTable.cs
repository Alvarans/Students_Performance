using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace OOPCourseProj
{
    /// <summary>
    /// New Table creation form
    /// </summary>
    public partial class CreateNewTable : Form
    {
        public CreateNewTable()
        {
            InitializeComponent();
            NewTable.Hide();
        }
        /// <summary>
        /// Create new table button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void CreateNewTableButton_Click(object sender, EventArgs e)
        {
            string tableName = NewTableFacultTextBox.Text;
            if (tableName == "")
            {
                MessageBox.Show("Введите название факультета");
                return;
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + tableName + ".json"))
            {
                MessageBox.Show("Таблица такого факультета уже существует");
                return;
            }
            List<Student> students = new List<Student>();
            int count = (int)newTableNumeric.Value;
            if (count == 0)
            {
                MessageBox.Show("Введите число студентов");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                string newfirstname = NewTable[0,i].Value.ToString();
                string newlastname = NewTable[1,i].Value.ToString();
                int newage = Convert.ToInt32(NewTable[2, i].Value);
                string newgender = NewTable[3, i].Value.ToString();
                string newgroup = NewTable[4, i].Value.ToString();
                int newfirstsem = Convert.ToInt32(NewTable[5, i].Value);
                int newsecondsem = Convert.ToInt32(NewTable[6, i].Value);
                int newthirdsem = Convert.ToInt32(NewTable[7, i].Value);
                int newforthsem = Convert.ToInt32(NewTable[8, i].Value);
                int newfirthsem = Convert.ToInt32(NewTable[9, i].Value);
                int newsixthsem = Convert.ToInt32(NewTable[10, i].Value);
                int newseventhsem = Convert.ToInt32(NewTable[11, i].Value);
                int neweightsem = Convert.ToInt32(NewTable[12, i].Value);
                Student newstudent = new(newfirstname, newlastname, newage, newgender, newgroup, newfirstsem, newsecondsem, newthirdsem, newforthsem, newfirthsem, newsixthsem, newseventhsem, neweightsem);
                students.Add(newstudent);
            }
                using (FileStream fs = new FileStream(tableName + ".json", FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions
                {
                    AllowTrailingCommas = true
                };
                    await JsonSerializer.SerializeAsync<List<Student>>(fs, students);
            }
            MessageBox.Show("Таблица факультета " + tableName + " создана");
            string Path = Directory.GetCurrentDirectory() + "/Faculties.txt";
            FileInfo treeJsonFile = new FileInfo(Path);

            if (!treeJsonFile.Exists)
                File.Create(Path).Close();
            string str = tableName+".json";
            StreamWriter writer = new StreamWriter(Path, true);
            writer.WriteLine(str);
            writer.Flush();
            writer.Close();
            Close();
        }
        /// <summary>
        /// Select number of students button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewTableStButton_Click(object sender, EventArgs e)
        {
            NewTable.Rows.Clear();
            int count = (int)newTableNumeric.Value;
            for (int i = 0; i < count-1; i++)
                NewTable.Rows.Add();
            NewTable.Show();
        }
    }
}
