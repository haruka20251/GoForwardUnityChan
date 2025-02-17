using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    private float delt = 0;//���Ԍv��������ϐ�
    private float span = 1.0f;//�L���[�u�̐����Ԋu�i���ԁj
    private float genPosX = 12;//�L���[�u�̐����ʒu�FX���W
    private float offsetY = 0.3f;//�L���[�u�̐����ʒu�I�t�Z�b�g
    private float spaceY = 6.9f;//�L���[�u�̏c�����̊Ԋu
    private float offsetX = 0.5f;//�L���[�u�̐����ʒu�I�t�Z�b�g
    private float spaceX = 0.4f;//�L���[�u�̉������̊Ԋu
    private int maxBlockNum = 4;//�L���[�u�������̏��
    //�I�t�Z�b�g�l�Ƃ́A��ƂȂ�ʒu��l����̂���⍷��\���l
    //�ʒu�̃I�t�Z�b�g: �I�u�W�F�N�g�̊�ʒu����̂���𒲐����邽�߂Ɏg�p
    //���L�����N�^�[�̏����ʒu�������E�ɂ��炵�����ꍇ�Ȃ�
    //�Ԋu�̃I�t�Z�b�g: �I�u�W�F�N�g���m�̊Ԋu�𒲐����邽�߂Ɏg�p
    //�������̃I�u�W�F�N�g�𓙊Ԋu�ɕ��ׂ����ꍇ�Ȃ�
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.delt += Time.deltaTime;
        if(this.delt > this.span)//�����̊Ԋu���Ԃ𒴂����Ƃ�
        {
            this.delt = 0;//delt�̌o�ߎ��Ԃ�0�Ƀ��Z�b�g����
            //Random.Range(�ŏ��l�i���̒l���܂ށj,�ő�l�i���̒l���܂܂Ȃ��j�j
            //maxBlockNum + 1 �́A�������鐮���̍ő�l�i���̒l���܂܂Ȃ��j
            //���� maxBlockNum �� 4 �̏ꍇ�ARandom.Range(1, maxBlockNum + 1) �́A1, 2, 3, 4 �̂����ꂩ�̐����������_���ɕԂ�
            //���񐶐�����L���[�u�̌���\���ϐ�
            int n =Random.Range(1, maxBlockNum+1);


            for(int i=0; i<n; i++)//i �� n ��菬�����ԁA���[�v������
            {
                //GameObect�^��go�Ƃ����ϐ��ɃL���[�u�𐶐�����֐�������
                GameObject go =Instantiate(cubePrefab);
                //�V����2�����x�N�g���iVector2�j���쐬���Ago�̈ʒu��ݒ�
                //this.offsetY:�L���[�u�̏����ʒu�𒲐����邽�߂Ɏg����
                //���̎��S�̂ł́Ai�Ԗڂ̃L���[�u��Y���W���v�Z�����B�܂�A�L���[�u���c�����ɓ��Ԋu�ɕ��Ԃ悤��Y���W���ݒ肳���
                go.transform.position=new Vector2(this.genPosX, this.offsetY+i*this.spaceY);

            }
            //this.spaceX * n �ŁA�������ɕ��ׂ�L���[�u�̐� n �ɃL���[�u�Ԋu spaceX ����Z���A�L���[�u�����ԕ����v�Z
            //this.offsetX + this.spaceX * n �ŁA�L���[�u�����ԕ��ɃI�t�Z�b�g�l offsetX �����Z���A���̃L���[�u�����܂ł̊Ԋu span ������
            //������L���[�u�̐� n ��������قǁA���̃L���[�u�����܂ł̊Ԋu span �������Ȃ�悤�ɒ��������
            this.span=this.offsetX+this.spaceX*n;
        }

    }
    
}
