public class EnrollmentService
{
public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
{
if(student is null)
    throw new ArgumentNullException(nameof(student));

if(course is null)
    throw new ArgumentNullException(nameof(course));

if(course.Capacity <= 0)
    throw new InvalidOperationException();


string standing = student.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "Good Standing",
    _ => "Academic Warning"
};

return new EnrollmentRecord(
    student.Id,
    course.Code,
    DateTime.UtcNow
);

}
}