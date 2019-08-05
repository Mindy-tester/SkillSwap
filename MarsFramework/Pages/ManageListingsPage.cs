using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

using System.Threading;

namespace MarsFramework.Pages
{
    class ManageListingsPage
    {
        public ManageListingsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        #region  Initialize Web Elements 

        //click on Manage Listings
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement manageListing { get; set; }



        //click on next page
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement nextPageBtn { get; set; }

        //click on accept
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement acceptBtn { get; set; }

        #endregion
        public void ValidateTheSkillAdded()
        {
            //click on Manage Listings
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            //wait for manage listing
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
            //number of pages
            IList<IWebElement> noOfPages = GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

            for (int i = 0; i <= noOfPages.Count; i++)
            {

                for (int j = 1; j <= 5; j++)

                {
                    GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tr[1]//td[3]"), 10);
                    var titleObj = GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[3]")).Text;
                    Console.WriteLine(titleObj);
                    GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    if (titleObj == (GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                    {
                        Base.Test.Log(LogStatus.Pass, "Add Skill successfully, Test passed");
                        return;
                    }

                }
                //click next page
                nextPageBtn.Click();
            }

        }
        public void DeleteListing()
        {
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");

            //wait for manage listing
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
                                 

            while(true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tr[1]//td[3]"), 10);
                    var categoryObj = GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[2]")).Text;
                    var titleObj = GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[3]")).Text;

                    Console.WriteLine(titleObj);
                    Console.WriteLine(categoryObj);
                    IWebElement deleteListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[8]//i[3]"));

                    GlobalDefinitions.wait(10);
                    if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
                    {
                        //wait for delete btn
                        GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//tr[" + j + "]//td[8]//i[3])", "XPath");

                        deleteListing.Click();
                        //wait for accept btn
                        GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//button[@class='ui icon positive right labeled button'])", "XPath");
                        acceptBtn.Click();

                        Base.Test.Log(LogStatus.Pass, "Skill deleted successfully, Test passed");

                        return;
                    }
                }
                //click next page
                nextPageBtn.Click();
            }

        }
       


        public void UpdatedListing()
        {
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");

            SkillSharePage updSkillObj = new SkillSharePage();

            //wait for manage listing
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//h2[contains(text(),'Manage Listings')]"), 10);
                                   
            while(true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tr[1]//td[3]"), 10);
                    var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[2]")).Text;
                    var titleObj = GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[3]")).Text;

                    IWebElement updateListing = GlobalDefinitions.driver.FindElement(By.XPath("//tr["+ j + "]//td[8]//i[2]"));
                    GlobalDefinitions.wait(10);
                    if (titleObj == "ttt" && categoryObj == "Programming & Tech")
                    {
                        //wait for update btn
                        GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//tr[" + j + "]//td[8]//i[2])", "XPath");
                        updateListing.Click();
                        GlobalDefinitions.wait(10);
                        updSkillObj.SkillShare();
                        Base.Test.Log(LogStatus.Pass, "Skill updated successfully, Test passed");
                        return;
                    }
                }
                //click next page
                nextPageBtn.Click();

            }

        }
    }
}