using Bumblebee.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using SpecFlowNg.Pages;

namespace SpecFlowNg.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        /// <summary>
        /// Called before every scenario.
        /// </summary>
        [BeforeScenario]
        public static void InitializeScenario()
        {
            // write any initialization which you want to apply once for every scenario
            //var driver = new ChromeDriver();
            //driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));

            //Session s = new Session<LocalEnvironment>();
            Threaded<Session>
                .With<LocalEnvironment>()
                .NavigateTo<HomePage>("http://10.10.30.37/home");

            //AFSession
            //    .With(TestRunHooks.Bootstrapper)
            //    .NavigateToPageInSettings<AuthorizationPage>();

           // ScenarioContext.Current.AddOrUpdate(typeof(Cleaner).FullName, new Cleaner());
        }

        /// <summary>
        /// Called after every scenario.
        /// </summary>
        [AfterScenario]
        public static void TearDownScenario()
        {
            // write any cleanup which you want to apply once for every scenario
            Threaded<Session>
                .End();

            //try
            //{
            //    ScenarioContext.Current.Get<Cleaner>().Clean();

            //    AFSession.End();
            //}
            //catch (Exception e)
            //{
            //    Log.Error("Exception when ending the session", e);
            //}
        }
    }
}
