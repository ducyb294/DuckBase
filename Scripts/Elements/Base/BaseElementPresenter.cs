namespace TheOneStudio.DuckBase.Scripts.Elements.Base
{
    using Cysharp.Threading.Tasks;
    using GameFoundation.Scripts.Utilities.ObjectPool;
    using TheOneStudio.DuckBase.Scripts.Elements.Interfaces;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public abstract class BaseElementPresenter<TView> : IElementPresenter where TView : IElementView
    {
        protected TView View;
        private   bool  isSpawn;

        public virtual string AddressableId { get; } = typeof(TView).Name;

        public abstract UniTask BindData();

        /// <summary>
        /// Should call this method by ElementManager
        /// </summary>
        public virtual UniTask Dispose()
        {
            if (this.isSpawn)
            {
                this.View.GameObject.Recycle();
            }

            this.View = default;
            return UniTask.CompletedTask;
        }

        /// <summary>
        /// Should call this method by ElementManager
        /// </summary>
        public async UniTask DestroyView()
        {
            Object.Destroy(this.View.GameObject);
            await this.Dispose();
        }

        public void SetView(GameObject view)
        {
            this.View    = (TView)view.GetComponent<IElementView>();
            this.isSpawn = true;
        }

        public void SetView(IElementView view)
        {
            this.View    = (TView)view;
            this.isSpawn = false;
        }
    }

    public abstract class BaseElementPresenter<TView, TModel> : IElementPresenter<TModel> where TView : IElementView
    {
        protected TView  View;
        protected TModel Model;
        private   bool   isSpawn;


        public virtual string AddressableId { get; } = typeof(TView).Name;

        public abstract UniTask BindData();

        public void SetModel(TModel model) { this.Model = model; }

        /// <summary>
        /// Should call this method by ElementManager
        /// </summary>
        public UniTask Dispose()
        {
            if (this.isSpawn)
            {
                this.View.GameObject.Recycle();
            }

            this.View  = default;
            this.Model = default;
            return UniTask.CompletedTask;
        }

        /// <summary>
        /// Should call this method by ElementManager
        /// </summary>
        public async UniTask DestroyView()
        {
            Object.Destroy(this.View.GameObject);
            await this.Dispose();
        }
        
        public void SetView(GameObject view)
        {
            this.View    = (TView)view.GetComponent<IElementView>();
            this.isSpawn = true;
        }

        public void SetView(IElementView view)
        {
            this.View    = (TView)view;
            this.isSpawn = false;
        }
    }
}