using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationTests.ForUI.Pages.SauceDemo
{
    internal class CheckoutInformationPage
    {
        private readonly IPage Page;

        private ILocator FirstNameTextBox => Page.GetByRole(AriaRole.Textbox, new() { Name = "First Name" });
        private ILocator LastNameTextBox => Page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name" });
        private ILocator PostalCodeTextBox => Page.GetByRole(AriaRole.Textbox, new() { Name = "Zip/Postal Code" });
        private ILocator CheckoutButton => Page.GetByRole(AriaRole.Button, new() { Name = "Continue" });


        public CheckoutInformationPage(IPage page)
        {
            Page = page;
        }

        public async Task FillCheckoutFormAsync(string firstName, string lastName, string postalCode)
        {
            await FirstNameTextBox.FillAsync(firstName);
            await LastNameTextBox.FillAsync(lastName);
            await PostalCodeTextBox.FillAsync(postalCode);
            await CheckoutButton.ClickAsync();
        }
    }
}
