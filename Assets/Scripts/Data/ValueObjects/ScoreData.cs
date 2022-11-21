using System;

namespace Data.ValueObjects
{
    [Serializable]
    public class ScoreData
    {
        public int Score;
        public int GainScore;
        public int HighScore;
        public int Combo;
        public int MaxComboScore;
    }
}