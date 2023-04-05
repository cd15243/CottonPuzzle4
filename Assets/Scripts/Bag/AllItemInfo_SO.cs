using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllItemInfo", menuName = "GameData/AllItemInfo")]
public class AllItemInfo_SO : ScriptableObject {
    public List<BagSingleItemInfo> ItemList;

    public BagSingleItemInfo GetSingleItemInfo(int itemId){
        BagSingleItemInfo tmpData = null;
        for(int i = 0;i<ItemList.Count;++i){
            if(ItemList[i].itemID == itemId){
                return ItemList[i];
            }
        }
        return tmpData;
    }
}
