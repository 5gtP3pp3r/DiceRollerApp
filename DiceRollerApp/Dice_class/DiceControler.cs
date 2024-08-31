using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerApp.Class
{
    public sealed class DiceController
    {
        private const int MAX_NB_DICES = 5;
        private const int MAX_MODIFIER = 5;

        private readonly List<Dice> DiceList;
        private readonly DiceImages DiceImages;
        public DiceController()
        {
            DiceList =
            [
                      new Dice(4),
                      new Dice(6),
                      new Dice(8),
                      new Dice(10),
                      new Dice(20)
            ];
            DiceImages = new();
        }
        private Dice GetDiceByFaces(int faces)
        {
            if (!Dice.FACES_ARRAY.Contains(faces))
            {
                throw new ArgumentOutOfRangeException("faces has to be 4, 6, 8, 10 or 20");
            }
            return DiceList.Find(dice => dice.NbFaces == faces);
        }
        public (int totalResult, List<string> imagePaths) GetResultAndPaths(int faces, int nbDices, int modifier)
        {
            if (!Dice.FACES_ARRAY.Contains(faces))
            {
                throw new ArgumentOutOfRangeException("faces has to be 4, 6, 8, 10 or 20");
            }
            if (nbDices < 1 || nbDices > MAX_NB_DICES)
            {
                throw new ArgumentOutOfRangeException($"nbDices must be between 1 and {MAX_NB_DICES} inclusive.");
            }
            if (modifier < 0 || modifier > MAX_MODIFIER)
            {
                throw new ArgumentOutOfRangeException($"modifier must be between 0 and {MAX_MODIFIER} inclusive.");
            }

            Dice dice = GetDiceByFaces(faces);
            int totalResult = 0;
            List<string> imagePaths = new();

            for (int qty = 0; qty < nbDices; qty++)
            {
                int result = dice.RollDice();
                totalResult += result + modifier;
                string imagePath = DiceImages.GetDiceImagePath(faces, result);
                imagePaths.Add(imagePath);
            }

            return (totalResult, imagePaths);
        }
    }
}
