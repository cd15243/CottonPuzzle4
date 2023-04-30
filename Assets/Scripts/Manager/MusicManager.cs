using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public Transform audioSourceTransform;
    private string currentMusicName;
    private AudioSource audioSource;
    private void OnEnable() {
        EventHandler.SwitchSceneComplete += OnSwitchSceneComplete;
    }

    private void OnDisable() {
       EventHandler.SwitchSceneComplete -= OnSwitchSceneComplete;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioSourceTransform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //通过一个名字来播放音乐
    public void PlayMusic(string name)
    {
        //通过名字来找到对应的音乐
        AudioClip clip = Resources.Load<AudioClip>("Music/" + name);
        //播放音乐
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    private void OnSwitchSceneComplete(string sceneName)
    {
        if(sceneName == "H2A" && currentMusicName!= "OpenRoad"){
            Debug.Log("现在正在播放 = OpenRoad~~~");
            currentMusicName = "OpenRoad";
            PlayMusic("OpenRoad");
        }
        else if(currentMusicName != "PaperWings"){
            Debug.Log("现在正在播放 = PaperWings~~~");
            currentMusicName = "PaperWings";
            PlayMusic("PaperWings");
        }
    }
}
