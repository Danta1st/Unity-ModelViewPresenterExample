using System;

namespace MVP
{
    public interface IVolumeModel
    {
        event Action<int> OnVolumeChanged;
		
        int Volume { get; set; }
    }
}