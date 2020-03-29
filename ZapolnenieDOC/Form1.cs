using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DataTable = System.Data.DataTable;

namespace ZapolnenieDOC
{
    public partial class Form1 : Form
    {
        private Application application;
        private Workbook workBook;
        private Worksheet worksheet;




        public Form1()
        {
            InitializeComponent();
            using (IDbConnection connection = new SqlConnection())
            {

            }
        }
        public struct Person
        {
            public string FIO
            { get; set; }
            public DateTime DateBirdhsday
            { get; set; }

        }

        public struct NekorektData
        {
            public string FIO
            { get; set; }
            public DateTime DateBirdhsday
            { get; set; }

        }

        public struct ДанныеПоТаблицеШаблоныГруппы
        {
            public string ФИО { get; set; }
            public System.DateTime ДатаРождения { get; set; }
            public string МестоРождения { get; set; }
            public string АдресПоРегистрации { get; set; }
            public string Телефон { get; set; }
            public string Паспорт { get; set; }
            public string Email { get; set; }
            public int id { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {



            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {


                var Shablons = db.ШаблонГруппы;
                var Student = db.Студенты2;



                foreach (ШаблонГруппы tl in Shablons)
                {
                    List<Person> persons = new List<Person>();
                    

                    string tlFio = tl.ФИО;
                    string[] b = tlFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string o = b[0] + " " + b[1] + " " + b[2];

                    foreach (Студенты2 ii in Student)
                    {
                        string iiFio = ii.ФИО;
                        string[] c = iiFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string y = c[0] + " " + c[1] + " " + c[2];

                        if (o == y && tl.ДатаРождения == ii.ДатаРождения)
                        {
                            if (string.IsNullOrEmpty(tl.Паспорт) || tl.Паспорт == " ")
                            {
                                tl.Паспорт = ii.ПаспортныеДанные;

                                Person person = new Person
                                {
                                    FIO = ii.ФИО,
                                    DateBirdhsday = ii.ДатаРождения

                                };
                                persons.Add(person);

                               



                            }
                        }


                    }
                   





                    if (persons.Count > 0)
                    {
                        foreach (Person p in persons)
                        {
                            listBox1.Items.Add("ФИО " + p.FIO + " Дата рождения " + p.DateBirdhsday);
                        }

                    }
                    
                }

                foreach (ШаблонГруппы tl in Shablons)
                {
                    List<NekorektData> nekorektDatas = new List<NekorektData>();

                    if (string.IsNullOrEmpty(tl.Паспорт) || tl.Паспорт == " ")
                    {
                        NekorektData nekorektData = new NekorektData
                        {
                            FIO = tl.ФИО,
                            DateBirdhsday = tl.ДатаРождения
                        };
                        nekorektDatas.Add(nekorektData);
                    }
                    if (nekorektDatas.Count > 0)
                    {
                        foreach (NekorektData l in nekorektDatas)
                        {
                            listBox2.Items.Add("ФИО " + l.FIO + " Дата рождения " + l.DateBirdhsday);
                        }

                    }
                }

                db.SaveChanges();



            }
        }







        private void button2_Click(object sender, EventArgs e)
        {

            string yourtext = "18.02. 2003";
            string tlFio = yourtext;
            string[] b = tlFio.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string o = b[0] + "." + b[1] + "." + b[2];
            //string text = yourtext.Replace(" ", ".");
            DateTime d = Convert.ToDateTime(o);
            //DateTime.TryParseExact(yourtext, "0:MM/dd/yy H:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d);




        }

        private void button3_Click(object sender, EventArgs e)
        {
            object missing = Type.Missing;

            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {
                var Shablons = db.ШаблонГруппы;
                int t = 0;
                int i = 0;
                foreach (ШаблонГруппы pp in Shablons)
                {
                    t++;



                }

                // Открываем приложение
                application = new Application



                {
                    DisplayAlerts = false
                };


                // Файл шаблона
                const string template = "E:\\Shablone.xlsx";

                // Открываем книгу
                workBook = application.Workbooks.Open(template);

                // Получаем активную таблицу
                worksheet = workBook.ActiveSheet as Worksheet;

                // Записываем данные
                worksheet.Range["A1"].Value = "ФИО";
                worksheet.Range["B1"].Value = "Дата рождения";
                worksheet.Range["C1"].Value = "Место рождения";
                worksheet.Range["D1"].Value = "Адрес по регистрации";
                worksheet.Range["E1"].Value = "Телефон";
                worksheet.Range["F1"].Value = "Паспорт";
                worksheet.Range["G1"].Value = "Email";
                worksheet.Range["H1"].Value = "id";

                foreach (ШаблонГруппы pp in Shablons)
                {
                    //t++;

                    if (i < t)
                    {
                        i++;
                        worksheet.Cells[i + 1, 1].Value = pp.ФИО;
                        worksheet.Cells[i + 1, 2].Value = pp.ДатаРождения;
                        worksheet.Cells[i + 1, 3].Value = pp.МестоРождения;
                        worksheet.Cells[i + 1, 4].Value = pp.АдресПоРегистрации;
                        worksheet.Cells[i + 1, 5].Value = pp.Телефон;
                        worksheet.Cells[i + 1, 6].Value = pp.Паспорт;
                        worksheet.Cells[i + 1, 7].Value = pp.Email;
                        worksheet.Cells[i + 1, 8].Value = pp.id;
                    }
                }
                // Показываем приложение
                application.Visible = true;
                TopMost = true;
                object template3 = "E:\\Shablone" + ".xlsx";
                string savedFileName = textBox3.Text+"\\ШаблоныГруппВыгрузкаССервера.xlsx"; //Добавить возможность выбора куда сохранять
                workBook.SaveAs(Path.Combine(Environment.CurrentDirectory, savedFileName));

                CloseExcel();
                MessageBox.Show("Файл сохранен путь: "+savedFileName);
            }
        }
        private void CloseExcel()
        {
            if (application != null)
            {
                int excelProcessId = -1;
                GetWindowThreadProcessId(application.Hwnd, ref excelProcessId);

                Marshal.ReleaseComObject(worksheet);
                workBook.Close();
                Marshal.ReleaseComObject(workBook);
                application.Quit();
                Marshal.ReleaseComObject(application);

                application = null;
                // Прибиваем висящий процесс
                try
                {
                    Process process = Process.GetProcessById(excelProcessId);
                    process.Kill();
                }
                finally { }
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(int hWnd, ref int lpdwProcessId);

        private void button4_Click(object sender, EventArgs e)
        {
            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {
                object missing = Type.Missing;


                Object Pa = textBox1.Text; // Путь к шаблону 

                Word.Application wordApp = new Word.Application();// Создаём объект приложения


                wordApp.Documents.Open(ref Pa, ref missing, true, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing);// доделать чтобы не вылетало сообщение

                Word.Document document = wordApp.ActiveDocument;

                int countTable = document.Tables.Count;


                for (int y = 1; y < countTable; y++)
                {



                    List<ШаблонГруппы> ShabloniGr = new List<ШаблонГруппы>();
                    Word.Table table = document.Tables[y];

                    if (table.Rows.Count > 0 && table.Columns.Count > 0)
                    {

                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            progressBar1.Maximum = (countTable - 1) * table.Columns.Count;
                            progressBar1.Value++;


                        }
                        for (int i = 0; i < table.Rows.Count - 1; i++)
                        {
                            string[] row = new string[table.Columns.Count];
                            for (int j = 0; j < table.Columns.Count; j++)
                                row[j] = table.Cell(i + 2, j + 1).Range.Text.Trim('a', 'r', 'n', 't').Replace("\r", " ").Replace("\a", "");



                            DateTime d;
                            string dateConv = row[2].Replace("\a", "");
                            string tlFio = dateConv;
                            string[] b = tlFio.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            string o = b[0] + "." + b[1] + "." + b[2];

                            if (DateTime.TryParse(o, out d))

                                d = Convert.ToDateTime(o);
                            else
                                o = "2000-01-01 00:00:00.000";// Если дата введена не коретно то вводиться это число
                            d = Convert.ToDateTime(o);

                            ShabloniGr.Add(new ШаблонГруппы
                            {
                                ФИО = row[1],
                                ДатаРождения = d,
                                МестоРождения = row[3],
                                АдресПоРегистрации = row[4],
                                Телефон = row[5],
                                Паспорт = row[6],
                                Email = row[7]
                            });




                        }

                    }
                    db.ШаблонГруппы.AddRange(ShabloniGr);
                    db.SaveChanges();

                    
                }

                MessageBox.Show("Данные помещены");



            }

        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MS Word 2007 (*.docx)|*.docx|MS Word 2003 (*.doc)|*.doc";
            dialog.Title = "Выберите документ для загрузки данных";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {
                object missing = Type.Missing;


                Object Pa = textBox2.Text; // Путь к шаблону 

                Word.Application wordApp = new Word.Application();// Создаём объект приложения


                wordApp.Documents.Open(ref Pa, ref missing, true, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing);

                Word.Document document = wordApp.ActiveDocument;

                int countTable = document.Tables.Count;

                for (int y = 1; y < countTable; y++)
                {

                    List<Студенты2> ShabloniGr = new List<Студенты2>();
                    Word.Table table = document.Tables[y];

                    if (table.Rows.Count > 0 && table.Columns.Count > 0)
                    {

                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            progressBar2.Maximum = (countTable - 1) * table.Columns.Count;
                            progressBar2.Value++;


                        }
                        for (int i = 0; i < table.Rows.Count - 1; i++)
                        {
                            string[] row = new string[table.Columns.Count];
                            for (int j = 0; j < table.Columns.Count; j++)
                                row[j] = table.Cell(i + 2, j + 1).Range.Text.Trim('a', 'r', 'n', 't').Replace("\r", " ").Replace("\a", "");



                            DateTime d;
                            string dateConv = row[2].Replace("\a", "");
                            string tlFio = dateConv;
                            string[] b = tlFio.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            string o = b[0] + "." + b[1] + "." + b[2];

                            if (DateTime.TryParse(o, out d))

                                d = Convert.ToDateTime(o);
                            else
                                o = "2000-01-01 00:00:00.000";// Если дата введена не коретно то вводиться это число 2000-01-01 00:00:00.000
                            d = Convert.ToDateTime(o);

                            ShabloniGr.Add(new Студенты2
                            {
                                ФИО = row[1],
                                ДатаРождения = d,
                                ПаспортныеДанные = row[3],
                                МедицинскийПолис = row[4],
                                Снилс = row[5],
                                ИНН = row[6]

                            });




                        }

                    }
                    db.Студенты2.AddRange(ShabloniGr);
                    db.SaveChanges();

                    
                }

                wordApp.ActiveDocument.Close();
                wordApp.Quit();

                MessageBox.Show("Данные помещены");

            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MS Word 2007 (*.docx)|*.docx|MS Word 2003 (*.doc)|*.doc";
            dialog.Title = "Выберите документ для загрузки данных";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)

        {
            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {
                var ShabloneGr = db.ШаблонГруппы;
                var Students = db.Студенты2;
                foreach (Студенты2 pl in Students)
                {

                    db.Студенты2.Remove(pl);


                }


                foreach (ШаблонГруппы rl in ShabloneGr)
                {

                    db.ШаблонГруппы.Remove(rl);


                }

                db.SaveChanges();

                MessageBox.Show("Данные удалены");

            }



        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = DirDialog.SelectedPath;
            }
        }
    }
}
