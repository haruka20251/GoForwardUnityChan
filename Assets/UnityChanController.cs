using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;//animationを入れる箱
    Rigidbody2D rigid2D;//リジッドbodyを入れる箱
    private float groundLevel = -3.0f;//地面の位置
    private float dump = 0.8f;//ジャンプの速度の減衰
    private float jumpVelocity = 20f;//ジャンプの速度
    private float deadLine = -9;//ゲームオーバーを表示する位置


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //アニメーターのSetFloat型のトリガーの設定
        //SetFloatのHorizontalというトリガーを1に変える
        this.animator.SetFloat("Horizontal", 1);

        //isGround は、キャラクターが地面に接地しているかどうかを表す変数名
        //(）？false:true;でオブジェクトの高さが地面より高いとき、変数はfaise（地面に設置してない）それ以外は設置していると示す
        bool isGround =(transform.position.y>this.groundLevel)?false:true;

        //アニメーターのBool型のトリガーisGroundに変数（isGround）の結果を入れるコード
        this.animator.SetBool("isGround", isGround);

        //.volume:値は 0 から 1 の範囲で、0 が無音、1 が最大音量
        //(isGround) ? 1 : 0;: isGround が true (地面に接地している) 場合、この式の結果は 1 
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //Input.GetMouseButtonDown(0)=マウスの左ボタンがクリックされた瞬間に「ture」を返す
        //Vector2 型で、x 方向と y 方向の速度を持つ(今回はY軸方向（高さ）にthis.jumpVelocityの速度を設定
        //「マウスの左ボタンが押された」かつ「isGround が true」の場合にのみジャンプ処理を実行
        if (Input.GetMouseButton(0) && isGround)
        {
            this.rigid2D.velocity=new Vector2(0,this.jumpVelocity);

        }

        //Input.GetMouseButton(0): の時tureなので==flaseでボタンを離したときになる
        if (Input.GetMouseButton(0)==false)
        {
            //this.rigid2D.velocity.y: キャラクターの y 方向の速度（垂直方向の速度）を表す
            if (this.rigid2D.velocity.y > 0)
            {
                //速度に減速係数を掛けることで、速度を減速させる
                //タップが離された時点からユニティちゃんの上方向への速度を落として勢いを減衰させることで、タップしつづけた場合よりも、ジャンプの高さが低くなる
                this.rigid2D.velocity*=this.dump;
            }
        }
        if (transform.position.x < this.deadLine)//デッドラインを超えた場合ゲームオーバーにする
        { 
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
       
        }
    }
}
