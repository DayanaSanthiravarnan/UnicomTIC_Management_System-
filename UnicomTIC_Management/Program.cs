using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTIC_Management.Controllers;
using UnicomTIC_Management.Datas;
using UnicomTIC_Management.Repositories;
using UnicomTIC_Management.Services;
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
            /*Application.Run(new Form1());*/

            // Initialize repositories
            var studentRepository = new StudentRepository();
            var courseRepository = new CourseRepository();
            var mainGroupRepository = new MainGroupRepository();

            // Initialize services
            var studentService = new StudentService(studentRepository);
            var courseService = new CourseService(courseRepository);
            var mainGroupService = new MainGroupService(mainGroupRepository);

            // Initialize controllers
            var studentController = new StudentController(studentService);
            var courseController = new CourseController(courseService);
            var mainGroupController = new MainGroupController(mainGroupService);

            //Application.Run(new StudentDetailsForm(studentController, courseController, mainGroupController));
            
            //Application.Run(new UserManagementForm ());
        }
    }
}
