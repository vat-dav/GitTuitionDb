using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Areas.Identity.Data;
using TuitionDbv1.Models;
using static TuitionDbv1.Models.Batch;

namespace TuitionDbv1.Areas.Identity.Data;

public class TuitionDbStartup
{
    public static void AddData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var tuitionDbContext = serviceScope.ServiceProvider.GetRequiredService<TuitionDbContext>();


            if (tuitionDbContext.Students.Any())
            {

                return;
            }
            if (tuitionDbContext.Subjects.Any())
            {

                return;
            }

            if (tuitionDbContext.Staffs.Any())
            {

                return; 
            }
            if (tuitionDbContext.BatchStudents.Any())
            {
                return;
            }
            if (tuitionDbContext.Batches.Any())
            {

                return;
            }
            


            // Dummy Data
            var students = new Student[]
 {
    new Student
    {
        StudentFirstName = "Aaron",
        StudentLastName = "Colaco",
        StudentPhone = "0212403002",
        StudentSchool = "Avondale College",
        YearLevel = StudentYearLevel.Year2,
        Course = StudentCourse.Cambridge,
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "123 Elm Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 2, 12)
    },
    new Student
    {
        StudentFirstName = "Emily",
        StudentLastName = "Johnson",
        StudentPhone = "0211234567",
        StudentSchool = "St. Mary's School",
        YearLevel = StudentYearLevel.Year10,
        Course = StudentCourse.NCEA,
        
        PaymentType = PaymentMethod.Cash,
        BillingAddress = "456 Maple Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 3, 20)
    },
    new Student
    {
        StudentFirstName = "Sophia",
        StudentLastName = "Nguyen",
        StudentPhone = "0219876543",
        StudentSchool = "New Lynn Intermediate",
        YearLevel = StudentYearLevel.Year8,
        Course = StudentCourse.IB,
       
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "789 Oak Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 4, 5)
    },
    new Student
    {
        StudentFirstName = "Daniel",
        StudentLastName = "Lee",
        StudentPhone = "0215551234",
        StudentSchool = "New Lynn High School",
        YearLevel = StudentYearLevel.Year11,
        Course = StudentCourse.NCEA,
        
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "101 Pine Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 4, 8)
    },
    new Student
    {
        StudentFirstName = "Emma",
        StudentLastName = "Chen",
        StudentPhone = "0217778889",
        StudentSchool = "Lynnmall College",
        YearLevel = StudentYearLevel.Year13,
        Course = StudentCourse.IB,
       
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "303 Oak Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 4, 10)
    },
    
    new Student
    {
        StudentFirstName = "Michael",
        StudentLastName = "Johnson",
        StudentPhone = "0214567890",
        StudentSchool = "Lynndale High School",
        YearLevel = StudentYearLevel.Year9,
        Course = StudentCourse.Cambridge,
       
        PaymentType = PaymentMethod.Cash,
        BillingAddress = "789 Cedar Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 5, 20)
    },
    new Student
    {
        StudentFirstName = "Sophie",
        StudentLastName = "Brown",
        StudentPhone = "0219876543",
        StudentSchool = "Westside Intermediate",
        YearLevel = StudentYearLevel.Year7,
        Course = StudentCourse.NCEA,
        
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "456 Pine Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 6, 1)
    },
    new Student
    {
        StudentFirstName = "Ethan",
        StudentLastName = "Davis",
        StudentPhone = "0216543210",
        StudentSchool = "Greenwood College",
        YearLevel = StudentYearLevel.Year12,
        Course = StudentCourse.IB,
       
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "101 Maple Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 6, 5)
    },
    new Student
    {
        StudentFirstName = "Isabella",
        StudentLastName = "Smith",
        StudentPhone = "0218889999",
        StudentSchool = "Oakdale High School",
        YearLevel = StudentYearLevel.Year10,
        Course = StudentCourse.Cambridge,
       
        PaymentType = PaymentMethod.Cash,
        BillingAddress = "303 Elmwood Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 6, 10)
    },
    new Student
    {
        StudentFirstName = "Noah",
        StudentLastName = "Garcia",
        StudentPhone = "0211234567",
        StudentSchool = "Riverside College",
        YearLevel = StudentYearLevel.Year11,
        Course = StudentCourse.NCEA,
        
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "789 Cedar Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 6, 15)
    },
    new Student
    {
        StudentFirstName = "Mia",
        StudentLastName = "Martinez",
        StudentPhone = "0217778889",
        StudentSchool = "Harborview Intermediate",
        YearLevel = StudentYearLevel.Year8,
        Course = StudentCourse.IB,
       
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "101 Pine Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 6, 20)
    },

    new Student
    {
        StudentFirstName = "Liam",
        StudentLastName = "Anderson",
        StudentPhone = "0212345678",
        StudentSchool = "Maplewood High School",
        YearLevel = StudentYearLevel.Year12,
        Course = StudentCourse.NCEA,
        
        PaymentType = PaymentMethod.Cash,
        BillingAddress = "456 Oak Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 7, 1)
    },
    new Student
    {
        StudentFirstName = "Charlotte",
        StudentLastName = "Wilson",
        StudentPhone = "0218765432",
        StudentSchool = "Rosewood College",
        YearLevel = StudentYearLevel.Year9,
        Course = StudentCourse.IB,
        
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "789 Pine Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 7, 5)
    },
    new Student
    {
        StudentFirstName = "Benjamin",
        StudentLastName = "Thomas",
        StudentPhone = "0215432167",
        StudentSchool = "Hilltop High School",
        YearLevel = StudentYearLevel.Year11,
        Course = StudentCourse.Cambridge,
       
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "101 Cedar Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 7, 10)
    },
    new Student
    {
        StudentFirstName = "Amelia",
        StudentLastName = "Roberts",
        StudentPhone = "0219876543",
        StudentSchool = "Brookside College",
        YearLevel = StudentYearLevel.Year10,
        Course = StudentCourse.NCEA,
       
        PaymentType = PaymentMethod.Cash,
        BillingAddress = "303 Elm Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 7, 15)
    },
    new Student
    {
        StudentFirstName = "William",
        StudentLastName = "Harris",
        StudentPhone = "0211112222",
        StudentSchool = "Riverview High School",
        YearLevel = StudentYearLevel.Year13,
        Course = StudentCourse.IB,
        
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "101 Oak Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 7, 20)
    },
 
    new Student
    {
        StudentFirstName = "Ava",
        StudentLastName = "Nelson",
        StudentPhone = "0212223333",
        StudentSchool = "Lakeview Intermediate",
        YearLevel = StudentYearLevel.Year8,
        Course = StudentCourse.Cambridge,
       
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "123 Cedar Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 7, 25)
    },
    new Student
    {
        StudentFirstName = "James",
        StudentLastName = "Thompson",
        StudentPhone = "0213334444",
        StudentSchool = "Parkside College",
        YearLevel = StudentYearLevel.Year12,
        Course = StudentCourse.NCEA,
       
        PaymentType = PaymentMethod.Cash,
        BillingAddress = "456 Pine Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 8, 1)
    },
    new Student
    {
        StudentFirstName = "Mia",
        StudentLastName = "Hall",
        StudentPhone = "0214445555",
        StudentSchool = "Highland High School",
        YearLevel = StudentYearLevel.Year9,
        Course = StudentCourse.IB,
        
        PaymentType = PaymentMethod.DirectDebit,
        BillingAddress = "789 Oak Street, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 8, 5)
    },
    new Student
    {
        StudentFirstName = "Alexander",
        StudentLastName = "Young",
        StudentPhone = "0215556666",
        StudentSchool = "Meadowbrook College",
        YearLevel = StudentYearLevel.Year11,
        Course = StudentCourse.Cambridge,
       
        PaymentType = PaymentMethod.BankTransfer,
        BillingAddress = "101 Cedar Avenue, New Lynn, Auckland",
        JoinDate = new DateOnly(2024, 8, 10)
    }
             };

