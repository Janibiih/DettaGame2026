using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
   [SerializeField] AudioSource musicSource;

   [Header("------ Audio Clip ------")]
   public AudioClip SnowStage1;
   public AudioClip SnowStage2;
   public AudioClip SnowStage3;

   public AudioClip MountainStage1;
   public AudioClip MountainStage2;
   public AudioClip MountainStage3;

   public AudioClip ForrestStage1;
   public AudioClip ForrestStage2;
   public AudioClip ForrestStage3;

   public void PlayMusic(AudioClip clip, float volume)
    {
        musicSource.PlayOneShot(clip);
        volume = musicSource.volume;
    }



  
}