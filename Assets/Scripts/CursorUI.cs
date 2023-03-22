using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorUI : MonoBehaviour
{
    public Image cursorImage;
    private bool isHasItem = false;
    private void OnEnable() {
        EventHandler.ClearCursorEvent += onCallClearCursorEvent;
    }

    private void OnDisable() {
        EventHandler.ClearCursorEvent -= onCallClearCursorEvent;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHasItem){
            cursorImage.transform.position = Input.mousePosition;
        }
    }

    public void onItemClick(){
        if(isHasItem){
            onCallClearCursorEvent();
        }
        else{
            isHasItem = true;
            cursorImage.gameObject.SetActive(true);
            BagSingleItemInfo currentItemInfo = BagManager.Instance.GetCurrentItemInfo();
            Debug.Log("currentItemInfo = " + currentItemInfo.itemName);
        }
    }

    private void onCallClearCursorEvent()
    {
        Debug.Log("onCallClearCursorEvent");
        isHasItem = false;
        cursorImage.gameObject.SetActive(false);
    }
}
