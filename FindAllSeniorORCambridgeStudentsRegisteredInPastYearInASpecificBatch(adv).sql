SELECT s.StudentId, s.StudentFirstName, s.StudentLastName, s.StudentSchool, 
       s.YearLevel, s.Course, s.JoinDate FROM Students s JOIN BatchStudents bs ON s.StudentId = bs.StudentId
WHERE (s.YearLevel IN ('9' ,'10', '11', '12', '13') OR s.Course = '1')
  AND bs.BatchId = 19;