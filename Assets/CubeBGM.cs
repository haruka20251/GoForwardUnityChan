using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBGM : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.CompareTag("GroundTag") || CompareTag("CubeTag") ���ƂԂ��������肪"GroundTag"�܂��͎�����"CubeTag"�̏ꍇ�̈Ӗ��ɂȂ�ithis.CompareTag("CubeTag"))�̈�
        if (collision.gameObject.CompareTag("CubeTag") || collision.gameObject.CompareTag("GroundTag"))
        {
            audioSource.Play();
            
        }
    }
}
