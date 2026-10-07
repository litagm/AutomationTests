using AutomationTests.DataProvider;
using AutomationTests.ForUI.Pages.SauceDemo;
using AutomationTests.Tests.UITests;
using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.Playwright.Assertions;

namespace AutomationTests.Tests.UITests
{
    [TestFixture]
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

        [Test]
        public async Task CreatingOrder()
        {
            LoginPage loginPage = new LoginPage(Page);

            await loginPage.OpenLoginPageAsync();
            await loginPage.FillLoginFormAsync("standard_user", "secret_sauce");

            ProductsPage productsPage = new ProductsPage(Page);
            await productsPage.CheckPageIsOpenAsync();

            await productsPage.AddToCartByNameAsync("Test.allTheThings() T-Shirt (Red)");
            await productsPage.AddToCartByNameAsync("Sauce Labs Bolt T-Shirt");

            await productsPage.ClickCartButtonAsync();

            CartPage cartPage = new CartPage(Page);
            await cartPage.CheckItemsInCartAsync(["Test.allTheThings() T-Shirt (Red)", "Sauce Labs Bolt T-Shirt"]);

            await cartPage.ClickCheckoutAsync();

            CheckoutInformationPage checkoutInformationPage = new CheckoutInformationPage(Page);
            await checkoutInformationPage.FillCheckoutFormAsync("Ivan", "Ivanov", "303404");

            CheckoutOverviewPage checkoutOverviewPage = new CheckoutOverviewPage(Page);
            await checkoutOverviewPage.CheckItemsInCartAsync(["Test.allTheThings() T-Shirt (Red)", "Sauce Labs Bolt T-Shirt"]);
            await checkoutOverviewPage.ClickFinishAsync();

            CheckoutComplete checkoutComplete = new CheckoutComplete(Page);
            await checkoutComplete.CheckPageIsOpenAsync();

        }

    }

    [TestFixture]
        public class SauceDemoLoginTests : BaseTest
        {
            [TestCaseSource(typeof(UserDataProvider),
                nameof(UserDataProvider.GetUserCases))]
            public async Task LoginValidationTest(string username)
            {
                LoginPage loginPage = new LoginPage(Page);
                await loginPage.OpenLoginPageAsync();
                await loginPage.FillLoginFormAsync(username, "secret_sauce");

                ProductsPage productsPage = new ProductsPage(Page);
                await productsPage.CheckPageIsOpenAsync();
            }
        }
    }
