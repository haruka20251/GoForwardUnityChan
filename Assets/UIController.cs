using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject gameOverText;//ゲームオーバーテキストを入れる変数
    private GameObject runLengthText;//走行距離テキストを入れる箱
    private float len = 0;//走った距離
    private float speed = 5f;//走る速度
    private bool isgameOver=false;//ゲームオーバー判定

    // Start is called before the first frame update
    void Start()
    {
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーの状態 (this.isgameOver) が false である (つまり、ゲームが続行中である) 場合
        if (this.isgameOver == false)
        {
            this.len += this.speed * Time.deltaTime;
            //
            this.runLengthText.GetComponent<Text>().text = "Distance;" + len.ToString("F2") + "m";

        }

        if(this.isgameOver == true) // ゲームオーバーになった場合
        {
            if (Input.GetMouseButtonDown(0))// クリックされたらシーンをロードする
            {
                SceneManager.LoadScene("SampleScene"); //SampleSceneを読み込む
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバーになった時に、画面上にゲームオーバーを表示
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isgameOver = true;
    }

}
