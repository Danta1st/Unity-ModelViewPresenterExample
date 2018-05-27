using System;
using UnityEngine;
using UnityEngine.UI;

namespace MVP
{
	public class VolumeSettingsView : MonoBehaviour, IVolumeSettingsView
	{
		public Button IncreaseVolumeButton;
		public Button DecreaseVolumeButton;
		public Text VolumeLabel;

		public event Action OnIncreaseVolumeButtonClicked;
		public event Action OnDecreaseVolumeButtonClicked;

		public void SetVolumeColoring(Color color)
		{
			VolumeLabel.color = color;
		}

		public void OnVolumeChanged(int volume)
		{
			VolumeLabel.text = volume.ToString();
		}

		private void Awake()
		{
			IncreaseVolumeButton.onClick.AddListener(() =>
			{
				if(OnIncreaseVolumeButtonClicked != null)
					OnIncreaseVolumeButtonClicked.Invoke();
			});
			
			DecreaseVolumeButton.onClick.AddListener(() =>
			{
				if(OnDecreaseVolumeButtonClicked != null)
					OnDecreaseVolumeButtonClicked.Invoke();
			});
			
			new VolumeSettingsPresenter(this, new VolumeModel());
		}
	}
}
