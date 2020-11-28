
namespace MineSweeper.Engine
{
    public class Square
    {
        public int NearByMineCnt { get; set; }
        public bool Covered { get; set; }
        public bool Marked { get; set; }
        public bool HasMine { get; set; }

        public Square()
        {
            Covered = false;
            Marked = false;
            HasMine = false;
            NearByMineCnt = 0;
        }
    }
}
