using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CircleCharacter.Constants.UI
{
    public class PanelService : MonoBehaviour, IPanelService
    {
        [SerializeField] private GameView _gameView;

        private readonly Dictionary<Type, BaseView> _views = new();

        public UniTask Initialize()
        {
            AddToCache(_gameView);
            DontDestroyOnLoad(gameObject);
            
            return UniTask.CompletedTask;
        }

        public TView Get<TView>() where TView : BaseView
        {
            return (TView)_views[typeof(TView)];
        }

        private void AddToCache<TView>(TView view) where TView : BaseView
        {
            view.SetEnabled(false);
            _views.Add(view.GetType(), view);
        }
    }
}