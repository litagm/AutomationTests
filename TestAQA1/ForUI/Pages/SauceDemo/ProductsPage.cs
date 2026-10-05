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
        private ILocator InventoryItems => Page.Locator(".inventory_item");

        public ProductsPage(IPage page)
        {
            Page = page;
        }

        public Task CheckPageIsOpenAsync() =>
            Assertions.Expect(PageTitle).ToHaveTextAsync("Products");

        public async Task AddToCartByNameAsync(string itemName)
        {

            await InventoryItems
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