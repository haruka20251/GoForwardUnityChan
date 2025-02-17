using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = -12;//�L���[�u�̈ړ����x
    private float deadLine = -10;//�L���[�u�̏��ňʒu
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Time.deltaTime�͑O��t���[������̌o�ߎ���(�O��̃t���[�����������Ă��猻�݂̃t���[�����J�n�����܂ł̌o�ߎ���)
        //Time.deltaTime ���g�p���邱�ƂŁA�t���[�����[�g�������Ƃ��͈ړ��ʂ��������Ȃ�A�t���[�����[�g���Ⴂ�Ƃ��͈ړ��ʂ��傫���Ȃ�悤�ɒ�������ru

        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }
}
