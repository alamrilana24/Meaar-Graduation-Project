SELECT 
    f.FirstName,
    f.LastName,
    c.CourseName,
    c.CourseCode,
    c.CreditHours
FROM FacultyCources fc
JOIN FacultyMembers f ON fc.FacultyId = f.FacultyId
JOIN Courses c ON fc.CourseId = c.CourseId
WHERE f.FirstName = 'Ahmed';
