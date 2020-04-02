using System.Windows;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace MongoTable
{
    public partial class MainWindow : Window
    {
        //Рядок підключення до MongoDB
        //Для підключення до локальної бази даних можна лишити дужки порожніми
        static readonly MongoClient client = new MongoClient("mongodb+srv://testUser:vouxjG57ERpNdAAs@projectdotnet-t1mwf.mongodb.net/test?retryWrites=true&w=majority");
        //Назва БД для підключення 
        static readonly IMongoDatabase database = client.GetDatabase("univesrity_database");
        //Назва колекції для підключення 
        static readonly IMongoCollection<Student> collection = database.GetCollection<Student>("students");
        
        public MainWindow()
        {
            InitializeComponent();
            MongoConnector();            
        }

        internal void MongoConnector()
        {
            //Вилучення документів з колекції у вигляді списку
            List<Student> studentsList = collection.AsQueryable().ToList();
            //Для кожного документу із списку створити рядок в таблиці
            foreach (Student student in studentsList)
            {
                DataGridXAML.Items.Add(student);
            }
        }

        //Викликаєтся при натисканні кнопки "Додати", створюючи новий об'єкт у списку, додаючи його до таблиці та колекції
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student(TextBoxName.Text, TextBoxSurname.Text, TextBoxGroup.Text, int.Parse(TextBoxYearOfStudy.Text));
            collection.InsertOne(student);
            DataGridXAML.Items.Add(student);
        }
    }
}