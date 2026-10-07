using AutomationTests.Storages.ForUI.Models;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AutomationTests.ForUI.Pages.DemoQA
{
    public class PracticeFormPage
    {
        private readonly IPage Page;

        private ILocator FirstNameInput => Page.Locator("//*[@id='firstName']");
        private ILocator LastNameInput => Page.Locator("//*[@id='lastName']");
        private ILocator EmailInput => Page.Locator("//*[@id='userEmail']");
        private ILocator MobileInput => Page.Locator("//*[@id='userNumber']");
        private ILocator DateOfBirthInput => Page.Locator("//*[@id='dateOfBirthInput']"); 
        private ILocator MonthSelect => Page.Locator("//*[@class='react-datepicker__month-select']");
        private ILocator YearSelect => Page.Locator("//*[@class='react-datepicker__year-select']");
        private ILocator SubjectsInput => Page.Locator("//*[@id='subjectsInput']");
        private ILocator UploadPictureInput => Page.Locator("//*[@id='uploadPicture']");
        private ILocator AddressInput => Page.Locator("//*[@id='currentAddress']");
        private ILocator StateDropdown => Page.Locator("//*[@id='state']");
        private ILocator CityDropdown => Page.Locator("//*[@id='city']");
        private ILocator SubmitButton => Page.Locator("//*[@id='submit']");
        private ILocator ModalTitle => Page.Locator("//*[@id='example-modal-sizes-title-lg']");


        public PracticeFormPage(IPage page)
        {
            Page = page;
        }

        public async Task OpenPageAsync()
        {
            await Page.GotoAsync("https://demoqa.com/automation-practice-form");

        }

        public async Task FillAllFormFieldAsync(StudentRegistrationFormModel studentData)
        {
            await FirstNameInput.FillAsync(studentData.FirstName);
            await LastNameInput.FillAsync(studentData.LastName);
            await EmailInput.FillAsync(studentData.Email);

            await Page.Locator($"xpath=//label[text()='{studentData.Gender}']").ClickAsync();

            await MobileInput.FillAsync(studentData.MobileNumber);

            await DateOfBirthInput.ClickAsync();

            string monthName = studentData.DateOfBirth.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
            await MonthSelect.SelectOptionAsync(monthName);

            await YearSelect.SelectOptionAsync(studentData.DateOfBirth.Year.ToString());

            string daySelector = $".react-datepicker__day--{studentData.DateOfBirth:03d}:not(.react-datepicker__day--outside-month)";
            await Page.Locator(daySelector).ClickAsync();

            foreach (var subject in studentData.Subjects)
            {
                await SubjectsInput.FillAsync(subject);
                await SubjectsInput.PressAsync("Enter");
            }

            foreach (var hobby in studentData.Hobbies)
            {
                await Page.Locator($"xpath=//label[text()='{hobby}']").ClickAsync();
            }

            await UploadPictureInput.SetInputFilesAsync(studentData.PicturePath);

            await AddressInput.FillAsync(studentData.CurrentAddress);

      
            await StateDropdown.ClickAsync();
            await Page.Locator($"xpath=//div[contains(@id, 'react-select') and text()='{studentData.State}']").ClickAsync();

            await CityDropdown.ClickAsync();
            await Page.Locator($"xpath=//div[contains(@id, 'react-select') and text()='{studentData.City}']").ClickAsync();
        }

        public async Task ClickSubmitAsync()
        {
            await SubmitButton.ClickAsync();
        }

        public async Task CheckSuccessMessageAsync()
        {
            await Assertions.Expect(ModalTitle).ToHaveTextAsync("Thanks for submitting the form");
        }
    }
}
