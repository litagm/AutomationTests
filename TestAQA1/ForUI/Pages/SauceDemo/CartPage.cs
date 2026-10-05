using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationTests.ForUI.Pages.SauceDemo
{

    public class CartPage

    {
        private readonly IPage Page;

        private ILocator ItemNames => Page.Locator("[data-test='inventory-item-name']");

        private ILocator CheckoutButton => Page.Locator("//*[@id='checkout']");
        public CartPage(IPage page)
        {
            Page = page;
        }
        public Task CheckItemsInCartAsync(string[] expectedItemNames) =>
               Assertions.Expect(ItemNames).ToHaveTextAsync(expectedItemNames);

        public Task ClickCheckoutAsync() => CheckoutButton.ClickAsync();
    }
}

