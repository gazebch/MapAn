namespace Anim
{
    public class Map
    {
        public static int[,] mapedit(int x, int y) //создание карты
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
        
        public static void viewmap(int[,] map, int rows, int columns) //просмотр карты
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

        public static int[] standmap(int[,] map, int rows, int columns, int atr) // установка первоначального положения объектов на карте
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

        public static void Posonmap(int[,] map, int rows, int columns, List<Anim> CatalogAnimals) // отрисовывает объекты на карте
        {
            var vs = new int[CatalogAnimals.Count()][];
            var names = new string[CatalogAnimals.Count()];
            for (int i = 0; i < vs.Length; i++) 
            {
                vs[i] = CatalogAnimals[i].position;
                names[i] = CatalogAnimals[i].name;
            }
            for (int i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var qwe = true;
                    var t = 0;
                    foreach (var tt in vs)
                    {
                        
                        if (i == tt[0] && j== tt[1])
                        {
                            Console.Write($"{names[t][0]} \t");
                            qwe = false;
                            break;
                        }
                        t++;
                    }
                    if (qwe) Console.Write($"{map[i, j]} \t");
                }
                Console.WriteLine();
            }
            
        }

        public static bool exam(List<Anim> CatalogAnimals, int[] pos, int tick, int atr)
        {            
            for (int i = 0; i < CatalogAnimals.Count; i++)
            {
                if (i == tick) continue;
                if (CatalogAnimals[i].position == pos && CatalogAnimals[i].atr == atr)
                {
                    return false;
                }
                
            }
            return true;
        }

        public static void motion(List<Anim> CatalogAnimals, int rows, int columns, int[,] map)
        {
            
            for (int i = 0; i < CatalogAnimals.Count; i++)
            {
                var basis = new int[2];
                var x = CatalogAnimals[i].position[0] + CatalogAnimals[i].Move();
                var y = CatalogAnimals[i].position[1] + CatalogAnimals[i].Move();
                basis[0] = x;
                basis[1] = y;
                if (x < rows && y < columns && x >= 0 && y >= 0 && // проверка на границы
                    exam(CatalogAnimals, basis, i, CatalogAnimals[i].atr) && map[x, y] <= CatalogAnimals[i].atr) // проверка на столкновение и ландшафт
                {
                    CatalogAnimals[i].position = basis;
                }
            }

        }
    }
}
