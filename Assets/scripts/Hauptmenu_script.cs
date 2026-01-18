using UnityEngine;
using UnityEngine.Video;   // wichtig für VideoPlayer

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // im Inspector zuweisen

    public void PlayVideo()
    {
        if (videoPlayer == null) return;

        // Optional: Video von Anfang an
        videoPlayer.time = 0;
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        if (videoPlayer == null) return;
        videoPlayer.Pause();
    }
}

