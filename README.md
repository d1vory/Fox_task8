# WPF Desktop Application for Course Management

## Description

This project involves creating a WPF (Windows Presentation Foundation) application to manage courses, groups, students, and teachers. The application will allow users to view and manipulate data, export/import student lists, and generate documents.

## Features

1. **Main Page:**
    - Display a list of courses.
    - Show groups for the selected course.
    - Show students for the selected group.
    - Use a treeview for hierarchical display.

2. **Group Management Page:**
    - Create and delete groups.
    - Edit group details (change name, assign/update teacher).
    - Ensure groups with students cannot be deleted.

3. **Student Management:**
    - Add, update, and delete student records.
    - Import and export student lists to/from CSV files.
    - Clear existing students before importing a new list.

4. **Teacher Management Page:**
    - Add, update, and delete teacher records.
    - Assign teachers to groups.

5. **Document Generation:**
    - Generate DOCX/PDF files listing group students with course and group names as the title.

## Prerequisites

- .NET 8 SDK
- SQL Server
- Entity Framework Core
