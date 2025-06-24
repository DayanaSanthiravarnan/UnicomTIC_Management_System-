using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Models.DTOs;
using UnicomTIC_Management.Models.Enums;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Repositories.Interfaces;
using UnicomTIC_Management.Services;
using UnicomTIC_Management.Services.Interfaces;
using UnicomTIC_Management.Views;

namespace UnicomTIC_Management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Migration.CreateTables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize repositories
            var studentRepository = new StudentRepository();
            var courseRepository = new CourseRepository();
            var mainGroupRepository = new MainGroupRepository();
            var userRepository = new UserRepository();
            var subGroupRepository = new SubGroupRepository();
            var subjectRepository = new SubjectRepository();
            var marksRepository = new MarksRepository();
            var examRepository = new ExamRepository();
            // Initialize services
            var studentService = new StudentService(studentRepository);
            var courseService = new CourseService(courseRepository);
            var mainGroupService = new MainGroupService(mainGroupRepository);
            var userService = new UserService(userRepository);
            var subGroupService = new SubGroupService(subGroupRepository);
            var subjectService = new SubjectService(subjectRepository);
            var marksService = new MarksService(marksRepository);
            var examService = new ExamService(examRepository, subjectService);
            // Initialize controllers
            var studentController = new StudentController(studentService);
            var courseController = new CourseController(courseService);
            var mainGroupController = new MainGroupController(mainGroupService);
            var userController = new UserController(userService);
            var subGroupController = new SubGroupController(subGroupService);
            var subjectController = new SubjectController(subjectService);
            var examController = new ExamController(examService);

            // Create dummy pending user and student for demonstration
            var pendingUser = new UserDTO
            {
                UserID = 0,
                Username = "pendingUser",
                Role = UserRole.Student,
                Status = UserStatus.Pending
            };

            var pendingStudent = new StudentDTO
            {
                StudentID = 0,
                Name = "Pending Student",
                CourseID = 1,
                Status = UserStatus.Pending
            };

            // Run UserManagementForm with all dependencies and dummy data
            //   Application.Run(new UserManagementForm(
            //  userController,
            //  studentController,
            // mainGroupController,
            // subGroupController,
            //  subjectController,
            //   pendingUser,
            // pendingStudent
            // ));
            var attendanceRepository = new AttendanceRepository();
            var attendanceService = new AttendanceService(attendanceRepository);
            var attendanceController = new AttendanceController(attendanceService);
            var marksController = new MarksController(marksService);
            // Application.Run(new AttendanceForm(attendanceController, studentController));


            ///Application.Run(new AttendanceForm()

            //Application.Run(new MarksForm(marksController, studentController, subjectController, examController));
            //Application.Run(new ExamForm());
            Application.Run(new LoginForm());
            // Application.Run(new StudentDetailsForm( studentController,
           // courseController,
                                //   mainGroupController, subGroupController));
        }

    }
    }
        