            var subjects = new Subject[]
            {
                new Subject
                {
                    SubjectName = "English"
                },

                new Subject
                {
                    SubjectName = "Science"
                },
                new Subject
                {
                    SubjectName = "History"
                },
                new Subject
                {
                    SubjectName = "Geography"
                },
                new Subject
                {
                    SubjectName = "Art"
                },
                new Subject 
                { SubjectName = "Algebra" 
                },
                new Subject 
                { 
                    SubjectName = "Geometry" 
                },
                new Subject 
                { 
                    SubjectName = "Statistics" 
                },
                new Subject
                {
                   SubjectName = "Art History"
                },
                new Subject
                {
                    SubjectName = "Drama"
                },
new Subject
{
    SubjectName = "Ethics"
},
new Subject
{
    SubjectName = "Anthropology"
},
new Subject
{
    SubjectName = "Politics"
},
new Subject
{
    SubjectName = "Botany"
},
new Subject
{
    SubjectName = "Zoology"
},
new Subject
{
    SubjectName = "Astronomy"
},
new Subject
{
    SubjectName = "Astrophysics"
},
new Subject
{
    SubjectName = "Culture"
},
new Subject
{
    SubjectName = "IT"
},
new Subject
{
    SubjectName = "Geology"
}




            };

            var staffs = new Staff[]
{
    new Staff
    {
        StaffFirstName = "Alice",
        StaffLastName = "Smith",
        StaffEmail = "Scienceischemical@gmail.com",
        StaffPhone = "0211112222",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Bob",
        StaffLastName = "Johnson",
        StaffEmail = "Mathismyfav@yahoo.com",
        StaffPhone = "0213334444",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Eva",
        StaffLastName = "Brown",
        StaffEmail = "Shakespeareisgreat@outlook.com",
        StaffPhone = "0215556666",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Mike",
        StaffLastName = "Davis",
        StaffEmail = "Iliketocode@gmail.com",
        StaffPhone = "0217778888",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffFirstName = "Sarah",
        StaffLastName = "Wilson",
        StaffEmail = "ILOVEART@gmail.com",
        StaffPhone = "0219990000",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Sophie",
        StaffLastName = "Miller",
        StaffEmail = "sophiem@example.com",
        StaffPhone = "0211234567",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Jake",
        StaffLastName = "Wilson",
        StaffEmail = "jake@example.com",
        StaffPhone = "0212345678",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Emma",
        StaffLastName = "Garcia",
        StaffEmail = "emma@example.com",
        StaffPhone = "0213456789",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Ryan",
        StaffLastName = "Clark",
        StaffEmail = "ryan@example.com",
        StaffPhone = "0214567890",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Isabella",
        StaffLastName = "Martinez",
        StaffEmail = "isabella@example.com",
        StaffPhone = "0215678901",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "David",
        StaffLastName = "Rodriguez",
        StaffEmail = "david@example.com",
        StaffPhone = "0216789012",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffFirstName = "Sophia",
        StaffLastName = "Hernandez",
        StaffEmail = "sophiah@example.com",
        StaffPhone = "0217890123",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffFirstName = "Matthew",
        StaffLastName = "Lee",
        StaffEmail = "matthew@example.com",
        StaffPhone = "0218901234",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffFirstName = "Madison",
        StaffLastName = "Young",
        StaffEmail = "madison@example.com",
        StaffPhone = "0219012345",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffFirstName = "Joshua",
        StaffLastName = "Lewis",
        StaffEmail = "joshua@example.com",
        StaffPhone = "0210123456",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffFirstName = "Emily",
        StaffLastName = "Hall",
        StaffEmail = "emily@example.com",
        StaffPhone = "0211234567",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Aiden",
        StaffLastName = "Baker",
        StaffEmail = "aiden@example.com",
        StaffPhone = "0212345678",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Olivia",
        StaffLastName = "Hill",
        StaffEmail = "olivia@example.com",
        StaffPhone = "0213456789",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Nathan",
        StaffLastName = "Wright",
        StaffEmail = "nathan@example.com",
        StaffPhone = "0214567890",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffFirstName = "Chloe",
        StaffLastName = "King",
        StaffEmail = "chloe@example.com",
        StaffPhone = "0215678901",
        Positions = Staff.StaffPosition.Teacher
    }
};



