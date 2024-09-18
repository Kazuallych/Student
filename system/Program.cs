List<Student> students = new List<Student>();
AttendanceManager attendanceManager = new AttendanceManager();
while (true)
{
    Console.Write("1.Добавить нового студента\n2.Удалить студента по идентификатору\n3.Редактировать данные студента\n4.Отобразить список всех студентов\n5.Добавить запись о посещении для студента\n6.Отобразить записи о посещаемости для конкретного студента\n7.Выйти из приложения\n");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            {
                students.Add(attendanceManager.AddStudent(students.Count + 1));
                break;
            }
        case 2:
            {
                Console.Write("Введите ID студента: ");
                int ID = int.Parse(Console.ReadLine());
                students = attendanceManager.RemoveStudent(ID, students);
                break;
            }
        case 3:
            {
                Console.Write("Введите ID студента: ");
                int ID = int.Parse(Console.ReadLine());
                students = attendanceManager.EditStudent(ID - 1, students);
                break;
            }
        case 4:
            {
                attendanceManager.ListStudents(students);
                break;
            }
        case 5:
            {
                Console.Write("Введите ID студента: ");
                int ID = int.Parse(Console.ReadLine());
                students = attendanceManager.AddAttendance(ID, students);
                break;
            }
        case 6:
            {
                Console.Write("Введите ID студента: ");
                int ID = int.Parse(Console.ReadLine());
                attendanceManager.ListAttendance(ID, students);
                break;
            }
        case 7:
            {
                Environment.Exit(0);
                break;
            }
    }
}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<AttendanceRecord> Attendance  = new List<AttendanceRecord>();
}
class AttendanceRecord
{
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }

}
class AttendanceManager
{
    public Student AddStudent(int NewID)
    {
        Student student = new Student();
        student.Id = NewID;
        Console.Write("Напишите ФИО студента: ");
        student.Name = Console.ReadLine();
        Console.Write("Напишите Email студента: ");
        student.Email = Console.ReadLine();
        Console.Clear();
        return student;
    }
    public List<Student> RemoveStudent(int id, List<Student> students)
    {
        foreach (Student student in students)
        {
            if (student.Id == id)
            {
                students.Remove(student);
                break;
            }
        }
        Console.Clear();
        return students;
    }
    public List<Student> EditStudent(int id, List<Student> updatedStudent)
    {
        Console.Write("Напишите новое ФИО студента: ");
        updatedStudent[id].Name = Console.ReadLine();
        Console.Write("Напишите новый Email студента: ");
        updatedStudent[id].Email = Console.ReadLine();
        Console.Clear();
        return updatedStudent;
    }
    public void ListStudents(List<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Id}.Имя студента: {student.Name}|Почта студента: {student.Email}");
        }
    }
    public List<Student> AddAttendance(int studentId, List<Student> students)
    {
        foreach (Student student in students)
        {
            if (student.Id == studentId)
            {
                AttendanceRecord record = new AttendanceRecord();
                student.Attendance.Add(record);
                Console.Write("Введите месяц: ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("Введите день: ");
                int day = int.Parse(Console.ReadLine());
                DateTime time = new DateTime(2024,month,day);   
                student.Attendance[student.Attendance.Count - 1].Date = time;
                Console.Write("Введите присутсвовал ли студент?\n1.Да\n2.Нет\n");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    student.Attendance[student.Attendance.Count-1].IsPresent = true;
                }
                else
                {
                    student.Attendance[student.Attendance.Count - 1].IsPresent = false;
                }
            }
        }
        return students;
    }
    public void ListAttendance(int studentId,List<Student> students)
    {
        foreach(Student student in students)
        {
            if (student.Id==studentId)
            {
                Console.WriteLine($"{student.Id}.Имя студента: {student.Name}|Почта студента: {student.Email}\n");
                foreach(AttendanceRecord record in student.Attendance)
                {
                    Console.Write($"{record.Date}: {record.IsPresent}\n");
                }
            }
        }
    }
}

