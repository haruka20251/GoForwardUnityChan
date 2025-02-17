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
        //collision.gameObject.CompareTag("GroundTag") || CompareTag("CubeTag") だとぶつかった相手が"GroundTag"または自分が"CubeTag"の場合の意味になる（this.CompareTag("CubeTag"))の意
        if (collision.gameObject.CompareTag("CubeTag") || collision.gameObject.CompareTag("GroundTag"))
        {
            audioSource.Play();
            
        }
    }
}
