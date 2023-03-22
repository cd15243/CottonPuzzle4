using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : Singleton<BagManager>
{
    public BagItemDetail_SO bagItemData;
    public int currentIndex = 0;

    private void OnEnable() {
        EventHandler.ItemClickDirectionEvent += OnItemClickDirectionEvent;
    }

    private void OnDisable() {
        EventHandler.ItemClickDirectionEvent -= OnItemClickDirectionEvent;
    }

    private void Start() {
        BagSingleItemInfo tmpInfo = bagItemData.BagList[currentIndex];
        EventHandler.CallUpdateSingleItemInfoEvent(currentIndex,tmpInfo);
    }

    private void OnItemClickDirectionEvent(ItemClickDirection itemClickDirection)
    {
        int tmpIndex = currentIndex;
        if(itemClickDirection == ItemClickDirection.Left){
            --tmpIndex;
        }
        else if(itemClickDirection == ItemClickDirection.Right){
            ++tmpIndex;
        }
        if (tmpIndex < 0 || tmpIndex > bagItemData.BagList.Count){
            return;
        }
        currentIndex = tmpIndex;
        BagSingleItemInfo tmpInfo = bagItemData.BagList[tmpIndex];

        EventHandler.CallUpdateSingleItemInfoEvent(tmpIndex,tmpInfo);
    }

    public BagSingleItemInfo GetCurrentItemInfo(){
        BagSingleItemInfo currentItemInfo = bagItemData.BagList[currentIndex];
        return currentItemInfo;
    }
}
