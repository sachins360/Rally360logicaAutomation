using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("Tasks")]
    public class TasksTest : BaseTest
    {
        static ReadData readTasks = new ReadData("Tasks");
        ProjectsTest pt = new ProjectsTest();

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readTasks.GetValue("SignInDifferentUser", "userName");
            String password = readTasks.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Create a Task
        private void CreateTask(String taskName)
        {
            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(3000);

            //Enter the Task Name
            tasksPage.EnterTaskName(taskName);
            log.Info("Enter the Task Name.");
            Thread.Sleep(2000);

            //Click the Add Task Plus icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click the Add Task Plus icon.");
            Thread.Sleep(4000);
        }

        //Delete Task
        private void DeleteTask(String taskName)
        {
            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Delete this task link
            tasksPage.ClickDeleteThisTaskLink();
            log.Info("Click the Delete This Task link.");
            Thread.Sleep(2000);

            //Click the Delete Task Window Yes Button
            tasksPage.PressDeleteTaskWindowYesBtn();
            log.Info("Click the Delete Task Window Yes Button.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_001_VerifyTasksOption()
        {
            Global.MethodName = "Tasks_001_VerifyTasksOption";

            Thread.Sleep(2000);
            tasksPage.VerifyTasksMenuOption();
            log.Info("Verify Tasks menu icon");
        }

        [Test]
        public void Tasks_002_VerifyTasksPage()
        {
            Global.MethodName = "Tasks_002_VerifyTasksPage";

            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(3000);

            //Verify Tasks Page get displayed
            tasksPage.VerifyTasksScreenDisplayed();
            log.Info("Verify Tasks Page get displayed.");
            Thread.Sleep(1000);

            //Verify Add Text field get displayed
            tasksPage.VerifyAddTaskText();
            log.Info("Verify Add Task Text field get displayed.");
            Thread.Sleep(1000);

            //Verify Add Text Plus Icon get displayed
            tasksPage.VerifyAddTextPlusIcon();
            log.Info("Verify Add Text Plus Icon get displayed.");
            Thread.Sleep(1000);

            //Verify To-Do section gets displayed
            tasksPage.VerifyToDoSection();
            log.Info("Verify To-Do section gets displayed.");
            Thread.Sleep(1000);

            //Verify In Progress section gets displayed
            tasksPage.VerifyInProgressSection();
            log.Info("Verify In Progress section gets displayed.");
            Thread.Sleep(1000);

            //Verify Completed section gets displayed
            tasksPage.VerifyCompletedSection();
            log.Info("Verify Completed section gets displayed.");
        }

        [Test]
        public void Tasks_003_CreateNewTask()
        {
            Global.MethodName = "Tasks_003_CreateNewTask";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Verify Task get displayed
            tasksPage.VerifyTaskDisplayed(taskName);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
        }

        [Test]
        public void Tasks_004_VerifyInProgressTasks()
        {
            Global.MethodName = "Tasks_004_VerifyInProgressTasks";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Drag and Drop the task to In-Progress section
            tasksPage.MoveFromToDoToInProgress(taskName);
            log.Info("Drag and Drop the task to In Progress section.");
            Thread.Sleep(2000);

            //Verify Task get displayed In Progress section
            tasksPage.VerifyTaskDisplayedInProgressSection(taskName);
            log.Info("Verify Task get displayed in In Progress section.");
            Thread.Sleep(2000);

            //Drag and Drop the task to To-Do section
            tasksPage.MoveFromInProgressToToDo(taskName);
            log.Info("Drag and Drop the task to To-Do section.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_005_VerifyCompletedTasks()
        {
            Global.MethodName = "Tasks_005_VerifyCompletedTasks";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Drag and Drop the task to Completed section
            tasksPage.MoveFromToDoToCompleted(taskName);
            log.Info("Drag and Drop the task to In Progress section.");
            Thread.Sleep(2000);

            //Verify Task get displayed In Progress section
            tasksPage.VerifyTaskDisplayedCompletedSection(taskName);
            log.Info("Verify Task get displayed in In Progress section.");
            Thread.Sleep(2000);

            //Drag and Drop the task to To-Do section
            tasksPage.MoveFromCompletedToToDo(taskName);
            log.Info("Drag and Drop the task to To-Do section.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_006_CreateTaskAndVerify()
        {
            Global.MethodName = "Tasks_006_CreateTaskAndVerify";

            //Get UserName
            String userName = commonPage.GetUserName();

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Verify Task get displayed
            tasksPage.VerifyTaskDisplayed(taskName);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_007_VerifyTaskWindow()
        {
            Global.MethodName = "Tasks_007_VerifyTaskWindow";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            /*//Verify the Task Window Task Label
            tasksPage.VerifyTaskTitle();
            log.Info("Verify the Task Title.");
            Thread.Sleep(2000);*/

            //Verify the Task Window Delete This Task Link
            tasksPage.VerifyDeleteThisTaskLink();
            log.Info("Verify the Task Window Delete This Task Link.");
            Thread.Sleep(1000);

            //Verify the Task Window Add Due Date field
            tasksPage.VerifyAddDueDateText();
            log.Info("Verify the Task Window Add Due Date.");
            Thread.Sleep(1000);

            //Verify the Task Window Add Comment Div
            tasksPage.VerifyAddCommentDiv();
            log.Info("Verify the Task Window Add Comment Div.");
            Thread.Sleep(1000);

            //Verify the Task Window Files Plus Icon
            tasksPage.VerifyFilesPlusIcon();
            log.Info("Verify the Task Window Files Plus Icon.");
            Thread.Sleep(1000);

            //Verify the Task Window Attachment Icon
            tasksPage.VerifyAttachmentIcon();
            log.Info("Verify the Task Window Attachment Icon.");
            Thread.Sleep(1000);

            //Verify the Task Window Close icon
            tasksPage.VerifyTaskWindowCloseIcon();
            log.Info("Verify Task Window Close Icon.");
            Thread.Sleep(1000);

            //Click the Task Window Close icon
            tasksPage.ClickTaskWindowCloseIcon();
            log.Info("Click Task Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
        }               

        [Test]
        public void Tasks_016_PostCommentAndVerify()
        {
            Global.MethodName = "Tasks_016_PostCommentAndVerify";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Task Window Add Comment Div
            tasksPage.ClickAddCommentDiv();
            log.Info("Click add comment area.");
            Thread.Sleep(2000);

            //Enter the Comment in Text Area
            String addComment = readTasks.GetValue("AddTask", "addComment");
            tasksPage.EnterAddCommentText(addComment);
            log.Info("Enter comment in Text Area.");
            Thread.Sleep(2000);

            //Click the Post button for the message
            tasksPage.ClickAddCommentPostBtn();
            log.Info("Click the Post button for the comment.");
            Thread.Sleep(2000);

            //Verify the Add Comment Reply button
            tasksPage.VerifyAddCommentReplyBtn();
            log.Info("Verify the Add Comment Reply button.");
            Thread.Sleep(4000);

            //Click the Task Window Close icon
            tasksPage.ClickTaskWindowCloseIcon();
            log.Info("Click Task Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        /*[Test]
        public void Tasks_017_UploadAttachmentFileAndVerify()
        {
            Global.MethodName = "Tasks_013_UploadAttachmentFileAndVerify";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Add Comment Attachment Icon
            tasksPage.ClickAddCommentAttachIcon();
            log.Info("Click attachment icon under task window.");
            Thread.Sleep(2000);
            String startupPath = System.IO.Directory.GetCurrentDirectory() + "\\TestData";
            startupPath = startupPath + "\\no-testing-required-it-will-work.jpg";
            Console.WriteLine("Start up path: " + startupPath);
            SendKeys.SendWait(@startupPath);
            Thread.Sleep(2000);
            SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(5000);

            //Click the Post button for the message
            tasksPage.ClickAddCommentPostBtn();
            log.Info("Click the Post button for the comment.");
            Thread.Sleep(2000);

            //Click the Task Window Close icon
            tasksPage.ClickTaskWindowCloseIcon();
            log.Info("Click Task Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }*/

        [Test]
        public void Tasks_019_ReplyAddCommentAndVerify()
        {
            Global.MethodName = "Tasks_019_ReplyAddCommentAndVerify";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Task Window Add Comment Div
            tasksPage.ClickAddCommentDiv();
            log.Info("Click add comment area.");
            Thread.Sleep(2000);

            //Enter the Comment in Text Area
            String addComment = readTasks.GetValue("AddTask", "addComment");
            tasksPage.EnterAddCommentText(addComment);
            log.Info("Enter comment in Text Area.");
            Thread.Sleep(2000);

            //Click the Post button for the message
            tasksPage.ClickAddCommentPostBtn();
            log.Info("Click the Post button for the comment.");
            Thread.Sleep(2000);

            //Click the Add Comment Reply button
            tasksPage.ClickAddCommentReplyBtn();
            log.Info("Click the Add Comment Message Reply button.");
            Thread.Sleep(2000);

            tasksPage.PressTabKey();
            Thread.Sleep(2000);
            tasksPage.PressTabKey();
            Thread.Sleep(4000);

            //Enter text in the Add Comment Reply Text Area
            String enterReply = readTasks.GetValue("AddTask", "enterReply");
            tasksPage.EnterCommentReplyTextArea(enterReply);
            log.Info("Enter the Reply Comment Text Area");
            Thread.Sleep(4000);

            //Click the Post button for the message
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            tasksPage.ClickAddCommentPostBtn();
            log.Info("Click the Post button for the comment.");
            Thread.Sleep(4000);

            //Click the Task Window Close icon
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            tasksPage.ClickTaskWindowCloseIcon();
            log.Info("Click Task Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_020_DeleteTaskAndVerify()
        {
            Global.MethodName = "Tasks_020_DeleteTaskAndVerify";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Delete this task link
            tasksPage.ClickDeleteThisTaskLink();
            log.Info("Click the Delete This Task link.");
            Thread.Sleep(2000);

            //Verify the Delete Task Window
            tasksPage.VerifyDeleteTaskWindow();
            log.Info("Verify the Delete Event window.");
            Thread.Sleep(2000);

            //Verify the Delete Task Window No Button
            tasksPage.VerifyDeleteTaskWindowNoBtn();
            log.Info("Verify the Delete Task window No Button.");
            Thread.Sleep(2000);

            //Verify the Delete Event Window Yes Button
            tasksPage.VerifyDeleteTaskWindowYesBtn();
            log.Info("Verify the Delete Task window Yes Button.");
            Thread.Sleep(2000);

            //Click Delete Task Window No button
            tasksPage.PressDeleteEventWindowNoBtn();
            log.Info("Click Delete Event Window No button.");
            Thread.Sleep(2000);

            //Click the Task Window Close icon
            tasksPage.ClickTaskWindowCloseIcon();
            log.Info("Click Task Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_021_DeleteTaskNoBtn()
        {
            Global.MethodName = "Tasks_021_DeleteTaskNoBtn";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Delete this task link
            tasksPage.ClickDeleteThisTaskLink();
            log.Info("Click the Delete This Task link.");
            Thread.Sleep(2000);

            //Click the Delete Task Window No Button
            tasksPage.PressDeleteEventWindowNoBtn();
            log.Info("Click the Delete Task window No Button.");
            Thread.Sleep(2000);

            //Click the Task Window Close icon
            tasksPage.ClickTaskWindowCloseIcon();
            log.Info("Click Task Window Close Icon.");
            Thread.Sleep(2000);

            //Verify Task get displayed
            tasksPage.VerifyTaskDisplayed(taskName);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_022_DeleteTaskYesBtn()
        {
            Global.MethodName = "Tasks_022_DeleteTaskYesBtn";

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;
            CreateTask(taskName);
            log.Info("Create new Task.");
            Thread.Sleep(2000);

            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Delete this task link
            tasksPage.ClickDeleteThisTaskLink();
            log.Info("Click the Delete This Task link.");
            Thread.Sleep(2000);

            //Click the Delete Task Window Yes Button
            tasksPage.PressDeleteTaskWindowYesBtn();
            log.Info("Click the Delete Task window Yes Button.");
            Thread.Sleep(2000);

            //Verify Task does not get displayed
            tasksPage.VerifyTaskNotDisplayed(taskName);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);
        }
        
        [Test]
        public void Tasks_030_CreateTaskFromPlusIcon()
        {
            Global.MethodName = "Tasks_030_CreateTaskFromPlusIcon";

            //Click on the Plus icon at the top
            Thread.Sleep(2000);
            dashboardPage.ClickPlusIconOnTop();
            log.Info("Click on the Plus icon at the top.");

            //Select Task from the options displayed
            Thread.Sleep(1000);
            dashboardPage.SelectOptionFromPlusIcon("Task");

            //Create a new Task
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String taskName = readTasks.GetValue("AddTask", "taskName");
            taskName = taskName + builder;

            //Enter the Task Name
            tasksPage.EnterTaskName(taskName);
            log.Info("Enter the Task Name.");
            Thread.Sleep(2000);

            //Click the Add Task Plus icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click the Add Task Plus icon.");
            Thread.Sleep(4000);

            commonPage.RefreshPage();
            Thread.Sleep(3000);

            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(5000);

            //Delete Task
            DeleteTask(taskName);
            Thread.Sleep(2000);
        }        

        [Test]
        public void Tasks_031_VerifyTasksUnderProjects()
        {
            Global.MethodName = "Tasks_031_VerifyTasksUnderProjects";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            projectsPage.EnterProjectName("Project for Task");
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Verify Tasks tab
            projectsPage.VerifyTasksTab();
            log.Info("Verify Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_032_AddTaskUnderProjectWithMember()
        {
            Global.MethodName = "Tasks_032_AddTaskUnderProjectWithMember";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskFor");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Text Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Text Plus Icon.");
            Thread.Sleep(2000);

            //Click About Tab of Project
            projectsPage.ClickAboutTab();
            log.Info("Click the About tab of Prjects");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_033_AddTaskUnderProjectWithoutMember()
        {
            Global.MethodName = "Tasks_033_AddTaskUnderProjectWithoutMember";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(4000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Text Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Text Plus Icon.");
            Thread.Sleep(2000);

            //Click About Tab of Project
            projectsPage.ClickAboutTab();
            log.Info("Click the About tab of Prjects");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }
                
        [Test]
        public void Tasks_035_VerifyTaskWindowUnderProject()
        {
            Global.MethodName = "Tasks_035_VerifyTaskWindowUnderProject";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Verify Add Task Text field gets displayed
            tasksPage.VerifyAddTextUnderProjectTask();
            log.Info("Verify Add Task Text field gets displayed.");
            Thread.Sleep(1000);

            //Verify Add Task Text Plus Icon get displayed
            tasksPage.VerifyAddTextPlusIcon();
            log.Info("Verify Add Text Plus Icon get displayed.");
            Thread.Sleep(1000);

            //Verify To-Do section gets displayed
            tasksPage.VerifyToDoSection();
            log.Info("Verify To-Do section gets displayed.");
            Thread.Sleep(1000);

            //Verify In Progress section gets displayed
            tasksPage.VerifyInProgressSection();
            log.Info("Verify In Progress section gets displayed.");
            Thread.Sleep(1000);

            //Verify Completed section gets displayed
            tasksPage.VerifyCompletedSection();
            log.Info("Verify Completed section gets displayed.");

            //Click About Tab of Project
            projectsPage.ClickAboutTab();
            log.Info("Click the About tab of Prjects");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Tasks_036_AddTaskUnderProjectAndVerifyToDo()
        {
            Global.MethodName = "Tasks_036_AddTaskUnderProjectAndVerifyToDo";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Enter Project Task Description
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Verify Task gets displayed under To Do
            tasksPage.VerifyTaskDisplayed(taskDesc);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);

            //Click About Tab of Project
            projectsPage.ClickAboutTab();
            log.Info("Click the About tab of Prjects");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        /*[Test]
        public void Tasks_037_AddTaskUnderProjectAndAssignToSelf()
        {
            Global.MethodName = "Tasks_037_AddTaskUnderProjectAndAssignToSelf";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readTasks.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Press Enter Key
            tasksPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskFor");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Verify Task gets displayed under To Do
            tasksPage.VerifyTaskDisplayed(taskDesc);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);

            //Click About Tab of Project
            projectsPage.ClickAboutTab();
            log.Info("Click the About tab of Prjects");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }*/

        [Test]
        public void Tasks_038_AddTaskUnderProjectAndAssignToOther()
        {
            Global.MethodName = "Tasks_038_AddTaskUnderProjectAndAssignToOther";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(5000);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readTasks.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Press Enter Key
            tasksPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskForOther");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(3000);

            //Verify Task is not displayed under To Do
            tasksPage.VerifyTaskNotDisplayed(taskDesc);
            log.Info("Verify Task get displayed.");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);
                        
            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        /*[Test]
        public void Tasks_039_AddTaskUnderProjectAndAssignToSelfInProgress()
        {
            Global.MethodName = "Tasks_039_AddTaskUnderProjectAndAssignToSelfInProgress";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readTasks.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Press Enter Key
            tasksPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskFor");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Drag and Drop the task to In-Progress section
            tasksPage.MoveFromToDoToInProgress(taskDesc);
            log.Info("Drag and Drop the task to In Progress section.");
            Thread.Sleep(2000);

            //Verify Task get displayed In Progress section
            tasksPage.VerifyTaskDisplayedInProgressSection(taskDesc);
            log.Info("Verify Task get displayed in In Progress section.");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }*/

        /*Creates a Task under a project, assign the task to other project member
         * and move to in progress. Then verify that this task is not displayed under
         * in progress section of the logged in user through Tasks menu option from
         * left panel*/
        [Test]
        public void Tasks_040_AddTaskUnderProjectAndAssignToOtherInProgress()
        {
            Global.MethodName = "Tasks_040_AddTaskUnderProjectAndAssignToOtherInProgress";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readTasks.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Press Enter Key
            tasksPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskForOther");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Drag and Drop the task to In-Progress section
            tasksPage.MoveFromToDoToInProgress(taskDesc);
            log.Info("Drag and Drop the task to In Progress section.");
            Thread.Sleep(2000);

            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(3000);

            //Verify Task is not displayed under In Progress
            tasksPage.VerifyTaskNotDisplayedInProgressSection(taskDesc);
            log.Info("Verify Task not displayed.");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        /*Creates a Task under a project, assign the task self
         * and move to complete. Then verify that this task is displayed under
         * in progress section of the logged in user*/
       /* [Test]
        public void Tasks_041_AddTaskUnderProjectAndAssignToSelfComplete()
        {
            Global.MethodName = "Tasks_041_AddTaskUnderProjectAndAssignToSelfComplete";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readTasks.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Press Enter Key
            tasksPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(2000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(2000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskFor");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Drag and Drop the task to Complete section
            tasksPage.MoveFromToDoToCompleted(taskDesc);
            log.Info("Drag and Drop the task to Complete section.");
            Thread.Sleep(2000);

            //Verify Task get displayed Complete section
            tasksPage.VerifyTaskDisplayedCompletedSection(taskDesc);
            log.Info("Verify Task get displayed in Complete section.");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }*/

        /*Creates a Task under a project, assign the task to other project member
         * and move to Complete. Then verify that this task is not displayed under
         * Complete section of the logged in user through Tasks menu option from
         * left panel*/
        [Test]
        public void Tasks_042_AddTaskUnderProjectAndAssignToOtherComplete()
        {
            Global.MethodName = "Tasks_042_AddTaskUnderProjectAndAssignToOtherComplete";

            //Create a new project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readTasks.GetValue("AddProjectMember", "projectName");
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            projectsPage.EnterProjectDescription("Project Description");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(2000);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readTasks.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);
            Thread.Sleep(3000);

            //Press Enter Key
            tasksPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(4000);

            //Click Tasks tab
            projectsPage.ClickTasksTab();
            log.Info("Click Tasks tab on the created Project page.");
            Thread.Sleep(4000);

            //Address a user in Add Text field
            String taskFor = readTasks.GetValue("AddTask", "taskForOther");
            tasksPage.EnterAddTextUnderProjectTask(taskFor);
            Thread.Sleep(2000);
            tasksPage.PressEnterKey();
            String taskDesc = readTasks.GetValue("AddTask", "taskDesc");
            taskDesc = taskDesc + builder;
            tasksPage.EnterAddTextUnderProjectTask(taskDesc);
            log.Info("Enter Add Text field get under Projects Task.");
            Thread.Sleep(2000);

            //Click Add Task Plus Icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click Add Task Plus Icon.");
            Thread.Sleep(2000);

            //Drag and Drop the task to Complete section
            tasksPage.MoveFromToDoToCompleted(taskDesc);
            log.Info("Drag and Drop the task to Complete section.");
            Thread.Sleep(2000);

            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(3000);

            //Verify Task is not displayed under Completed
            tasksPage.VerifyTaskNotDisplayedCompleteSection(taskDesc);
            log.Info("Verify Task not displayed.");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }
    }
}