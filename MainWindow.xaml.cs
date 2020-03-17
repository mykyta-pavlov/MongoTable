using System.Windows;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace MongoTable
{
    public partial class MainWindow : Window
    {
        static readonly MongoClient client = new MongoClient();
        static readonly IMongoDatabase database = client.GetDatabase("local");
        static readonly IMongoCollection<Student> collection = database.GetCollection<Student>("students");
        
        public MainWindow()
        {
            InitializeComponent();
            MongoConnector();            
        }

        internal void MongoConnector()
        {          
            List<Student> studentsList = collection.AsQueryable().ToList();
            foreach (Student student in studentsList)
            {
                DataGridXAML.Items.Add(student);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student(TextBoxName.Text, TextBoxSurname.Text, TextBoxGroup.Text, int.Parse(TextBoxYearOfStudy.Text));
            collection.InsertOne(student);
            DataGridXAML.Items.Add(student);
        }
    }
}