using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = -12;//キューブの移動速度
    private float deadLine = -10;//キューブの消滅位置
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Time.deltaTimeは前回フレームからの経過時間(前回のフレームが完了してから現在のフレームが開始されるまでの経過時間)
        //Time.deltaTime を使用することで、フレームレートが高いときは移動量が小さくなり、フレームレートが低いときは移動量が大きくなるように調整されru

        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }
}
