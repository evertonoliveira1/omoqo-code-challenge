namespace OmoqoCodeChallenge.Infrastructure.Data
{
    using System;

    public class DataFaker
    {
        public class FakeItem
        {
            public string Name { get; set; }
            public decimal Length { get; set; }
            public decimal Width { get; set; }
            public string Code { get; set; }
        }

        public static string GenerateFakeCode()
        {
            var random = new Random();
            return $"{RandomString(4)}-{random.Next(1000, 9999)}-{RandomString(1)}{random.Next(1, 9)}";
        }

        static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
