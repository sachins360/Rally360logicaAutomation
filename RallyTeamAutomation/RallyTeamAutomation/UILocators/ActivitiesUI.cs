using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RallyTeam.UILocators
{
    public static class ActivitiesUI
    {
        public readonly static By activityFeedPage = By.XPath("//div[text()='Activity Feed']");
        public static By userNameActivity(String variable)
        {
            return By.XPath("//div[@class='chat-activity-list']//div[2]//a[contains(text(), '" + variable + "')]");
        }
        public readonly static By editIcon = By.XPath("//div[@class='chat-activity-list']//div[2]//i[contains(@class, 'fa fa-chevron-down')]");
        public readonly static By editMessageOption = By.XPath("//ul[1]//li[1]//a[text()='Edit Message']");
        public readonly static By deleteMessageOption = By.XPath("//ul[1]//li[2]//a[text()='Delete Message']");
        public readonly static By editDiv= By.XPath("//div[@class='chat-activity-list']//div[2]//div[contains(@class, 'ta-text')]");
        public readonly static By editDivText = By.XPath("//div[@class='chat-activity-list']//div[2]//div[contains(@class, 'ta-text')]//div[contains(@id, 'taTextElement')]");
        public readonly static By editDivAttachmentIcon = By.XPath("//div[@class='chat-activity-list']//div[2]//a[@class='rt-activity-post__file-uploader']");
        public readonly static By editDivCancelBtn = By.XPath("//div[@class='chat-activity-list']//div[2]//div[contains(@class, 'm-t-sm')]//a[1]//strong[text()='Cancel']");
        public readonly static By editDivPostBtn = By.XPath("//div[@class='chat-activity-list']//div[2]//div[contains(@class, 'm-t-sm')]//a[2]//strong[text()='Post']");

        public readonly static By createNewEventActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='created a new event: ']");
        public readonly static By createNewGroupActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='created a new group: ']");
        public readonly static By createNewProjectActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='created a new project: ']");
        public readonly static By joinEventActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='joined the event: ']");
        public readonly static By joinGroupActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='joined the group: ']");
        public readonly static By joinProjectActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='joined the project: ']");
        public readonly static By completeProjectActivity = By.XPath("//div[@class='chat-activity-list']//div[2]//span[text()='completed a project: ']");
        public static By nameActivity(String variable)
        {
            return By.XPath("//div[@class='chat-activity-list']//div[2]//a[contains(text(), '"+variable+"')]");
        }
        
    }
}
