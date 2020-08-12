using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinAppDriverTestFramework;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1 - Open Viewer 
            WindowsDriver<WindowsElement> leafSession;
            AppiumOptions desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability("app", @"C:\Program Files (x86)\Viewer MI6.lnk");

            leafSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), desiredCapabilities);
            leafSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            leafSession.SwitchTo().Window(leafSession.CurrentWindowHandle);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            leafSession.Keyboard.SendKeys(Keys.Control + Keys.Shift + "I");


             if (leafSession.CurrentWindowHandle != leafSession.WindowHandles.Last())
             {
                 leafSession.SwitchTo().Window(leafSession.WindowHandles.Last());
                 WindowsElement thisPC = leafSession.FindElementByName("Este Computador");
                 Assert.IsTrue(thisPC.Displayed);
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 thisPC.Click();

                 WindowsElement localDisk = leafSession.FindElementByName("Disco Local (C:)");
                 Assert.IsTrue(localDisk.Displayed);
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 localDisk.Click();
                 localDisk.SendKeys(Keys.Enter);

                 WindowsElement workspacePath = leafSession.FindElementByAccessibilityId("1148");
                 Assert.IsTrue(workspacePath.Displayed);
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 workspacePath.SendKeys("aworkspaceWinAppDriver");


                 WindowsElement openPath = leafSession.FindElementByName("Abrir");
                 Assert.IsTrue(openPath.Displayed);
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 openPath.Click();


                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 workspacePath.SendKeys("LeafScript");

                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 openPath.Click();

                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 workspacePath.SendKeys("ScriptTeste.lsc");

                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                 openPath.Click();


                 WindowsElement play = leafSession.FindElementByName("Executar");
                 Assert.IsTrue(play.Displayed);
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                 play.Click();
                 Console.WriteLine("Window handles: " + leafSession.CurrentWindowHandle);

                 WindowsElement confirmPlay = leafSession.FindElementByName("Sim Enter");
                 Assert.IsTrue(confirmPlay.Displayed);
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                 confirmPlay.Click();
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(8));

                 // Open Dashboard 
                 WindowsElement openDashboard = leafSession.FindElementByName("Dashboard");
                 Assert.IsTrue(openDashboard.Displayed);
                 openDashboard.Click();
                 System.Threading.Thread.Sleep(TimeSpan.FromSeconds(13));
               
            }
 
           // Export data  
           leafSession.Keyboard.SendKeys(Keys.F8);
           leafSession.Keyboard.SendKeys(Keys.Tab);
           leafSession.Keyboard.SendKeys("csvfile");
           leafSession.Keyboard.SendKeys(Keys.Enter);
           leafSession.Keyboard.SendKeys(Keys.Enter);

        }
    }
}
