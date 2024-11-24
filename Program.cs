using System.Linq;

namespace Final_OOP_Assignment
{
    // Exercise 1
    class clsGenericList<T>
    {
        private List <T> _items;

        public clsGenericList()
        {
            _items = new List<T>();
        }
        public void Add(T item)
        {
            _items.Add(item);
        }
        public void DisplayFirstElement()
        {
            if (_items.Count > 0)
            {
                Console.WriteLine($"First Element: {_items[0]}");
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }
        public void DisplayAllItems()
        {
            if (_items.Count > 0)
            {
                Console.Write("All Items: ");
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.Write(_items[i]);

                    if (i < _items.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }

    }

    // Exercise 3
    class clsCity
    {
        private string _name;
        private string _region;
        private List<clsSchool> _schools;

        public clsCity(string name, string region)
        {
            _name = name;
            _region = region;
            _schools = new List<clsSchool>();
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        public List<clsSchool> Schools
        {
            get { return _schools; }
        }
        public void AddSchool(clsSchool school)
        {
            _schools.Add(school);
        }
    }
    class clsSchool
    {
        private string _name;
        private int _space;
        private List<clsTeacher> _teachers;

        public clsSchool(string name, int space)
        {
            _name = name;
            _space = space;
            _teachers = new List<clsTeacher>();
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Space
        {
            get { return _space; }
            set { _space = value; }
        }
        public List<clsTeacher> Teachers
        {
            get { return _teachers; }
        }
        public void AddTeacher(clsTeacher teacher)
        {
            _teachers.Add(teacher);
        }
    }
    class clsTeacher
    {
        private string _name;
        private int _teacherId;

        public clsTeacher(string name, int teacherId)
        {
            _name = name;
            _teacherId = teacherId;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int TeacherId
        {
            get { return _teacherId; }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {

            // First exercise test

            // Example with integers
            Console.WriteLine("Working with integers:\n");
            var intList = new clsGenericList<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.DisplayFirstElement();
            intList.DisplayAllItems();

            Console.WriteLine();

            // Example with strings
            Console.WriteLine("\nWorking with strings:\n");
            var stringList = new clsGenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("Are you doing well!");
            stringList.DisplayFirstElement();
            stringList.DisplayAllItems();

            Thread.Sleep(7000); // Wating 7 seconds before starting the Exercise 2
            Console.Clear();
            /*---------------------------------------------------------------------------------------------------*/

            // Exercise 2
            string docOneLocation = @"C:\Users\Alsur\OneDrive\Desktop\C# Projects\Test-Project\Doc-1.txt";
            string docTwoLocation = @"C:\Users\Alsur\OneDrive\Desktop\C# Projects\Test-Project\Doc-2.txt";
            

            string content = "Welcome and I hope you're dowing well!\n" +
                             "Name: Motasem Alsuradi\n" +
                             "Age: 23\n" + 
                             "Position: Web Developer traniee @ Tahaluf AlEmarat Technical Solutions.";

            File.WriteAllText(docOneLocation, content);

            try
            {
                using (StreamReader reader = new StreamReader(docOneLocation))
                using (StreamWriter writer = new StreamWriter(docTwoLocation))
                {
                    string Line;
                    while ((Line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(Line);
                    }
                }

                string contentDoc2 = File.ReadAllText(docTwoLocation);

                int wordCount = contentDoc2
                    .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Count();

                Console.Write($"Total number of words in Doc-2: {wordCount}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
            }

            Thread.Sleep(3000); // Wating 3 seconds before starting the Third Exercise test
            Console.Clear();
            /*---------------------------------------------------------------------------------------------------*/

            // Third exercise test

            clsCity amman = new clsCity("Amman", "Central");
            clsCity irbid = new clsCity("Irbid", "North");
            clsCity aqaba = new clsCity("Aqaba", "South");

            clsSchool ammanSchool = new clsSchool("Amman School", 600);
            clsSchool ammanHighSchool = new clsSchool("Amman High School", 700);
            clsSchool irbidAcademy = new clsSchool("Irbid Academy", 500);
            clsSchool aqabaInternationalSchool = new clsSchool("Aqaba International School", 300);

            // Add schools to cities
            amman.AddSchool(ammanSchool);
            amman.AddSchool(ammanHighSchool);
            irbid.AddSchool(irbidAcademy);
            aqaba.AddSchool(aqabaInternationalSchool);

            // Add teachers to Amman School
            ammanSchool.AddTeacher(new clsTeacher("Mr. Omar", 1010));
            ammanSchool.AddTeacher(new clsTeacher("Ms. Layla", 1011));

            // Add teachers to Amman High School
            ammanHighSchool.AddTeacher(new clsTeacher("Mr. Ahamd", 1001));
            ammanHighSchool.AddTeacher(new clsTeacher("Mr. Hassan", 1002));
            ammanHighSchool.AddTeacher(new clsTeacher("Mr. Khaled", 1003));
            ammanHighSchool.AddTeacher(new clsTeacher("Ms. Zainab", 1004));

            // Add teachers to Irbid Academy
            irbidAcademy.AddTeacher(new clsTeacher("Mr. Sami", 2001));
            irbidAcademy.AddTeacher(new clsTeacher("Ms. Nour", 2002));
            irbidAcademy.AddTeacher(new clsTeacher("Ms. Dana", 2003));

            // Add teachers to Aqaba International School
            aqabaInternationalSchool.AddTeacher(new clsTeacher("Mr. Firas", 3001));
            aqabaInternationalSchool.AddTeacher(new clsTeacher("Ms. Noor", 3002));
            aqabaInternationalSchool.AddTeacher(new clsTeacher("Ms. Sarah", 3003));
            aqabaInternationalSchool.AddTeacher(new clsTeacher("Mr. Bassam", 3004));
            aqabaInternationalSchool.AddTeacher(new clsTeacher("Ms. Rania", 3005));


            var citySchoolsTeachers = new List<clsCity> { amman, irbid, aqaba}
            .Select(city => new
            {
                CityName = city.Name,
                Schools = city.Schools.Select(school => new
                {
                    SchoolName = school.Name,
                    Teachers = school.Teachers.Select(teacher => teacher.Name)
                })
            });

            Console.WriteLine("Schools and Teachers in Jordan:");
            foreach (var city in citySchoolsTeachers)
            {
                Console.WriteLine($"\nCity: {city.CityName}");
                foreach (var school in city.Schools)
                {
                    Console.WriteLine($"\n  School: {school.SchoolName}");
                    foreach (var teacher in school.Teachers)
                        Console.WriteLine($"    Teacher: {teacher}");
                    
                }
            }

            var schoolWithMostTeachers = new List<clsCity> { amman, irbid, aqaba }
            .SelectMany(city => city.Schools)
            .OrderByDescending(school => school.Teachers.Count)
            .FirstOrDefault();

            Console.WriteLine("\n\nSchool with the highest number of teachers:");
            if (schoolWithMostTeachers != null)
            {
                Console.WriteLine($"School: {schoolWithMostTeachers.Name}, Number of Teachers: {schoolWithMostTeachers.Teachers.Count}");
            }
        }
    }
}
