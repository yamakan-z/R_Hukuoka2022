using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    //水鉄砲を入れる　　0:左　1:右
    public WaterGunMove[] watergunmove;

    public ShotBullet[] shotBullets;

    [Header("水鉄砲出現時間")]
    public float w_time;

    // Start is called before the first frame update
    void Start()
    {
        
        w_time = 0.0f;//初期の発生時間
    }

    // Update is called once per frame
    void Update()
    {
        w_time = w_time + Time.deltaTime;

        //指定した時間に水鉄砲出現
        if(w_time > 40.0f)
        {
            Debug.Log("動き");
            watergunmove[0].left = true;
            shotBullets[0].g_stop = false;
        }

        if (w_time > 90.0f)
        {
            Debug.Log("動き2");
            watergunmove[1].right = true;
            shotBullets[1].g_stop = false;
        }
    }
}
