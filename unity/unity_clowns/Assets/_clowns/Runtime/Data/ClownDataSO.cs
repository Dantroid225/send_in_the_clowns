using UnityEngine;

namespace Clowns.Data
{
    /// <summary>
    /// Abstract base for inspector-authored identity data assets (humor types, temperaments).
    /// Holds the fields every such asset shares — a stable string key, a debug/UI-only label, and a
    /// grey-box tint — so concrete data types stay free of boilerplate and new data kinds are a
    /// one-line subclass rather than copy-pasted fields.
    /// </summary>
    /// <remarks>
    /// GUARDRAIL (DEC-2026-06-29-C): <see cref="DisplayName"/> is for debug/UI labels ONLY. It must
    /// never contain a joke, punchline, or any comedic line — all in-game humor is performed
    /// gibberish, never written text.
    /// </remarks>
    public abstract class ClownDataSO : ScriptableObject
    {
        [Tooltip("Stable lookup key, lowercase, never comedic content (e.g. \"wit\", \"snob\").")]
        [SerializeField] private string _id;

        [Tooltip("Human-readable label for DEBUG/UI ONLY. NEVER a joke or punchline (DEC-2026-06-29-C).")]
        [SerializeField] private string _displayName;

        [Tooltip("Tint used for grey-box visualisation and editor gizmos.")]
        [SerializeField] private Color _debugColor = Color.white;

        /// <summary>Stable identifier used as a lookup key. Data-authored, never a display string.</summary>
        public string Id => _id;

        /// <summary>Debug/UI-only label. NEVER comedic text (DEC-2026-06-29-C).</summary>
        public string DisplayName => _displayName;

        /// <summary>Grey-box tint for placeholder visuals and editor readability.</summary>
        public Color DebugColor => _debugColor;
    }
}
