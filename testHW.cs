using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;

namespace CSharpExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courseList = new List<Course>()
            {
                new Course() { CourseId = "A001", Name = "C#", Teacher = "Bill", Classroom = "L107", Credit = 3 },
                new Course() { CourseId = "A002", Name = "HTML/CSS", Teacher = "Amos", Classroom = "L104", Credit = 2 },
                new Course() { CourseId = "A003", Name = "JavaScript/jQuery", Teacher = "奚江華", Classroom = "L104", Credit = 3 },
                new Course() { CourseId = "A004", Name = "MSSQL", Teacher = "Jimmy", Classroom = "L202", Credit = 3 },
                new Course() { CourseId = "A005", Name = "MVC5/CoreMVC", Teacher = "奚江華", Classroom = "L107", Credit = 6 },
                new Course() { CourseId = "B001", Name = "VueJS", Teacher = "Jimmy", Classroom = "L104", Credit = 2 },
                new Course() { CourseId = "B002", Name = "DevOps", Teacher = "David", Classroom = "L107", Credit = 3 },
                new Course() { CourseId = "B003", Name = "MongoDB", Teacher = "Ben", Classroom = "L202", Credit = 2 },
                new Course() { CourseId = "B004", Name = "Redis", Teacher = "Ben", Classroom = "L202", Credit = 2 },
                new Course() { CourseId = "B005", Name = "Git", Teacher = "Andy", Classroom = "L107", Credit = 1 },
                new Course() { CourseId = "B006", Name = "Git", Teacher = "Jimmy", Classroom = "L107", Credit = 1 }
            };

            List<Student> studentList = new List<Student>()
             {
               new Student() { StudentId = "S0001", Name = "小新", Gender = GenderOption.Male, CourseList = new List<string>() { "A001", "A004", "B002", "B003", "B004", "B005" } },
               new Student() { StudentId = "S0002", Name = "妮妮", Gender = GenderOption.Female, CourseList = new List<string>() { "A002", "A003", "B001", "B002", "B005" } },
               new Student() { StudentId = "S0003", Name = "風間", Gender = GenderOption.Male, CourseList = new List<string>() { "A001", "A002", "A003", "A004", "A005", "B001", "B002", "B003", "B004", "B005"  } },
               new Student() { StudentId = "S0004", Name = "阿呆", Gender = GenderOption.Male, CourseList = new List<string>() { "A001", "A002", "A003", "A004", "A005" } },
               new Student() { StudentId = "S0005", Name = "正男", Gender = GenderOption.Male, CourseList = new List<string>() { "B001", "B002", "B003", "B004", "B005" } },
               new Student() { StudentId = "S0006", Name = "小丸子", Gender = GenderOption.Female, CourseList = new List<string>() { "A005" } },
               new Student() { StudentId = "S0007", Name = "小玉", Gender = GenderOption.Female, CourseList = new List<string>() { "A005", "B002", "B003", "B004" } },
             };

            #region 第1題
            // 1. 列出所有課程的名稱
            Console.WriteLine("1. 列出所有課程的名稱");
            {
                var AllcouseName = courseList.Select((x) => x.Name);
                Console.WriteLine(string.Join(",", AllcouseName));
            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第2題
            // 2. 列出所有在"L107"教室上課的課程ID
            Console.WriteLine("2. 列出所有在'L107'教室上課的課程ID");
            {
                var CouseItem = courseList.Where((x) => x.Classroom == "L107").Select((x) => x.CourseId);
                Console.WriteLine(string.Join(",", CouseItem));

            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第3題
            // 3. 列出所有在'L107'教室上課，並且學分為3的課程ID
            Console.WriteLine("3. 列出所有在'L107'教室上課，並且學分為3的課程ID");
            {
                var CouseCreditItem = courseList.Where((x) => x.Classroom == "L107").Where((x) => x.Credit == 3).Select((x) => x.CourseId); ;
                Console.WriteLine(string.Join(",", CouseCreditItem));

            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第4題
            // 4. 列出所有老師的名字(名字不能重複出現)
            Console.WriteLine("4. 列出所有老師的名字(名字不能重複出現)");
            {
                var AllteacherName = courseList.Select(x => x.Teacher).Distinct();
                Console.WriteLine(string.Join(",", AllteacherName));
            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第5題
            // 5. 列出所有有在'L202'上課的老師名字(名字不能重複出現)
            Console.WriteLine("5. 列出所有有在'L202'上課的老師名字(名字不能重複出現)");
            {
                var TeacherName = courseList.Where((x) => x.Classroom == "L202").Select((x) => x.Teacher).Distinct();
                Console.WriteLine(string.Join(",", TeacherName));//ok
            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第6題
            // 6. 列出所有女性學生的名字
            Console.WriteLine("6. 列出所有女性學生的名字");
            {
                var femaleStudentNames = studentList.Where(s => s.Gender == GenderOption.Female).Select(s => s.Name);
                Console.WriteLine(string.Join(",", femaleStudentNames));//ok

            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第7題
            // 7. 列出有上'Git'這門課的學員名字
            Console.WriteLine("7. 列出有上'Git'這門課的學員名字");
            {
                var CourseGit = courseList.Where((x) => x.Name == "Git").Select((x) => x.CourseId);
                Console.WriteLine(string.Join(",", CourseGit));
                var studentsOfGit = studentList.Where((y) => y.CourseList.Any(course => CourseGit.Contains(course))).Select(w => w.Name);
                Console.WriteLine(string.Join(",", studentsOfGit));//ok

            }

            Console.WriteLine($"{Environment.NewLine}");
            #endregion

            #region 第8題
            // 8. 列出每個學員上的每一堂課
            // ex:
            /*
                       小玉: 
                            MVC5/CoreMVC
                            DevOps
                            MongoDB
                            Redis
                    */
            Console.WriteLine("8. 列出每個學員上的每一堂課");
            {
                foreach (var student in studentList)
                {
                    Console.WriteLine($"{student.Name}");

                    foreach (var courseId in student.CourseList)
                    {
                        var course = courseList.FirstOrDefault(c => c.CourseId == courseId);

                        if (course != null)
                        {
                            Console.WriteLine($" {course.Name}");
                        }
                    }
                }

                //var result = studentlist.select(s =>
                //{
                //    var coursenames = s.courselist.select(id =>
                //    {
                //        var course = courselist.firstordefault(c => c.courseid == id);
                //        if (course != null)
                //        {
                //            return course.name;
                //        }
                //        else
                //        {
                //            return "null";
                //        }
                //    });

                //    return $"{s.name}: \n {string.join("\n", coursenames)}";
                //});
                //console.writeline(string.join("\n", result));

                Console.WriteLine($"{Environment.NewLine}");
                #endregion

                #region 第9題
                // 9. 找出誰上的課數量最少
                Console.WriteLine("9. 找出誰上的課數量最少");
                {
                    var result9 = studentList.OrderBy(s => s.CourseList.Count).First();
                    Console.WriteLine(string.Join(",", result9.Name));
                }

                Console.WriteLine($"{Environment.NewLine}");
                #endregion

                #region 第10題
                // 10. 找出誰修的學分總和小於10
                Console.WriteLine("10. 找出誰修的學分總和小於10");
                //
                var result10 = studentList.Select((x) => new
                {
                    x.Name,
                    totalscredits = x.CourseList.Select((y) =>
                    {
                        var course = courseList.FirstOrDefault((w) => w.CourseId == y);
                        if (course != null)
                        {
                            return course.Credit;
                        }
                        else
                        {
                            return 0;
                        }
                    }).Sum()
                }).Where(student => student.totalscredits < 10).Select(s => s.Name);
                Console.WriteLine(string.Join(",", result10));

                //var result10 = studentList.Select((x) => new
                //{
                //    x.Name,
                //    totalscredits = x.CourseList.Select((y) => courseList.FirstOrDefault((w) => w.CourseId == y)?.Credit ?? 0)
                //    .Sum()
                //}).Where(student => student.totalscredits < 10).Select(s => s.Name);
                //Console.WriteLine(string.Join(",", result10)); totalscredits = x.CourseList.Select((y) => courseList.FirstOrDefault((w) => w.CourseId == y)?.Credit ?? 0)


                //var result10 = studentList
                //    .Select(x=> new
                //    {
                //        Student = x,
                //        TotalCredits = x.CourseList
                //            .Join(courseList, 
                //            studentCourseId => studentCourseId, 
                //            course => course.CourseId, 
                //            (studentCourseId, course) => course.Credit).Sum()

                //    })
                //    .Where(x => x.TotalCredits < 10)
                //    .Select(x => x.Student);
                //foreach (var student in result10)
                //{
                //    Console.WriteLine($"學生: {student.Name}, 學分總和: {student.CourseList.Join(courseList, id => id, course => course.CourseId, (id, course) => course.Credit).Sum()}");
                //}






                Console.WriteLine($"{Environment.NewLine}");
                #endregion

                #region 第11題
                // 11. 找出誰最後獲得學分數最高
                Console.WriteLine("11. 找出誰最後獲得學分數最高");
                //var result11_2 = courseList.Select(x => new { x.CourseId, x.Credit }); 如果要在select中有兩種屬性


                var result11 = studentList.Select((x) => new
                {
                    x.Name,
                    totalscredits = x.CourseList.Select((y) =>
                    {
                        var course = courseList.FirstOrDefault((w) => w.CourseId == y);
                        if (course != null)
                        {
                            return course.Credit;
                        }
                        else
                        {
                            return 0;
                        }
                    }).Sum()
                }).OrderByDescending(x => x.totalscredits).First();
                Console.WriteLine(string.Join(",", result11.Name));

                Console.WriteLine($"{Environment.NewLine}");
                #endregion

                #region 第12題(加分題)
                // 12. 十二生肖自定義排序
                Console.WriteLine("12. 十二生肖自定義排序");
                {
                    var zoo = new List<string> { "龍", "鼠", "馬", "豬", "羊" }; //答案: 鼠、龍、馬、羊、豬
                    Console.WriteLine($"排序前: {string.Join("、", zoo)}{Environment.NewLine}");
                    Console.Write("排序後: ");
                    //作答區

                }

                #endregion

                Console.ReadLine();

            }
        }
    }
}

