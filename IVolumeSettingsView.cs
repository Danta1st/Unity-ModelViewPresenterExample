using System;
using UnityEngine;

namespace MVP
{
    public interface IVolumeSettingsView
    {
        event Action OnIncreaseVolumeButtonClicked;
        event Action OnDecreaseVolumeButtonClicked;

        void OnVolumeChanged(int volume);
		
        void SetVolumeColoring(Color color);
    }
}