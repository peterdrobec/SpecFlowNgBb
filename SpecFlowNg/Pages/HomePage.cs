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
}