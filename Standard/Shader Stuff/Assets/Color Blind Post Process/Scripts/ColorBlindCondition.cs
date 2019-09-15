using UnityEngine;

namespace Koro
{
    [CreateAssetMenu]
    public class ColorBlindCondition : ScriptableObject
    {
        public ColorBlindType Type;
        public RGBMixContainer Mix;
    }
}