using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowNg.Pages;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Bumblebee.Setup;

namespace SpecFlowNg.HomePageSpecs
{
    [Binding]
    public class HomePageSteps
    {
        [Given(@"Location Is HomePage")]
        public void GivenLocationIsHomePage()
        {
            Threaded<Session>
                .CurrentBlock<HomePage>()
                .FileShareBtn.Click();       
            
        }


    }
}
