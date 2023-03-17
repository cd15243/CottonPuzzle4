using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2ALogic : MonoBehaviour
{
    public Transform Lines;
    public Transform createLinePos;
    public Transform circleTmpGroup;
    public Transform correctCircleGroup;
    private Sprite singleLine;
    private int startNullIndex = 7;
    //   0 1 2 3 4 5 6
    private int [,] lineInfo = new int [ 7,7 ] { 
        {0,1,1,0,0,1,1},
        {1,0,0,0,0,0,1},
        {1,0,0,1,0,0,1},
        {0,0,1,0,0,1,1},
        {0,0,0,0,0,1,1},
        {1,0,0,1,1,0,1},
        {1,1,1,1,1,1,0},
    };


    private int[] startOrder = new int[7]{6,5,4,3,2,1,-1};
    private int[] currentOrder = new int[7]{6,5,4,3,2,1,-1};
    private int[] correctOrder = new int[7]{1,2,3,4,5,6,-1};
    private void OnEnable() {
        EventHandler.H2ACIRCLEClickEvent += onH2ACIRCLEClickEvent;
        EventHandler.H2AResetEvent += onH2AResetEvent;
    }

    private void OnDisable() {
        EventHandler.H2ACIRCLEClickEvent -= onH2ACIRCLEClickEvent;
        EventHandler.H2AResetEvent -= onH2AResetEvent;
    }

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        int res = PlayerPrefs.GetInt("IsPassMinGame",-999);
        if(res == 1){
            Debug.Log("HAS PASS!!!");
        }

        singleLine = Resources.Load<Sprite>("CIRCLELINE");
        createLines();
        InitCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createLines(){
        for(int i = 0;i < 7;++i){
            for(int j = i+1;j < 7;++j){
                if(lineInfo[i,j] == 1){
                    GameObject line = new GameObject();
                    line.AddComponent<SpriteRenderer>();
                    SpriteRenderer lineSpriteRenderer = line.GetComponent<SpriteRenderer>();
                    // lineSpriteRenderer.sortingOrder = -1;
                    lineSpriteRenderer.sprite = singleLine;
                    line.name = "line" + i + "To" + j;
                    line.transform.parent = Lines;
                    int startIndex = (i+1);
                    int endIndex = (j+1);
                    Transform startPos = createLinePos.Find("H2ACircle" + startIndex);
                    Transform endPos = createLinePos.Find("H2ACircle" + endIndex);
                    line.transform.position = getPos(startPos,endPos);

                    Vector3 direction = getDir(startPos,endPos);
                    //计算 线的方向
                    Quaternion targetRotation = Quaternion.FromToRotation(transform.right, direction);
                    line.transform.rotation *= targetRotation;

                    //计算线的长度
                    float lineLength = Mathf.Sqrt(Mathf.Pow(direction.x * 100,2) + Mathf.Pow(direction.y * 100,2));
                    line.transform.localScale = new Vector3(lineLength/100 * 1.5f,1,1);
                }
            }
        }
    }

    Vector3 getPos(Transform startPos,Transform endPos){
        Vector3 res = Vector3.zero;

        res.x = (endPos.position.x + startPos.position.x)/2;
        res.y = (endPos.position.y + startPos.position.y)/2;
        res.z = (endPos.position.z + startPos.position.z)/2;

        return res;
    }

    Vector3 getDir(Transform startPos,Transform endPos){
        Vector3 res = Vector3.zero;

        res.x = (endPos.position.x - startPos.position.x);
        res.y = (endPos.position.y - startPos.position.y);
        res.z = (endPos.position.z - startPos.position.z);

        return res;
    }

    private void onH2ACIRCLEClickEvent(int index)
    {
        int realIndex = index - 1;
        int nullPos = isHasNullPosition(realIndex);
        if(nullPos != -1){
            exchangeCur2Null(realIndex,nullPos);
            exchangeSprite(realIndex,nullPos);
            checkAllPos();
        }
    }

    private int isHasNullPosition(int index){
        int res = -1;

        for(int i = 0;i < 7;++i){
            if(lineInfo[index,i] == 1 && currentOrder[i] == -1){
                return i;
            }
        }

        return res;
    }

    private void exchangeCur2Null(int cur,int nullPos){
        currentOrder[nullPos] = currentOrder[cur];
        currentOrder[cur] = -1;
    }

    //TODO:优化Find
    private void exchangeSprite(int cur,int nullPos){
        Sprite tmpSprite = circleTmpGroup.transform.Find("CircleTmpSign" + (cur + 1)).GetComponent<SpriteRenderer>().sprite;
        circleTmpGroup.transform.Find("CircleTmpSign" + (nullPos + 1)).GetComponent<SpriteRenderer>().sprite = tmpSprite;
        circleTmpGroup.transform.Find("CircleTmpSign" + (cur + 1)).GetComponent<SpriteRenderer>().sprite = null;
    }

    private void checkAllPos(){
        int correctNum = 0;
        for(int i = 0;i < 7;++i){
            int tmpIndex = currentOrder[i];
            if(tmpIndex == correctOrder[i]){
                circleTmpGroup.transform.Find("CircleTmpSign" + (i+1)).gameObject.SetActive(false);
                if(i+1 != 7){
                    correctCircleGroup.transform.Find("CircleCorrectSign" + (i+1)).gameObject.SetActive(true);
                }
                ++correctNum;
            }
            else{
                circleTmpGroup.transform.Find("CircleTmpSign" + (i+1)).gameObject.SetActive(true);
                if(i+1 != 7){
                    correctCircleGroup.transform.Find("CircleCorrectSign" + (i+1)).gameObject.SetActive(false);
                }
            }
        }
        if(correctNum == 7){
            int res = PlayerPrefs.GetInt("IsPassMinGame",-999);
            if(res == -999){
                PlayerPrefs.SetInt("IsPassMinGame",1);
                Debug.Log("PASS!!!");
            }
        }
    }

    private void onH2AResetEvent()
    {
        InitCircle();
        ResetCorrectCircle();
        ResetOrder();
    }

    private void InitCircle(){
        for(int i = 0;i<7;++i){
            int index = startOrder[i];
            Transform tmpCircle = circleTmpGroup.Find("CircleTmpSign" + (i+1));
            tmpCircle.gameObject.SetActive(true);
            if(index != -1){
                Sprite tmpSprite = Resources.Load<Sprite>("SS_0" + index);
                tmpCircle.GetComponent<SpriteRenderer>().sprite = tmpSprite;                
            }
            else{
                tmpCircle.GetComponent<SpriteRenderer>().sprite = null;
            }

        }
    }

    private void ResetCorrectCircle(){
        var transformChildren = correctCircleGroup.GetComponentsInChildren<Transform>();
        foreach(var item in transformChildren){
            item.gameObject.SetActive(false);
        }
        correctCircleGroup.gameObject.SetActive(true);
    }

    private void ResetOrder(){
        for(int i = 0;i<7;++i){
            currentOrder[i] = startOrder[i];
        }
    }
}
