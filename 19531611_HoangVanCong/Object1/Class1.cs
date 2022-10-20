namespace Object1
{
    [Serializable]
    public class Student
    {
        public long id { get; set; }
        public string name { get; set; }

        public Student(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}