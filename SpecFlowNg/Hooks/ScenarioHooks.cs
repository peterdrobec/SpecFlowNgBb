using Bumblebee.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using SpecFlowNg.Pages;
using SpecFlowNg.Extensions;
using SpecFlowNg.Helpers;

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

            var _settings = new EnvironmentSettings();

            Threaded<Session>
                .With<LocalEnvironment>()
                .NavigateTo<HomePage>(_settings.BaseUrl);

            ScenarioContext.Current.AddOrUpdate(typeof(Cleaner).FullName, new Cleaner());

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
            

            try
            {
                ScenarioContext.Current.Get<Cleaner>().Clean();
                Threaded<Session>
                .End();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}
