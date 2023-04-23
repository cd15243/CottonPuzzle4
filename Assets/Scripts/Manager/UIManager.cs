using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RectTransform itemMain;
    public RectTransform MenuButton;
    public RectTransform DialogueMain;
    public RectTransform CursorUI;
    public RectTransform MainUI;
    public RectTransform bg;
    
    // Start is called before the first frame update
    void Start()
    {
        hideMainUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameStartClick(){
        showMainUI();
        // EventHandler.CallGameStartEvent();
    }

    public void OnGameContinue(){

    }

    private void showMainUI(){
        MainUI.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
        CursorUI.gameObject.SetActive(true);
        // DialogueMain.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        itemMain.gameObject.SetActive(true);
    }

    private void hideMainUI(){
        MainUI.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        CursorUI.gameObject.SetActive(false);
        // DialogueMain.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);
    }

    public void onMenuClick(){
        hideMainUI();
        EventHandler.CallGameRestartEvent();
    }
}
