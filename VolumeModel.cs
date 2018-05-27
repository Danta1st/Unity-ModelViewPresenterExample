using System;
using UnityEngine;

namespace MVP
{
    public class VolumeModel : IVolumeModel
    {
        public event Action<int> OnVolumeChanged;

        private int volume;
        public int Volume
        {
            get { return volume; }
            set
            {
                if(volume == value)
                    return;
                
                volume = Mathf.Clamp(value, 0, 10);
				
                if(OnVolumeChanged != null)
                    OnVolumeChanged.Invoke(volume);
            }
        }
    }
}