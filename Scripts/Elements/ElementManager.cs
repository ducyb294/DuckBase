namespace TheOneStudio.DuckBase.Scripts.Elements
{
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using GameFoundation.Scripts.Utilities.ObjectPool;
    using TheOneStudio.DuckBase.Scripts.Elements.Interfaces;
    using Zenject;

    public class ElementManager
    {
        private List<IElementPresenter> presenters = new();

        private readonly DiContainer       diContainer;
        private readonly ObjectPoolManager objectPoolManager;

        public ElementManager(DiContainer diContainer, ObjectPoolManager objectPoolManager)
        {
            this.diContainer       = diContainer;
            this.objectPoolManager = objectPoolManager;
        }

        public async UniTask<TPresenter> Creat<TPresenter>(IElementView view = null)
            where TPresenter : IElementPresenter
        {
            var presenter = this.diContainer.Instantiate<TPresenter>();
            if (view == null)
            {
                presenter.SetView(await this.objectPoolManager.Spawn(presenter.AddressableId));
            }
            else
            {
                presenter.SetView(view);
            }

            await presenter.BindData();
            this.presenters.Add(presenter);

            return presenter;
        }

        public async UniTask<TPresenter> Creat<TPresenter, TModel>(TModel model, IElementView view = null)
            where TPresenter : IElementPresenter<TModel>
        {
            var presenter = this.diContainer.Instantiate<TPresenter>();
            if (view == null)
            {
                presenter.SetView(await this.objectPoolManager.Spawn(presenter.AddressableId));
            }
            else
            {
                presenter.SetView(view);
            }

            presenter.SetModel(model);
            await presenter.BindData();
            this.presenters.Add(presenter);

            return presenter;
        }

        public async UniTask Dispose<TPresenter>(TPresenter presenter)
            where TPresenter : IElementPresenter
        {
            this.presenters.Remove(presenter);
            await presenter.Dispose();
        }

        public void DisposeAll()
        {
            this.presenters.ForEach(x => x.Dispose());
            this.presenters.Clear();
        }

        public async UniTask Destroy<TPresenter>(TPresenter presenter)
            where TPresenter : IElementPresenter
        {
            this.presenters.Remove(presenter);
            await presenter.DestroyView();
        }

        public void DestroyAll()
        {
            this.presenters.ForEach(x => x.DestroyView());
            this.presenters.Clear();
        }
    }
}