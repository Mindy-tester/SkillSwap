using System;
using TechTalk.SpecFlow;

namespace SpecflowPage.StepDefinitions
{
    [Binding]
    public class ShareSkillFeature1Steps
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
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user click on manage listings and click on edit listing")]
        public void WhenUserClickOnManageListingsAndClickOnEditListing()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user click on manage listings and click on delete listing")]
        public void WhenUserClickOnManageListingsAndClickOnDeleteListing()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"new skill should display on manage listings")]
        public void ThenNewSkillShouldDisplayOnManageListings()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"skill should display with new updates")]
        public void ThenSkillShouldDisplayWithNewUpdates()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"skill should not display in listings")]
        public void ThenSkillShouldNotDisplayInListings()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
