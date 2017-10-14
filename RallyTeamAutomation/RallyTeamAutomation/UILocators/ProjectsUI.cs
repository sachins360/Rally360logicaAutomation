using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class ProjectsUI
    {
        public readonly static By addProjectBtn = By.XPath("//*[contains(@class, 'title-action')]//span[contains(text(), 'Add Project')]");
        public readonly static By suggestedProjectBtn = By.XPath("//*[contains(@class, 'title-action')]//a[contains(text(), 'Suggested Projects')]");
        public readonly static By nameField = By.XPath("//*[contains(@class, 'form-control') and @name='abstract']");
        public readonly static By descriptionField = By.XPath("//*[contains(@class, 'form-control') and @name='description']");
        public readonly static By createBtn = By.XPath("//a[text()='Create']");
        public static By ProjectType(String variable)
        {
            return By.XPath("//div[@class='modal-content']//span[text()='" + variable + "']");
        }
        //public readonly static By allProjectDrpdwnLink = By.XPath("//a[@class='dropdown-toggle']//*[contains(text(), 'All Projects')]");
        public readonly static By allProjectDrpdwnLink = By.XPath("//span[@class= 'caret']");
        public static By ProjTypeIvePosted = By.XPath("//ul[@class='dropdown-menu']/li[3]");
        public static By ProjTypeRecruiting = By.XPath("//ul[@class='dropdown-menu']/li[5]");
        public static By ProjTypeInProgress = By.XPath("//ul[@class='dropdown-menu']/li[6]");
        public static By ProjTypeCompleted = By.XPath("//ul[@class='dropdown-menu']/li[7]");
        public static By ProjTypeClosed = By.XPath("//ul[@class='dropdown-menu']/li[8]");

        public static By ProjectNameOnPage(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable+"')]");
        }

        public readonly static By statusDropDown = By.XPath("//select[@title= 'opp-status']");
        public readonly static By startDate = By.XPath("//dd[2]/input");
        public readonly static By todayDate = By.XPath("//table[contains(@class, 'table-condensed')]//td[@class= 'today day']");
        public readonly static By dueDate = By.XPath("//dd[3]/input");
        public readonly static By location = By.XPath("//dd[4]/input[@name='location']");
        public readonly static By group = By.XPath("//dd[5]/select");
        public readonly static By eventSelect = By.XPath("//dd[6]/select");
        public readonly static By reward = By.XPath("//dd[7]/input[@name='reward']");
        public readonly static By projectOwner = By.XPath("//dd[1]/select");
        public readonly static By gitHubRepo = By.XPath("//div[contains(@class, 'rt-github-repo')]/select");
        public readonly static By markCompleteBtn = By.XPath("//a[contains(text(), 'Mark Complete')]");

        public readonly static By addMemberIcon = By.XPath("//i[@class= 'fa fa-user-plus']");
        public readonly static By shareProjectIcon = By.XPath("//i[@class= 'fa fa-share']");
        public readonly static By deleteProjectIcon = By.XPath("//i[@class= 'fa fa-trash-o']");


        public readonly static By discussionAddMemberIcon = By.XPath("//div[3]/div/div/ul/li/a/div/i");
        public readonly static By discussionShareProjectIcon = By.XPath("//div[3]/div/div/ul/li[2]/a/div/i");
        public readonly static By discussionDeleteProjectIcon = By.XPath("//div[3]/div/div/ul/li[3]/a/div/i");

        public readonly static By deleteProjectWindow = By.XPath("//div[contains(@class, 'modal-content')]//div[text()='Are you sure you want to delete this project?']");
        public readonly static By deleteProjectWindowNoBtn = By.XPath("//div[contains(@class, 'modal-content')]//a[contains(text(),'No')]");
        public readonly static By deleteProjectWindowYesBtn = By.XPath("//div[contains(@class, 'modal-content')]//a[contains(text(),'Yes')]");
        //public static By deleteGroupConfirmationMsg = By.XPath("//div[contains(@class, 'cg-notify-message')]//div[contains(text(), 'Group has been deleted.')]");
        
        public readonly static By completeProjectWindow = By.XPath("//div[contains(text(), 'Complete Your Project')]");
        public readonly static By completeProjStarIcon = By.XPath("//*[contains(@class, 'rt-stars-container')]//i[5]");
        public readonly static By completeProjMarkComplete = By.XPath("//button[text()= 'Complete Project']");

        public readonly static By requestToJoinBtn = By.XPath("//a[contains(text(),'Request to Join')]");
        public readonly static By requestSentBtn = By.XPath("//a[contains(text(),'Request Sent')]");
        public readonly static By addRequestedMember = By.XPath("//div[contains(@class, 'col-lg-12')]//div[3]//i[@class='fa fa-user']");
        public readonly static By pendingWindowAcceptIcon = By.XPath("//div[contains(@class, 'modal-content')]//a[@class='rt-user-row__approve']");
        public readonly static By pendingWindowDeclineIcon = By.XPath("//div[contains(@class, 'modal-content')]//a[@class='rt-user-row__decline']");
        public readonly static By pendingWindowCrossIcon = By.XPath("//div[contains(@class, 'modal-content')]//i[@class='fa fa-times']");

        public readonly static By leaveProjectIcon = By.XPath("//div[contains(@class, 'rt-project-actions')]//i[@class='fa fa-sign-out']");
        public readonly static By leaveProjectWindowNoBtn = By.XPath("//div[contains(@class, 'modal-content')]//a[contains(text(),'No')]");
        public readonly static By leaveProjectWindowYesBtn = By.XPath("//div[contains(@class, 'modal-content')]//a[contains(text(),'Yes')]");

        public readonly static By projectCreatedMsg = By.XPath("//div[contains(@class, 'cg-notify-message')]//div[contains(text(), 'Project successfully created.')]");

        public readonly static By aboutTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'About')]");
        public readonly static By discussionTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Discussions')]");
        public readonly static By tasksTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Tasks')]");
        public readonly static By filesTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Files')]");

        public readonly static By discussionMessageDiv = By.XPath("//form[@name='activityForm']//div[contains(@class, 'ta-scroll-window')]");
        public readonly static By discussionTypeMessageArea = By.XPath("//div[@class='fr-element fr-view']");
        //public readonly static By discussionTypeMessageArea = By.XPath("//form[@name= 'activityForm']//div[contains(@id, 'taTextElement')]");
        public readonly static By discussionPostBtn = By.XPath("//button[contains(@class, 'btn')]");
        public readonly static By discussionReplyBtn = By.XPath("//div[contains(@class, 'chat-activity-list')]//div[2]//a[contains(text(), 'Reply')]");
        public readonly static By discussionAttachIcon = By.XPath("//form[@name= 'activityForm']//i[contains(@class, 'fa fa-paperclip')]");

        public readonly static By addProjectDlg = By.XPath("//div[contains(@class, 'rt-modal__title')]/span[text()='Create a Project']");
        public readonly static By AddMemberButton = By.XPath("//a[contains(@class, 'rt-member__action') and @tooltip='Add members']/i]");
        public readonly static By addSomeoneText = By.XPath("//input[contains(@placeholder, 'Enter user')]");
        public readonly static By PlusIcon = By.XPath("//div[contains(@class, 'add-button') and contains(text(), '+')]");
        public readonly static By searchSkillsText = By.XPath("//input[@placeholder='What skills are you looking for?']");
        public readonly static By myTeamDiv = By.XPath("//div[@class='row m-t-xl rt-staffing-wizard__team']");
        public readonly static By doneBtn = By.XPath("//a[text()='Done']");
        public readonly static By closeAddMemberWindowIcon = By.XPath("//i[contains(@class, 'fa fa-times rt-close-tool')]");
        public static By addMemberSuggList(string variable)
        {
            return By.XPath("//ul[contains(@class, 'suggestion-list')]//span[contains(text(), '" + variable + "')]");
        }
        public readonly static By addMemberConfirmationMsg = By.XPath("//span[contains(text(), 'Your team is updated.')]");
        public readonly static By addedMemberRemoveIcon = By.XPath("//div[@class= 'col-lg-12 rt-projects-members']//i[contains(@class, 'rt-member__remove-btn')]");
        public readonly static By removeMemberWindow = By.XPath("//div[contains(@class, 'modal-content')]//div[contains(text(), 'Are you sure you want to remove')]");
        public readonly static By removeMemberNoBtn = By.XPath("//div[contains(@class, 'modal-content')]//a[contains(text(),'No')]");
        public readonly static By removeMemberYesBtn = By.XPath("//div[contains(@class, 'modal-content')]//a[contains(text(),'Yes')]");
        public static By VerifyProjectMemberName(String variable)
        {
            return By.XPath("//a[contains(text(),'" + variable + "')]");
        }
        public readonly static By VerifyTeamStatusType = By.XPath("//div[contains(@class, 'rt-find-teamates')]//tbody//tr[1]//td[2]");
        public readonly static By VerifyTeamStatusProjectRole = By.XPath("//div[contains(@class, 'rt-find-teamates')]//tbody//tr[1]//td[3]");
        public readonly static By VerifyTeamStatus = By.XPath("//div[contains(@class, 'rt-find-teamates')]//tbody//tr[1]//td[4]");

        public static By VerifyProjectName(String variable)
        {
            return By.XPath("//input[@name='abstract' and text()='" + variable + "')]");
        }

        public readonly static By nameRequired = By.XPath("//form[contains(@class, 'ng-pristine')]//div[1]//span[text()='* Field is required']");
        public readonly static By onlyNameEmptyMsg = By.XPath("//form[contains(@class, 'ng-invalid')]//div[1]//span[text()='* Field is required']");
        public readonly static By descRequired = By.XPath("//form[contains(@class, 'ng-pristine')]//div[2]//span[text()='* Field is required']");
        public readonly static By onlyDescEmptyMsg = By.XPath("//form[contains(@class, 'ng-invalid')]//div[2]//span[text()='* Field is required']");
        public readonly static By createProjectCloseIcon = By.XPath("//div[@class='modal-dialog']//i[@class='fa fa-times']");
        public readonly static By viewTeamStatus = By.XPath("//a[text()='View Team Status']");
        public static By viewProjectTeamMember(String variable)
        {
            return By.XPath("//table[@class, 'rt-find-teamates__candidates']//a[text()='" + variable + "']");
        }
        public readonly static By teamStatusCloseIcon = By.XPath("//div[@class='modal-content']//i[@class='fa fa-times']");
        //<addedmember><![CDATA[//a[contains(text(), '@variable')]]]></addedmember>
        /*<Suggitem><![CDATA[//ul[@class='suggestion-list']//span[contains(text(), '@variable')]]]></Suggitem>
        <confirmationmessage><![CDATA[//div[@class="cg-notify-message-template"]//span[contains(text(), 'Your team is updated')]]]></confirmationmessage>
        <AllProjectDrpdwnLink><![CDATA[//a[@class="dropdown-toggle"]//*[contains(text(), 'All Projects')]]]></AllProjectDrpdwnLink>
        <DroDownMenu><![CDATA[//ul[@class='dropdown-menu']//a[contains(text(), '@variable')]]]></DroDownMenu>
        <ProjectTitle><![CDATA[//div[@class="rt-project-tile"]//span[contains(text(), '@variable') and contains(@class, 'project-tile__title')]]]></ProjectTitle>
        <NavTab><![CDATA[//*[@class='nav nav-tabs']//a[contains(text(), '@variable')]]]></NavTab>


         public static By groupNameDashboard(string variable)
         {
             return By.XPath("//div[contains(text(), '" + variable + "')]");
         }*/

    }
}
