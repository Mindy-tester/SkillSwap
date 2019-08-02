using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class SkillSharePage
    {

        public SkillSharePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements    
        //Click on share skill
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Share Skill')]")]
        private IWebElement shareSkillBtn { get; set; }

        //Title
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement addTitle { get; set; }

        //Description
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement addDescription { get; set; }

        //Category
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement addCategory { get; set; }


        //Subcategory
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement addSubCategory { get; set; }

        //Tags
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement addTags { get; set; }

        //Hourly basis ServiceType

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Hourly basis service')]")]
        private IWebElement hourlyService { get; set; }

        //one off ServiceType
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'One-off service')]")]
        private IWebElement oneOffService { get; set; }

        //onsite location type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType' and @value = '0']")]
        private IWebElement onsiteBtn { get; set; }

        //online location type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType' and @value = '1']")]
        private IWebElement onlineBtn { get; set; }

        //Select start date from calendar
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Start date']")]
        private IWebElement startDate { get; set; }

        //Select end date from calendar
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='End date']")]
        private IWebElement endDate { get; set; }

        //credit

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement credit { get; set; }

        //skill exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement skillExchange { get; set; }

        //Work Samples
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement uploadFile { get; set; }

        //Active
        [FindsBy(How = How.XPath, Using = "//label[text()= 'Active']")]
        private IWebElement activeBtn { get; set; }

        //Hidden
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Hidden')]")]
        private IWebElement hiddenBtn { get; set; }


        //Save
        [FindsBy(How = How.XPath, Using = "//input[@value = 'Save']")]
        private IWebElement saveBtn { get; set; }

        //Next page
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement nextPageBtn { get; set; }
        #endregion

        public void SkillShare()
        {
            //wait for Skill share button
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//a[contains(text(), 'Share Skill')])", "XPath");

            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            shareSkillBtn.Click();


            //wait for Title textbox
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//h3[contains(text(),'Title')]"), 10);

            //add Title
            addTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Base.Test.Log(LogStatus.Pass, "Add Title Successfully, Test passed");

            //add Description
            addDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Base.Test.Log(LogStatus.Pass, "Add Description Successfully, Test passed");


            // wait for Select Category
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//select[@name='categoryId'])", "XPath");

            //select category        
            SelectElement categoryObj = new SelectElement(addCategory);
            categoryObj.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            Base.Test.Log(LogStatus.Pass, "Add category successfully, Test passed");


            // wait for sub category
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//select[@name='subcategoryId'])", "XPath");

            //Select Sub Category
            SelectElement subCategoryObj = new SelectElement(addSubCategory);
            subCategoryObj.SelectByValue(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            Base.Test.Log(LogStatus.Pass, "Add subcategory successfully, Test passed");

            //add Tags
            addTags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            addTags.SendKeys(Keys.Enter);
            Base.Test.Log(LogStatus.Pass, "Add Tags successfully, Test passed");

            //Select Service Type
            switch (GlobalDefinitions.ExcelLib.ReadData(2, "Location"))
            {
                case "One-off service":
                    oneOffService.Click();
                    break;

                case "Hourly basis service":
                    hourlyService.Click();
                    break;

                
            }
            Base.Test.Log(LogStatus.Pass, "Service is selcted successfully, Test passed");

            //select location type
            switch (GlobalDefinitions.ExcelLib.ReadData(2, "Location"))
            {
                case "On-site":
                    onsiteBtn.Click();
                    break;

                case "online":
                    onlineBtn.Click();
                    break;
            }
            Base.Test.Log(LogStatus.Pass, "Location is selected successfully, Test passed");

            //wait for start date
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//input[@placeholder='Start date'])", "XPath");
           
            startDate.Clear();
            startDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            Base.Test.Log(LogStatus.Pass, "Add start date, Test passed");


            //Press tab to shift focus to End date
            startDate.SendKeys(Keys.Tab);

            //Enter End date 
            endDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            Base.Test.Log(LogStatus.Pass, "Add End Date, Test passed");

            //Press tab to shift focus to End date
            endDate.SendKeys(Keys.Tab);

            //count number of days 
            int noOfDays = Global.GlobalDefinitions.driver.FindElements(By.Name("Available")).Count();
            var i = 1;
            while (i <= noOfDays)
            {
                var daysObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[1]/div/label")).Text;
                var daysChekBox = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[1]/div/input"));
                var startTime = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[2]/input"));
                var endTime = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[3]/input"));

                switch (daysObj)
                {
                    case "Sun":
                        daysChekBox.Click();
                        daysChekBox.SendKeys(Keys.Tab);
                        startTime.SendKeys("0940am");
                        daysChekBox.SendKeys(Keys.Tab);
                        endTime.SendKeys("0500pm");
                        goto Start;

                    case "Tue":
                        daysChekBox.Click();
                        daysChekBox.SendKeys(Keys.Tab);
                        startTime.SendKeys("0800am");
                        daysChekBox.SendKeys(Keys.Tab);
                        endTime.SendKeys("0310pm");
                        goto Start;

                    case "Sat":
                        daysChekBox.Click();
                        daysChekBox.SendKeys(Keys.Tab);
                        startTime.SendKeys("0800am");
                        daysChekBox.SendKeys(Keys.Tab);
                        endTime.SendKeys("0310pm");
                        break;
                }
                Start:
                i++;
            }

            Base.Test.Log(LogStatus.Pass, "Add Available days and time, Test passed");

            //Select SkillTrade

            IList<IWebElement> skillTradeObj = Global.GlobalDefinitions.driver.FindElements(By.Name("skillTrades"));

            bool skillTrade = skillTradeObj.ElementAt(0).Selected;

            if (skillTrade == true)
            {
                skillTradeObj.ElementAt(1).Click();
                //Wait for Credit textbox
                GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//input[@placeholder='Amount']"), 10);
                          
               credit.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }
            else
            {
                skillTradeObj.ElementAt(0).Click();
                //Wait for skill exchange textbox
                GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"), 10);
                          
                skillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            }

            Base.Test.Log(LogStatus.Pass, "Add skill Trade, Test passed");

            //Wait for work sample
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//i[@class='huge plus circle icon padding-25']"), 10);
            //select file for work sample
            uploadFile.Click();
            //create a AutoIT class and object
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            GlobalDefinitions.wait(50);
            autoIt.Send(GlobalDefinitions.ExcelLib.ReadData(2, "WorkSamples"));
            GlobalDefinitions.wait(50);
            autoIt.Send("{Enter}");

            Base.Test.Log(LogStatus.Pass, "WorkSample uploaded, Test passed");

           
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//div[10]//div[2]//div[1]//div[1]//div[1]//input[1]"), 10);

            // Select Active
            switch (GlobalDefinitions.ExcelLib.ReadData(2, "IsActive"))
            {
                case "Hidden":
                    hiddenBtn.Click();
                    break;

                case "Active":
                    activeBtn.Click();
                    break;

            }
            Base.Test.Log(LogStatus.Pass, "Is Active selected, Test passed");

            //wait for save button
            GlobalDefinitions.waitUntilClickable(GlobalDefinitions.driver, 1000, "(//input[@value = 'Save'])", "XPath");
            

            //click Save
            saveBtn.Click();

        }


    }

}
