namespace Anim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("asdsad");
            var rand = new Random();
            List<Anim> CatalogAnimals = new List<Anim>();
            var x = int.Parse(Test());
            var y = int.Parse(Test());
            var mas = Map.mapedit(x, y);
            instr();
            while (true)
            {
                var contr = Console.ReadLine();
                if (contr == "q") break;
                switch (contr)
                {
                    case "1":
                        {
                            Map.viewmap(mas, x, y);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите две строки: первая строка имя зверя. Вторая стока тип зверя");
                            Console.WriteLine("1 - собака, 2 - птица");
                            var name = testvoid();
                            var atr = oneortwo();
                            Anim animal = new Anim(name, atr);
                            CatalogAnimals.Add(animal);
                            break;
                        }
                    case "3":
                        {
                            foreach (Anim anim in CatalogAnimals)
                            {
                                anim.position = Map.standmap(mas, x, y, anim.atr);

                            }
                            Map.Posonmap(mas, x, y, CatalogAnimals);
                            break;
                        }
                    case "4":
                        {
                            Map.Posonmap(mas, x, y, CatalogAnimals);
                            break;
                        }
                    case "5":
                        {

                            Map.motion(CatalogAnimals, x, y, mas);
                            Map.Posonmap(mas, x, y, CatalogAnimals);
                            break;
                        }
                    case "9":
                        {
                            instr();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            
        }

        static string Test()
        {
            while (true)
            {
                var x = Console.ReadLine();
                if (x == "") Console.WriteLine("Ошибка. Пустая строка");
                else if (!exam(x)) continue;
                else
                {
                    return x;
                }
            }       
        }
        
        static string testvoid()
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

        static bool exam (string text)
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

        static void instr()
        {
            Console.WriteLine("Команда \"1\" - показать карту");
            Console.WriteLine("Команда \"2\" - добавление объектов");
            Console.WriteLine("Команда \"3\" - расстановка объектов на карте");
            Console.WriteLine("Команда \"4\" - показать карту с объектами");
            Console.WriteLine("Команда \"5\" - выполнить один шаг");
            Console.WriteLine("Команда \"q\" - выйти из программы");
            Console.WriteLine("Команда \"9\" - вывести инструкцию повторно");
        }

        public static int rand()
        {
            var rand = new Random();
            return rand.Next();
        }
        public static int rand(int i)
        {
            var rand = new Random();
            return rand.Next(i);
        }

        public static int oneortwo()
        {
            var x = "";
            while (true)
            {
                x = Test();
                if (int.Parse(x) == 1 || int.Parse(x) == 2)
                {
                    break;
                }
            }
            return int.Parse(x);
        }
    }
}
