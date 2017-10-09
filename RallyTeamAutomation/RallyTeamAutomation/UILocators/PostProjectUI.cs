using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class PostProjectUI
    {
        public readonly static By createProjectJobBtn = By.XPath("//nav[@class= 'rt-top-navbar']//ul[contains(@class, 'rt-top-navbar')]//button");
        public readonly static By newProjectOption = By.XPath("//nav[@class= 'rt-top-navbar']//ul[contains(@class, 'rt-top-navbar')]//a[text()= 'New Project']");
        public readonly static By jobPostingOption = By.XPath("//nav[@class= 'rt-top-navbar']//ul[contains(@class, 'rt-top-navbar')]//a[text()= 'Job Posting']");
        public readonly static By postAProjectTab = By.XPath("//div[contains(@class, 'pull-left')]//a[text()= 'POST A PROJECT']");
        public readonly static By removeProjectButton = By.XPath("//div[@class='col-md-12 m-t-sm text-center']//a[@class='btn btn-block rt-btn--white rt-btn--l m-t-sm col-lg-12 ng-scope']");
        public readonly static By joinProjectButton = By.XPath("//div[@class='row ng-scope']//div[@class='col-md-12 m-t-sm text-center']//a[contains(@ng-if,'!vm.opportunity.isOwner')]//span[@ng-if='!vm.currentSession.features.isAdminAccessOn' and (@class='ng-scope')]");
        
        /*Create Project elements*/
        public readonly static By projectName = By.XPath("//input[@name='abstract']");
        public readonly static By projectDesc = By.XPath("//form[@name= 'projectWizard1']//div[2]//span[@class= 'fr-placeholder']");
        public readonly static By projectDelv = By.XPath("//form[@name= 'projectWizard1']//div[3]//span[contains(text(), 'For example')]");
        public readonly static By projectCategory = By.XPath("//form[@name= 'projectWizard1']//div[4]//select");
        public readonly static By projectType = By.XPath("//form[@name= 'projectWizard1']//div[5]//select");
        public readonly static By startDate = By.XPath("//input[@title='start date']");
        public readonly static By todayDate = By.XPath("//table[contains(@class, 'table-condensed')]//td[@class= 'today day']");
        public readonly static By dueDate = By.XPath("//input[@title='due date']");
        public readonly static By ongoingCheckbox = By.XPath("//span[contains(@class, 'fa-square-o')]");
        public readonly static By uploadImageBtn = By.XPath("//label[contains(text(), 'Upload Image')]");
        public readonly static By saveDraftBtn = By.XPath("//a[contains(text(), 'Save Draft')]");
        public readonly static By continueBtn = By.XPath("//a[contains(text(), 'Continue')]");
        public readonly static By submitForApprovalBtn = By.XPath("//div[@class='rt-standalone-page__footer text-right m-t-md ng-scope']//a[contains(text(),'Submit for Approval')]");
        


        /*Staff Project elements*/
        public readonly static By skillsNeeded = By.XPath("//input[@placeholder='+ Add skills']");
        public readonly static By projectLocation = By.XPath("//input[@name='location']");
        public readonly static By remoteCheckbox = By.XPath("//div[@class= 'col-lg-12']//span[contains(@class, 'rt-checkbox')][1]");
        public readonly static By onsiteCheckbox = By.XPath("//div[@class= 'col-lg-12']//span[contains(@class, 'rt-checkbox')][2]");
        public readonly static By staff = By.XPath("//form[@name= 'projectWizard2']//div[4]//select");
        public readonly static By expectedTimeCommt = By.XPath("//form[@name= 'projectWizard2']//div[5]//select");
        public readonly static By membersNeeded = By.XPath("//input[@name= 'numberOfMembers']");
        public readonly static By memberName = By.XPath("//input[@placeholder= 'Enter a name...']");
        public readonly static By vendorName = By.XPath("//input[@placeholder= 'Enter a vendor name...']");
        public readonly static By addBtn = By.XPath("(//div[contains(text(), 'Add')])[1]");
        public readonly static By backBtn = By.XPath("//a[contains(text(), 'Back')]");
        public readonly static By removeMemberIcon = By.XPath("//div[contains(@class, 'rt-projects-members')]/div[2]//i");

        /*Publish Project elements*/
        public readonly static By publishBtn = By.XPath("//a[contains(text(),'Publish')]");
        public readonly static By privateRdoBtn = By.XPath("//div[@class='radio']//label//input[@ng-value='true']");

        public readonly static By publicRadio = By.XPath("//div[1]/label/input");
        public readonly static By privateRadio = By.XPath("//div[2]/label/input");

        /*Project About Page*/
        public readonly static By projectSettings = By.XPath("//div[contains(@class, 'rt-project-actions')]//button");
        public static By projectSettingsOptions(string variable)
        {
           return By.XPath("//div[contains(@class, 'rt-project-actions')]//a[contains(text(), '"+ variable + "')]");
        }
        public static By aboutProjectName(string variable)
        {
            return By.XPath("//div[contains(@class, 'rt-project__title') and contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectDesc(string variable)
        {
            return By.XPath("//div[contains(@class, 'fr-view')]//p[contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectDelv(string variable)
        {
            return By.XPath("//div[contains(@class, 'fr-view')]//p[contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectSkills(string variable)
        {
            return By.XPath("//a[contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectType(string variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectLocation(string variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectStaffingOnsite()
        {
            return By.XPath("//span[contains(text(), 'On-site')]");
        }
        public static By aboutProjectStaffingRemote()
        {
            return By.XPath("//span[contains(text(), 'Remote')]");
        }
        public readonly static By aboutProjectOnsite = By.XPath("//div[contains(text(), 'On-site')]");
        public readonly static By aboutProjectRemote = By.XPath("//div[contains(text(), 'Remote')]");
        public static By aboutProjectCategory(string variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public static By aboutProjectHours(string variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public static By aboutMemberName(string variable)
        {
            return By.XPath("//div[@class= 'rt-project-member__about']//a[contains(@tooltip, '" + variable + "')]");
        }
        public static By projectTabName(int variable,string tabName)
        {
           // return By.XPath("//div[@class= 'rt-project-member__about']//a[contains(@tooltip, '" + variable + "')]");
            return By.XPath("//ul[@class='nav nav-tabs']//li["+ variable + "]/a[contains(text(), '"+ tabName + "')]");
            
        }
        public readonly static By aboutProjectleaveProjectBtn = By.XPath("//a[contains(text(), 'Leave Project')]");
        public readonly static By aboutProjectMarkCompleteBtn = By.XPath("//a[contains(text(), 'Mark Complete')]");
        public readonly static By aboutProjectUpdateMetricsBtn = By.XPath("//a[contains(text(), 'Update Metrics')]");
        public readonly static By aboutProjectCompletedStatus = By.XPath("//span[text()= 'Completed']");
        public readonly static By aboutProjectInProgressStatus = By.XPath("//span[text()= 'In Progress']");
        public readonly static By aboutProjectClosedStatus = By.XPath("//span[text()= 'Closed']");
        public readonly static By deleteProjectWindowNoBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'No')]");
        public readonly static By deleteProjectWindowYesBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'Yes')]");
        public static By deleteProjectConfirmationMsg = By.XPath("//div[contains(@class, 'cg-notify-message')]//div[contains(text(), 'Project has been deleted.')]");
        public readonly static By requestToJoinBtn = By.XPath("//a[contains(@class, 'col-lg-12')]//span[contains(text(),'Request to Join')]");
        public readonly static By requestedBtn = By.XPath("//a[contains(text(),'Requested') and @disabled= 'disabled']");
        public readonly static By privateProjectIcon = By.XPath("//i[@class= 'fa fa-eye-slash']");

        /*Mark Complete elements*/
        public readonly static By markCompleteAwesomeMember1 = By.XPath("//rt-project-complete-user[@id='project-complete-user-0']//div[@tooltip= 'Awesome']");
        public readonly static By markCompleteAwesomeMember2 = By.XPath("//rt-project-complete-user[@id='project-complete-user-1']//div[@tooltip= 'Awesome']");
        public readonly static By CompleteProjectBtn = By.XPath("//button[contains(text(), 'Complete Project')]");
        public readonly static By CompleteProjectPointBtn = By.XPath("//div[@class='rt-modal__ellipsis-container--inner']//a[@class='rt-modal__ellipsis']//i[@class='fa fa-check-circle-o']");
        
        /*Projects Edit Page*/
        public readonly static By generalTab = By.XPath("//a[contains(text(), 'GENERAL')]");
        public readonly static By staffingInfoTab = By.XPath("//a[contains(text(), 'STAFFING INFO')]");
        public readonly static By saveBtn = By.XPath("//a[contains(text(), 'Save')]");
        public readonly static By projectStatusDropDown = By.XPath("//div[5]//select");
        public readonly static By projectOwnerDropDown = By.XPath("//div[4]//select");

        /*Projects Manage Team Page*/
        public readonly static By manageTeamSaveBtn = By.XPath("//button[contains(text(), 'Save')]");
        public readonly static By manageTeamAcceptIcon = By.XPath("//i[2]");
        public readonly static By manageTeamRejectIcon = By.XPath("//a[2]/span/i[2]");

        /*Projects Promote Project Page*/
        public readonly static By promoteBtn = By.XPath("//button[contains(text(), 'Promote')]");
        public readonly static By promoteSuccessMsg = By.XPath("//div[contains(text(), 'Boom! We have notified potential candidates about your project')]");








        public readonly static By specificallyAddMember = By.XPath("//input[@placeholder='Type a name or email']");
        public readonly static By specificallyAddMemberPlusIcon = By.XPath("//div[@class= 'rt-add-button']");
        public readonly static By createBtn = By.XPath("//a[text()= 'Create Project']");
        public readonly static By aboutTab = By.XPath("//a[text()= 'About']");
     
        public readonly static By Pending = By.XPath("//div[@class='text-center']//span[contains(text(),'Pending')]");

        public readonly static By approveBtn = By.XPath("//div[@class='ng-scope']//a[@class='btn rt-btn--primary rt-btn--l m-t-sm rt-project-approve-deny-buttons' and contains(text(),'Approve')]");
        public readonly static By denyButton = By.XPath("//div[@class='ng-scope']//a[@class='btn rt-btn--white rt-btn--l m-t-sm rt-project-approve-deny-buttons' and contains(text(),'Deny')]");


        public readonly static By Recruiting = By.XPath("//div[@class='text-center']//span[contains(text(),'Recruiting')]");
        public readonly static By updateMetricsBtn = By.XPath("//a[text()= 'Update Metrics']");
        public readonly static By addedMemberRemoveIcon = By.XPath("//div[contains(@class, 'rt-projects-members')]//i[contains(@class, 'rt-member__remove-btn')]");

        public readonly static By addMemberIcon = By.XPath("//li[1]/a/div/i");
        public readonly static By deleteProjectIcon = By.XPath("//li[2]/a/div/i");

        public static By suggestedMemberName(string variable)
        {
            return By.XPath("//a[contains(text(), '" + variable + "')]");
        }
        public readonly static By addMemberWindow = By.XPath("//div[@class= 'modal-dialog']//div[contains(text(), 'Add Members')]");
        public readonly static By addWindowAddButton = By.XPath("//div[@class= 'modal-dialog']//a[contains(text(), 'Add')]");
        public readonly static By addMemberText = By.XPath("//form[@name= 'addUsersForm']//input[contains(@class, 'input')]");
        public static By addMemberSuggList(string variable)
        {
            return By.XPath("//ul[contains(@class, 'suggestion-list')]//span[contains(text(), '" + variable + "')]");
        }
        public static By addMemberConfirmationMsg(string variable)
        {
            return By.XPath("//div[contains(@class, 'cg-notify-message')]//div[contains(text(), '" + variable + "')]");
        }
        public readonly static By addMemberWindowCloseIcon = By.XPath("//div[contains(@class, 'modal-dialog')]//i[contains(@class, 'fa fa-times')]");
        public readonly static By manageMemberWindow = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(), 'All Members')]");
        public readonly static By manageMemberSecondCrossIcon = By.XPath("//div[contains(@class, 'rt-modal__tab--scroll')]//div[2]//i[contains(@class, 'fa fa-times')]");
        public readonly static By manageMemberSecondRemoveBtn = By.XPath("//html/body/div[11]/div/div/div/div/div/div/div[2]/div[2]/button[1]");
        public readonly static By manageMemberSecondCancelBtn = By.XPath("//html/body/div[11]/div/div/div/div/div/div/div[2]/div[2]/button[2]");



        public readonly static By editGroupWindow = By.XPath("//div[contains(@class, 'ng-scope')]//span[contains(text(), 'Edit this Group')]");
        public readonly static By editGroupWindowCloseIcon = By.XPath("//i[contains(@class, 'fa fa-times')]");

        public readonly static By editGroupSaveBtn = By.XPath("//button[@value='Save']");
        public readonly static By editGroupCancelBtn = By.XPath("//a[contains(text(),'Cancel')]");

       
        public static By groupErrorMessage = By.XPath("//form[contains(@class, 'ng-invalid ng-invalid-required')]//span[contains(text(), 'Please correct the errors in the form to continue.')]");

        public readonly static By leaveGroupWindow = By.XPath("//div[contains(@class, 'modal-dialog')]//h3[contains(text(),'Are you sure you want to delete this group?')]");
        public readonly static By leaveGroupWindowNoBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'No')]");
        public readonly static By leaveGroupWindowYesBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'Yes')]");

        public readonly static By discussionTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Discussions')]");
        public readonly static By discussionMessageDiv = By.XPath("//div[contains(@class, 'message-main')]");
        public readonly static By discussionTypeMessageDiv = By.XPath("//div[contains(@class, 'ta-scroll-window')]");
        public readonly static By discussionTypeMessageArea = By.XPath("//div[contains(@id, 'taTextElement')]");
        public readonly static By discussionAttachIcon = By.XPath("//i[contains(@class, 'fa fa-paperclip')]");
        public static By discussionMsgPosted(String variable)
        {
            return By.XPath("//div[contains(@class, 'chat-activity-list')]//div[2]//p[contains(text(), '" + variable + "')]");
        }
        public readonly static By discussionReplyBtn = By.XPath("//div[contains(@class, 'chat-activity-list')]//div[2]//a[contains(text(), 'Reply')]");
        public readonly static By discussionReplyTextDiv = By.XPath("//div[contains(@class, 'chat-activity-list']//div[2]//div[contains(@class, 'media-body-replies')]");
        public readonly static By discussionReplyText = By.XPath("//form[contains(@class, 'ng-dirty')]//div[contains(@id, 'taTextElement')]");
        public readonly static By discussionReplyPostBtn = By.XPath("//div[2]/div/rt-activity-feed-post/div/form/div/div[2]/button");

        public readonly static By projectTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Projects')]");
        public readonly static By eventTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Events')]");

        public readonly static By privateProjectCheckbox = By.XPath("//span[contains(@class, 'rt-checkbox')]");
        
        public readonly static By publicProjectIcon = By.XPath("//a[contains(text(), 'Public')]");
        public readonly static By noProjectDisplayedMsg = By.XPath("//p[text()= 'No projects match the search criteria. Please try refining your search.']");

        // public readonly static By discussionPostBtn = By.XPath("//div[contains(@class, 'text-right')]//button[contains(@class, 'btn')]//strong[text()= 'Post']");
        public readonly static By discussionPostBtn = By.XPath("//div[contains(@class, '__toolbar__buttons')]//button[contains(@class,'btn')]//strong[text()='Post']");
        
        /*Project About Page elements*/
        public readonly static By projectOwner = By.XPath("//select[contains(@title, 'opp-user-id')]");

        //marketplace
        public readonly static By marketPlaceMenu = By.XPath("//div[@class='pull-left rt-top-navbar__links']//a[contains(text(),'MARKETPLACE')]");

        public readonly static By goRallyButton = By.XPath("//td[@class='content-pad center']//center//a[@class='rt-button']");


        public static By RecProjectNameOnPage(String variable)
        {
            return By.XPath("//div[@class='col-md-10 col-sm-12 col-xs-12 m-b-lg']/div[contains( text(), '" + variable + "')]");
            //return By.XPath("//span[contains(text(), '" + variable + "')]");
        }
    }
}
