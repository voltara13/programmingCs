using System;

namespace programmingCs
{
    abstract class Person
    {
        protected Person(string firstName, string secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
        }
        private string firstName;
        private string secondName;
        public virtual void print()
        {
            Console.WriteLine($"Имя: {firstName}\n" +
                              $"Фамилия: {secondName}");
        }
    }
}
