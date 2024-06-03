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
    // More unique student records
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
    // Add 15 more unique student records here
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
},

    new Staff
    {
        StaffName = "Sophie Miller",
        StaffEmail = "sophiem@example.com",
        StaffPhone = "0211234567",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Jake Wilson",
        StaffEmail = "jake@example.com",
        StaffPhone = "0212345678",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Emma Garcia",
        StaffEmail = "emma@example.com",
        StaffPhone = "0213456789",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Ryan Clark",
        StaffEmail = "ryan@example.com",
        StaffPhone = "0214567890",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Isabella Martinez",
        StaffEmail = "isabella@example.com",
        StaffPhone = "0215678901",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "David Rodriguez",
        StaffEmail = "david@example.com",
        StaffPhone = "0216789012",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffName = "Sophia Hernandez",
        StaffEmail = "sophiah@example.com",
        StaffPhone = "0217890123",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffName = "Matthew Lee",
        StaffEmail = "matthew@example.com",
        StaffPhone = "0218901234",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffName = "Madison Young",
        StaffEmail = "madison@example.com",
        StaffPhone = "0219012345",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffName = "Joshua Lewis",
        StaffEmail = "joshua@example.com",
        StaffPhone = "0210123456",
        Positions = Staff.StaffPosition.Admin
    },
    new Staff
    {
        StaffName = "Emily Hall",
        StaffEmail = "emily@example.com",
        StaffPhone = "0211234567",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Aiden Baker",
        StaffEmail = "aiden@example.com",
        StaffPhone = "0212345678",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Olivia Hill",
        StaffEmail = "olivia@example.com",
        StaffPhone = "0213456789",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Nathan Wright",
        StaffEmail = "nathan@example.com",
        StaffPhone = "0214567890",
        Positions = Staff.StaffPosition.Teacher
    },
    new Staff
    {
        StaffName = "Chloe King",
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
},
    new Batch
    {
        BatchDay = StudentBatchDay.Monday,
        BatchTime = StudentBatchTime.Batch_1630,
        SubjectId = 2,
        BatchNotes = "Sophie Miller will cover the topic of Newton's Laws. Aaron showed good understanding in the previous class. Emily struggled with applying the formulas correctly.",
        StaffId = 1
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Tuesday,
        BatchTime = StudentBatchTime.Batch_1730,
        SubjectId = 3,
        BatchNotes = "Jake Wilson will discuss the periodic table. Sophia asked insightful questions but struggled with memorizing the elements. Daniel demonstrated excellent knowledge and helped others understand.",
        StaffId = 2
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Wednesday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 4,
        BatchNotes = "Emma Garcia will introduce the topic of genetics. Liam expressed interest in genetic engineering but needs more practice with Punnett squares. Charlotte grasped the concepts quickly and completed extra exercises.",
        StaffId = 3
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Thursday,
        BatchTime = StudentBatchTime.Batch_1930,
        SubjectId = 5,
        BatchNotes = "Ryan Clark will teach about the solar system. Benjamin struggled with understanding the scale of the planets. Amelia actively participated in discussions but needs to work on memorizing facts.",
        StaffId = 4
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Friday,
        BatchTime = StudentBatchTime.Batch_1530,
        SubjectId = 6,
        BatchNotes = "Isabella Martinez will lead a discussion on philosophical ethics. William presented a thought-provoking argument but struggled with articulating his thoughts clearly. Emma actively engaged in debates and showed good understanding of ethical theories.",
        StaffId = 5
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Saturday,
        BatchTime = StudentBatchTime.Batch_1630,
        SubjectId = 7,
        BatchNotes = "David Rodriguez will introduce art history. Ava showed interest in Renaissance art but needs to work on identifying different art movements. James demonstrated knowledge of impressionist art and contributed to class discussions.",
        StaffId = 6
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Sunday,
        BatchTime = StudentBatchTime.Batch_1730,
        SubjectId = 8,
        BatchNotes = "Sophia Hernandez will discuss political ideologies. Mia struggled with understanding communism but showed improvement after extra reading. Alexander demonstrated a good grasp of political theory and engaged in lively debates.",
        StaffId = 7
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Monday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 9,
        BatchNotes = "Matthew Lee will cover botanical anatomy. Benjamin showed interest in plant classification but needs more practice with identifying plant structures. Abigail struggled with memorizing botanical terms but demonstrated improvement after group exercises.",
        StaffId = 8
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Tuesday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 10,
        BatchNotes = "Madison Young will introduce zoological classification. William demonstrated understanding of vertebrate classification but needs more practice with invertebrate groups. Sophie showed enthusiasm for marine biology and actively participated in class activities.",
        StaffId = 9
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Wednesday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 11,
        BatchNotes = "Joshua Lewis will discuss astronomical phenomena. Emma showed interest in constellations but needs more practice with identifying stars. Liam demonstrated good understanding of celestial bodies and asked insightful questions.",
        StaffId = 10
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Thursday,
        BatchTime = StudentBatchTime.Batch_1630,
        SubjectId = 12,
        BatchNotes = "Emily Hall will lead a session on cultural diversity. Isabella expressed interest in learning about different cultures but struggled with pronunciation. Sophie actively participated in discussions and shared personal experiences.",
        StaffId = 11
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Friday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 13,
        BatchNotes = "Aiden Baker will discuss world historical events. Benjamin showed interest in ancient civilizations but needs to work on organizing historical events chronologically. Olivia demonstrated good knowledge of modern history and contributed to class discussions.",
        StaffId = 12
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Saturday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 14,
        BatchNotes = "Olivia Hill will cover geological formations. Daniel struggled with understanding rock types but showed improvement after field trip. Ava demonstrated interest in plate tectonics and actively participated in class activities.",
        StaffId = 13
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Sunday,
        BatchTime = StudentBatchTime.Batch_1930,
        SubjectId = 15,
        BatchNotes = "Nathan Wright will lead a session on plate tectonics. Sophia showed interest in volcanoes but needs more practice with identifying different types. William demonstrated good understanding of seismic activity and asked insightful questions.",
        StaffId = 14
    },
    new Batch
    {
        BatchDay = StudentBatchDay.Monday,
        BatchTime = StudentBatchTime.Batch_1830,
        SubjectId = 1,
        BatchNotes = "Chloe King will discuss geographical landmarks. Charlotte struggled with understanding contour lines but showed improvement after map reading exercises. Liam demonstrated good knowledge of physical geography and contributed to class discussions.",
        StaffId = 15
    }
};


            var batchStudent = new BatchStudent[]
            {
                new BatchStudent
{
StudentId = 1,
AmountToPay = 50,
Received = false
},
new BatchStudent
{
StudentId = 2,
AmountToPay = 75,
Received = true
},
new BatchStudent
{
StudentId = 3,
AmountToPay = 100,
Received = false
},
new BatchStudent
{
StudentId = 4,
AmountToPay = 125,
Received = true
},
new BatchStudent
{
StudentId = 5,
AmountToPay = 150,
Received = false
},
new BatchStudent
    {
        StudentId = 6,
        AmountToPay = 80,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 7,
        AmountToPay = 95,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 8,
        AmountToPay = 110,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 9,
        AmountToPay = 125,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 10,
        AmountToPay = 140,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 11,
        AmountToPay = 155,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 12,
        AmountToPay = 170,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 13,
        AmountToPay = 185,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 14,
        AmountToPay = 200,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 15,
        AmountToPay = 215,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 16,
        AmountToPay = 230,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 17,
        AmountToPay = 245,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 18,
        AmountToPay = 260,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 19,
        AmountToPay = 275,
        Received = false
    },
    new BatchStudent
    {
        StudentId = 20,
        AmountToPay = 290,
        Received = false
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