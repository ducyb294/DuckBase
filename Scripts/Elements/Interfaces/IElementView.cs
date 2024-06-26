namespace TheOneStudio.DuckBase.Scripts.Elements.Interfaces
{
    using UnityEngine;

    public interface IElementView
    {
        public GameObject GameObject => (this as Component)?.gameObject;

        void DestroySelf();
    }
}