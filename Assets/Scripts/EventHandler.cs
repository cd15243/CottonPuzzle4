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
}
