using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTIC_Management.Datas
{
    internal static class Migration
    {
        public static void CreateTables()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @" CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        NIC TEXT NOT NULL,
                        Role TEXT NOT NULL CHECK (Role IN ('Admin','Staff','lecturer','Student'))
                        );
                                           
                        CREATE TABLE IF NOT EXISTS NICDetails (
                        NIC TEXT PRIMARY 
                        );

                       
                        CREATE TABLE IF NOT EXISTS AdminApprovalLogs (
                        LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER NOT NULL,
                        AdminID INTEGER NOT NULL,
                        Action TEXT NOT NULL CHECK (Action IN ('Accepted', 'Rejected')),
                        ActionDate TEXT NOT NULL,
                        FOREIGN KEY (UserID) REFERENCES Users(UserID),
                        FOREIGN KEY (AdminID) REFERENCES Users(UserID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Departments (
                        DepartmentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        DepartmentName TEXT NOT NULL
                        );

                       
                        CREATE TABLE IF NOT EXISTS Courses (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                        );

                       
                        CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        NIC TEXT NOT NULL UNIQUE,
                        Address TEXT,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
                        FOREIGN KEY (NIC) REFERENCES NICDetails(NIC)
                        );

                        
                        CREATE TABLE IF NOT EXISTS AdmissionNumbers (
                        AdmissionNumber TEXT PRIMARY KEY,
                        StudentID INTEGER UNIQUE,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Lecturers (
                        LecturerID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        NIC TEXT NOT NULL UNIQUE,
                        Phone TEXT,
                        Address TEXT,
                        DepartmentID INTEGER,
                        FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
                        FOREIGN KEY (NIC) REFERENCES NICDetails(NIC)
                        );

                        
                        CREATE TABLE IF NOT EXISTS Staff (
                        StaffID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        NIC TEXT NOT NULL UNIQUE,
                        DepartmentID INTEGER,
                        Role TEXT,
                        FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
                        FOREIGN KEY (NIC) REFERENCES NICDetails(NIC)
                        );

                        
                        CREATE TABLE IF NOT EXISTS EmployeeIDs (
                        EmployeeID TEXT PRIMARY KEY,
                        UserID INTEGER UNIQUE,
                        FOREIGN KEY (UserID) REFERENCES Users(UserID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Mentors (
                        MentorID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        NIC TEXT NOT NULL UNIQUE,
                        DepartmentID INTEGER,
                        FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
                        FOREIGN KEY (NIC) REFERENCES NICDetails(NIC)
                        );

                       
                        CREATE TABLE IF NOT EXISTS MentorStudents (
                        MentorID INTEGER NOT NULL,
                        StudentID INTEGER NOT NULL,
                        PRIMARY KEY (MentorID, StudentID),
                        FOREIGN KEY (MentorID) REFERENCES Mentors(MentorID),
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS LectureSubjects (
                        LecturerID INTEGER,
                        SubjectID INTEGER,
                        PRIMARY KEY (LecturerID, SubjectID),
                        FOREIGN KEY (LecturerID) REFERENCES Lecturers(LecturerID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS StudentLecturer (
                        StudentID INTEGER,
                        LecturerID INTEGER,
                        PRIMARY KEY (StudentID, LecturerID),
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (LecturerID) REFERENCES Lecturers(LecturerID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Exams (
                        ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        ExamDate TEXT NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Marks (
                        MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        ExamID INTEGER NOT NULL,
                        MarksObtained INTEGER NOT NULL,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                        FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS TopPerformers (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        GPA REAL NOT NULL,
                        Term TEXT NOT NULL,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS Rooms (
                        RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Timetables (
                        TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        TimeSlot TEXT NOT NULL,
                        RoomID INTEGER NOT NULL,
                        LecturerID INTEGER NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                        FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
                        FOREIGN KEY (LecturerID) REFERENCES Lecturers(LecturerID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Attendance (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER,
                        SubjectID INTEGER,
                        Date TEXT,
                        Status TEXT,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS Assignments (
                        AssignmentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        DueDate TEXT,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Submissions (
                        SubmissionID INTEGER PRIMARY KEY AUTOINCREMENT,
                        AssignmentID INTEGER NOT NULL,
                        StudentID INTEGER NOT NULL,
                        SubmittedAt TEXT,
                        FOREIGN KEY (AssignmentID) REFERENCES Assignments(AssignmentID),
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
                        );

                       
                        CREATE TABLE IF NOT EXISTS Notifications (
                        NotificationID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Message TEXT NOT NULL,
                        SentTo TEXT,
                        SentAt TEXT
                        );

                        
                        CREATE TABLE IF NOT EXISTS ActivityLogs (
                        LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER,
                        Action TEXT NOT NULL,
                        Timestamp TEXT NOT NULL,
                        FOREIGN KEY (UserID) REFERENCES Users(UserID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS BackupLogs (
                        BackupID INTEGER PRIMARY KEY AUTOINCREMENT,
                        BackupDate TEXT NOT NULL,
                        BackupPath TEXT NOT NULL
                        );

                        
                        CREATE TABLE IF NOT EXISTS LeaveRequests (
                        LeaveID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffID INTEGER,
                        Reason TEXT,
                        StartDate TEXT,
                        EndDate TEXT,
                        Status TEXT,
                        FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS StudentComplaints (
                        ComplaintID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER,
                        ComplaintText TEXT,
                        SubmittedAt TEXT,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
                        );

                        
                        CREATE TABLE IF NOT EXISTS CourseSubjects (
                        CourseID INTEGER,
                        SubjectID INTEGER,
                        PRIMARY KEY (CourseID, SubjectID),
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                        );

            ";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
