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
        string AcceptCookiesButton { get; set; } = @"//button[contains(text(),'Piekrītu')]";
        string ApdrosinasanaDropdownButton { get; set; } = @"//*[@class='if desktop-menu-item is-parent']";
        string ClickToCelojumiButton { get; set; } = @"(//li/a[contains(text(),'Ceļojumi')])[3]";
        string PirktPolisiButton { get; set; } = @"(//span[@class='if white icon ui arrow-right'])[1]";
        string SakumaDatumsSelector { get; set; } = @"(//input[@type='text' and @class='form-control hasDatepicker'])[1]";
        string BeiguDatumsSelector { get; set; } = @"//input[@type='text' and @class='form-control hasDatepicker' and @placeholder='Beigu datums']";
        string CelojumaTeritorija { get; set; } = @"//div[@ng-repeat='item in singleTripEffectiveAreas' and @class='destination btn btn-default selected' and @ng-click='selectEffectiveArea(item)']";
        string TurpinatButton { get; set; } = @"(//input[@type='button' and @data-title='Lai turpinātu, nepieciešams aizpildīt obligātos laukus' and @value='Turpināt'])[1]";
        string DayCounterSelector { get; set; } = @"*//div[contains(text(),'4 diena/-s')]";
        string BerniFieldSelector { get; set; } = @"//div[@name='ageGroup0' and @ng-model='model.ageGroups[ageGroup.key]' and @ng-change='ageGroupChanged()' and @hk-model='' and @hk-positive-number='']/input[@type='number' and @ng-model='value' and @ng-click='selectText();']";
        string PieaugisieFieldSelector { get; set; } = @"//div[@name='ageGroup3' and @ng-model='model.ageGroups[ageGroup.key]' and @ng-change='ageGroupChanged()' and @hk-model='' and @hk-positive-number='']/input[@type='number' and @ng-model='value' and @ng-click='selectText();']";
        string AprekinatCenuButton { get; set; } = @"//input[@type='button' and @data-title='Lai turpinātu, nepieciešams aizpildīt obligātos laukus' and @class='hk-btn-step-proceed btn btn-primary' and @value='Aprēķināt cenu']";
        string CovidInfoForValidation { get; set; } = @"//a[@href='https://www.if.lv/privatpersonam/apdrosinasana/celojumu-apdrosinasana/celosana-covid-laika' and @target='_blank' and text()='Vairāk par ceļojumu apdrošināšanu Covid-19 laikā']";
        string OpenDropDownMenu { get; set; } = @"(//div[@class='col-xs-12 col-sm-5 col-lg-4' ]//button[@ng-click='open()'])[1]";
        string BagazaUnMantasField { get; set; } = @"(//div[@class='col-xs-12 col-sm-5 col-lg-4' ]//button[@ng-click='open()'])[2]";
        string CelojumaIzmainasField { get; set; } = @"(//button[@ng-click='open()' and @class='form-control' ][contains(text(),'€')])[3]";
        string AtbildibaUnJuridiskaPalidzibaSelector { get; set; } = @"//span[@name='liability']//span[@class='hk-check']";
        string NelaimesGadijumiSelector { get; set; } = @"//span[@name='personalAccident']//span[@class='hk-check']";
        string DrosibaNomojotAutoSelector { get; set; } = @"//span[@name='carDeductible']//span[@class='hk-check']";
        string PaaugstinataRiskaAktivitateSelector { get; set; } = @"//span[@name='highRiskActivities']//span[@class='hk-check']";
        string LoadingPopUpMessageGatavojamPiedavajumu { get; set; } = @"//span[contains(text(),'Gatavojam piedāvājumu')]";
        string LoadingPopUpMessageAprekinamCenu { get; set; } = @"//span[contains(text(),'Aprēķinām cenu')]";
        string TotalPrice { get; set; } = @"//div[@class='hk-step-summary']";


        [Test, Order(1)]
        public void aceptCookies()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(AcceptCookiesButton))).Click();
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
            IWebElement element = driver.FindElement(By.XPath(ApdrosinasanaDropdownButton));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ApdrosinasanaDropdownButton))).Click();


        }


        [Test, Order(4)]
       public void PressCelojumi()
        {
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
              wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ClickToCelojumiButton))).Click();
            Assert.AreEqual("Ceļojumu apdrošināšana internetā | If.lv", driver.Title); 
           
        }
        [Test,Order(5)]
        public void FillForm()
        {
            driver.SwitchTo().DefaultContent();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(PirktPolisiButton))).Click();

            

            DateTime currentDate = DateTime.Now;
            DateTime nextDay = currentDate.AddDays(1);
            
            DateTime endDay = nextDay.AddDays(3);

            //enter start day 
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(SakumaDatumsSelector))).SendKeys(nextDay.ToString("dd.MM.yyyy"));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BeiguDatumsSelector))).Clear();
            //enter end day
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BeiguDatumsSelector))).SendKeys(endDay.ToString("dd.MM.yyyy"));

            
                    Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
                    screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);

            //Validation step - would be 4 days 

     
            //Click to the Turpināt button
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(TurpinatButton))).Click();

            IWebElement el = driver.FindElement(By.XPath(DayCounterSelector));
            string elTextValue = el.Text;

            Assert.AreEqual("4 diena/-s", elTextValue);            
        }




        [Test,Order(6)]
        public void CalculatePrice()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BerniFieldSelector))).Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BerniFieldSelector))).SendKeys("2");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(PieaugisieFieldSelector))).Clear();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(PieaugisieFieldSelector))).SendKeys("2");

            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("screenshotEnterPeopleCount.png", ScreenshotImageFormat.Png);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(AprekinatCenuButton))).Click();

            
            screenshot.SaveAsFile("screenshotEnterPeopleCoun2t.png", ScreenshotImageFormat.Png);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(CovidInfoForValidation)));
            IWebElement element = driver.FindElement(By.XPath(CovidInfoForValidation));

            Assert.AreEqual(true, element.Displayed);
        }


        [Test, Order(7)]
        public void SelectPoliseSegums()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions actions = new Actions(driver);
           


            //enter data to Medicinska palidzība 
            try
            {

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpenDropDownMenu))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("300 000 €"))).Click();
            }
            catch  {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpenDropDownMenu)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("300 000 €"))).Click();


            }


            //enter data to Bagāža un personīgās mantas 
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BagazaUnMantasField))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("600 €"))).Click();
            }
            catch 
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(BagazaUnMantasField)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("600 €"))).Click();
            }


            //enter data to Ceļojuma izmaiņas
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(CelojumaIzmainasField))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Nevēlos"))).Click();
            } catch
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(CelojumaIzmainasField)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Nevēlos"))).Click();
            }


            //Mark checkboxes
            //Click to the "Atbildība un juridiska palidzība"
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(AtbildibaUnJuridiskaPalidzibaSelector))).Click();
                //add here assert
            } catch
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(AtbildibaUnJuridiskaPalidzibaSelector)));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", myElement);
                myElement.Click();
            }


            //check "Nelaimes gadījumi" 
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));
                IWebElement element = driver.FindElement(By.XPath(NelaimesGadijumiSelector));
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
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));
                IWebElement element = driver.FindElement(By.XPath(DrosibaNomojotAutoSelector));
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
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(LoadingPopUpMessageAprekinamCenu)));
                IWebElement element = driver.FindElement(By.XPath(PaaugstinataRiskaAktivitateSelector));
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

            //take price screenshot          
            try
            {
                IWebElement priceElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(TotalPrice)));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", priceElement);

                Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile("price-screenshot.png", ScreenshotImageFormat.Png);
            } catch
            {
                Console.WriteLine("Screenshot err");
            }          
        }
    }
}