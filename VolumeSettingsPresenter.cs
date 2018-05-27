using UnityEngine;

namespace MVP
{
    /// <summary>
    /// This class dictates presentation logic.
    /// Note color change when above a certain volume threshold.
    /// </summary>
    public class VolumeSettingsPresenter
    {
        public VolumeSettingsPresenter(IVolumeSettingsView volumeSettingsView, IVolumeModel volumeModel)
        {
            volumeSettingsView.OnIncreaseVolumeButtonClicked += () => { IncreaseVolume(volumeModel); };

            volumeSettingsView.OnDecreaseVolumeButtonClicked += () => { DecreaseVolume(volumeModel); };
			
            volumeModel.OnVolumeChanged += volume => { OnVolumeChanged(volumeSettingsView, volume); };
        }

        private static void OnVolumeChanged(IVolumeSettingsView volumeSettingsView, int volume)
        {
            volumeSettingsView.OnVolumeChanged(volume);

            var color = volume > 5 ? Color.red : Color.black;
            volumeSettingsView.SetVolumeColoring(color);
        }

        private static void DecreaseVolume(IVolumeModel volumeModel)
        {
            volumeModel.Volume--;
        }

        private static void IncreaseVolume(IVolumeModel volumeModel)
        {
            volumeModel.Volume++;
        }
    }
}