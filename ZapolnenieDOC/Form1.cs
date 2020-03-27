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

namespace ZapolnenieDOC
{
    public partial class Form1 : Form
    {
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
        private void button1_Click(object sender, EventArgs e)
        {
            Word.Application wordApp = new Word.Application();// Создаём объект приложения

            Word.Document Word = new Word.Document();


            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {

                //var Bd_911 = db.Бд_911;
                //var I_913 = db.И_913;
                //var Ip_93 = db.Ип_93;
                //var M_92 = db.М_92;
                //var Mc_91 = db.Мц_91;
                //var Me_912 = db.Мэ_912;
                //var Ol_94 = db.Ол_94;
                //var Tv_914 = db.Тв_914;
                var Students = db.Студенты2;




                foreach (Студенты2 tl in Students)
                {
                    List<Person> persons = new List<Person>();
                    string tlFio = tl.ФИО;
                    string[] b = tlFio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string o = b[0] + " " + b[1] + " " + b[2];

                    //var name = db.И_913.Where(c =>c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (name != null)
                    //{
                    //    string sPersons = name.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];

                        

                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (customer != null)
                    //{
                    //    if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //    {
                    //        customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения
                                    
                    //            };
                    //            persons.Add(person);
                    //        }
                    //}
                    //}
                    //var n = db.Ип_93.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (n != null)
                    //{
                    //    string sPersons = n.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}
                    //var na = db.М_92.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (na != null)
                    //{
                    //    string sPersons = na.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}
                    //var nam = db.Мэ_912.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (nam != null)
                    //{
                    //    string sPersons = nam.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}
                    //var name1 = db.Ол_94.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (name1 != null)
                    //{
                    //    string sPersons = name1.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}
                    //var name2 = db.Тв_914.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (name2 != null)
                    //{
                    //    string sPersons = name2.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}
                    //var name3 = db.Мц_91.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (name3 != null)
                    //{
                    //    string sPersons = name3.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}
                    //var name4 = db.Бд_911.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //if (name4 != null)
                    //{
                    //    string sPersons = name4.ФИО;
                    //    string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    string p = a[0] + " " + a[1] + " " + a[2];



                    //    var customer = db.Бд_911.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    //    if (customer != null)
                    //    {
                    //        if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                    //        {
                    //            customer.Паспорт = tl.ПаспортныеДанные;

                    //            Person person = new Person
                    //            {
                    //                FIO = customer.ФИО,
                    //                DateBirdhsday = customer.ДатаРождения

                    //            };
                    //            persons.Add(person);
                    //        }
                    //    }
                    //}

                    var name4 = db.ШаблонГруппы.Where(c => c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                    if (name4 != null)
                    {
                        string sPersons = name4.ФИО;
                        string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string p = a[0] + " " + a[1] + " " + a[2];



                        var customer = db.ШаблонГруппы.Where(c => o == p && c.ДатаРождения == tl.ДатаРождения).FirstOrDefault();
                        if (customer != null)
                        {
                            if (p == "Куденикина Маргарита Дмитриевна")
                            {
                                MessageBox.Show(p);
                            }
                            if (string.IsNullOrEmpty(customer.Паспорт) || customer.Паспорт == " ")
                            {
                                customer.Паспорт = tl.ПаспортныеДанные;

                                Person person = new Person
                                {
                                    FIO = customer.ФИО,
                                    DateBirdhsday = customer.ДатаРождения

                                };
                                persons.Add(person);
                            }
                        }
                    }




                    if (persons.Count >0) {
                        foreach (Person p in persons)
                        {
                            listBox1.Items.Add("ФИО "+p.FIO +" Дата рождения "+p.DateBirdhsday );
                        }
                       
                    }
                }

                db.SaveChanges();
               
                

            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            //string а  = "Гумбатова  Светлана Габиловна Перевод в гр Ол-94 с 26.09.19 пр. №58-К/д от 25.09.19";


            //List<Person> persons = new List<Person>();
            string sPersons = "Ахматжанова   Салтанат   Эркинбековна";
            string[] a = sPersons.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < a.Length;)
            //{
            //    Person person = new Person
            //    {
            //        Famaly = a[i++],
            //        Name = a[i++],
            //        Sername = a[i++]
            //    };
            //    persons.Add(person);
            //}
            string p = a[0] + " " + a[1] + " " + a[2];
            MessageBox.Show(p);
            //foreach (Person p in persons)
            //    MessageBox.Show(string.Format("Фамилия: {0}\nИмя: {1}\nОтчество: {2}\n________________",
            //        p.Famaly, p.Name, p.Sername));

        }
    }
}
