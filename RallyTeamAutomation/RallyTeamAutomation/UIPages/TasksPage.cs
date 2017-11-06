using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace RallyTeam.UIPages
{
    public class TasksPage : BasePage
    {
        CommonMethods commonPage;

        public TasksPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Press Enter Key
        public void PressEnterKey()
        {
            _driver.PressKeyBoardEnter();
        }

        //Press Tab Key
        public void PressTabKey()
        {
            _driver.PressKeyBoardTab();
        }

        //Verify Tasks menu option
        public void VerifyTasksMenuOption()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.sideNavBar("Tasks"));
        }

        //Click on Tasks menu option
        public void ClickTasksMenu()
        {
            _driver.WaitForElementAvailableAtDOM(DashboardUI.sideNavBar("Tasks"), 1);
            _driver.SafeClick(DashboardUI.sideNavBar("Tasks"));
        }

        //Assert the Tasks screen displayed
        public void VerifyTasksScreenDisplayed()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.tasksPage);
        }

        //Assert the To-Do section
        public void VerifyToDoSection()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.toDoSection);
        }

        //Assert the In Progress section
        public void VerifyInProgressSection()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.inProgressSection);
        }

        //Assert the Completed section
        public void VerifyCompletedSection()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.completedSection);
        }

        

        //Assert the Add Task Text field
        public void VerifyAddTaskText()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.addTaskText);
        }

        //Assert the Add Text field under Projects Task
        public void VerifyAddTextUnderProjectTask()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.addProjectTask);
        }

        //Assert the Add Text Plus Icon
        public void VerifyAddTextPlusIcon()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.addTaskPlusIcon);
        }

        //Assert the Error Message
        public void VerifyErrorMessage()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.errorMessage, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.errorMessage);
        }

        //Enter Task Name
        public void EnterTaskName(String taskName)
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addTaskText, 1);
            _driver.SafeEnterText(TasksUI.addTaskText, taskName);
        }

        //Press Add Task Plus Icon
        public void ClickAddTaskPlusIcon()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addTaskPlusIcon, 1);
            _driver.SafeClick(TasksUI.addTaskPlusIcon);
        }

        //Assert the Task displayed
        public void VerifyTaskDisplayed(String taskName)
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.taskDisplayed(taskName), 1);
            _assertHelper.AssertElementDisplayed(TasksUI.taskDisplayed(taskName));
        }

        //Assert the Task is not displayed
        public void VerifyTaskNotDisplayed(String taskName)
        {
            _assertHelper.AssertElementNotDisplayed(TasksUI.taskDisplayed(taskName));
        }

        //Assert the Task User Name displayed
        public void VerifyTaskUserNameDisplayed(String taskName)
        {
            _assertHelper.AssertElementDisplayed(TasksUI.taskUserName(taskName));
        }

        //Assert the Task displayed In Progress Section
        public void VerifyTaskDisplayedInProgressSection(String taskName)
        {
            _assertHelper.AssertElementDisplayed(TasksUI.taskDisplayedInProgress(taskName));
        }

        //Assert the Task is not displayed In Progress Section
        public void VerifyTaskNotDisplayedInProgressSection(String taskName)
        {
            _assertHelper.AssertElementNotDisplayed(TasksUI.taskDisplayedInProgress(taskName));
        }

        //Assert the Task displayed Completed Section
        public void VerifyTaskDisplayedCompletedSection(String taskName)
        {
            _assertHelper.AssertElementDisplayed(TasksUI.taskDisplayedCompleted(taskName));
        }

        //Assert the Task is not displayed Complete Section
        public void VerifyTaskNotDisplayedCompleteSection(String taskName)
        {
            _assertHelper.AssertElementNotDisplayed(TasksUI.taskDisplayedCompleted(taskName));
        }

        //Drag and Drop a task to In Progress section
        public void MoveFromToDoToInProgress(String taskName)
        {
            _driver.DragAndDropElementUsingAction(TasksUI.taskDisplayed(taskName), TasksUI.inProgressUl);
        }

        //Drag and Drop a task to Completed section
        public void MoveFromToDoToCompleted(String taskName)
        {
            _driver.DragAndDropElementUsingAction(TasksUI.taskDisplayed(taskName), TasksUI.completedUl);
        }

        //Drag and Drop a task from In Progress To To Do section
        public void MoveFromInProgressToToDo(String taskName)
        {
            _driver.DragAndDropElementUsingAction(TasksUI.taskDisplayedInProgress(taskName), TasksUI.toDoUl);
        }

        //Drag and Drop a task from In Progress To To Do section
        public void MoveFromCompletedToToDo(String taskName)
        {
            _driver.DragAndDropElementUsingAction(TasksUI.taskDisplayedCompleted(taskName), TasksUI.toDoUl);
        }

        //Get All the Tasks under a UI and Mark Complete the related Task
        public void MarkTaskCompleteCheckBox(String text)
        {
            IWebElement ulItems = _driver.FindElement(TasksUI.AllTasks);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine(liItems[i].FindElement(By.XPath("//span[3]")).Text);
                if (liItems[i].FindElement(By.XPath("//span[3]")).Text == text)
                {
                    IWebElement matchedItem = liItems[i].FindElement(By.XPath("//span[2]"));
                    By m = By.XPath("//ul[contains(@class, 'rt-tasklist')]//li[" + i + "]//span[2]");
                    _driver.SafeClick(m);
                    break;
                }
            }
        }

        //Get All the Tasks under a UI and Mark Incomplete the related Task
        public void MarkTaskIncompleteCheckBox(String text)
        {
            IWebElement ulItems = _driver.FindElement(TasksUI.AllCompletedTasks);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Inside for loop");
                String s = liItems[i-1].FindElement(By.XPath("//span[3]")).Text;
                Console.WriteLine(s);
                if (liItems[i-1].FindElement(By.XPath("//span[3]")).Text == text)
                {
                    IWebElement matchedItem = liItems[i-1].FindElement(By.XPath("//span[2]"));
                    By m = By.XPath("//div[@ng-show='!vm.isActiveShown()']//ul[contains(@class, 'rt-tasklist')]//li[" + i + "]//span[2]");
                    _driver.SafeClick(m);
                    break;
                }
            }
        }

        //Get All the Tasks under a UI and assert the Verify Mark Complete check-box
        public void VerifyMarkCompleteCheckBox(String text)
        {
            IWebElement ulItems = _driver.FindElement(TasksUI.AllTasks);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine(liItems[i].FindElement(By.XPath("//span[3]")).Text);
                if (liItems[i].FindElement(By.XPath("//span[3]")).Text == text)
                {
                    try
                    {
                        IWebElement matchedItem = liItems[i].FindElement(By.XPath("//span[2]"));
                        NUnit.Framework.Assert.IsTrue(matchedItem.Displayed);
                        break;
                    }
                    catch (Exception e)
                    {
                        UtilityHelper.TakeScreenshot(_driver);
                        String error = "Expected element to be displayed but did not.";
                        Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                        NUnit.Framework.Assert.Fail(error);
                        Console.WriteLine("000");
                    }
                }
            }
        }

        //Get All the Tasks under a UI and assert the Verify Menu icon
        public void VerifyTaskMenu(String text)
        {
            IWebElement ulItems = _driver.FindElement(TasksUI.AllTasks);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            for (int i = 1; i <= count; i++)
            {
                if (liItems[i].FindElement(By.XPath("//span[3]")).Text == text)
                {
                    try
                    {
                        IWebElement matchedItem = liItems[i].FindElement(By.XPath("//span[1]"));
                        NUnit.Framework.Assert.IsTrue(matchedItem.Displayed);
                        break;
                    }
                    catch (Exception e)
                    {
                        UtilityHelper.TakeScreenshot(_driver);
                        String error = "Expected element to be displayed but did not.";
                        Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                        NUnit.Framework.Assert.Fail(error);
                        Console.WriteLine("000");
                    }
                }
            }
        }

        //Get All the Tasks under a UI and assert the Verify the Task Add Due Date
        public void VerifyTaskAddDueDate(String text)
        {
            IWebElement ulItems = _driver.FindElement(TasksUI.AllTasks);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine(liItems[i].FindElement(By.XPath("//span[3]")).Text);
                if (liItems[i].FindElement(By.XPath("//span[3]")).Text == text)
                {
                    try
                    {
                        IWebElement matchedItem = liItems[i].FindElement(By.XPath("//span[4]//span[text()='Add due date']"));
                        NUnit.Framework.Assert.IsTrue(matchedItem.Displayed);
                        break;
                    }
                    catch (Exception e)
                    {
                        UtilityHelper.TakeScreenshot(_driver);
                        String error = "Expected element to be displayed but did not.";
                        Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                        NUnit.Framework.Assert.Fail(error);
                        Console.WriteLine("000");
                    }
                }
            }
        }

        //Get All the Tasks under a UI and press the Verify the Task Add Due Date
        public void ClickTaskAddDueDate(String text)
        {
            IWebElement ulItems = _driver.FindElement(TasksUI.AllTasks);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine(liItems[i].FindElement(By.XPath("//span[3]")).Text);
                if (liItems[i].FindElement(By.XPath("//span[3]")).Text == text)
                {
                    try
                    {
                        IWebElement matchedItem = liItems[i].FindElement(By.XPath("//span[4]//span[text()='Add due date']"));
                        matchedItem.Click();
                        break;
                    }
                    catch (Exception e)
                    {
                        UtilityHelper.TakeScreenshot(_driver);
                        String error = "Expected element to be displayed but did not.";
                        Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                        NUnit.Framework.Assert.Fail(error);
                        Console.WriteLine("000");
                    }
                }
            }
        }

        //Click the Task displayed
        public void ClickTaskDisplayed(String taskName)
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.taskDisplayed(taskName), 1);
            _driver.SafeClick(TasksUI.taskDisplayed(taskName));
        }

        //Assert the Task Displayed under Task section
        public void VerifyTaskTitle()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.taskName);
        }

        //Assert the Task Add Due Date under Task section
        public void VerifyAddDueDateText()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.addDueDate);
        }

        //Assert Delete This Task link under Task section
        public void VerifyDeleteThisTaskLink()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.deleteThisTask);
        }

        //Assert the Add Comment div under Task section
        public void VerifyAddCommentDiv()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.addCommentDiv);
        }

        //Assert the Attachment icon under Task section
        public void VerifyAttachmentIcon()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.attachmentIcon);
        }

        //Assert the Files Plus Icon under Task section
        public void VerifyFilesPlusIcon()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.filesPlusIcon);
        }

        //Assert the Task Section close icon
        public void VerifyTaskWindowCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(TasksUI.closeTaskIcon);
        }

        //Press the Task Section close icon
        public void ClickTaskWindowCloseIcon()
        {
            _driver.SafeClick(TasksUI.closeTaskIcon);
        }

        //Enter the Task Displayed under Task section
        public void EnterAddDueDateText(String addDueDate)
        {
            _driver.SafeEnterText(TasksUI.addDueDate, addDueDate);
        }

        //Enter the Add Task Text field under Projects Task
        public void EnterAddTextUnderProjectTask(String variable)
        {
            _driver.SafeEnterText(TasksUI.addProjectTask, variable);
        }

        //Assert the Add Comment div under Task section
        public void ClickAddCommentDiv()
        {
            _driver.SafeClick(TasksUI.addCommentDiv);
        }

        //Enter the Task Add Comment under Task section
        public void EnterAddCommentText(String addComment)
        {
            _driver.SafeEnterText(TasksUI.commentText, addComment);
        }

        //Press the Task Window Add Comment Post button
        public void ClickAddCommentPostBtn()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addCommentPostBtn, 1);
            _driver.SafeClick(TasksUI.addCommentPostBtn);
        }

        //Assert the Task Window Add Comment Reply button
        public void VerifyAddCommentReplyBtn()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addCommentReplyBtn, 1);
            _assertHelper.AssertElementDisplayed(TasksUI.addCommentReplyBtn);
        }

        //Press the Task Window Add Comment Attachment Icon
        public void ClickAddCommentAttachIcon()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addCommentAttachIcon, 1);
            _driver.SafeClick(TasksUI.addCommentAttachIcon);
        }

        //Press the Add Comment Reply button
        public void ClickAddCommentReplyBtn()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addCommentReplyBtn, 1);
            _driver.SafeClick(TasksUI.addCommentReplyBtn);
        }

        //Enter the comment in the Reply Text Area
        public void EnterCommentReplyTextArea(String message)
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.addCommentReplyText, 1);
            _driver.SafeEnterText(TasksUI.addCommentReplyText, message);
        }

        //Press Delete this task link
        public void ClickDeleteThisTaskLink()
        {
            _driver.SafeClick(TasksUI.deleteThisTask);
        }

        //Assert Delete Task Window on click of Delete Task link
        public void VerifyDeleteTaskWindow()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.deleteTaskWindow, 1);
            _assertHelper.AssertElementDisplayed(TasksUI.deleteTaskWindow);
        }

        //Assert Delete Task Window No Btn
        public void VerifyDeleteTaskWindowNoBtn()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.deleteTaskWindowNoBtn, 1);
            _assertHelper.AssertElementDisplayed(TasksUI.deleteTaskWindowNoBtn);
        }

        //Assert Delete Task Window Yes Btn
        public void VerifyDeleteTaskWindowYesBtn()
        {
            _driver.WaitForElementAvailableAtDOM(TasksUI.deleteTaskWindowYesBtn, 1);
            _assertHelper.AssertElementDisplayed(TasksUI.deleteTaskWindowYesBtn);
        }

        //Press No Button from the Delete Event Window
        public void PressDeleteEventWindowNoBtn()
        {
            _driver.SafeClick(TasksUI.deleteTaskWindowNoBtn);
        }

        //Press Yes Button from the Delete Task Window
        public void PressDeleteTaskWindowYesBtn()
        {
            _driver.SafeClick(TasksUI.deleteTaskWindowYesBtn);
        }

        //Press Add Task Cancel button
        public void PressAddTaskCancelBtn()
        {
            _driver.SafeClick(TasksUI.addTaskCancel);
        }

    }
}
