using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationTests.ForUI.Pages.SauceDemo
{
    public class LoginPage
    {
        private readonly IPage Page;

        private ILocator UserNameTextBox => Page.Locator("//*[@id=\'user-name\']");
        private ILocator PasswordTextBox => Page.Locator("//*[@id=\'password\']");
        private ILocator LoginButton => Page.Locator("//*[@id=\'login-button\']");

        public LoginPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenLoginPageAsync()
        {
            await Page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task FillLoginFormAsync(string username, string password)
        {
            await UserNameTextBox.FillAsync(username);
            await PasswordTextBox.FillAsync(password);
            await LoginButton.ClickAsync();
        }

    }
}
