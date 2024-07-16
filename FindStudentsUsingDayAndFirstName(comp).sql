SELECT s.* FROM Students s INNER JOIN BatchStudents bs ON s.StudentId = bs.StudentId 
INNER JOIN Batches b ON bs.BatchId = b.BatchId 
WHERE b.BatchDay = '3'  AND s.StudentFirstName LIKE '%Isabel%'