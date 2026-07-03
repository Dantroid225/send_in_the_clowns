using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Clowns.Data;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Clowns.Tests
{
    /// <summary>
    /// Pure-logic tests for the affinity lookup. All SOs are built in memory (no asset dependency), so
    /// the core "read" contract is verifiable in CI without opening a scene — and the same lookup runs
    /// identically in solo and co-op.
    /// </summary>
    public sealed class AffinityTableTests
    {
        private static T Make<T>() where T : ScriptableObject => ScriptableObject.CreateInstance<T>();

        private static AffinityTableSO.AffinityRow Row(HumorTypeSO h, TemperamentSO c, AffinityGrade g)
            => new AffinityTableSO.AffinityRow { humor = h, crowd = c, grade = g, multiplier = 1f };

        private static void SetRows(AffinityTableSO table, List<AffinityTableSO.AffinityRow> rows)
        {
            // The rows list is private serialized state; poke it directly rather than adding a
            // production-only mutator just for the test.
            var field = typeof(AffinityTableSO).GetField("_rows",
                BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(table, rows);
            table.RebuildLookup();
        }

        [Test]
        public void GetAffinity_ReturnsAuthoredGrade()
        {
            var wit = Make<HumorTypeSO>();
            var slapstick = Make<HumorTypeSO>();
            var snob = Make<TemperamentSO>();
            var rowdy = Make<TemperamentSO>();
            var table = Make<AffinityTableSO>();

            SetRows(table, new List<AffinityTableSO.AffinityRow>
            {
                Row(wit, snob, AffinityGrade.Strong),
                Row(wit, rowdy, AffinityGrade.Weak),
                Row(slapstick, snob, AffinityGrade.Weak),
                Row(slapstick, rowdy, AffinityGrade.Strong),
            });

            Assert.AreEqual(AffinityGrade.Strong, table.GetAffinity(wit, snob).Grade);
            Assert.AreEqual(AffinityGrade.Weak, table.GetAffinity(wit, rowdy).Grade);
            Assert.AreEqual(AffinityGrade.Weak, table.GetAffinity(slapstick, snob).Grade);
            Assert.AreEqual(AffinityGrade.Strong, table.GetAffinity(slapstick, rowdy).Grade);
        }

        [Test]
        public void GetAffinity_UnsetMultiplier_CoercedToOne()
        {
            var wit = Make<HumorTypeSO>();
            var snob = Make<TemperamentSO>();
            var table = Make<AffinityTableSO>();

            SetRows(table, new List<AffinityTableSO.AffinityRow>
            {
                new AffinityTableSO.AffinityRow { humor = wit, crowd = snob, grade = AffinityGrade.Strong, multiplier = 0f }
            });

            Assert.AreEqual(1f, table.GetAffinity(wit, snob).Multiplier);
        }

        [Test]
        public void GetAffinity_MissingPair_ReturnsNeutralWithoutThrowing()
        {
            var wit = Make<HumorTypeSO>();
            var snob = Make<TemperamentSO>();
            var table = Make<AffinityTableSO>();
            SetRows(table, new List<AffinityTableSO.AffinityRow>());

            LogAssert.Expect(LogType.Warning, new Regex("No authored row"));
            var result = table.GetAffinity(wit, snob);

            Assert.AreEqual(AffinityGrade.Neutral, result.Grade);
            Assert.AreEqual(1f, result.Multiplier);
        }

        [Test]
        public void GetAffinity_NullArgs_ReturnNeutral()
        {
            var table = Make<AffinityTableSO>();
            SetRows(table, new List<AffinityTableSO.AffinityRow>());

            LogAssert.Expect(LogType.Warning, new Regex("Null lookup"));
            Assert.AreEqual(AffinityGrade.Neutral, table.GetAffinity(null, null).Grade);
        }
    }
}
