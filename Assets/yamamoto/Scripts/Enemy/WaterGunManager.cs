using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    //…“S–C‚ð“ü‚ê‚é@@0:¶@1:‰E
    public WaterGunMove[] watergunmove;

    public ShotBullet[] shotBullets;

    [Header("…“S–CoŒ»ŽžŠÔ")]
    public float w_time;

    // Start is called before the first frame update
    void Start()
    {
        
        w_time = 0.0f;//‰Šú‚Ì”­¶ŽžŠÔ
    }

    // Update is called once per frame
    void Update()
    {
        w_time = w_time + Time.deltaTime;

        //Žw’è‚µ‚½ŽžŠÔ‚É…“S–CoŒ»
        if(w_time > 40.0f)
        {
            Debug.Log("“®‚«");
            watergunmove[0].left = true;
            shotBullets[0].g_stop = false;
        }

        if (w_time > 70.0f)
        {
            Debug.Log("“®‚«2");
            watergunmove[1].right = true;
            shotBullets[1].g_stop = false;
        }
    }
}
