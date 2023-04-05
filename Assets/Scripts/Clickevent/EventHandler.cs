using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler
{
    public static event Action<string> SwitchSceneFun;
    public static void CallSwitchSceneFun(string sceneName){
        SwitchSceneFun?.Invoke(sceneName);
    }

    public static event Action<string> SwitchSceneComplete;
    public static void CallSwitchSceneComplete(string sceneName){
        SwitchSceneComplete?.Invoke(sceneName);
    }

    public static event Action<ItemClickDirection> ItemClickDirectionEvent;
    public static void CallItemClickDirectionEvent(ItemClickDirection itemClickDirection){
        ItemClickDirectionEvent?.Invoke(itemClickDirection);
    }

    public static event Action<int,BagSingleItemInfo> UpdateSingleItemInfoEvent;
    public static void CallUpdateSingleItemInfoEvent(int index,BagSingleItemInfo bagSingleItemInfo){
        UpdateSingleItemInfoEvent?.Invoke(index,bagSingleItemInfo);
    }

    public static event Action<int> H2ACIRCLEClickEvent;
    public static void CallH2ACIRCLEClickEvent(int index){
        H2ACIRCLEClickEvent?.Invoke(index);
    }
    
    public static event Action H2AResetEvent;
    public static void CallH2AResetEvent(){
        H2AResetEvent?.Invoke();
    }
    public static event Action DialogueEvent;
    public static void CallDialogueEvent(){
        DialogueEvent?.Invoke();
    }
    public static event Action ContinueDialogueEvent;
    public static void CallContinueDialogueEvent(){
        ContinueDialogueEvent?.Invoke();
    }

    public static event Action CloseDialogueEvent;
    public static void CallCloseDialogueEvent(){
        CloseDialogueEvent?.Invoke();
    }

    public static event Action<DialogueContentStruct> StartDialogueEvent;
    public static void CallStartDialogueEvent(DialogueContentStruct dialogueContent){
        StartDialogueEvent?.Invoke(dialogueContent);
    }

    public static event Action ClearCursorEvent;
    public static void CallClearCursorEvent(){
        ClearCursorEvent?.Invoke();
    }

    public static event Action<int> InteractWithItem;
    public static void CallInteractWithItem(int itemId){
        InteractWithItem?.Invoke(itemId);
    }

    public static event Action InteractWithMail;
    public static void CallInteractWithMail(){
        InteractWithMail?.Invoke();
    }

    public static event Action MailOpen;
    public static void CallMailOpen(){
        MailOpen?.Invoke();
    }

    public static event Action MailClose;
    public static void CallMailClose(){
        MailClose?.Invoke();
    }
}
