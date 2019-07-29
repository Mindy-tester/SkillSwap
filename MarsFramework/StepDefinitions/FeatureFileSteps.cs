using MarsFramework.Global;
using MarsFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.StepDefinitions
{
    [Binding]
    public class FeatureFileSteps : Global.Base
    {
        [Given(@"User is on profile page")]
        public void GivenUserIsOnProfilePage()
        {
            //Explicit wait for Skill share button
            WebDriverWait skillSharewait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            IWebElement skillShareObj = skillSharewait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(), 'Share Skill')]")));
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(), 'Share Skill')]")).Click();

        }
        
        [When(@"user click on share skill and add skill")]
        public void WhenUserClickOnShareSkillAndAddSkill()
        {
            SkillSharePage skillObj = new SkillSharePage();
            skillObj.SkillShare();
        }

        [Then(@"new skill should display on manage listings")]
        public void ThenNewSkillShouldDisplayOnManageListings()
        {
            SkillSharePage skillObj = new SkillSharePage();
            skillObj.ValidateTheSkillAdded();

        }

        [When(@"user click on manage listings and click on edit listing")]
        public void WhenUserClickOnManageListingsAndClickOnEditListing()
        {
            ManageListingsPage updateSkillObj = new ManageListingsPage();
            updateSkillObj.UpdatedListing();
        }

        [Then(@"skill should display with new updates")]
        public void ThenSkillShouldDisplayWithNewUpdates()
        {
            Base.Test.Log(LogStatus.Info, "skill updated");
        }


        [When(@"user click on manage listings and click on delete listing")]
        public void WhenUserClickOnManageListingsAndClickOnDeleteListing()
        {
            ManageListingsPage manageListingObj = new ManageListingsPage();
            manageListingObj.DeleteListing();
        }
        
       
        
       
        
        [Then(@"skill should not display in listings")]
        public void ThenSkillShouldNotDisplayInListings()
        {
            ManageListingsPage manageListingObj = new ManageListingsPage();
            manageListingObj.ValidatedDeletedSkills();
        }
    }
}
