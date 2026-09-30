using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationTests.ForUI.Pages.SauceDemo
{
    internal class CheckoutComplete
    {
        private readonly IPage Page;
        private ILocator CompleteHeader => Page.Locator("[data-test=\"complete-header\"]");


        public CheckoutComplete(IPage page)
        {
            Page = page;
        }

        public Task CheckPageIsOpenAsync() =>
            Assertions.Expect(CompleteHeader).ToHaveTextAsync("Thank you for your order!");

    }
}
