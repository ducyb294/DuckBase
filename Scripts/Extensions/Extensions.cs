namespace TheOneStudio.DuckBase.Scripts.Extensions
{
    using UnityEngine;

    public static class Extensions
    {
        /// <summary>
        /// Contains layers
        /// </summary>
        public static bool Contains(this LayerMask mask, int layer) { return mask == (mask | (1 << layer)); }
    }
}