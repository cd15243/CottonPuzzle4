using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public bool isPassH2AGame = false;
    public bool mailState = false;
    // Start is called before the first frame update
    void Start()
    {
        if(isPassH2AGame){
            PlayerPrefs.SetInt("IsPassMinGame",1);
        }
        else{
            PlayerPrefs.SetInt("IsPassMinGame",-999);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
