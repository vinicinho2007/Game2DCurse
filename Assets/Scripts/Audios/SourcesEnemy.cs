using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourcesEnemy : MonoBehaviour
{
    [Header("SoundsAtack")]
    public AudioSource audioSourceAttack;
    public AudioClip clipAtack;

    [Header("SoundsDano")]
    public AudioSource audioSourceDano;
    public AudioClip clipDano;

    [Header("SoundsDelth")]
    public AudioSource audioSourceDelth;
    public AudioClip clipDelth;

    public void Atack()
    {
        audioSourceAttack.clip = clipAtack;
        audioSourceAttack.Play();
    }
    public void Dano()
    {
        audioSourceDano.clip = clipDano;
        audioSourceDano.Play();
    }
    public void Delth()
    {
        audioSourceDelth.clip = clipDelth;
        audioSourceDelth.Play();
    }
}