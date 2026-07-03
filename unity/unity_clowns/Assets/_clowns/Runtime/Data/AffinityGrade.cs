namespace Clowns.Data
{
    /// <summary>
    /// How well a humor type lands on a given temperament. Values are ordered
    /// Weak &lt; Neutral &lt; Strong so grades can be compared numerically by the Pillar-2 validator.
    /// </summary>
    public enum AffinityGrade
    {
        /// <summary>The bit bounces off. Least mirth.</summary>
        Weak = 0,

        /// <summary>Lands, but nothing special.</summary>
        Neutral = 1,

        /// <summary>The read pays off. Most mirth.</summary>
        Strong = 2
    }
}
