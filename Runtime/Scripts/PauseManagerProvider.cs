using NaughtyAttributes;
using NikosAssets.Helpers;
using UnityEngine;

namespace NikosAssets.PauseHandler
{
    public class PauseManagerProvider : BaseSingletonMono<PauseManagerProvider>
    {
        [SerializeField]
        [BoxGroup(HelperConstants.ATTRIBUTE_FIELD_BOXGROUP_SETTINGS)]
        protected BasePauseManager _pauseManager;
        public BasePauseManager GetPauseManager => _pauseManager;
    }
}
