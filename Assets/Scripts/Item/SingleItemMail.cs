using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleItemMail : SingleItem
{
    public GameObject mailOpen;
    public GameObject mailClose;

    private void OnEnable() {
        EventHandler.InteractWithMail += onInteractWithMail;

        EventHandler.SwitchSceneComplete += onSwitchSceneComplete;
    }

    private void OnDisable() {
        EventHandler.InteractWithMail -= onInteractWithMail;

        EventHandler.SwitchSceneComplete -= onSwitchSceneComplete;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void onSwitchSceneComplete(string sceneName)
    {
        if(SceneName == sceneName && itemId == -1){
            bool currentMailState = PlayerDataManager.Instance.mailState; 

            if(currentMailState){
                mailOpen.gameObject.SetActive(true);
                mailClose.gameObject.SetActive(false);
            }
            else{
                mailOpen.gameObject.SetActive(false);
                mailClose.gameObject.SetActive(true);
            }
        }
    }

    private void onInteractWithMail()
    {
        bool isHasBoatTicket = BagManager.Instance.IsHasItemInBagByItemId(1);
        bool currentMailState = PlayerDataManager.Instance.mailState;
        
        Debug.Log("currentMailState = " + currentMailState.ToString());

        if(!currentMailState){
            mailOpen.gameObject.SetActive(true);
            mailClose.gameObject.SetActive(false);
            if(!isHasBoatTicket){
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            EventHandler.CallMailOpen();
        }
        else{
            mailOpen.gameObject.SetActive(false);
            mailClose.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            EventHandler.CallMailClose();
        }

        PlayerDataManager.Instance.mailState = !currentMailState;
    }
}
