using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float scrollSpeed = -1;//�X�N���[�����x
    private float deadLine = -16;//�w�i�I���ʒu
    private float startLine = 15.8f;//�w�i�J�n�ʒu

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.scrollSpeed*Time.deltaTime,0,0);

        //�Q�[���I�u�W�F�N�g��X���W��this.deadLine��菬�����i�����ɂ���j�ꍇ
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }

    }
}
