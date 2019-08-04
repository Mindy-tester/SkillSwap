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

            manageListing.Click();
            WebDriverWait wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

            for (int i = 0; i <= noOfPages.Count; i++)
            {
                //IList<IWebElement> noOfRows = Global.GlobalDefinitions.driver.FindElements(By.XPath("//td[@class='two wide']"));
                for (int j = 1; j <= 5; j++)

                {
                    //var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//td[@class = 'two wide']["+ j + "]")).Text;
                    Console.WriteLine(titleObj);
                    var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                    Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


                    if (titleObj == (GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                    {
                        Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill added Successfully");
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

            WebDriverWait wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(100));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            
            try
            {
                IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

                for (int i = 0; i <= noOfPages.Count; i++)
                {

                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                        Console.WriteLine(titleObj);
                        Console.WriteLine(categoryObj);
                        IWebElement deleteListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]"));

                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
                        {
                            //Explicit wait for delete btn
                            WebDriverWait deleteListingWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
                            IWebElement deleteListingObj = deleteListingWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]")));
                            //Console.WriteLine(titleObj);
                            //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                            deleteListing.Click();
                            //Explicit wait for accept btn
                            WebDriverWait acceptBtnWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
                            IWebElement acceptBtnObj = acceptBtnWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='ui icon positive right labeled button']")));
                            //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            acceptBtn.Click();

                            return;

                        }
                    }
                    //click next page
                    nextPageBtn.Click();
                }
            }


            catch (Exception)
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "deleted failed");
            }



        }
        public void ValidatedDeletedSkills()
        {

            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");

            IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
            try
            {
                for (int i = 0; i <= noOfPages.Count; i++)
                {
                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                        if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
                        {
                            Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill deleted failed");
                        }

                    }
                    //click next page
                    nextPageBtn.Click();
                }
            }
            catch (Exception)
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill deleted passed");
            }


        }



        public void UpdatedListing()
        {
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            SkillSharePage updSkillObj = new SkillSharePage();

            WebDriverWait manageListingWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            IWebElement manageListingObj = manageListingWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));

            //IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']"));
            IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

            for (int i = 0; i <= noOfPages.Count; i++)
            {

                for (int j = 1; j <= 5; j++)

                {
                    Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                    IWebElement updateListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[2]"));
                    Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    if (titleObj == "ttt" && categoryObj == "Programming & Tech")
                    {
                        //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        updateListing.Click();
                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        updSkillObj.SkillShare();
                        Base.Test.Log(LogStatus.Info, "Skill Updated");
                        return;
                    }
                }
                //click next page
                nextPageBtn.Click();

            }

        }
    }
}