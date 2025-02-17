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
        //collision.gameObject.CompareTag("GroundTag") || CompareTag("CubeTag") ‚¾‚Æ‚Ô‚Â‚©‚Á‚½‘Šè‚ª"GroundTag"‚Ü‚½‚Í©•ª‚ª"CubeTag"‚Ìê‡‚ÌˆÓ–¡‚É‚È‚éithis.CompareTag("CubeTag"))‚ÌˆÓ
        if (collision.gameObject.CompareTag("CubeTag") || collision.gameObject.CompareTag("GroundTag"))
        {
            audioSource.Play();
            
        }
    }
}
