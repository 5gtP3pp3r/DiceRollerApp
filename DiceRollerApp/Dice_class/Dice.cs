using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerApp.Class
{
    public sealed class Dice
    {
        public static readonly int[] FACES_ARRAY = [4, 6, 8, 10, 20];

        private int nbFaces;
        private readonly Roller Roll;
        public int NbFaces
        {
            get => nbFaces;
            init
            {
                if (!FACES_ARRAY.Contains(value))
                {
                    throw new ArgumentOutOfRangeException("NbFaces has to be 4, 6, 8, 10 or 20");
                }
                nbFaces = value;
            }
        }
        public Dice(int faces)
        {
            NbFaces = faces;
            Roll = new(faces);
        }
        public int RollDice()
        {
            return Roll.GetRandomRoll();
        }
    }
}
