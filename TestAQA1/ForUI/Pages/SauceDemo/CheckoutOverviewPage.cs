using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationTests.ForUI.Pages.SauceDemo
{
    internal class CheckoutOverviewPage
    {
        private readonly IPage Page;
        private ILocator ItemNames => Page.Locator("[data-test='inventory-item-name']");
        private ILocator FinishButton => Page.GetByRole(AriaRole.Button, new() { Name = "Finish" });


        public CheckoutOverviewPage(IPage page)
        {
            Page = page;
        }

        public Task CheckItemsInCartAsync(string[] expectedItemNames) =>
               Assertions.Expect(ItemNames).ToHaveTextAsync(expectedItemNames);

        public Task ClickFinishAsync() => FinishButton.ClickAsync();

    }
}
