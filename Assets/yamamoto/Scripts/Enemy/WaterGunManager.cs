using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    //水鉄砲を入れる　　0:左　1:右
    public GameObject[] WaterGun;

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

        if(w_time>10.0f)
        {
            Debug.Log("動き");
            shotBullets[0].g_stop = false;
        }
    }
}
