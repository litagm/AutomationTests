using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace AutomationTests.DataProvider
{
    // Обязательно статический публичный класс
    public static class UserDataProvider
    {
        private const string UserDataFilePath = @"Resources\Users.csv";

        // Именно так метод и оформляем
        public static IEnumerable<TestCaseData> GetUserCases()
        {
            // Получаем директорию, в которой исполняется процесс запуска автотестов
            string baseDirectory = AppContext.BaseDirectory;
            // Формируем полный путь к файлу с юзерами
            string fullPath = Path.Combine(baseDirectory, UserDataFilePath);
            // Читаем все строки из файла
            var lines = File.ReadAllLines(fullPath);

            foreach (string line in lines)
            {
                // Пропускаем пустые строки, если они есть в файле
                if (string.IsNullOrWhiteSpace(line)) continue;

                string username = line.Trim();

                // Именно так оформляем возврат тестовых случаев
                yield return new TestCaseData(username);
            }
        }
    }
}