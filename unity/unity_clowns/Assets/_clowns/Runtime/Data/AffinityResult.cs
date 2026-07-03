namespace Clowns.Data
{
    /// <summary>
    /// The outcome of a humor-type-vs-temperament lookup: a discrete <see cref="AffinityGrade"/> plus
    /// a reserved <see cref="Multiplier"/> (defaults to 1, unused at MVP). Populating the multiplier is
    /// how the discrete-vs-continuous question (Q2) flips later — with no recompile and no change to
    /// any consumer of this contract.
    /// </summary>
    public readonly struct AffinityResult
    {
        /// <summary>The discrete grade of the matchup.</summary>
        public readonly AffinityGrade Grade;

        /// <summary>Reserved tuning scalar. Defaults to 1 and is unused at MVP (see Q2).</summary>
        public readonly float Multiplier;

        /// <summary>Creates a result. <paramref name="multiplier"/> defaults to 1 (the MVP value).</summary>
        public AffinityResult(AffinityGrade grade, float multiplier = 1f)
        {
            Grade = grade;
            Multiplier = multiplier;
        }

        /// <summary>The safe default (Neutral, x1) returned when a matchup is not authored.</summary>
        public static AffinityResult Neutral => new AffinityResult(AffinityGrade.Neutral, 1f);
    }
}