            var batches = new Batch[]
                {

                   new Batch
{
    BatchDay = StudentBatchDay.Monday,
    BatchTime = StudentBatchTime.Batch_1930,
    SubjectId = 2,
    StaffId = 1
},
new Batch
{
    BatchDay = StudentBatchDay.Tuesday,
    BatchTime = StudentBatchTime.Batch_1830,
    SubjectId = 1,
    StaffId = 5
},
new Batch
{
    BatchDay = StudentBatchDay.Wednesday,
    BatchTime = StudentBatchTime.Batch_1630,
    SubjectId = 4,
    StaffId = 2
},
new Batch
{
    BatchDay = StudentBatchDay.Thursday,
    BatchTime = StudentBatchTime.Batch_1730,
    SubjectId = 3,
    StaffId = 3
},
new Batch
{
    BatchDay = StudentBatchDay.Friday,
    BatchTime = StudentBatchTime.Batch_1530,
    SubjectId = 5,
    StaffId = 4
},
new Batch
{
    BatchDay = StudentBatchDay.Monday,
    BatchTime = StudentBatchTime.Batch_1630,
    SubjectId = 2,
    StaffId = 1
},
new Batch
{
    BatchDay = StudentBatchDay.Tuesday,
    BatchTime = StudentBatchTime.Batch_1730,
    SubjectId = 3,
    StaffId = 2
},
new Batch
{
    BatchDay = StudentBatchDay.Wednesday,
    BatchTime = StudentBatchTime.Batch_1830,
    SubjectId = 4,
    StaffId = 3
},
new Batch
{
    BatchDay = StudentBatchDay.Thursday,
    BatchTime = StudentBatchTime.Batch_1930,
    SubjectId = 5,
    StaffId = 4
},
new Batch
{
    BatchDay = StudentBatchDay.Friday,
    BatchTime = StudentBatchTime.Batch_1530,
    SubjectId = 6,
    StaffId = 5
}
                };


