using UnityEngine;

namespace Clowns.Data
{
    /// <summary>
    /// An enemy crowd temperament (e.g. Snob, Rowdy). The affinity between a <see cref="HumorTypeSO"/>
    /// and a temperament is the core "read" of the fight (Pillar 2).
    /// </summary>
    [CreateAssetMenu(fileName = "TMP_NewTemperament", menuName = "Clowns/Data/Temperament", order = 1)]
    public sealed class TemperamentSO : ClownDataSO
    {
        [Tooltip("Optional grey-box silhouette proxy wired in TB-06 for the glance-readable tell. " +
                 "The temperament tell is VISUAL — never a text label.")]
        [SerializeField] private GameObject _silhouetteProxyPrefab;

        /// <summary>Optional glance-readable silhouette proxy (visual tell). Nullable; wired in TB-06.</summary>
        public GameObject SilhouetteProxyPrefab => _silhouetteProxyPrefab;
    }
}
