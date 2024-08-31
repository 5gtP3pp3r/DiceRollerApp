using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerApp.Class
{
    public sealed class Roller
    {
        private const int LOWER_FACE = 1;

        private int higherFace;
        private readonly Random Result;
        public int HigherFace
        {
            get => higherFace;
            init
            {
                if (!Dice.FACES_ARRAY.Contains(value))
                {
                    throw new ArgumentOutOfRangeException("higherFace has to be 4, 6, 8, 10 or 20");
                }
                higherFace = value;
            }
        }
        public Roller(int higherFace)
        {
            Result = new();
            HigherFace = higherFace;
        }
        public int GetRandomRoll()
        {
            return Result.Next(LOWER_FACE, HigherFace + 1);
        }
    }
}
