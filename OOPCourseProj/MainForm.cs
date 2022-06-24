using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;

namespace OOPCourseProj
{
    /// <summary>
    /// Main functional form
    /// </summary>
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            Program.f1 = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// report creation event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button1_Click(object sender, EventArgs e)
        {
            
            Stream myStream;
            string gr = reportTextBox.Text;
            if (gr == "")
            {
                MessageBox.Show("Введите наименование группы");
                return;
            }
            string Path = Directory.GetCurrentDirectory() + "/Faculties.txt";
            string[] temp = File.ReadAllLines(Path, Encoding.Default);
            List<Student>[] students = new List<Student>[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + temp[i]))
                {
                    using (FileStream fs = new FileStream(temp[i], FileMode.OpenOrCreate))
                    {
                        students[i] = await JsonSerializer.DeserializeAsync<List<Student>>(fs);
                    }
                }
            }
            List<Student> neededGroup = new();
            bool flag = false;
            for (int i = 0; i < temp.Length; i++)
            {
                neededGroup = students[i].Where(students => students.group == gr).ToList();
                if (neededGroup.Count != 0)
                    flag = true;
            }
            if (!flag)
            {
                MessageBox.Show("Такой группы нет. Проверьте введённые данные");
                return;
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text report (*.doc)|*.doc|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = ".doc";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter writer = new StreamWriter(myStream);
                    
                    
                    int count = 0;
                    string myReport = $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tОтчёт по успеваемости\n\t\t\t\t\tГруппы {gr}\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"
                        + $"\tОтчёт отражает в себе успехи студентов группы {gr} в сдаче экзаменов на протяжении всего срока обучения. Список студентов:\n";
                    for (int i = 0; i < temp.Length; i++)
                    {
                        neededGroup = students[i].Where(students => students.group == gr).ToList();
                        for (int j = 0; j < neededGroup.Count; j++)
                        {
                            count++;
                            myReport += $"\n\t {neededGroup[j].firstName} {neededGroup[j].lastName}:"
                                + $"\n\t\t 1 курс: {(neededGroup[j].firstSem + neededGroup[j].secondSem) / 2}"
                                + $"\n\t\t 2 курс: {(neededGroup[j].thirdSem + neededGroup[j].fourthSem) / 2}"
                                + $"\n\t\t 3 курс: {(neededGroup[j].fifthSem + neededGroup[j].sixthSem) / 2}"
                                + $"\n\t\t 4 курс: {(neededGroup[j].sevenSem + neededGroup[j].eighthSem) / 2}"
                                + $"\n\t\t Средняя оценка за срок обучения: {Math.Round((((neededGroup[j].firstSem + neededGroup[j].secondSem) / 2) + ((neededGroup[j].thirdSem + neededGroup[j].fourthSem) / 2)+ ((neededGroup[j].fifthSem + neededGroup[j].sixthSem) / 2)+ ((neededGroup[j].sevenSem + neededGroup[j].eighthSem) / 2)) / 4, 2)}";
                        }
                        
                    }
                    myReport += $"\n\n\n\tВсего в группе {count} студента.";
                    writer.Write(myReport);
                    writer.Flush();
                    myStream.Close();
                }
            }
        }

        /// <summary>
        /// Create New Table button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CreateNewTable newForm = new();
            newForm.Show();
        }
        /// <summary>
        /// Session analys button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void sessionButton_Click(object sender, EventArgs e)
        {
            string Path = Directory.GetCurrentDirectory() + "/Faculties.txt";
            string[] temp = File.ReadAllLines(Path, Encoding.Default);
            List<Student>[] students = new List<Student>[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + temp[i]))
                {
                    using (FileStream fs = new FileStream(temp[i], FileMode.OpenOrCreate))
                    {
                        students[i] = await JsonSerializer.DeserializeAsync<List<Student>>(fs);
                    }
                }
            }
            int selected = comboBox1.SelectedIndex;
            //case 0 - analys by semesters. case 1 - analys by faculties
            switch (selected)
            {
                case 0:
                    sessionAnalysTable.RowHeadersWidth = 150;
                    sessionAnalysTable.Rows.Clear();
                    sessionAnalysTable.Columns.Clear();
                    sessionAnalysTable.Columns.Add("SAColumn1", "Худшая оценка");
                    sessionAnalysTable.Columns.Add("SAColumn2", "Лучшая оценка");
                    sessionAnalysTable.Columns.Add("SAColumn3", "Средняя оценка");
                    sessionAnalysTable.Columns.Add("SAColumn4", "Общее число студентов");
                    sessionAnalysTable.Columns.Add("SAColumn5", "Аттестованных");
                    sessionAnalysTable.Columns.Add("SAColumn6", "Неаттестованных");
                    for (int i = 0; i < 7; i++)
                        sessionAnalysTable.Rows.Add();
                    sessionAnalysTable.Rows[0].HeaderCell.Value = "1 семестр";
                    sessionAnalysTable.Rows[1].HeaderCell.Value = "2 семестр";
                    sessionAnalysTable.Rows[2].HeaderCell.Value = "3 семестр";
                    sessionAnalysTable.Rows[3].HeaderCell.Value = "4 семестр";
                    sessionAnalysTable.Rows[4].HeaderCell.Value = "5 семестр";
                    sessionAnalysTable.Rows[5].HeaderCell.Value = "6 семестр";
                    sessionAnalysTable.Rows[6].HeaderCell.Value = "7 семестр";
                    sessionAnalysTable.Rows[7].HeaderCell.Value = "8 семестр";
                    int[] min = new int[8];
                    min[0] = Convert.ToInt32(students[0][0].firstSem);
                    min[1] = Convert.ToInt32(students[0][0].secondSem);
                    min[2] = Convert.ToInt32(students[0][0].thirdSem);
                    min[3] = Convert.ToInt32(students[0][0].fourthSem);
                    min[4] = Convert.ToInt32(students[0][0].fifthSem);
                    min[5] = Convert.ToInt32(students[0][0].sixthSem);
                    min[6] = Convert.ToInt32(students[0][0].sevenSem);
                    min[7] = Convert.ToInt32(students[0][0].eighthSem);
                    int[] max = new int[8];
                    max[0] = Convert.ToInt32(students[0][0].firstSem);
                    max[1] = Convert.ToInt32(students[0][0].secondSem);
                    max[2] = Convert.ToInt32(students[0][0].thirdSem);
                    max[3] = Convert.ToInt32(students[0][0].fourthSem);
                    max[4] = Convert.ToInt32(students[0][0].fifthSem);
                    max[5] = Convert.ToInt32(students[0][0].sixthSem);
                    max[6] = Convert.ToInt32(students[0][0].sevenSem);
                    max[7] = Convert.ToInt32(students[0][0].eighthSem);
                    double[] srar = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] studentCount = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] successCount = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] failedCount = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int i = 0; i < students.Count(); i++)
                    {
                        for (int j = 0; j < students[i].Count(); j++)
                        {
                            int conv1 = Convert.ToInt32(students[i][j].firstSem);
                            srar[0] += conv1;
                            studentCount[0]++;
                            if (min[0] > conv1)
                                min[0] = conv1;
                            if (max[0] < conv1)
                                max[0] = conv1;
                            if(students[i][j].firstSem > 2)
                            {
                                successCount[0]++;
                            } else
                                failedCount[0]++;

                            int conv2 = Convert.ToInt32(students[i][j].secondSem);
                            srar[1] += conv2;
                            studentCount[1]++;
                            if (min[1] > conv2)
                                min[1] = conv2;
                            if (max[1] < conv2)
                                max[1] = conv2;
                            if (students[i][j].secondSem > 2)
                            {
                                successCount[1]++;
                            }
                            else
                                failedCount[1]++;

                            int conv3 = Convert.ToInt32(students[i][j].thirdSem);
                            srar[2] += conv3;
                            studentCount[2]++;
                            if (min[2] > conv3)
                                min[2] = conv3;
                            if (max[2] < conv3)
                                max[2] = conv3;
                            if (students[i][j].thirdSem > 2)
                            {
                                successCount[2]++;
                            }
                            else
                                failedCount[2]++;

                            int conv4 = Convert.ToInt32(students[i][j].fourthSem);
                            srar[3] += conv4;
                            studentCount[3]++;
                            if (min[3] > conv4)
                                min[3] = conv4;
                            if (max[3] < conv4)
                                max[3] = conv4;
                            if (students[i][j].fourthSem > 2)
                            {
                                successCount[3]++;
                            }
                            else
                                failedCount[3]++;

                            int conv5 = Convert.ToInt32(students[i][j].fifthSem);
                            srar[4] += conv5;
                            studentCount[4]++;
                            if (min[4] > conv5)
                                min[4] = conv5;
                            if (max[4] < conv5)
                                max[4] = conv5;
                            if (students[i][j].fifthSem > 2)
                            {
                                successCount[4]++;
                            }
                            else
                                failedCount[4]++;

                            int conv6 = Convert.ToInt32(students[i][j].sixthSem);
                            srar[5] += conv6;
                            studentCount[5]++;
                            if (min[5] > conv6)
                                min[5] = conv6;
                            if (max[5] < conv6)
                                max[5] = conv6;
                            if (students[i][j].sixthSem > 2)
                            {
                                successCount[5]++;
                            }
                            else
                                failedCount[5]++;

                            int conv7 = Convert.ToInt32(students[i][j].sevenSem);
                            srar[6] += conv7;
                            studentCount[6]++;
                            if (min[6] > conv7)
                                min[6] = conv7;
                            if (max[6] < conv7)
                                max[6] = conv7;
                            if (students[i][j].sevenSem > 2)
                            {
                                successCount[6]++;
                            }
                            else
                                failedCount[6]++;

                            int conv8 = Convert.ToInt32(students[i][j].eighthSem);
                            srar[7] += conv8;
                            studentCount[7]++;
                            if (min[7] > conv8)
                                min[7] = conv8;
                            if (max[7] < conv8)
                                max[7] = conv8;
                            if (students[i][j].fifthSem > 2)
                            {
                                successCount[7]++;
                            }
                            else
                                failedCount[7]++;
                        }
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        sessionAnalysTable.Rows[i].Cells[0].Value = min[i];
                        sessionAnalysTable.Rows[i].Cells[1].Value = max[i];
                        sessionAnalysTable.Rows[i].Cells[2].Value = Math.Round(srar[i]/studentCount[i], 2);
                        sessionAnalysTable.Rows[i].Cells[3].Value = studentCount[i];
                        sessionAnalysTable.Rows[i].Cells[4].Value = successCount[i];
                        sessionAnalysTable.Rows[i].Cells[5].Value = failedCount[i];
                    }
                    break;
                case 1:
                    sessionAnalysTable.RowHeadersWidth = 150;
                    sessionAnalysTable.Columns.Clear();
                    sessionAnalysTable.Columns.Add("SAColumn1", "1 курс");
                    sessionAnalysTable.Columns.Add("SAColumn2", "2 курс");
                    sessionAnalysTable.Columns.Add("SAColumn3", "3 курс");
                    sessionAnalysTable.Columns.Add("SAColumn4", "4 курс");
                    sessionAnalysTable.Columns.Add("SAColumn5", "Средняя оценка");
                    sessionAnalysTable.Columns.Add("SAColumn6", "Число студентов");
                    sessionAnalysTable.Columns.Add("SAColumn7", "Число аттестованных");
                    sessionAnalysTable.Columns.Add("SAColumn8", "Число неаттестованных");
                    for (int i = 0; i < temp.Length; i++)
                    {
                        sessionAnalysTable.Rows.Add();
                        sessionAnalysTable.Rows[i].HeaderCell.Value = temp[i].Remove(temp[i].Length-5, 5);
                    }
                    double[] srarfirst = new double [temp.Length],
                           srarsecond = new double [temp.Length], 
                           srarthird = new double [temp.Length], 
                           srarfourth = new double[temp.Length],
                           srar2 = new double[temp.Length];
                    int[] studCount = new int[temp.Length],
                        succCount = new int[temp.Length],
                        failCount = new int[temp.Length];
                    for (int i = 0; i < students.Count(); i++)
                    {
                        for (int j = 0; j < students[i].Count(); j++)
                        {
                            srarfirst[i] += Math.Abs((students[i][j].firstSem + students[i][j].secondSem)/2);
                            srarsecond[i] += Math.Abs((students[i][j].fifthSem + students[i][j].sixthSem)/2);
                            srarthird[i] += Math.Abs((students[i][j].fifthSem + students[i][j].sixthSem) / 2);
                            srarfourth[i] += Math.Abs((students[i][j].sevenSem + students[i][j].eighthSem)/2);
                            srar2[i] += (srarfirst[i] + srarsecond[i] + srarthird[i] + srarfourth[i]) / 4;
                            studCount[i]++;
                            if (srarfirst[i] > 2 && srarsecond[i] > 2 && srarthird[i] > 2 && srarfourth[i] > 2)
                                succCount[i]++;
                            else
                                failCount[i]++;
                        }
                    }
                    for (int i = 0; i < temp.Length; i++)
                    {
                        sessionAnalysTable.Rows[i].Cells[0].Value = Math.Round(srarfirst[i]/studCount[i], 2);
                        sessionAnalysTable.Rows[i].Cells[1].Value = Math.Round(srarsecond[i]/studCount[i], 2);
                        sessionAnalysTable.Rows[i].Cells[2].Value = Math.Round(srarthird[i]/studCount[i], 2);
                        sessionAnalysTable.Rows[i].Cells[3].Value = Math.Round(srarfourth[i]/studCount[i], 2);
                        sessionAnalysTable.Rows[i].Cells[4].Value = Math.Round(srar2[i]/studCount[i],2);
                        sessionAnalysTable.Rows[i].Cells[5].Value = studCount[i];
                        sessionAnalysTable.Rows[i].Cells[6].Value = succCount[i];
                        sessionAnalysTable.Rows[i].Cells[7].Value = failCount[i];
                    }
                    break;
            }
        }
        /// <summary>
        /// Show facult info button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void facultConfirmButton_Click(object sender, EventArgs e)
        {
            string str = choosedFacultyTextBox.Text;
            if (str == "")
            {
                MessageBox.Show("Введите название факультета");
                return;
            }
            if (File.Exists(Directory.GetCurrentDirectory() + "/"+ str + ".json"))
            {
                List<Student> students = new();
                FileStream fss = new FileStream(str + ".json", FileMode.OpenOrCreate);

                students = await JsonSerializer.DeserializeAsync<List<Student>>(fss);
                facultyDataGridView.Rows.Clear();
                fss.Close();
                for (int i = 0; i < students.Count(); i++)
                {
                    facultyDataGridView.Rows.Add();
                    facultyDataGridView[0, i].Value = students[i].firstName;
                    facultyDataGridView[1, i].Value = students[i].lastName;
                    facultyDataGridView[2, i].Value = students[i].age;
                    facultyDataGridView[3, i].Value = students[i].gender;
                    facultyDataGridView[4, i].Value = students[i].group;
                    facultyDataGridView[5, i].Value = students[i].firstSem;
                    facultyDataGridView[6, i].Value = students[i].secondSem;
                    facultyDataGridView[7, i].Value = students[i].thirdSem;
                    facultyDataGridView[8, i].Value = students[i].fourthSem;
                    facultyDataGridView[9, i].Value = students[i].fifthSem;
                    facultyDataGridView[10, i].Value = students[i].sixthSem;
                    facultyDataGridView[11, i].Value = students[i].sevenSem;
                    facultyDataGridView[12, i].Value = students[i].eighthSem;
                }
                
            }
            else
            {
                MessageBox.Show("Таблицы такого факультета не существует!");
            }
            
        }

        /// <summary>
        /// Faculty info editing button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void button5_Click(object sender, EventArgs e)
        {
            string str = choosedFacultyTextBox.Text;
            if (str == "")
            {
                MessageBox.Show("Введите название факультета");
                return;
            }
            List<Student> saveStudents = new();
            for( int i = 0; i < facultyDataGridView.RowCount; i++)
            {
                if (facultyDataGridView[0, i].Value.ToString() == null)
                    continue;
                string? firstName = facultyDataGridView[0, i].Value.ToString();
                if (facultyDataGridView[1, i].Value.ToString() == null)
                    continue;
                string? secondName = facultyDataGridView[1, i].Value.ToString();
                int age = Convert.ToInt32(facultyDataGridView[2, i].Value);
                string gender = facultyDataGridView[3, i].Value.ToString();
                string group = facultyDataGridView[4, i].Value.ToString();
                int firstSem = Convert.ToInt32(facultyDataGridView[5, i].Value);
                int secondSem = Convert.ToInt32(facultyDataGridView[6, i].Value);
                int thirdSem = Convert.ToInt32(facultyDataGridView[7, i].Value);
                int forthSem = Convert.ToInt32(facultyDataGridView[8, i].Value);
                int firthSem = Convert.ToInt32(facultyDataGridView[9, i].Value);
                int sixthSem = Convert.ToInt32(facultyDataGridView[10, i].Value);
                int seventhSem = Convert.ToInt32(facultyDataGridView[11, i].Value);
                int eighthSem = Convert.ToInt32(facultyDataGridView[12, i].Value);
                Student student = new Student(firstName, secondName, age, gender, group, firstSem, secondSem, thirdSem, forthSem, firthSem, sixthSem, seventhSem, eighthSem);
                saveStudents.Add(student);
            }
            using (FileStream fs = new FileStream(str + ".json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Student>>(fs, saveStudents);
            }
            MessageBox.Show("Изменения сохранены");
        }
        /// <summary>
        /// Delete Faculty button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void faciltDeleteTableButton_Click(object sender, EventArgs e)
        {
            TableDeleteForm delform = new();
            delform.Show();
        }
        /// <summary>
        /// Show information about group button click event handler 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void choosedGroupButton_Click(object sender, EventArgs e)
        {
            groupDataGridView.Rows.Clear(); 
            string gr = groupTextBox.Text;
            if (gr == "")
            {
                MessageBox.Show("Введите название группы!");
                return;
            }
            string Path = Directory.GetCurrentDirectory() + "/Faculties.txt";
            string[] temp = File.ReadAllLines(Path, Encoding.Default);
            List<Student>[] students = new List<Student> [temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + temp[i])){
                    using (FileStream fs = new FileStream(temp[i], FileMode.OpenOrCreate))
                    {
                        students[i] = await JsonSerializer.DeserializeAsync<List<Student>>(fs);
                    }
                }
            }
            List<Student> neededGroup = new();
            int count = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                neededGroup = students[i].Where(students => students.group == gr).ToList();
                for (int j = 0; j < neededGroup.Count; j++)
                {
                    groupDataGridView.Rows.Add();
                    groupDataGridView[0, count].Value = neededGroup[j].firstName;
                    groupDataGridView[1, count].Value = neededGroup[j].lastName;
                    groupDataGridView[2, count].Value = neededGroup[j].firstSem;
                    groupDataGridView[3, count].Value = neededGroup[j].secondSem;
                    groupDataGridView[4, count].Value = neededGroup[j].thirdSem;
                    groupDataGridView[5, count].Value = neededGroup[j].fourthSem;
                    groupDataGridView[6, count].Value = neededGroup[j].fifthSem;
                    groupDataGridView[7, count].Value = neededGroup[j].sixthSem;
                    groupDataGridView[8, count].Value = neededGroup[j].sevenSem;
                    groupDataGridView[9, count].Value = neededGroup[j].eighthSem;
                    var srar = (neededGroup[j].firstSem +
                               neededGroup[j].secondSem +
                               neededGroup[j].thirdSem +
                               neededGroup[j].fourthSem +
                               neededGroup[j].fifthSem +
                               neededGroup[j].sixthSem +
                               neededGroup[j].sevenSem +
                               neededGroup[j].eighthSem) / 8;
                    groupDataGridView[10, count].Value = Math.Round(srar, 2);
                    count++;
                }
                
            }
            if (count == 0)
                MessageBox.Show("Такой группы не существует");
        }
        /// <summary>
        /// Main form closed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shutdown(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
