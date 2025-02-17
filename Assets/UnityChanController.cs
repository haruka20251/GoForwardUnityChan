using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;//animation�����锠
    Rigidbody2D rigid2D;//���W�b�hbody�����锠
    private float groundLevel = -3.0f;//�n�ʂ̈ʒu
    private float dump = 0.8f;//�W�����v�̑��x�̌���
    private float jumpVelocity = 20f;//�W�����v�̑��x
    private float deadLine = -9;//�Q�[���I�[�o�[��\������ʒu


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�A�j���[�^�[��SetFloat�^�̃g���K�[�̐ݒ�
        //SetFloat��Horizontal�Ƃ����g���K�[��1�ɕς���
        this.animator.SetFloat("Horizontal", 1);

        //isGround �́A�L�����N�^�[���n�ʂɐڒn���Ă��邩�ǂ�����\���ϐ���
        //(�j�Hfalse:true;�ŃI�u�W�F�N�g�̍������n�ʂ�荂���Ƃ��A�ϐ���faise�i�n�ʂɐݒu���ĂȂ��j����ȊO�͐ݒu���Ă���Ǝ���
        bool isGround =(transform.position.y>this.groundLevel)?false:true;

        //�A�j���[�^�[��Bool�^�̃g���K�[isGround�ɕϐ��iisGround�j�̌��ʂ�����R�[�h
        this.animator.SetBool("isGround", isGround);

        //.volume:�l�� 0 ���� 1 �͈̔͂ŁA0 �������A1 ���ő剹��
        //(isGround) ? 1 : 0;: isGround �� true (�n�ʂɐڒn���Ă���) �ꍇ�A���̎��̌��ʂ� 1 
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //Input.GetMouseButtonDown(0)=�}�E�X�̍��{�^�����N���b�N���ꂽ�u�ԂɁuture�v��Ԃ�
        //Vector2 �^�ŁAx ������ y �����̑��x������(�����Y�������i�����j��this.jumpVelocity�̑��x��ݒ�
        //�u�}�E�X�̍��{�^���������ꂽ�v���uisGround �� true�v�̏ꍇ�ɂ̂݃W�����v���������s
        if (Input.GetMouseButton(0) && isGround)
        {
            this.rigid2D.velocity=new Vector2(0,this.jumpVelocity);

        }

        //Input.GetMouseButton(0): �̎�ture�Ȃ̂�==flase�Ń{�^���𗣂����Ƃ��ɂȂ�
        if (Input.GetMouseButton(0)==false)
        {
            //this.rigid2D.velocity.y: �L�����N�^�[�� y �����̑��x�i���������̑��x�j��\��
            if (this.rigid2D.velocity.y > 0)
            {
                //���x�Ɍ����W�����|���邱�ƂŁA���x������������
                //�^�b�v�������ꂽ���_���烆�j�e�B�����̏�����ւ̑��x�𗎂Ƃ��Đ��������������邱�ƂŁA�^�b�v���Â����ꍇ�����A�W�����v�̍������Ⴍ�Ȃ�
                this.rigid2D.velocity*=this.dump;
            }
        }
        if (transform.position.x < this.deadLine)//�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        { 
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
       
        }
    }
}
