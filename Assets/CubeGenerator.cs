using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    private float delt = 0;//時間計測をする変数
    private float span = 1.0f;//キューブの生成間隔（時間）
    private float genPosX = 12;//キューブの生成位置：X座標
    private float offsetY = 0.3f;//キューブの生成位置オフセット
    private float spaceY = 6.9f;//キューブの縦方向の間隔
    private float offsetX = 0.5f;//キューブの生成位置オフセット
    private float spaceX = 0.4f;//キューブの横方向の間隔
    private int maxBlockNum = 4;//キューブ生成個数の上限
    //オフセット値とは、基準となる位置や値からのずれや差を表す値
    //位置のオフセット: オブジェクトの基準位置からのずれを調整するために使用
    //↑キャラクターの初期位置を少し右にずらしたい場合など
    //間隔のオフセット: オブジェクト同士の間隔を調整するために使用
    //↑複数のオブジェクトを等間隔に並べたい場合など
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.delt += Time.deltaTime;
        if(this.delt > this.span)//生成の間隔時間を超えたとき
        {
            this.delt = 0;//deltの経過時間を0にリセットする
            //Random.Range(最小値（この値を含む）,最大値（この値を含まない））
            //maxBlockNum + 1 は、生成する整数の最大値（この値を含まない）
            //もし maxBlockNum が 4 の場合、Random.Range(1, maxBlockNum + 1) は、1, 2, 3, 4 のいずれかの整数をランダムに返す
            //今回生成するキューブの個数を表す変数
            int n =Random.Range(1, maxBlockNum+1);


            for(int i=0; i<n; i++)//i が n より小さい間、ループが続く
            {
                //GameObect型のgoという変数にキューブを生成する関数を入れる
                GameObject go =Instantiate(cubePrefab);
                //新しい2次元ベクトル（Vector2）を作成し、goの位置を設定
                //this.offsetY:キューブの初期位置を調整するために使われる
                //この式全体では、i番目のキューブのY座標が計算される。つまり、キューブが縦方向に等間隔に並ぶようにY座標が設定される
                go.transform.position=new Vector2(this.genPosX, this.offsetY+i*this.spaceY);

            }
            //this.spaceX * n で、横方向に並べるキューブの数 n にキューブ間隔 spaceX を乗算し、キューブが並ぶ幅を計算
            //this.offsetX + this.spaceX * n で、キューブが並ぶ幅にオフセット値 offsetX を加算し、次のキューブ生成までの間隔 span を決定
            //成するキューブの数 n が増えるほど、次のキューブ生成までの間隔 span が長くなるように調整される
            this.span=this.offsetX+this.spaceX*n;
        }

    }
    
}
