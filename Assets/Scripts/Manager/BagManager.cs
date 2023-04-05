using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : Singleton<BagManager>
{
    public BagItemDetail_SO bagItemData;
    public AllItemInfo_SO allItemInfo;
    public int currentIndex = -1;

    private void OnEnable() {
        EventHandler.ItemClickDirectionEvent += OnItemClickDirectionEvent;
    }

    private void OnDisable() {
        EventHandler.ItemClickDirectionEvent -= OnItemClickDirectionEvent;
    }

    private void Start() {
        if(bagItemData.BagList.Count > 0 && currentIndex >= 0){
            BagSingleItemInfo tmpInfo = bagItemData.BagList[currentIndex];
            EventHandler.CallUpdateSingleItemInfoEvent(currentIndex,tmpInfo);
        }
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
        if (tmpIndex < 0 || tmpIndex >= bagItemData.BagList.Count){
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

    public bool IsHasItemInBagByItemId(int id){
        bool res = false;

        foreach(BagSingleItemInfo singleItemInfo in bagItemData.BagList){
            if(singleItemInfo.itemID == id){
                res = true;
                break;
            }
        }

        return res;
    }

    public bool AddItemToBag(int itemId,int num){
        bool res = false;

        for(int i = 0;i < bagItemData.BagList.Count; ++i){
            if(bagItemData.BagList[i].itemID == itemId){
                bagItemData.BagList[i].itemNum += num;
                res = true;
                break;
            }
        }

        if(!res){
            BagSingleItemInfo tmpData = allItemInfo.GetSingleItemInfo(itemId);
            tmpData.itemNum = num;
            BagSingleItemInfo newItem = new BagSingleItemInfo(tmpData);
            bagItemData.BagList.Add(newItem);
            res = true;
        }

        if(currentIndex == -1){
            currentIndex = 0;
            Debug.Log("更新1");
            EventHandler.CallUpdateSingleItemInfoEvent(currentIndex,bagItemData.BagList[0]);
        }

        return res;
    }

    public bool DeleteItemFromBag(int itemId, int num){
        bool res = false;

        for(int i = 0;i < bagItemData.BagList.Count; ++i){
            if(bagItemData.BagList[i].itemID == itemId){
                bagItemData.BagList[i].itemNum -= num;
                if(bagItemData.BagList[i].itemNum <= 0){
                    bagItemData.BagList.Remove(bagItemData.BagList[i]);
                }
                res = true;
                break;
            }
        }

        return res;
    }

}
