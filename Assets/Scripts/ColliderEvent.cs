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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.name == this.name)
            {
                switch (curClickType)
                {
                    case ClickTypes.SCENECHANGE:
                            Debug.Log("name = " + hit.transform.name + "tag = " + hit.transform.gameObject.tag);
                            if(hit.transform.gameObject.tag == "SceneTag"){
                                var switchScene = hit.transform.GetComponent<SwitchScene>();
                                string sceneName = switchScene.toSceneName;
                                EventHandler.CallSwitchSceneFun(sceneName);
                            }

                        break;
                    case ClickTypes.H2ACIRCLE:
                        Debug.Log("name = " + this.name);
                        Match match = Regex.Match(this.name, @"\d+");
                        Debug.Log("index = " + match.Value);
                        EventHandler.CallH2ACIRCLEClickEvent(int.Parse(match.Value));
                        break;
                    case ClickTypes.H2ARESET:
                        EventHandler.CallH2AResetEvent();
                        break;
                    default:
                        break;
                }
            }

         
        }

    }
}
