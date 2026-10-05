using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomationTests.ForUI.Pages.SauceDemo
{
    public class ProductsPage
    {
        private readonly IPage Page;
        private ILocator PageTitle => Page.Locator("//*[@class='title']");
        private ILocator CartButton => Page.Locator("//*[@id='shopping_cart_container']");

        public ProductsPage(IPage page)
        {
            Page = page;
        }

        public Task CheckPageIsOpenAsync() =>
            Assertions.Expect(PageTitle).ToHaveTextAsync("Products");

        public async Task AddToCartByNameAsync(string itemName)
        {
            await Page.Locator(".inventory_item")
                .Filter(new() { HasText = itemName })
                .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
                .ClickAsync();
        }

        public async Task ClickCartButtonAsync()
        {
            await CartButton.ClickAsync();
        }
    }
}
