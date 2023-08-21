using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EditVolumeGroupsMixes : MonoBehaviour
{
    [Header("Sounds")]
    public AudioMixer audioMixer;
    public string nameGroup;

    public void EditVolume(Slider volume)
    {
        audioMixer.SetFloat(nameGroup, volume.value);
    }

    public void BackPadrao(Slider volume)
    {
        volume.value = 0;
        EditVolume(volume);
    }
}