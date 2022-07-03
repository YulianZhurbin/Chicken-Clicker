using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip radiationSound;
    [SerializeField] AudioClip[] spawnSounds;
    [SerializeField] AudioClip[] destructionSounds;

    public void PlaySpawnSound()
    {
        int clipIndex = Random.Range(0, spawnSounds.Length);
        audioSource.PlayOneShot(spawnSounds[clipIndex], 1.0f);
    }

    public void PlayDestructionSound()
    {
        int clipIndex = Random.Range(0, destructionSounds.Length);
        audioSource.PlayOneShot(destructionSounds[clipIndex], 1.0f);
    }

    public void PlayRadiationSound()
    {
        audioSource.PlayOneShot(radiationSound, 1.0f);
    }
}
