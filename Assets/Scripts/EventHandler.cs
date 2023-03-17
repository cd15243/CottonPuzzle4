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
}
