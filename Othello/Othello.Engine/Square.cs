using System;

namespace Othello.Engine
{
    [Serializable]
    public class Square
    {
        public int State { set; get; }
        public bool TurnOverSelect { set; get; }
    }
}
