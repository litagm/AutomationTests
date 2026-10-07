using AutomationTests.Enums;
using AutomationTests.ForUI.Pages;
using AutomationTests.ForUI.Pages.DemoQA;
using AutomationTests.Storages.ForUI.Builders;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AutomationTests.Tests.UITests
{
    public class DemoqaTest : BaseTest
    {
        [Test]
        public async Task FormLogIn()
        {
            await Page.GotoAsync("https://demoqa.com/select-menu");

            var selectOneDropdown = Page.Locator("//*[@id='selectOne']");
            await Assertions.Expect(selectOneDropdown).ToBeVisibleAsync();

            await selectOneDropdown.ClickAsync();

            var profOption = Page.GetByText("Prof.", new() { Exact = true });
            await profOption.ClickAsync();

            await Assertions.Expect(selectOneDropdown).ToContainTextAsync("Prof.");
        }

        [Test]
        public async Task FillStudentRegistrationForm_Advanced()
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "test_picture.jpg");
            await File.WriteAllTextAsync(tempFilePath, "test image content");

            try
            {
                StudentRegistrationBuilder builder = new StudentRegistrationBuilder();
                var studentData = builder
                    .WithFirstName("Ivan")
                    .WithLastName("Ivanov")
                    .WithEmail("ivanov@test.com")
                    .WithGender(GenderType.Male) 
                    .WithMobile("9529098567")
                    .WithDateOfBirth(new DateTime(1995, 5, 01))
                    .WithSubjects("Maths", "Computer Science")
                    .WithHobbies(HobbyType.Sports, HobbyType.Reading)
                    .WithPicture(tempFilePath)
                    .WithAddress("Prague, Czech Republic")
                    .WithLocation("Uttar Pradesh", "Merrut")
                    .Build();

                PracticeFormPage formPage = new PracticeFormPage(Page);

                await formPage.OpenPageAsync();
                await formPage.FillAllFormFieldAsync(studentData);
                await formPage.ClickSubmitAsync();

                await formPage.CheckSuccessMessageAsync();
            }
            finally
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }
    }
}