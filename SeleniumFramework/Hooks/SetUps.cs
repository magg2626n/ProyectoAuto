﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ClassLibrary3.Hooks
{
    [Binding]
    public class SetUps
    {

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private RemoteWebDriver webDriver;
        public RemoteWebDriver DetermineBrowserType()
        {
            //Change to Case Statement
            var tagNames = ScenarioContext.Current.ScenarioInfo.Tags;
            if (tagNames.Contains("Chrome"))
            {
                webDriver = new ChromeDriver(@"D:\Borrar\Maggie\chromedriver"); // => No te olvides especificar el path donde está el chrome driver
            }
            else if (tagNames.Contains("Firefox"))
            {
                webDriver = new FirefoxDriver();
            }
            else if (tagNames.Contains("Edge"))
            {
                webDriver = new EdgeDriver();
            }
            else
            {
                throw new Exception("Browser Tag was not found");
            }
            return webDriver;                                                
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            //string startupPath = System.IO.Directory.GetParent(@"./").FullName;

            //var htmlReporter = new ExtentHtmlReporter("C:\\Reports\\ExtentReport.html");
            var htmlReporter = new ExtentHtmlReporter(@"C:\Usuarios\malvarez\source\repos\CSharpFramework\SeleniumFramework\Reports\ExtentReport.html");

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            webDriver = DetermineBrowserType();
            ScenarioContext.Current.Add("webDriver", webDriver);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException); ;
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException); ;
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }








}

