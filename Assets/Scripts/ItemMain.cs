using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMain : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;

    public Button LeftBtn;
    public Button RightBtn;

    private void OnEnable() {
        EventHandler.UpdateSingleItemInfoEvent += OnUpdateSingleItemInfoEvent;
    }

    private void OnDisable() {
        EventHandler.UpdateSingleItemInfoEvent -= OnUpdateSingleItemInfoEvent;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnUpdateSingleItemInfoEvent(int index,BagSingleItemInfo bagSingleItemInfo)
    {
        itemName.text = bagSingleItemInfo.itemName;
        itemImage.sprite = bagSingleItemInfo.sprite;

        if(index == 0){
            LeftBtn.enabled = false;
            LeftBtn.interactable = false;
        }
        else if(index == BagManager.Instance.bagItemData.BagList.Count - 1){
            RightBtn.enabled = false;
            RightBtn.interactable = false;
        }
        else{
            LeftBtn.enabled = true;
            LeftBtn.interactable = true;
            RightBtn.enabled = true;
            RightBtn.interactable = true;
        }
    }
}
