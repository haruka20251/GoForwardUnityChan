using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float scrollSpeed = -1;//スクロール速度
    private float deadLine = -16;//背景終了位置
    private float startLine = 15.8f;//背景開始位置

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.scrollSpeed*Time.deltaTime,0,0);

        //ゲームオブジェクトのX座標がthis.deadLineより小さい（左側にある）場合
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }

    }
}
