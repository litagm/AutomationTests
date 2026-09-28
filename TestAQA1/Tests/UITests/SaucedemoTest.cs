using FluentAssertions;
using AutomationTests.Tests.UITests;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.Playwright.Assertions;

namespace AutomationTests.Tests.UITests
{
    public class SaucedemoTest : BaseTest
    {
        [Test]
        public async Task FormLogIn()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");

            var userNameTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" });
            await userNameTextBox.FillAsync("standard_user");

            var passTextBox = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
            await passTextBox.FillAsync("secret_sauce");

            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();

            var pageTitle = Page.Locator("//*[@class='title']");
            await Expect(pageTitle).ToHaveTextAsync("Products");
        }
    }
}
 