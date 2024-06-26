namespace TheOneStudio.DuckBase.Scripts.Elements.Base
{
    using TheOneStudio.DuckBase.Scripts.Elements.Interfaces;
    using UnityEngine;

    public class BaseElementView : MonoBehaviour, IElementView
    {
        public void DestroySelf() { Destroy(this.gameObject); }
    }
}