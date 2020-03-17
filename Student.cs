using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTable
{
    internal class Student
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string StudentName { get; set; }
        [BsonElement("surname")]
        public string StudentSurname { get; set; }
        [BsonElement("group")]
        public string StudentGroup { get; set; }
        [BsonElement("yearOfStudy")]
        public int StudentYearOfStudy { get; set; }

        public Student(string studentName, string studentSurname, string studentGroup, int studentYearOfStudy)
        {
            StudentName = studentName;
            StudentSurname = studentSurname;
            StudentGroup = studentGroup;
            StudentYearOfStudy = studentYearOfStudy;
        }
    }
}
