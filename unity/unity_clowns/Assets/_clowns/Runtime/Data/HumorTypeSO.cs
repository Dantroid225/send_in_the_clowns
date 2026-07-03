using UnityEngine;

namespace Clowns.Data
{
    /// <summary>
    /// A humor type a clown can perform (e.g. Wit, Slapstick, Dark). Pure data: its combat meaning
    /// comes entirely from the <see cref="AffinityTableSO"/> matchup, not from any hard-coded branch —
    /// so adding or removing a humor type is authoring work, not a code change.
    /// </summary>
    [CreateAssetMenu(fileName = "HT_NewHumorType", menuName = "Clowns/Data/Humor Type", order = 0)]
    public sealed class HumorTypeSO : ClownDataSO
    {
        // Intentionally empty at MVP. Per-type performance signatures (cadence/animation/VFX) and
        // any type-thematic mechanics are added as data here later — never as enum branches.
    }
}
