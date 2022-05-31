namespace MapAn
{
    public interface IMoveb
    {
        public int Move()
        {
            var rand = new Random();
            return rand.Next(-2, 1);
        }

        public int Move(int n)
        {
            var rand = new Random();
            return rand.Next(-n, n + 1);
        }
    }
}
