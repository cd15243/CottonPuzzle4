using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[HideInInspector]
[System.Serializable]
public class DialogueContentStruct{
    public int groupId;
    public List<string> content;
}

public class DialogueController : MonoBehaviour
{
    public List<DialogueContentStruct> dialogueContent;
    public bool isHasShipTicket = false;

    private void OnEnable() {
        EventHandler.DialogueEvent += onDialogueEvent;
    }

    private void OnDisable() {
        EventHandler.DialogueEvent -= onDialogueEvent;
    }

    private void onDialogueEvent()
    {
        DialogueContentStruct currentDialogueContent = getCurrentDialogueContent();
        GlobalVariable.isOnDialogue = true;
        EventHandler.CallStartDialogueEvent(currentDialogueContent);
    }

    private DialogueContentStruct getCurrentDialogueContent(){
        int index = 0;
        isHasShipTicket = checkIsHasShipTicket();
        if(isHasShipTicket){
            index = 1;
        }

        return dialogueContent[index];
    }

    private bool checkIsHasShipTicket(){
        bool res = false;
        int boatItemIndex = 1;
        res = BagManager.Instance.IsHasItemInBagByItemId(boatItemIndex);
        return res;
    }
}
