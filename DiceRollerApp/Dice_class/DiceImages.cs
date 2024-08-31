using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerApp.Class
{
    public sealed class DiceImages
    {
        private const string path = "Resources/Images/";
        private const string png = ".png";

        private readonly Dictionary<int, string[]> DiceImagePaths;
        public DiceImages()
        {
            DiceImagePaths = new Dictionary<int, string[]>
            {
                { 4, new[] { "d4_1", "d4_2", "d4_3", "d4_4" } },
                { 6, new[] { "d6_1", "d6_2", "d6_3", "d6_4", "d6_5", "d6_6" } },
                { 8, new[] { "d8_1", "d8_2", "d8_3", "d8_4", "d8_5", "d8_6", "d8_7", "d8_8" } },
                { 10, new[] { "d10_1", "d10_2", "d10_3", "d10_4", "d10_5", "d10_6", "d10_7", "d10_8", "d10_9", "d10_10" } },
                { 20, new[] { "d20_1", "d20_2", "d20_3", "d20_4", "d20_5", "d20_6", "d20_7", "d20_8", "d20_9", "d20_10",
                              "d20_11", "d20_12", "d20_13", "d20_14", "d20_15", "d20_16", "d20_17", "d20_18", "d20_19", "d20_20" } },
            };
        }
        public string GetDiceImagePath(int faces, int result)
        {
            if (!DiceImagePaths.ContainsKey(faces) || result < 1 || result > DiceImagePaths[faces].Length)
            {
                throw new ArgumentOutOfRangeException($"Invalid faces ({faces}) or result ({result})");
            }
            string fileName = DiceImagePaths[faces][result - 1];
            return $"{path}{fileName}{png}";
        }
    }
}
