using System.Collections.Generic;
using UnityEngine;

namespace Clowns.Data
{
    /// <summary>
    /// Inspector-authored grid of humor-type-vs-temperament matchups, and the single implementation of
    /// the <see cref="IAffinityTable"/> lookup contract. The grid is DATA, not code: designers tune it
    /// in the inspector and re-run the Pillar-2 validator; nothing here recompiles when values change.
    /// </summary>
    /// <remarks>
    /// Seed defaults come from HUMOR_SYSTEM.md §7 and are explicitly NOT a locked decision — they are
    /// hot-swappable tuning values. This asset answers only "what grade is this matchup?" How much a
    /// grade fills the mirth meter is TB-03 config, not here.
    /// </remarks>
    [CreateAssetMenu(fileName = "AT_NewAffinityTable", menuName = "Clowns/Data/Affinity Table", order = 2)]
    public sealed class AffinityTableSO : ScriptableObject, IAffinityTable
    {
        /// <summary>One authored cell of the affinity grid.</summary>
        [System.Serializable]
        public struct AffinityRow
        {
            public HumorTypeSO humor;
            public TemperamentSO crowd;
            public AffinityGrade grade;

            [Tooltip("Reserved tuning scalar (Q2). Leave at 1 for discrete MVP grades; 0 is coerced to 1.")]
            public float multiplier;
        }

        [Tooltip("Authored matchup cells. A missing pair resolves to Neutral x1 with a warning, never an exception.")]
        [SerializeField] private List<AffinityRow> _rows = new List<AffinityRow>();

        // O(1) lookup cache rebuilt from _rows, keyed by the two SO references (reference equality).
        private Dictionary<(HumorTypeSO, TemperamentSO), AffinityResult> _lookup;

        /// <summary>Read-only view of the authored rows, for editor tooling and the validator.</summary>
        public IReadOnlyList<AffinityRow> Rows => _rows;

        private void OnEnable() => RebuildLookup();
        private void OnValidate() => RebuildLookup();

        /// <summary>Rebuilds the fast-lookup cache from the serialized rows. Safe to call repeatedly.</summary>
        public void RebuildLookup()
        {
            if (_lookup == null)
                _lookup = new Dictionary<(HumorTypeSO, TemperamentSO), AffinityResult>();
            else
                _lookup.Clear();

            foreach (var row in _rows)
            {
                if (row.humor == null || row.crowd == null)
                    continue;

                // An unset multiplier serializes as 0; treat that as the MVP default of 1.
                float mult = Mathf.Approximately(row.multiplier, 0f) ? 1f : row.multiplier;
                _lookup[(row.humor, row.crowd)] = new AffinityResult(row.grade, mult);
            }
        }

        /// <inheritdoc/>
        public AffinityResult GetAffinity(HumorTypeSO humor, TemperamentSO crowd)
        {
            if (humor == null || crowd == null)
            {
                Debug.LogWarning($"[AffinityTable] Null lookup argument on '{name}' " +
                                 $"(humor={(humor == null ? "null" : humor.Id)}, " +
                                 $"crowd={(crowd == null ? "null" : crowd.Id)}). Returning Neutral x1.");
                return AffinityResult.Neutral;
            }

            if (_lookup == null)
                RebuildLookup();

            if (_lookup.TryGetValue((humor, crowd), out var result))
                return result;

            Debug.LogWarning($"[AffinityTable] No authored row for ({humor.Id} vs {crowd.Id}) in '{name}'. " +
                             $"Returning Neutral x1 — author this pair or accept the neutral default.");
            return AffinityResult.Neutral;
        }
    }
}
