# Schoolsystem

## Get started
in Docs/How To Run
You can find information about how to get the program set up and how the program is run and navigated.

## Design/Architecture Overview

This schoolsystem involves Students, Teachers, classrooms, grades and enrollments.
All classes for these entities can be found in the Models folder.
All the entities have services that are used when running CRUD operations, an example of this is the StudentService.
With this the program can ex Create, Update, Delete and read all the entities from the database.

All the different services takes a SchoolSystemContext in the constructor, this is then used to communicate with the database.
There is also a MenuHelper class to that is used by the menusystem (ConsoleUI) to more easily interact with the different services.

One service that is not directly tied to an entity is the MenuService, which is a class that runs more specific requests from the menu, ex "ShowActiveCoursesWithStudents"
Another special class is the DataSeeder class that upon request from the menu can seed the database.

The Program when run looks like this:
``` 
=================================================
                  Main menu
=================================================

Use arrowkeys to navigate. Press Enter to select.

[1]: CRUD-operations
[2]: Overview of a student's courses, grades, and teacher assessments
[3]: Student overview
[4]: List of active courses and participating students
[5]: Student ratio between passed and failed
[6]: Seed the database
[7]: Delete data from database
[8]: [SQL View] Student Grade Report
[9]: [SQL SP] Grade Statistics Distribution
[0]: Exit menu
```

## Migrations

