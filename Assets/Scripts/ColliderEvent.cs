using System.Net.WebSockets;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    private Ray ray;
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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.name == this.name)
            {
                Debug.Log("name = " + hit.transform.name + "tag = " + hit.transform.gameObject.tag);
                if(hit.transform.gameObject.tag == "SceneTag"){
                    var switchScene = hit.transform.GetComponent<SwitchScene>();
                    string sceneName = switchScene.toSceneName;
                    EventHandler.CallSwitchSceneFun(sceneName);
                }
            }            
        }

    }
}
