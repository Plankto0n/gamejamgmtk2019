using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoNext : MonoBehaviour
{
    VideoPlayer vp;
    public string SceneName;
    // Start is called before the first frame update
    void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if((ulong)vp.frame == vp.frameCount-1)
        {
            EndVideo();
        }
    }

    void EndVideo()
    {
        SceneManager.LoadScene(SceneName);
    }
}
