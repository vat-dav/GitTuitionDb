using Microsoft.AspNetCore.Builder;
using System;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Areas.Identity.Data;
using TuitionDbv1.Models;

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

                return; // Stop the process
            }
            if (tuitionDbContext.Subjects.Any())
            {

                return; // Stop the process
            }

            if (tuitionDbContext.Staffs.Any())
            {

                return; // Stop the process
            }
            if (tuitionDbContext.Batches.Any())
            {

                return; // Stop the process
            }
            if (tuitionDbContext.BatchFee.Any())
            {

                return; // Stop the process
            }


            // Dummy Student Data
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
                    BatchDay = StudentBatchDay.Wednesday,
                    BatchTime = StudentBatchTime.Batch_1530,
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
                    BatchDay = StudentBatchDay.Friday,
                    BatchTime = StudentBatchTime.Batch_1730,
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
                    BatchDay = StudentBatchDay.Monday,
                    BatchTime = StudentBatchTime.Batch_1630,
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
                BatchDay = StudentBatchDay.Thursday,
                BatchTime = StudentBatchTime.Batch_1830,
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
                BatchDay = StudentBatchDay.Saturday,
                BatchTime = StudentBatchTime.Batch_1930,
                PaymentType = PaymentMethod.DirectDebit,
                BillingAddress = "303 Oak Avenue, New Lynn, Auckland",
                JoinDate = new DateOnly(2024, 4, 10)
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
                }
            };

            var staff = new Staff[]
               { new Staff
                {
                    StaffName = "Alice Smith",
                    StaffEmail = "Scienceischemical@gmail.com",
                    StaffPhone = "0211112222",
                    Positions = Staff.StaffPosition.Teacher
                },
new Staff
{
StaffName = "Bob Johnson",
StaffEmail = "Mathismyfav@yahoo.com",
StaffPhone = "0213334444",
Positions = Staff.StaffPosition.Teacher
},
new Staff
{
StaffName = "Eva Brown",
StaffEmail = "Shakespeareisgreat@outlook.com",
StaffPhone = "0215556666",
Positions = Staff.StaffPosition.Teacher
},
new Staff
{
StaffName = "Mike Davis",
StaffEmail = "Iliketocode@gmail.com",
StaffPhone = "0217778888",
Positions = Staff.StaffPosition.Admin
},
new Staff
{
StaffName = "Sarah Wilson",
StaffEmail = "ILOVEART@gmail.com",
StaffPhone = "0219990000",
Positions = Staff.StaffPosition.Teacher
}
               };


            var batches = new Batch[]
                {new Batch
{
BatchDay = StudentBatchDay.Monday,
BatchTime = StudentBatchTime.Batch_1930,
SubjectId = 2,
BatchNotes = "Aaron is excelling in this subject, nice punctuation. Sophia is having trouble with consonants, given homework to follow up next batch.",
StaffId = 1

},
new Batch
{
BatchDay = StudentBatchDay.Tuesday,
BatchTime = StudentBatchTime.Batch_1830,
SubjectId = 1,
BatchNotes = "Emily started algebra today and is having difficulty with variables. Daniel however has picked up algebra quickly. Both given homework to follow up next batch.",
StaffId = 5
},
new Batch
{
BatchDay = StudentBatchDay.Wednesday,
BatchTime = StudentBatchTime.Batch_1630,
SubjectId = 4,
BatchNotes = "Emma is having difficulty naming parts of a cell, given poster and quiz along with it, Sophia is confident with Animal cells, but doesn't understand plant cells",
StaffId = 2
},
new Batch
{
BatchDay = StudentBatchDay.Thursday,
BatchTime = StudentBatchTime.Batch_1730,
SubjectId = 3,
BatchNotes = "Aaron is extremely passionate about the French Revolution and scored 100% on the quiz, Emily is positively contributing to classroom discussions.",
StaffId = 3
},
new Batch
{
BatchDay = StudentBatchDay.Friday,
BatchTime = StudentBatchTime.Batch_1530,
SubjectId = 5,
BatchNotes = "Daniel is able to shade well, he is able to express himself through art. Sophia has completed the shading component and is moving to the paint precision component.",
StaffId = 4
}
};


            var batchFee = new BatchFee[]
            {
                new BatchFee
{
StudentId = 1,
AmountToPay = 50,
Received = false
},
new BatchFee
{
StudentId = 2,
AmountToPay = 75,
Received = true
},
new BatchFee
{
StudentId = 3,
AmountToPay = 100,
Received = false
},
new BatchFee
{
StudentId = 4,
AmountToPay = 125,
Received = true
},
new BatchFee
{
StudentId = 5,
AmountToPay = 150,
Received = false
}

            };






            tuitionDbContext.Students.AddRange(students);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.Staffs.AddRange(staff);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.Subjects.AddRange(subjects);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.BatchFee.AddRange(batchFee);
            tuitionDbContext.SaveChanges();
            tuitionDbContext.Batches.AddRange(batches);
            tuitionDbContext.SaveChanges();


        }
    }
}