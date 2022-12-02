using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunMove : MonoBehaviour
{
    [SerializeField, Header("移動幅")]
    private float move;

    private Vector2 pos;

    private bool movelock;//上下移動させない

    [Header("水鉄砲の位置")]
    public bool left;

    public bool right;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        movelock = true;
    }


    // Update is called once per frame
    void Update()
    {
        //マップの中心Y：2
        if(!movelock)
        {
            transform.position = new Vector2(pos.x, Mathf.Sin(Time.time) * move + pos.y);
        }
        else
        {
            //水鉄砲が左の時
            if( left && transform.localPosition.y < 2.0f)
            {
               // Debug.Log("とまり");
                transform.Translate(Vector2.up * 0.05f);
            }
            //右の時
            else if (right && transform.localPosition.y > 2.0f)
            {
                Debug.Log("とまり");
                transform.Translate(Vector2.up * -0.05f);
            }


        }

      
    }
}
