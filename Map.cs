namespace Anim
{
    public class Map
    {
        public static int[,] MapEdit(int x, int y) //создание карты
        {
            var rand = new Random();
            var result = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var chance = rand.Next(1, 11);    
                    if (chance == 1)   
                        result[i, j] = 2;// дерево
                    else if (chance > 1 && chance < 5)
                        result[i, j] = 1;// вода
                    else 
                        result[i, j] = 0;// земля
                }
            }
            return result;
        }
        
        public static void ViewMap(int[,] map, int rows, int columns) //просмотр карты
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{map[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public static int[] StandMap(int[,] map, int rows, int columns, int atr) // установка первоначального положения объектов на карте
        {
            var result = new int[2];
            while (true)
            {
                var x = Program.rand(rows);
                var y = Program.rand(columns);
                if ( map[x, y] < atr)
                {
                    result[0] = x;
                    result[1] = y;
                    break;
                }                
            }
            return result;
        }

        public static void PositionOnMap(int[,] map, int rows, int columns, List<Anim> CatalogAnimals) // отрисовывает объекты на карте
        {
            var vs = new int[CatalogAnimals.Count()][]; // массив положений объектов на карте
            var namesAnimals = new string[CatalogAnimals.Count()]; //массив имен объектов
            for (int i = 0; i < vs.Length; i++) 
            {
                vs[i] = CatalogAnimals[i].position;
                namesAnimals[i] = CatalogAnimals[i].name;
            }
            for (int i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var checkPoint = true;
                    var t = 0;
                    foreach (var tt in vs)
                    {
                        
                        if (i == tt[0] && j== tt[1])                    // проверка на нахождение обектов в текущих 
                        {
                            Console.Write($"{namesAnimals[t][0]} \t");
                            checkPoint = false;
                            break;
                        }
                        t++;
                    }
                    if (checkPoint) Console.Write($"{map[i, j]} \t");
                }
                Console.WriteLine();
            }            
        }

        public static bool Exam(List<Anim> CatalogAnimals, int[] pos, int atr) // проверка на столкновение и ландшафт
        {   
            var ActiveAn = CatalogAnimals.Any(a => a.position == pos && a.atr == atr); // с помощью linq проверка на столкновения при шаге
            if (ActiveAn) return false;
            else return true;
        }

        public static void Motion(List<Anim> CatalogAnimals, int rows, int columns, int[,] map) // движение объекта по карте
        {            
            for (int i = 0; i < CatalogAnimals.Count; i++)
            {
                var basis = new int[2]; // переменная для временных координат
                var x = CatalogAnimals[i].position[0] + CatalogAnimals[i].Move();
                var y = CatalogAnimals[i].position[1] + CatalogAnimals[i].Move();
                basis[0] = x;
                basis[1] = y;
                if (x < rows && y < columns && x >= 0 && y >= 0 && // проверка на границы
                    Exam(CatalogAnimals, basis, CatalogAnimals[i].atr) && map[x, y] <= CatalogAnimals[i].atr) // проверка на столкновение и ландшафт
                {
                    CatalogAnimals[i].position = basis;
                }
            }

        }
    }
}
