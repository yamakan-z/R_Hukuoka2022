using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    //���S�C������@�@0:���@1:�E
    public GameObject[] WaterGun;

    public ShotBullet[] shotBullets;

    [Header("���S�C�o������")]
    public float w_time;

    // Start is called before the first frame update
    void Start()
    {
        w_time = 0.0f;//�����̔�������
    }

    // Update is called once per frame
    void Update()
    {
        w_time = w_time + Time.deltaTime;

        if(w_time>10.0f)
        {
            Debug.Log("����");
            shotBullets[0].g_stop = false;
        }
    }
}
