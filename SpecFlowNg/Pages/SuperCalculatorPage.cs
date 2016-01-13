using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowNg.Pages
{
    public class HomePage : WebBlock
    {
        /// <summary>Creates a new instance of AddActionWindow class.</summary>
        /// <param name="session">Session Bumblebee context</param>
        public HomePage(Session session)
            : base(session)
        {
           // session.NavigateTo<HomePage>("http://10.10.30.89/file-browser");
           
        }

        public Clickable<HomePage> FileShareBtn => new Clickable<HomePage>(this, By.XPath("//a[@ui-sref='file-browser']"));

        /*

        /// <summary>'Create a ServiceNow Incident' item</summary>
        public Clickable<AddActionWindow> LabelCreateServiceNowIncident => new Clickable<AddActionWindow>(this,
            By.XPath("//span[.='Create a ServiceNow Incident']"));
        /// <summary>Configure Action button</summary>
        public Clickable<ConfigureActionWindow> BtnConfigureAction => new Clickable<ConfigureActionWindow>(this,
            By.XPath("//span/span[.='Configure Action']"));
            */

    }
    public class SuperCalculatorPage
    {
        private NgWebDriver _ngDriver;

        public SuperCalculatorPage(IWebDriver driver, string url)
        {
            _ngDriver = new NgWebDriver(driver);
            _ngDriver.Url = url;
        }

        public string LatestResult
        {
            get { return _ngDriver.FindElement(NgBy.Binding("latest")).Text; }
        }

        public IEnumerable<SuperCalculatorPageHistory> History
        {
            get
            {
                return _ngDriver.FindElements(NgBy.Repeater("result in memory"))
                    .Select(e => new SuperCalculatorPageHistory(e));
            }
        }

        public void Add(string first, string second)
        {
            DoMath(first, second, "+");
        }

        public void Subtract(string first, string second)
        {
            DoMath(first, second, "-");
        }

        public void Divide(string first, string second)
        {
            DoMath(first, second, "/");
        }

        private void DoMath(string first, string second, string op)
        {
            SetFirst(first);
            SetSecond(second);
            SetOperator(op);
            ClickGo();
        }

        private void SetFirst(string number)
        {
            var first = _ngDriver.FindElement(NgBy.Input("first"));
            first.Clear();
            first.SendKeys(number);
        }

        private void SetSecond(string number)
        {
            var second = _ngDriver.FindElement(NgBy.Input("second"));
            second.Clear();
            second.SendKeys(number);
        }

        private void SetOperator(string op)
        {
            var operatorSelect = new SelectElement(_ngDriver.FindElement(NgBy.Select("operator")));
            operatorSelect.SelectByText(op);
        }

        private void ClickGo()
        {
            _ngDriver.FindElement(By.Id("gobutton")).Click();
        }

    }

    public class SuperCalculatorPageHistory
    {
        public string Time { get; set; }
        public string Expression { get; set; }
        public string Result { get; set; }

        public SuperCalculatorPageHistory()
        {
        }

        public SuperCalculatorPageHistory(IWebElement element)
        {
            var tds = element.FindElements(By.TagName("td"));
            Time = tds[0].Text;
            Expression = tds[1].Text;
            Result = tds[2].Text;
        }
    }
}
