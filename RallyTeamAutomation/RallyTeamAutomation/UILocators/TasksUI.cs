using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class TasksUI
    {
        public readonly static By tasksPage = By.XPath("//div[contains(@class, 'rt-sub-navbar') and text()='Tasks']");
        public readonly static By addTaskText = By.XPath("//input[@name='title']");
        public readonly static By toDoSection = By.XPath("//span[text() ='To-do']");
        public readonly static By toDoUl = By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[1]//ul");
        public readonly static By inProgressSection = By.XPath("//span[text() ='In Progress']");
        public readonly static By inProgressUl = By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[3]//ul");
        public readonly static By completedSection = By.XPath("//span[text() ='Completed']");
        public readonly static By completedUl = By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[5]//ul");
        public readonly static By addProjectTask = By.XPath("//form[@name='taskCreateForm']//input");
        public readonly static By addTaskPlusIcon = By.XPath("//i[@class= 'fa fa-plus']");
        public static By taskDisplayed(String variable)
        {
            return By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[1]//li[contains(@class, 'rt-kanban-task-item')]//span[text()='" + variable+"']");
        }
        public static By taskUserName(String variable)
        {
            return By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[1]//li[contains(@class, 'rt-kanban-task-item')]//span[text()='" + variable + "']");
        }
        public static By taskDisplayedInProgress(String variable)
        {
            return By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[3]//li[contains(@class, 'rt-kanban-task-item')]//span[text()='" + variable + "']");
        }
        public static By taskDisplayedCompleted(String variable)
        {
            return By.XPath("//div[@class= 'rt-kanban-row rt-kanban-row--body']//div[5]//li[contains(@class, 'rt-kanban-task-item')]//span[text()='" + variable + "']");
        }
        public readonly static By AllTasks = By.XPath("//ul[contains(@class, 'rt-tasklist')]");
        public readonly static By AllCompletedTasks = By.XPath("//div[@ng-show='!vm.isActiveShown()']//ul[contains(@class, 'rt-tasklist')]");

        public readonly static By deleteThisTask = By.XPath("//a[text()='Delete this task']");
        public readonly static By deleteTaskWindow = By.XPath("//div[contains(@class, 'modal-dialog')]//div[contains(text(),'Are you sure you want to delete this task?')]");
        public readonly static By deleteTaskWindowNoBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'No')]");
        public readonly static By deleteTaskWindowYesBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'Yes')]");

        /* Task Details Section */
        public readonly static By addDueDate = By.XPath("//input[@name='duedate']");
        public readonly static By addCommentDiv = By.XPath("//form[@name='activityForm']//div[contains(@class, 'ta-scroll-window')]");
        public readonly static By commentText = By.XPath("//div[contains(@id, 'taTextElement')]");
        public readonly static By attachmentIcon = By.XPath("//i[@class='fa fa-paperclip']");
        public readonly static By filesPlusIcon = By.XPath("//i[@class='fa fa-plus-square']");
        public readonly static By taskName = By.XPath("//input[@name= 'title']");
        public readonly static By closeTaskIcon = By.XPath("//i[contains(@class, 'fa fa-times')]");
        public readonly static By addCommentPostBtn = By.XPath("//div[contains(@class, 'text-right')]//button[contains(@class, 'btn')]");
        public readonly static By addCommentReplyBtn = By.XPath("//div[contains(@class, 'chat-activity-list')]//div[2]//a[contains(text(), 'Reply')]");
        public readonly static By addCommentAttachIcon = By.XPath("//i[contains(@class, 'fa fa-paperclip')]");
        public readonly static By addCommentReplyText = By.XPath("//form[@name= 'activityForm']//div[contains(@id, 'taTextElement')]");
        public readonly static By addTaskCancel = By.XPath("//button[text()='Cancel']");
    }
}
