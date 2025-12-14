## SchoolSystem

This is a console application built with C\# and SQL Server, designed to manage school administration tasks. The system features a menu-driven interface allowing users to perform various CRUD operations, such as managing students, teachers, courses, and more.



## What is "SchoolSystem"?

This program provides a structured way to handle educational data. It allows users to:

  * Add students to courses.
  * Assign teachers to classrooms.
  * Track student progress (passed/failed courses).
  * Ensure data integrity (e.g., unique indices to prevent duplicate emails).

## Prerequisites

Before running the application, ensure you have the following installed:

  * **SQL Server Management Studio (SSMS)** (2021 or later)
  * **Visual Studio 2022** (or later)
  * **.NET SDK** (compatible with the project version)

## Setup & Installation

### 1\. Database Configuration

1.  Navigate to the `SchoolSystem` project folder: `SchoolSystem/SchoolSystem`.
2.  Create a `appsettings.json` file by copying the example file:
    ```bash
    copy appsettings.example.json appsettings.json
    ```
    *(Alternatively, create it manually and ensure your connection string is correct for your local server).*

    > **Automatic Database Creation**
>
> When running `dotnet ef database update`, Entity Framework Core will automatically create the database specified in `appsettings.json` **if it does not already exist**.  
> No manual database creation in SQL Server is required.

3.  Open `appsettings.json` and verify the connection string:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=SchoolSystemDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
    }
    ```

### 2\. Initialize Database

Open a terminal in the project directory and run the Entity Framework updates to create the database schema:

```bash
dotnet ef database update
```

### 3\. Run SQL Scripts

Some schema functionality requires raw SQL scripts. Open **SSMS**, connect to your `SchoolSystemDB`, and execute the following scripts located in the `Schema` folder:

1.  `Schema/adding_name_active_to_courses_table.sql`
2.  `Schema/alter_start_end_time_columns_on_schedules_table.sql`

## How to Run

1.  Open the solution in **Visual Studio**.
2.  Press **Run** (or `F5`).
3.  A terminal window will appear. Use the **arrow keys** to navigate.
4.  **First Run / Seeding**:
      * In the main menu, select **Option 6 (Seed Database)** to populate the system with initial sample data.
      * *Note: If you ever use Option 7 (Delete Database), the system is now smart enough to automatically reset identity counters, so you can immediately re-seed without restarting or running manual SQL scripts\!*

## Data Model & Design Justification

The database is designed using relational principles to ensure data integrity and minimize redundancy.

### Entities

  * **Students**: Stores personal information (Name, Email, Personal Number).
      * *Design*: Uses unique indices on Email to prevent duplicates.
  * **Teachers**: Stores instructor details.
  * **Courses**: Represents subjects effectively with start/end dates.
  * **Classrooms**: Physical locations with capacity limits.
  * **Schedules**: Links a Course, Teacher, and Classroom to a specific time slot.
      * *Design*: This is a central intersection entity ensuring that a room or teacher isn't double-booked.
  * **Enrollments**: Connects Students to Courses (Many-to-Many relationship resolved via a join table).
      * *Design*: Allows tracking individually which students are in which course including the date of enrollment.
  * **Grades**: Associated with an Enrollment and a Teacher.
      * *Design*: Separating grades keeps the Enrollment table clean and allows for grading history or multiple grading components if expanded.

### Design Motivation

The architecture separates **Data**, **Models**, **Services**, and **UI** (Console):

  * **Separation of Concerns**: Database logic is isolated in the `Data` layer.
  * **Entity Framework Core**: Used for ORM to interact with SQL Server using strong typing.

### Database Strategy (Hybrid Approach)

To satisfy requirements for both Code First and Database First methodologies, this project uses a **hybrid strategy**:

1.  **Code First**: The core entities (Students, Teachers) were initialized using EF Core migrations.
2.  **Database First**: Specific schema enhancements were applied directly via SQL scripts (see `Schema` folder) and then mapped back to the C\# models.
      * *Example*: The `Active` column in `Courses` and the column structure for `Start/EndTime` in `Schedules` were created via raw SQL to demonstrate manual DDL proficiency, then integrated into the application.

## Contributors

  * [@Johan45671](https://github.com/Johan45671)
  * [@RobotaLiz](https://github.com/RobotaLiz)
  * [@skvortsov-ivan](https://github.com/skvortsov-ivan)
  * [@exikoz](https://www.google.com/search?q=https://github.com/exikoz)
