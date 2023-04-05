using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleItem : MonoBehaviour
{
    public bool isHas;
    public int itemId;

    [SceneName]
    public string SceneName = string.Empty;

    private void OnEnable() {
        EventHandler.InteractWithItem += onInteractWithItem;
        EventHandler.SwitchSceneComplete += onSwitchSceneComplete;
        EventHandler.MailOpen += OnMailOpen;
        EventHandler.MailClose += OnMailClose;
    }

    private void OnDisable() {
        EventHandler.InteractWithItem -= onInteractWithItem;
        EventHandler.SwitchSceneComplete -= onSwitchSceneComplete;
        EventHandler.MailOpen -= OnMailOpen;
        EventHandler.MailClose -= OnMailClose;
    }

    private void onSwitchSceneComplete(string sceneName)
    {
        isHas = BagManager.Instance.IsHasItemInBagByItemId(itemId);

        if(SceneName == sceneName && isHas){
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onInteractWithItem(int itemId)
    {
        
        Debug.Log("当前物品id = " + itemId);
        // bool mailState = PlayerDataManager.Instance.mailState;
        // if(itemId == 1 && mailState){
        //     return;
        // }
        gameObject.SetActive(false);
        BagManager.Instance.AddItemToBag(itemId,1);
        isHas = true;
    }

    private void OnMailOpen()
    {
        if(itemId == 1 && !isHas){
            gameObject.GetComponent<SpriteRenderer>().enabled = true;            
            gameObject.GetComponent<BoxCollider2D>().enabled = true;            
        }
    }

    private void OnMailClose()
    {
        if(itemId == 1){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;            
            gameObject.GetComponent<BoxCollider2D>().enabled = false;            
        }
    }
}
