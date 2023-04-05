using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagItemDetail", menuName = "GameData/BagItemDetail")]
public class BagItemDetail_SO : ScriptableObject {
    public List<BagSingleItemInfo> BagList;
}

[System.Serializable]
public class BagSingleItemInfo{
    public BagSingleItemInfo(BagSingleItemInfo tmpData){
        itemID = tmpData.itemID;
        itemName = tmpData.itemName;
        itemNum = tmpData.itemNum;
        sprite = tmpData.sprite;
        isHasItem = true;
    }

    public int itemID;
    public string itemName;
    public Sprite sprite;
    public bool isHasItem;
    public int itemNum;
}
