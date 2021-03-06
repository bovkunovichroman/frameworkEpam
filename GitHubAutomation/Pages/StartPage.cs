﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    public class StartPage
    {
        private IWebDriver driver;

        private const string BASE_URL = "http://bilet.aviakassa.by/";

        public StartPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#header > div > div > div > div.cabinet.right.js-cabinet > a.js-login.do-login > span")]
        private IWebElement signInButton;

        [FindsBy(How = How.CssSelector, Using = "#email_login")]
        private IWebElement memberIdInput;

        [FindsBy(How = How.CssSelector, Using = "#pass_login")]
        private IWebElement passwordInput;

        [FindsBy(How = How.CssSelector, Using = "#login_popup > div.popup__content > form > div.row.login-popup__footer > div > input")]
        private IWebElement enterButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div/table[1]/tbody/tr[2]/td[2]/a")]
        private IWebElement plansPage;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div[1]/div[1]/ul/li[1]/label")]
        private IWebElement radioButtonOnlyTo;

        [FindsBy(How = How.Id, Using = "to_name")]
        private IWebElement takePlaceTo;
    
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div[1]/div[2]/form/div[2]/div/div[1]/div/input")]
        private IWebElement searchButton;

        [FindsBy(How = How.ClassName, Using = "js-my login")]
        private IWebElement myTicketSpace;

        [FindsBy(How = How.CssSelector, Using = "#base_direction > div > div.fields_block > div.form-item.form-item--date.input-block.search_field.date_field > div > samp")]
        public IWebElement errorMessage;

        [FindsBy(How = How.CssSelector, Using = "#header > div > div > div > div.cabinet.right.js-cabinet.logged_ico > a.js-logout.logout")]
        public IWebElement textSignInButton;

        [FindsBy(How = How.ClassName, Using = "tooltip-btn")]
        public IWebElement feedBackClicker;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/footer/div[2]/div[2]/div[1]/div/div[1]/div[3]/div/div/div[2]/form/div[4]/input")]
        private IWebElement submitButton;
    
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/footer/div[2]/div[2]/div[1]/div/div[1]/div[3]/div/div/div[2]/form/div[2]/samp/text()")]
        public IWebElement errorTextBeforeSubmitButton;

        public StartPage OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            return this;
        }

        public StartPage ClickSignInAccountButton()
        {
            signInButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(enterButton));
            return this;
        }

        public StartPage ClickMyTicket()
        {
            myTicketSpace.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(enterButton));
            return this;
        }

        public StartPage FillInLoginAndPassword(SignIn signIn)
        {
            memberIdInput.SendKeys(signIn.MemberId);          
            passwordInput.SendKeys(signIn.Password);
            enterButton.Click();
            return this;
        }

        public StartPage GoToSearch(SearchResultWithoutDate SearchResultWithoutDate)
        {
            radioButtonOnlyTo.Click();
            takePlaceTo.SendKeys(SearchResultWithoutDate.InputSityTo);
            Thread.Sleep(1000);
            searchButton.Click();
            searchButton.Click();
            return this;
        }
        
        public StartPage CheckFeedBack()
        {
            feedBackClicker.Click();
            submitButton.Click();
            return this;
        }
    }
}
