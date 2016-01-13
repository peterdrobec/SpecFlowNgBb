using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Protractor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNg.Hooks
{
    public class LocalEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(15));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(15));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            var _ngDriver = new NgWebDriver(driver);
            //_ngDriver.IgnoreSynchronization = true;
            return _ngDriver;
        }
    }

}
