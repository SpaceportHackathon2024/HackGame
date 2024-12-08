using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume_num)
    {
        audioMixer.SetFloat("master_volume", volume_num);
    }
}
