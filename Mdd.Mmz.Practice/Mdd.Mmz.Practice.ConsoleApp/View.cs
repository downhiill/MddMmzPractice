using Mdd.Mmz.Practice.Core;


namespace Mdd.Mmz.Practice.ConsoleApp
{
    public class View : IView
    {
        public string GetMode()
        {
            Console.WriteLine("|---------------------------------------------------------------------------|");
            Console.WriteLine("|Режимы: 1 - Добавить, 2 - Изменить запись, 3 - Удалить запись, 4 - Просмотр|");
            Console.WriteLine("|---------------------------------------------------------------------------|");

            var text =  Console.ReadLine();

            return text;
            
        }
        
        public void ShowPerson(Person person)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Id: {person.Id} |");
            Console.Write($"Возраст: {person.Age} |");
            Console.Write($"Номер телефона: {person.Phone} |");
            Console.Write($"Введите имя: {person.Name} |");
            Console.Write($"Введите город: {person.City} |");
            Console.Write($"Введите страну: {person.Country}|");
            Console.ResetColor();
            Console.WriteLine("");

        }

        public Person EditPerson(Person person)
        {
            Console.WriteLine("");

            Console.WriteLine("Введите возраст:");
            person.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер телефона:");
            person.Phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя: ");
            person.Name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Введите город: ");
            person.City = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Введите страну: ");
            person.Country = Convert.ToString(Console.ReadLine());

            Console.WriteLine("-------------");


            return person;
        }

        public string GetRepeat()
        {
            Console.WriteLine("Ввести данные еще раз? (1 - да, 2 - нет)");
            var text = Console.ReadLine();

            return text;
        }
        
        public string GetEditPersonId()
        {
            Console.WriteLine("Введите id сотрудника:");
            var personId = Console.ReadLine();

            return personId;

        }

        public string GetDeletePersonId()
        {
            Console.WriteLine("Введите id сотрудника:");
            var personId = Console.ReadLine();

            return personId;
        }
        
        public string GetShow()
        {
            Console.WriteLine("Вывести ифнормацию? (1 - да, 2 - нет)");
            var text = Console.ReadLine();

            return text;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
