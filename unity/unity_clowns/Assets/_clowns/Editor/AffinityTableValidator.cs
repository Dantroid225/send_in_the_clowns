using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clowns.Data;
using UnityEditor;
using UnityEngine;

namespace Clowns.EditorTools
{
    /// <summary>
    /// Pillar-2 design-integrity guard for affinity tables. It does NOT lock any specific grade values
    /// — designers own those — it locks the INVARIANT that the read stays a real decision: no humor
    /// type may be a universal answer, and no humor type may dominate the whole roster. It also prints
    /// a per-crowd "best answer(s)" report so a single dominant answer is visible at a glance.
    /// </summary>
    public static class AffinityTableValidator
    {
        private const string MenuPath = "Clowns/Validate Affinity Table";

        [MenuItem(MenuPath)]
        public static void ValidateAll()
        {
            var tables = LoadAllTables();
            if (tables.Count == 0)
            {
                Debug.LogWarning("[AffinityValidator] No AffinityTableSO assets found to validate.");
                return;
            }

            foreach (var table in tables)
                Validate(table);
        }

        /// <summary>Validates one table. Returns true on PASS, false if any check FAILED.</summary>
        public static bool Validate(AffinityTableSO table)
        {
            if (table == null)
                return false;

            table.RebuildLookup();

            var humors = table.Rows.Select(r => r.humor).Where(h => h != null).Distinct().ToList();
            var crowds = table.Rows.Select(r => r.crowd).Where(c => c != null).Distinct().ToList();

            if (humors.Count == 0 || crowds.Count == 0)
            {
                Debug.LogWarning($"[AffinityValidator] '{table.name}' has no complete rows to validate.");
                return true;
            }

            bool passed = true;

            // Grade of a cell (Neutral if that specific cell was left unauthored).
            AffinityGrade GradeOf(HumorTypeSO h, TemperamentSO c) => table.GetAffinity(h, c).Grade;

            // FAIL 1 — universal answer: a humor type Strong against EVERY temperament.
            foreach (var h in humors)
            {
                if (crowds.All(c => GradeOf(h, c) == AffinityGrade.Strong))
                {
                    passed = false;
                    Debug.LogError($"[AffinityValidator] FAIL on '{table.name}': humor type '{h.Id}' is " +
                                   $"Strong against EVERY temperament — a universal answer (violates " +
                                   $"Pillar 2). Weaken at least one of its matchups.");
                }
            }

            // FAIL 2 — roster dominance: a humor type that is >= every other type in EVERY column, and
            // strictly greater than some other type somewhere (so it stands above the field rather than
            // merely tying a symmetric table). Such a type is always at least the best pick.
            foreach (var x in humors)
            {
                bool geqAllEverywhere = crowds.All(c =>
                    humors.Where(y => y != x).All(y => GradeOf(x, c) >= GradeOf(y, c)));
                bool strictlyAboveSomewhere = crowds.Any(c =>
                    humors.Where(y => y != x).Any(y => GradeOf(x, c) > GradeOf(y, c)));

                if (geqAllEverywhere && strictlyAboveSomewhere)
                {
                    passed = false;
                    Debug.LogError($"[AffinityValidator] FAIL on '{table.name}': humor type '{x.Id}' is " +
                                   $"the best (>=) answer against every temperament — it dominates the " +
                                   $"roster (violates Pillar 2). No single type may be universally best.");
                }
            }

            // REPORT — best-scoring humor type(s) per crowd (not a failure; makes degeneracy visible).
            var report = new StringBuilder();
            report.AppendLine($"[AffinityValidator] Per-crowd best-answer report for '{table.name}':");
            foreach (var c in crowds)
            {
                AffinityGrade best = humors.Max(h => GradeOf(h, c));
                var winners = humors.Where(h => GradeOf(h, c) == best).Select(h => h.Id);
                report.AppendLine($"    vs {c.Id}: best = {best} -> [{string.Join(", ", winners)}]");
            }
            Debug.Log(report.ToString().TrimEnd());

            if (passed)
                Debug.Log($"[AffinityValidator] PASS: '{table.name}' — no universal or dominant humor type.");

            return passed;
        }

        private static List<AffinityTableSO> LoadAllTables()
        {
            return AssetDatabase.FindAssets("t:AffinityTableSO")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<AffinityTableSO>)
                .Where(t => t != null)
                .ToList();
        }
    }
}
