﻿using OpenQA.Selenium.Edge;

namespace TestCases
{
    public class BaseClass
    {
        public IWebDriver driver;

        [Before]
        public void Setup()
        {
            driver = new EdgeDriver();
        }

        [After]
        public void Teardown()
        {
            driver.Close();
        }
    }
}