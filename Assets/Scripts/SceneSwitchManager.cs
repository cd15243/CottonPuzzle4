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
        SceneManager.LoadScene("UI",LoadSceneMode.Additive);
        StartCoroutine(StartScene(startSceneName));
    }

    private IEnumerator StartScene(string sceneName){
        if(SceneManager.GetActiveScene().name != "Main Scene"){
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        yield return LoadSceneSetActive(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onMyCallSwitchSceneFun(string sceneName)
    {
        StartCoroutine(SwitchScene(sceneName));
    }

    private IEnumerator SwitchScene(string sceneName){
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadSceneSetActive(sceneName);
    }

    private IEnumerator LoadSceneSetActive(string sceneName){
        yield return SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);

        Scene scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(scene);
    }
}
