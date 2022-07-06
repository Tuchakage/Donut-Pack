using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer m_LevelVideo;
    
    public void PlayVideo()
    {
        m_LevelVideo.Play();
    }

    public void StopVideo()
    {
        m_LevelVideo.Stop();
    }
}
