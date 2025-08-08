using NaughtyAttributes;
using NikosAssets.Helpers;
using UnityEngine;

namespace NikosAssets.PauseHandler
{
    public class ChangeTimeScalePauseListener : BaseNotesMono
    {
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected BasePauseManager _pauseManager;
        
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected float _timeScaleOnPause = 0;
        protected float _prevTimeScale = 1;

        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected bool _resetTimeScaleOnDisable = true;

        protected virtual void OnEnable()
        {
            if (_pauseManager.Paused)
                OnPaused();
            
            _pauseManager.OnPaused += OnPaused;
            _pauseManager.OnUnPaused += OnUnPaused;
        }

        protected virtual void OnDisable()
        {
            _pauseManager.OnPaused -= OnPaused;
            _pauseManager.OnUnPaused -= OnUnPaused;
            
            if (_resetTimeScaleOnDisable)
                OnUnPaused();
        }

        protected virtual void OnPaused()
        {
            PauseTimeScale();
        }
        
        protected virtual void OnUnPaused()
        {
            ResetTimeScale();
        }

        public void PauseTimeScale()
        {
            _prevTimeScale = Time.timeScale;
            Time.timeScale = _timeScaleOnPause;
        }
        
        public void ResetTimeScale()
        {
            Time.timeScale = _prevTimeScale;
        }
    }
}
