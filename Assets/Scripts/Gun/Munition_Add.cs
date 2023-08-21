using UnityEngine;

public class Munition_Add : MonoBehaviour
{
    public ParticleSystem particleSystemMunition;
    public SOInt munition;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("SFX_MunitionCollet").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource != null) { audioSource.Play(); }
            particleSystemMunition.transform.SetParent(null);
            particleSystemMunition.Play();
            GameObject.FindObjectOfType<Gun>().munitionContinue.value += munition.value;
            Destroy(gameObject);
        }
    }
}