
using PatikaWeek7PracticeLinqGroup;

List<Student> students = new List<Student>(); // Öğrenci listesi

students.Add(new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 });
students.Add(new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 });
students.Add(new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 });
students.Add(new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 });
students.Add(new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 });

 
List<Class> classes = new List<Class>(); // Sınıf Listesi

classes.Add(new Class { ClassId = 1, ClassName = "Matematik" });
classes.Add(new Class { ClassId = 2, ClassName = "Türkçe" });
classes.Add(new Class { ClassId = 3, ClassName = "Kimya" });



// GroupJoin metoduyla verili sınıflara kayıtlı öğrencilerin sorgusu yapıldı

var studentsWithClasses = classes.GroupJoin(students,
                                            @class => @class.ClassId,
                                            student => student.ClassId,
                                            (@class, studentGroup) => new
                                            {
                                                Class = @class,
                                                Students = studentGroup.ToList()
                                            });

foreach (var item in studentsWithClasses)
{
    Console.WriteLine($"-- Sınıf: {item.Class.ClassName}");
    foreach (var student in item.Students)
    {
        Console.WriteLine($"Öğrenci: {student.StudentName}");
    }

}
                                                                          