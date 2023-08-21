using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SourcesPlayer : MonoBehaviour
{
    [Header("SoundsMove")]
    public AudioClip[] moveClips;
    public AudioMixerGroup audioMixerGroup;
    [Range(0,1)]
    public float volume;
    public int audiosSourcesMoveLimit;
    public GameObject targetAudioSourceMove;
    private List<AudioSource> audioSourcesMove;
    private int _indexSounds;

    [Header("SoundsDelth")]
    public AudioSource audioSourceDelth;
    public AudioClip clipDelth;

    private void Start()
    {
        audioSourcesMove = new List<AudioSource>();
        for (int i = 0; i < audiosSourcesMoveLimit; i++)
        {
            var audioSource = targetAudioSourceMove.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = audioMixerGroup;
            audioSource.playOnAwake = false;
            audioSource.volume = volume;
            audioSourcesMove.Add(audioSource);
        }
    }

    public void MoveSounds()
    {
        if (_indexSounds >= audioSourcesMove.Count) { _indexSounds = 0; }
        audioSourcesMove[_indexSounds].clip = moveClips[Random.Range(0, moveClips.Length)];
        audioSourcesMove[_indexSounds].Play();
        _indexSounds++;
    }
    public void Delth()
    {
        audioSourceDelth.clip = clipDelth;
        audioSourceDelth.Play();
    }
}