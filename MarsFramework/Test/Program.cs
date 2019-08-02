using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Mars : Global.Base
        {


            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                // test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();

            }
            [Test, Order(1)]
            public void AddSkill()
            {
                SkillSharePage skillObj = new SkillSharePage();
                skillObj.SkillShare();
                

            }
            [Test, Order(2)]
            public void DeleteSkill()
            {

                ManageListingsPage manageListingObj = new ManageListingsPage();
                manageListingObj.DeleteListing();
                manageListingObj.ValidatedDeletedSkills();

            }
            [Test, Order(3)]

            public void UpdateSkill()
            {
                ManageListingsPage updateSkillObj = new ManageListingsPage();
                updateSkillObj.UpdatedListing();
            }
            [Test , Order(4)]
            public void ManageRequests()
            {
                ManageRequestsPage manageRequest = new ManageRequestsPage();
                manageRequest.Requests();
                

            }
            [Test, Order(5)]

            public void SearchSkill()
            {
                ManageRequestsPage searchSkillObj = new ManageRequestsPage();
                searchSkillObj.SearchSkills();
            }




        }
    }
}