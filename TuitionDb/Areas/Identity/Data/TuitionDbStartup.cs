using Microsoft.AspNetCore.Builder;
using System;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Models;

namespace TuitionDbv1.Areas.Identity.Data
{
    public class TuitionDbStartup
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TuitionDbContext>();

                // Dummy Student Data
                var students = new Student[]
                {
                    new Student
                    {
                        StudentId = 1,
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
                        StudentId = 2,
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
                        StudentId = 3,
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
                    StudentId = 4,
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
                    StudentId = 5,
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

                dbContext.Students.AddRange(students);
                dbContext.SaveChanges();
            }
        }
    }
}
