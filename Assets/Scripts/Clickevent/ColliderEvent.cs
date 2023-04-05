using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ColliderEvent : MonoBehaviour
{
    private Dictionary<string,ClickTypes> clickTypes2Enum = new Dictionary<string, ClickTypes>();

    [ClickTypesAttribute]
    public string clickTypes = string.Empty;
    private Ray ray;

    private void Awake() {
        clickTypes2Enum.Add("SCENECHANGE",ClickTypes.SCENECHANGE);
        clickTypes2Enum.Add("H2ACIRCLE",ClickTypes.H2ACIRCLE);
        clickTypes2Enum.Add("H2ARESET",ClickTypes.H2ARESET);
        clickTypes2Enum.Add("DIALOGUE",ClickTypes.DIALOGUE);
        clickTypes2Enum.Add("ITEM",ClickTypes.ITEM);
        clickTypes2Enum.Add("MAIL",ClickTypes.MAIL);
    }

    // Start is called before the first frame update
    void Start()
    {
        // ray = new Ray(this.gameObject.transform.position, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //ray = Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero;

        if(Input.GetMouseButtonDown(0)){
            ClickTypes curClickType;
            clickTypes2Enum.TryGetValue(clickTypes,out curClickType);
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            for(int i = 0;i < hits.Length;++i){
                RaycastHit2D hit = hits[i];
                if(hit.collider != null && hit.collider.name == this.name)
                {
                    switch (curClickType)
                    {
                        case ClickTypes.SCENECHANGE:
                                // Debug.Log("name = " + hit.transform.name + "tag = " + hit.transform.gameObject.tag);
                                if(hit.transform.gameObject.tag == "SceneTag"){
                                    var switchScene = hit.transform.GetComponent<SwitchScene>();
                                    string sceneName = switchScene.toSceneName;
                                    if(hit.transform.gameObject.name == "Door" && sceneName == "H2A"){
                                        bool isPass = PlayerPrefs.GetInt("IsPassMinGame",-999) == 1 ;
                                        if(isPass){
                                            sceneName = "H3";
                                        }
                                        checkDialogueIsOpen();
                                        EventHandler.CallSwitchSceneFun(sceneName);
                                    }
                                    else{
                                        checkDialogueIsOpen();
                                        EventHandler.CallSwitchSceneFun(sceneName);
                                    }
                                }

                            break;
                        case ClickTypes.H2ACIRCLE:
                            // Debug.Log("name = " + this.name);
                            Match match = Regex.Match(this.name, @"\d+");
                            // Debug.Log("index = " + match.Value);
                            EventHandler.CallH2ACIRCLEClickEvent(int.Parse(match.Value));
                            break;
                        case ClickTypes.H2ARESET:
                            EventHandler.CallH2AResetEvent();
                            break;
                        case ClickTypes.DIALOGUE:
                            if(GlobalVariable.isOnDialogue){
                                EventHandler.CallContinueDialogueEvent();
                            }
                            else{
                                EventHandler.CallDialogueEvent();
                            }
                            break;

                        case ClickTypes.ITEM:
                            int itemId = -1;
                            itemId = hit.collider.transform.GetComponent<SingleItem>().itemId;
                            EventHandler.CallInteractWithItem(itemId);
                            break;

                        case ClickTypes.MAIL:
                            EventHandler.CallInteractWithMail();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void checkDialogueIsOpen(){
        if(GlobalVariable.isOnDialogue){
            EventHandler.CallCloseDialogueEvent();
        }
    }
}
