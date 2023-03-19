using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public RectTransform dialogueMain;
    public Text content;

    private int dialogueIndex = 0;
    private DialogueContentStruct currentDialogueContent;

    private void OnEnable() {
        EventHandler.StartDialogueEvent += onStartDialogueEvent;
        EventHandler.ContinueDialogueEvent += onContinueDialogueEvent;
        EventHandler.CloseDialogueEvent += onCloseDialogueEvent;
    }

    private void OnDisable() {
        EventHandler.StartDialogueEvent -= onStartDialogueEvent;
        EventHandler.ContinueDialogueEvent -= onContinueDialogueEvent;
        EventHandler.CloseDialogueEvent -= onCloseDialogueEvent;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueMain.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onStartDialogueEvent(DialogueContentStruct tmpDialogueContent)
    {
        dialogueMain.gameObject.SetActive(true);
        dialogueIndex = 0;
        currentDialogueContent = tmpDialogueContent;
        content.text = tmpDialogueContent.content[dialogueIndex];
        ++dialogueIndex;
    }

    private void onContinueDialogueEvent()
    {
        if(currentDialogueContent.content.Count > dialogueIndex){
            content.text = currentDialogueContent.content[dialogueIndex];
            ++dialogueIndex;
        }
        else{
            dialogueMain.gameObject.SetActive(false);
            GlobalVariable.isOnDialogue = false;
        }
    }

    private void onCloseDialogueEvent(){
        dialogueMain.gameObject.SetActive(false);
        GlobalVariable.isOnDialogue = false;
    }
}
