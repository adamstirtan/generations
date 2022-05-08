using System;

using NameGenerator.Generators;

using Generations.ObjectModel;

namespace Generations.Tests.Helpers
{
    public static class ModelFactory
    {
        private static readonly Random random = new();
        private static readonly RealNameGenerator nameGenerator = new();

        public static Person NewPerson()
        {
            string fullName = nameGenerator.Generate();
            string[] split = fullName.Split(' ');

            Person person = new()
            {
                Id = random.Next(),
                FirstName = split[0],
                LastName = split[1]
            };

            return person;
        }
    }
}