using NaughtyAttributes;
using NikosAssets.Helpers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NikosAssets.PauseHandler
{
    public class TogglPauseByInput : BaseNotesMono
    {
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected BasePauseManager _pauseManager;
        
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected InputActionReference _pauseHandlerInputActions;

        protected virtual void OnEnable()
        {
            _pauseHandlerInputActions.action.Enable();
            _pauseHandlerInputActions.action.performed += OnPausePerformed;
        }

        protected virtual void OnDisable()
        {
            _pauseHandlerInputActions.action.Disable();
            _pauseHandlerInputActions.action.performed -= OnPausePerformed;
        }
        
        protected virtual void OnPausePerformed(InputAction.CallbackContext ctx)
        {
            _pauseManager.TogglePause();
        }
    }
}
