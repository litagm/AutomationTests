using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTests.Tests.UITests
{

    public class DemoqaTest : BaseTest
    {
        [Test]
        public async Task FormLogIn()
        {
            await Page.GotoAsync("https://demoqa.com/select-menu");

            var selectOneDropdown = Page.Locator("//*[@id=\'selectOne\']");
            await Assertions.Expect(selectOneDropdown).ToBeVisibleAsync();

            await selectOneDropdown.ClickAsync();

            var profOption = Page.GetByText("Prof.", new() { Exact = true });
            await profOption.ClickAsync();


            await Assertions.Expect(selectOneDropdown).ToContainTextAsync("Prof.");
        }
    }
}
