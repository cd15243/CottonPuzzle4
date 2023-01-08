using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagItemDetail", menuName = "GameData/BagItemDetail")]
public class BagItemDetail_SO : ScriptableObject {
    public List<BagSingleItemInfo> BagList;
}

[System.Serializable]
public class BagSingleItemInfo{
    public int itemID;
    public string itemName;
    public Sprite sprite;
}
