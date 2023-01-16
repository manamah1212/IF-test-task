using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IF_automations_task.BaseClass;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using Humanizer.Localisation;
using System.Threading;

namespace IF_automations_task
{
    [TestFixture]
    public class TestClass : BaseTest
    {


        string PrivatpersonamButton { get; set; } = @"(//a[@href=" + '\u0022' + "/" + "privatpersonam" + '\u0022' + "])[2]";
        string acceptCookiesButton { get; set; } = @"//button[contains(text(),'Piekrītu')]";
        string apdrosinasanaDropdownButton { get; set; } = @"//*[@class='if desktop-menu-item is-parent']";
        string clickToCelojumiButton { get; set; } = @"(//li/a[contains(text(),'Ceļojumi')])[3]";
        string pirktPolisiButton { get; set; } = @"(//span[@class='if white icon ui arrow-right'])[1]";
        string sakumaDatumsSelector { get; set; } = @"(//input[@type='text' and @class='form-control hasDatepicker'])[1]";
        string beiguDatumsSelector { get; set; } = @"//input[@type='text' and @class='form-control hasDatepicker' and @placeholder='Beigu datums']";
        string celojumaTeritorija { get; set; } = @"//div[@ng-repeat='item in singleTripEffectiveAreas' and @class='destination btn btn-default selected' and @ng-click='selectEffectiveArea(item)']";
        string turpinatButton { get; set; } = @"(//input[@type='button' and @data-title='Lai turpinātu, nepieciešams aizpildīt obligātos laukus' and @value='Turpināt'])[1]";
        string dayCounterSelector { get; set; } = @"*//div[contains(text(),'4 diena/-s')]";
        string berniFieldSelector { get; set; } = @"//div[@name='ageGroup0' and @ng-model='model.ageGroups[ageGroup.key]' and @ng-change='ageGroupChanged()' and @hk-model='' and @hk-positive-number='']/input[@type='number' and @ng-model='value' and @ng-click='selectText();']";
        string pieaugisieFieldSelector { get; set; } = @"//div[@name='ageGroup3' and @ng-model='model.ageGroups[ageGroup.key]' and @ng-change='ageGroupChanged()' and @hk-model='' and @hk-positive-number='']/input[@type='number' and @ng-model='value' and @ng-click='selectText();']";
        string aprekinatCenuButton { get; set; } = @"//input[@type='button' and @data-title='Lai turpinātu, nepieciešams aizpildīt obligātos laukus' and @class='hk-btn-step-proceed btn btn-primary' and @value='Aprēķināt cenu']";
        string covidInfoForValidation { get; set; } = @"//a[@href='https://www.if.lv/privatpersonam/apdrosinasana/celojumu-apdrosinasana/celosana-covid-laika' and @target='_blank' and text()='Vairāk par ceļojumu apdrošināšanu Covid-19 laikā']";
        string openDropDownMenu { get; set; } = @"(//div[@class='col-xs-12 col-sm-5 col-lg-4' ]//button[@ng-click='open()'])[1]";
        string bagazaUnMantasField { get; set; } = @"(//div[@class='col-xs-12 col-sm-5 col-lg-4' ]//button[@ng-click='open()'])[2]";
        string celojumaIzmainasField { get; set; } = @"(//button[@ng-click='open()' and @class='form-control' ][contains(text(),'€')])[3]";
        string atbildibaUnJuridiskaPalidzibaSelector { get; set; } = @"//span[@name='liability']//span[@class='hk-check']";
        string nelaimesGadijumiSelector { get; set; } = @"//span[@name='personalAccident']//span[@class='hk-check']";
        string drosibaNomojotAutoSelector { get; set; } = @"//span[@name='carDeductible']//span[@class='hk-check']";
        string paaugstinataRiskaAktivitateSelector { get; set; } = @"//span[@name='highRiskActivities']//span[@class='hk-check']";


        [Test, Order(1)]
        public void aceptCookies()
        {
           // IWebElement element = driver.FindElement(By.XPath(acceptCookiesButton));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(acceptCookiesButton))).Click();
            driver.SwitchTo().DefaultContent();
        }

        [Test, Order(2)]
        public void CheckApdrosinasanaButtonIsEnambledOrNot()
        {
            IWebElement element = driver.FindElement(By.XPath(PrivatpersonamButton));
            Assert.AreEqual(true, element.Enabled);
        }

