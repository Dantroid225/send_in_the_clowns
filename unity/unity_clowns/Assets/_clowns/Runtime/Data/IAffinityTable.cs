namespace Clowns.Data
{
    /// <summary>
    /// Read-only affinity lookup contract. Consumers (the mirth system, feedback, enemy AI) depend on
    /// this interface rather than the concrete <see cref="AffinityTableSO"/>, so the table can be
    /// swapped — a unit-test double, a per-arena table, or a future runtime-composed table — without
    /// touching any caller. The lookup is pure: no player/ownership assumptions, so it behaves
    /// identically in solo and in co-op.
    /// </summary>
    public interface IAffinityTable
    {
        /// <summary>Returns the matchup result for a humor type against a crowd temperament.</summary>
        AffinityResult GetAffinity(HumorTypeSO humor, TemperamentSO crowd);
    }
}
