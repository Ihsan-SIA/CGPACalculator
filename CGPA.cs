internal class CGPA
{
    public static string CalculateCGPA()
    {
        double totalPoints = 0;
        int totalUnits = 0;
        string grade = string.Empty;
        Console.Write("Please enter your name: ");
        string studentName = Console.ReadLine()!;
        Console.Write("How many courses did you do? ");
        bool countInput = int.TryParse(Console.ReadLine()!, out int coursesCount);

        bool checkCourseInput = false;
        while (!checkCourseInput)
        {
            switch (countInput)
            {
                case false:
                    Console.Write("Please input a valid number of courses: ");
                    countInput = int.TryParse(Console.ReadLine()!, out coursesCount); break;
                case true:
                    checkCourseInput = true; Console.WriteLine($"Nice! Now let's go take the next input of your {coursesCount} courses"); break;
            }
        }
        int[] courses = new int[coursesCount];
        int[] courseUnit = new int[coursesCount];
        string[] coursesName = new string[coursesCount];
        int indexCourses;
        for (indexCourses = 0; indexCourses < courses.Length; indexCourses++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter course name:");
            coursesName[indexCourses] = Console.ReadLine()!;
            Console.Write($"Unit for {coursesName[indexCourses]}: ");
            bool unitInput = int.TryParse(Console.ReadLine()!, out courseUnit[indexCourses]);
            bool checkUnits = false;
            while (!checkUnits)
            {
                {
                    switch (unitInput)
                    {
                        case false:
                            Console.WriteLine($"Please input a valid number for unit of {coursesName[indexCourses]}: ");
                            unitInput = int.TryParse(Console.ReadLine()!, out courseUnit[indexCourses]); break;
                        case true:
                            Console.WriteLine("Great! Kindly note that units are the weight of your courses and they are only integers");
                            checkUnits = true; break;
                    }
                }
            }

            string[] gradeArray = new string[6] { "a", "b", "c", "d", "e", "f" };
            bool checkGrade = false;
            Console.Write($"Grade for {coursesName[indexCourses]}: ");
            grade = Console.ReadLine()!;
            while (!checkGrade)
            {
                switch (grade.ToLower())
                {
                    case "a":
                        courses[indexCourses] = 5 * courseUnit[indexCourses];
                        checkGrade = true; break;
                    case "b":
                        courses[indexCourses] = 4 * courseUnit[indexCourses];
                        checkGrade = true; break;
                    case "c":
                        courses[indexCourses] = 3 * courseUnit[indexCourses];
                        checkGrade = true; break;
                    case "d":
                        courses[indexCourses] = 2 * courseUnit[indexCourses];
                        checkGrade = true; break;
                    case "e":
                        courses[indexCourses] = 1 * courseUnit[indexCourses];
                        checkGrade = true; break;
                    case "f":
                        courses[indexCourses] = 1 * courseUnit[indexCourses];
                        checkGrade = true; break;
                    default:
                        Console.WriteLine($"Please input a valid grade for {coursesName[indexCourses]} (grades are from A-F): ");
                        grade = Console.ReadLine()!; break;
                }

            }
            totalPoints += courses[indexCourses];
            totalUnits += courseUnit[indexCourses];
        }

        double studentCGPA = totalPoints / totalUnits;
        string message = string.Format($"{studentName}'s CGPA for this semester is = {studentCGPA:f2} ");
        Console.WriteLine(message);
        ConsoleColor classColour = studentCGPA > 4.5 ? Console.ForegroundColor = ConsoleColor.Green : Console.ForegroundColor = ConsoleColor.Gray;
        string studentClass = studentCGPA > 4.5 ? "You're on a first class!" : "You can still do much better to attain a first class. You've got this!";
        Console.WriteLine(studentClass);
        string end = "Thank you!";
        Console.ForegroundColor = ConsoleColor.White;
        return end;
    }
}