            var batchStudent = new BatchStudent[]
            {
                new BatchStudent
                {
                    StudentId = 1,
                   
                    BatchId = 1
                },
                new BatchStudent
                {
                    StudentId = 2,
                   
                    BatchId = 2
                },
                new BatchStudent
                {
                    StudentId = 3,
                   
                  
                    BatchId = 3
                },
                new BatchStudent
                {
                    StudentId = 4,
                  
                    BatchId = 4
                },
                new BatchStudent
                {
                    StudentId = 5,
                    
                    BatchId = 5
                },
                new BatchStudent
                {
                    StudentId = 6,
                  
                    BatchId = 6
                },
                new BatchStudent
                {
                    StudentId = 7,
                  
                    BatchId = 7
                },
                new BatchStudent
                {
                    StudentId = 8,
                   
                    BatchId = 8
                },
                new BatchStudent
                {
                    StudentId = 9,
              
                    BatchId = 9
                },
                new BatchStudent
                {
                    StudentId = 10,
                   
                    BatchId = 10
                },
                new BatchStudent
                {
                    StudentId = 11,
                   
                    BatchId = 1
                },
                new BatchStudent
                {
                    StudentId = 12,
                   
                    BatchId = 2
                },
                new BatchStudent
                {
                    StudentId = 13,
                   
                    BatchId = 3
                },
                new BatchStudent
                {
                    StudentId = 14,
                   
                    BatchId = 4
                },
                new BatchStudent
                {
                    StudentId = 15,
                  
                    BatchId = 2
                },
                new BatchStudent
                {
                    StudentId = 16,
                   
                    BatchId = 10
                },
                new BatchStudent
                {
                    StudentId = 17,
                   
                    BatchId = 9
                },
                new BatchStudent
                {
                    StudentId = 18,
                   
                    BatchId = 6
                },
                new BatchStudent
                {
                    StudentId = 19,
                    
                    BatchId = 7
                },
                new BatchStudent
                {
                    StudentId = 20,
                   
                    BatchId = 8
                }
            };





            tuitionDbContext.Staffs.AddRange(staffs);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.Students.AddRange(students);
            tuitionDbContext.SaveChanges();
           
            tuitionDbContext.Subjects.AddRange(subjects);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.Batches.AddRange(batches);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.BatchStudents.AddRange(batchStudent);
            tuitionDbContext.SaveChanges();
           

        }
    }
}