using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageRequestsPage
    {
        public ManageRequestsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region
        //Intilaize web elements

        //click on Recieved Requests
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Received Requests')]")]
        private IWebElement recievedRequests { get; set; }

        //click on sent requests
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sent Requests')]")]
        private IWebElement sentRequests { get; set; }

        //Enter skill in seach skills
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search skills']")]
        private IWebElement searchSkills { get; set; }

        //click on all categories
        [FindsBy(How = How.XPath, Using = "//b[contains(text(),'All Categories')]")]
        private IWebElement allCategories { get; set; }


        //click on chat
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Chat')]")]
        private IWebElement chatButton { get; set; }

        #endregion

        public void Requests()
        {

            Actions manageRequestaction = new Actions(Global.GlobalDefinitions.driver);
            manageRequestaction.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), 'Manage Requests')]"))).Click().Build().Perform();
            //wait for Recieved Request
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//a[contains(text(),'Received Requests')])", "XPath");
            //click on recieved requests
            recievedRequests.Click();
            Base.Test.Log(LogStatus.Pass, "open Recieved Request, Test passed");
            Actions action = new Actions(Global.GlobalDefinitions.driver);
            action.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), 'Manage Requests')]"))).Click().Build().Perform();
            //wait for sent requests
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//a[contains(text(),'Sent Requests')])", "XPath");
            //click on sent requets
            sentRequests.Click();
            Base.Test.Log(LogStatus.Pass, "open send requests, Test passed");



        }

        public void SearchSkills()
        {
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");

            //wait for skill searchbox
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//input[@placeholder='Search skills']"), 10);


            //Enter skill in skill search
            searchSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));
            searchSkills.SendKeys(Keys.Enter);

            // wait for All categories
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//b[contains(text(),'All Categories')])", "XPath");

            //click on all category
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]")).Click();

            //wait for category
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//a[@role = 'listitem' and text() ='Graphics & Design']"), 10);

            //click on category
            
            GlobalDefinitions.driver.FindElement(By.XPath("//a[@role = 'listitem' and text() ='Graphics & Design']")).Click();

            Base.Test.Log(LogStatus.Pass, "Search Skill by category successfully");
            //wait for sub category  
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//a[@role = 'listitem' and text() = 'Logo Design']"), 10);
           
            //click on sub category
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[@role = 'listitem' and text() = 'Logo Design']")).Click();

           Base.Test.Log(LogStatus.Pass, "Search Skill by sub category successfully");

            //click onsite
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Onsite')]")).Click();
            GlobalDefinitions.wait(10);

            //click on online 
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Online')]")).Click();

            //click on chat button
            chatButton.Click();

            //click on notification
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']")).Click();




        }


    }
}