        [Test, Order(3)]
        public void PressApdrosinasanaDropDown()
        {
            driver.Navigate().Refresh();
            //driver.SwitchTo().ActiveElement();
            IWebElement element = driver.FindElement(By.XPath(apdrosinasanaDropdownButton));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(apdrosinasanaDropdownButton))).Click();


        }
        [Test, Order(4)]
       public void PressCelojumi()
        {
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
              wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(clickToCelojumiButton))).Click();
            Assert.AreEqual("Ceļojumu apdrošināšana internetā | If.lv", driver.Title); 
           
        }
        [Test,Order(5)]
        public void FillForm()
        {
            driver.SwitchTo().DefaultContent();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pirktPolisiButton))).Click();

            

            DateTime currentDate = DateTime.Now;
            DateTime nextDay = currentDate.AddDays(1);
            
            DateTime endDay = nextDay.AddDays(3);

            //enter start day 
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(sakumaDatumsSelector))).SendKeys(nextDay.ToString("dd.MM.yyyy"));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(beiguDatumsSelector))).Clear();
            //enter end day
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(beiguDatumsSelector))).SendKeys(endDay.ToString("dd.MM.yyyy"));

            
                    Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
                    screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);

            //Validation step - would be 4 days 

            //4 diena/-s       
            //Click to the Turpināt button
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(turpinatButton))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(turpinatButton))).Click();

            IWebElement el = driver.FindElement(By.XPath(dayCounterSelector));
            string elTextValue = el.Text;

            Assert.AreEqual("4 diena/-s", elTextValue);            
        }
        [Test,Order(6)]
        public void CalculatePrice()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(berniFieldSelector))).Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(berniFieldSelector))).SendKeys("2");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pieaugisieFieldSelector))).Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pieaugisieFieldSelector))).SendKeys("2");

            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("screenshotEnterPeopleCount.png", ScreenshotImageFormat.Png);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(aprekinatCenuButton))).Click();

            
            screenshot.SaveAsFile("screenshotEnterPeopleCoun2t.png", ScreenshotImageFormat.Png);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(covidInfoForValidation)));
            IWebElement element = driver.FindElement(By.XPath(covidInfoForValidation));

            Assert.AreEqual(true, element.Displayed);
        }
        [Test, Order(7)]
        public void SelectPoliseSegums()
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions actions = new Actions(driver);
            //span[@ng-if="(hideMessage == false || hideMessage == undefined) && loadingMessageValue !== undefined"]
            //enter data to Medicinska palidzība arrea


            try
            {
               
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(openDropDownMenu))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("300 000 €"))).Click();
            }
            catch (Exception exc) {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(openDropDownMenu)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("300 000 €"))).Click();


            }
            //enter data to Bagāža un personīgās mantas errea
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(bagazaUnMantasField))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("600 €"))).Click();
            }
            catch (Exception exc1)
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(bagazaUnMantasField)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("600 €"))).Click();
            }

            //enter data to Ceļojuma izmaiņas
            
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(celojumaIzmainasField))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Nevēlos"))).Click();
            } catch (Exception Excep)
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(celojumaIzmainasField)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Nevēlos"))).Click();
            }

            Thread.Sleep(2000);

            //mark checkboxes
            //click to the "Atbildība un juridiska palidzība"




            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(atbildibaUnJuridiskaPalidzibaSelector))).Click();
                //add here assert
            } catch(Exception e)
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(atbildibaUnJuridiskaPalidzibaSelector)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();
            }

           // Thread.Sleep(5000);

            //check "Nelaimes gadījumi" 
            try
            {
                IWebElement element = driver.FindElement(By.XPath(nelaimesGadijumiSelector));
                if(element.Selected == false)
                {
                    element.Click();
                    Assert.AreEqual(false, element.Selected);
                } else
                {
                    Assert.AreEqual(false, element.Selected);
                }
            }catch (Exception e)
            {
                Console.WriteLine(e + "catch - Nelaimes gadijumi - something went wrong");
            }

            //check  "Drošība nomājot auto"
            //Thread.Sleep(5000);
            try
            {
                IWebElement element = driver.FindElement(By.XPath(drosibaNomojotAutoSelector));
                if (element.Selected == true)
                {
                    element.Click();
                    Assert.AreEqual(false, element.Selected);
                }
                else
                {
                    Assert.AreEqual(false, element.Selected);
                }

            }
            catch (Exception err) {
                Console.WriteLine(err + "catch - Drošība nomājot auto");
            }
            //check "Paaugstinata riska aktivitates"

            try
            {
                IWebElement element = driver.FindElement(By.XPath(paaugstinataRiskaAktivitateSelector));
                if (element.Selected == true)
                {
                    element.Click();
                    Assert.AreEqual(false, element.Selected);
                }
                else
                {
                    Assert.AreEqual(false, element.Selected);
                }
            } catch (Exception err)
            {
                Console.WriteLine(err + " catch - Paaugstinata riska aktivitates");
            }

            Thread.Sleep(1000);

            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("awdawd.png", ScreenshotImageFormat.Png);
            Thread.Sleep(5000);
        }
    }
}