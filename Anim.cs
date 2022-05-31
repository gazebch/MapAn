using MapAn;

namespace Anim
{
    public class Anim : IMoveb
    {
        public string name; // имя животного
        public int atr; // атрибут животного (1 собака, 2 птица)
        public int[] position = new int[2];
        public Anim(string name, int atr)
        {
            this.name = name;
            this.atr = atr;
        }
        public int Move()
        {
            var rand = new Random();
            return rand.Next(-1, 2);
        }
    }
}
