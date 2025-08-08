using System;
using NaughtyAttributes;
using NikosAssets.Helpers;
using UnityEngine;
using UnityEngine.Events;

namespace NikosAssets.PauseHandler
{
    public class BasePauseManager : BaseNotesMono
    {
        public static event Action<BasePauseManager> OnPausedWorld, OnUnPausedWorld;
        public event Action OnPaused, OnUnPaused;

        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_EVENTS)]
        public UnityEvent OnPausedUnityEvt, OnUnPausedUnityEvt;

        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        [SerializeField]
        protected bool _paused;
        public virtual bool Paused
        {
            get => _paused;
            protected set
            {
                if (_paused != value)
                {
                    _paused = value;

                    if (_paused)
                    {
                        OnPaused?.Invoke();
                        OnPausedWorld?.Invoke(this);

                        OnPausedUnityEvt.Invoke();
                    }
                    else
                    {
                        OnUnPaused?.Invoke();
                        OnUnPausedWorld?.Invoke(this);

                        OnUnPausedUnityEvt.Invoke();
                    }
                }
            }
        }
        
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        [SerializeField]
        protected bool _blockPause;
        public bool BlockPause
        {
            get => _blockPause;
            set => _blockPause = value;
        }

        #region Unity LifeCycle

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
        }

        protected virtual void OnDestroy()
        {
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void OnValidate()
        {
        }

        protected virtual void Reset()
        {
        }

        #endregion

        public virtual void Pause()
        {
            if (BlockPause) return;

            Paused = true;
        }

        public virtual void UnPause()
        {
            if (BlockPause) return;

            Paused = false;
        }

        public virtual void TogglePause()
        {
            TogglePause(!Paused);
        }
        
        public virtual void TogglePause(bool pause)
        {
            if (pause)
                Pause();
            else
                UnPause();
        }

#if UNITY_EDITOR

        [Button("Force Pause", EButtonEnableMode.Playmode)]
        private void Button_ForcePause()
        {
            Pause();
        }

        [Button("Force UnPause", EButtonEnableMode.Playmode)]
        private void Button_ForceUnPause()
        {
            UnPause();
        }

#endif
    }
}
