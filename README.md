# Tuition Centre Management System

## Project Overview
- This project is a web-based application designed to manage a tuition centre. It manages the storage of information related to Students, Staff, Batches, and the tracking of Students in Batches. It was built using Asp.Net Entity Framework Core MVC, because of this, the application offers a user-friendly interface with a clear default format, making it easy to understand and use.

## Repository Contents
- Developed code journey through the different Standards it applies to: 
- Documentation on issues I encountered and how I resolved them.

## Requirements
- Windows 10 (or above) running Visual Studio 2022 .NET 6.0 or above.

## How to Operate
1. **Clone Repository and Database Setup:**
   - Clone the repository.
   - Run "update-database" command in the Package Manager Console of Visual Studio to apply migrations to the Visual Studio SQL Server database.

2. **Building and Running the Application:**
   - Build the solution in Visual Studio to launch the web application, for best results open with Google Chrome.

3. **Functionality:**
   - The web application allows users to manage student, staff, and batch information.
   	- Users can assign students to specific batches, consolidating all relevant information in one accessible place.

### Creating New Records
- **Students:**
  - Navigate to [Manage Students](Students Index View) and click "Create New". Fill out the required details.

- **Staff:**
  - Navigate to [Manage Staff](Staffs Index View) and click "Create New". Fill out the required details.

- **Subjects:**
  - Navigate to [Manage Subjects](Subjects Index View) and click "Create New". Fill out the required details.

- **Batches:**
  - Before creating a batch, ensure the associated staff and subject exist.
  - Navigate to [Manage Batches](Batches Index View) and click "Create New". Fill out the required details.

- **Adding Students to Batches:**
  - Before adding a student to a batch, ensure both the batch and student records exist.
   	- Then navigate to [Manage StudentBatches](BatchStudents Index View) and create the record.

## Contact Information - Feel free to reach out for assistance related to this project!
- **Developer Name:** Vatsal Dave
- **Email:** ac121655@avcol.school.nz

