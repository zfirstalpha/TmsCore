// string? region = null;
// string?upperRegion=region?.ToUpper();
// Console.WriteLine($"Region (conditional): {upperRegion}");

// string displayRegion = region??"unassigned";
// Console.WriteLine($"Region (coalesced): {displayRegion}");

// region??="addis ababa";
// Console.WriteLine($"Region (assigned): {region}");

// string studentName = "Abeba";
// string studentId = "STU-001";
// int enrollmentCount = 3;
// decimal grantAmount = 1999.99m; // 'm' suffix marks a decimal literal
// DateTime enrolledAt = DateTime.UtcNow;
// string? campusRegion = null;
// Console.WriteLine($"Student: {studentName} ({studentId})");

// Console.WriteLine($"Courses: {enrollmentCount}");
// Console.WriteLine($"Grant: {grantAmount:F2}");
// Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
// Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");

// var enrollment = new EnrollmentRecord ("STU-001", "CS-401", DateTime.UtcNow);
// Console.WriteLine(enrollment);


//  var corrected = enrollment with { CourseCode = "CS-402" };
//  Console.WriteLine(corrected);

//  var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
// Console.WriteLine($"Same data? {enrollment == duplicate}");

// var course = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
// Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");

// try
// {
// course.Capacity = -5;
// }
// catch (ArgumentOutOfRangeException ex)
// {
// Console.WriteLine($"Caught: {ex.Message}");
// }
// // Invalid title — should throw
// try
// {
// course.Title = "";
// }
// catch (ArgumentException ex)
// {
// Console.WriteLine($"Caught: {ex.Message}");
// }


// var s = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
// Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");

void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    Console.WriteLine("--- Grade Report ---");
    foreach (var item in assessments)
    {
        Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
    }
}
IGradable[] cohortAssessments = [
new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =
85m }
];

PrintGradeReport(cohortAssessments);

var service = new EnrollmentService();
// Test 1: Valid registration
var validStudent = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
var validCourse = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
var result = service.ProcessRegistration(validStudent, validCourse);
Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");
// Test 2: Null student should throw
try
{
    _ = service.ProcessRegistration(null, validCourse);
}
catch (ArgumentNullException ex)
{
Console.WriteLine($"Guard caught: {ex.ParamName}");
}
// Test 3: Full course should throw
var fullCourse = new Course { Code = "CS-402", Title = "Full Course", Capacity = 1 };
fullCourse.EnrolledCount = 1;
try
{
    _ = service.ProcessRegistration(validStudent, fullCourse);
}
catch (InvalidOperationException ex)
{
Console.WriteLine($"Business rule: {ex.Message}");
}