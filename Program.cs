namespace Anim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерноесть карты (x, y) на отдельных строках");
            var CatalogAnimals = new List<Anim>();           
            var x = int.Parse(EmptyStringCheckDigit());// 
            var y = int.Parse(EmptyStringCheckDigit());
            var mas = Map.MapEdit(x, y);
            Catalog();
            while (true)
            {
                var checkPoint = Console.ReadLine();
                if (checkPoint == "q") break;
                switch (checkPoint)
                {
                    case "1":
                        {
                            Map.ViewMap(mas, x, y);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите две строки: первая строка имя зверя. Вторая стока тип зверя");
                            Console.WriteLine("1 - собака, 2 - птица");
                            var name = EmptyStringCheck();
                            var atr = AttributeSelection();
                            Anim animal = new Anim(name, atr);
                            CatalogAnimals.Add(animal);
                            break;
                        }
                    case "3":
                        {
                            foreach (Anim anim in CatalogAnimals)
                            {
                                anim.position = Map.StandMap(mas, x, y, anim.atr);

                            }
                            Map.PositionOnMap(mas, x, y, CatalogAnimals);
                            break;
                        }
                    case "4":
                        {
                            Map.PositionOnMap(mas, x, y, CatalogAnimals);
                            break;
                        }
                    case "5":
                        {

                            Map.Motion(CatalogAnimals, x, y, mas);
                            Map.PositionOnMap(mas, x, y, CatalogAnimals);
                            break;
                        }
                    case "9":
                        {
                            Catalog();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            
        }

        static string EmptyStringCheckDigit() // проверка на входные данные (пустую строку)
        {
            while (true)
            {
                var x = Console.ReadLine();
                if (x == "") Console.WriteLine("Ошибка. Пустая строка");
                else if (!DigitChek(x)) continue;
                else
                {
                    return x;
                }
            }       
        }
        
        static string EmptyStringCheck()
        {
            while (true)
            {
                var x = Console.ReadLine();
                if (x == "") Console.WriteLine("Ошибка. Пустая строка");
                else
                {
                    return x;
                }
            }
        }

        static bool DigitChek(string text) // Проверка что строка состоит из цифр
        {
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    Console.WriteLine("Введите цифровое значение");
                    return false;
                }
            }
            return true;
        }

        static void Catalog()
        {
            Console.WriteLine("Команда \"1\" - показать карту");
            Console.WriteLine("Команда \"2\" - добавление объектов");
            Console.WriteLine("Команда \"3\" - расстановка объектов на карте");
            Console.WriteLine("Команда \"4\" - показать карту с объектами");
            Console.WriteLine("Команда \"5\" - выполнить один шаг");
            Console.WriteLine("Команда \"q\" - выйти из программы");
            Console.WriteLine("Команда \"9\" - вывести инструкцию повторно");
        }

        public static int rand(int i)
        {
            var rand = new Random();
            return rand.Next(i);
        }

        public static int AttributeSelection()
        {
            var x = "";
            while (true)
            {
                x = EmptyStringCheckDigit();
                if (int.Parse(x) == 1 || int.Parse(x) == 2)
                {
                    break;
                }
            }
            return int.Parse(x);
        }
    }
}
