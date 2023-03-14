using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2ALogic : MonoBehaviour
{
    public Transform Lines;
    public Transform createLinePos;
    private Sprite singleLine;
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


    private void Awake() {
        // Lines = this.transform.Find("Lines");
    }
    // Start is called before the first frame update
    void Start()
    {
        singleLine = Resources.Load<Sprite>("CIRCLELINE");
        createLines();
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
}
