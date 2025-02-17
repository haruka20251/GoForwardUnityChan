using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject gameOverText;//�Q�[���I�[�o�[�e�L�X�g������ϐ�
    private GameObject runLengthText;//���s�����e�L�X�g�����锠
    private float len = 0;//����������
    private float speed = 5f;//���鑬�x
    private bool isgameOver=false;//�Q�[���I�[�o�[����

    // Start is called before the first frame update
    void Start()
    {
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I�[�o�[�̏�� (this.isgameOver) �� false �ł��� (�܂�A�Q�[�������s���ł���) �ꍇ
        if (this.isgameOver == false)
        {
            this.len += this.speed * Time.deltaTime;
            //
            this.runLengthText.GetComponent<Text>().text = "Distance;" + len.ToString("F2") + "m";

        }

        if(this.isgameOver == true) // �Q�[���I�[�o�[�ɂȂ����ꍇ
        {
            if (Input.GetMouseButtonDown(0))// �N���b�N���ꂽ��V�[�������[�h����
            {
                SceneManager.LoadScene("SampleScene"); //SampleScene��ǂݍ���
            }
        }
    }

    public void GameOver()
    {
        //�Q�[���I�[�o�[�ɂȂ������ɁA��ʏ�ɃQ�[���I�[�o�[��\��
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isgameOver = true;
    }

}
