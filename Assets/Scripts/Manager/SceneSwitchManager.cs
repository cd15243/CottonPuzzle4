using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    [SceneName]
    public string startSceneName = string.Empty;

    private void OnEnable() {
        EventHandler.SwitchSceneFun += onMyCallSwitchSceneFun;
    }

    private void OnDisable() {
        EventHandler.SwitchSceneFun -= onMyCallSwitchSceneFun;
    }

    protected void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartScene(startSceneName));
    }

    private IEnumerator StartScene(string sceneName){
        // if(SceneManager.GetActiveScene().name != "MainScene"){
        //     yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        // }
        // Debug.Log("StartScene = UI");
        yield return SceneManager.LoadSceneAsync("UI",LoadSceneMode.Additive);
        // Debug.Log("StartScene = " + sceneName);
        yield return LoadSceneSetActive(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onMyCallSwitchSceneFun(string sceneName)
    {
        EventHandler.CallClearCursorEvent();
        StartCoroutine(SwitchScene(sceneName));
    }

    private IEnumerator SwitchScene(string sceneName){
        // Debug.Log("SwitchScene");
        // Debug.Log("UnloadScene = " + SceneManager.GetActiveScene().name);
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        // Debug.Log("StartScene = " + sceneName);
        yield return LoadSceneSetActive(sceneName);
        EventHandler.CallSwitchSceneComplete(sceneName);
    }

    private IEnumerator LoadSceneSetActive(string sceneName){
        // Debug.Log("LoadSceneSetActive");
        // Debug.Log("LoadSceneSetActive = " + sceneName);
        yield return SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
        // 通过场景名字获取到该场景的 index
        int sceneIndex = SceneManager.GetSceneByName(sceneName).buildIndex;
        // Debug.Log("sceneIndex = " + sceneIndex);
        Scene scene = SceneManager.GetSceneByBuildIndex(sceneIndex);
        // Debug.Log("SetActiveScene = " + scene.name);
        SceneManager.SetActiveScene(scene);
    }
}
