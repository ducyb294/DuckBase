namespace TheOneStudio.DuckBase.Scripts.Elements.Interfaces
{
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public interface IElementPresenter
    {
        string  AddressableId { get; }
        UniTask Dispose();
        UniTask DestroyView();
        void    SetView(GameObject view);
        void    SetView(IElementView view);
        UniTask BindData();
    }

    public interface IElementPresenter<in TModel> : IElementPresenter
    {
        void SetModel(TModel model);
    }
}