using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunMove : MonoBehaviour
{
    [SerializeField, Header("à⁄ìÆïù")]
    private float move;

    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(pos.x, Mathf.Sin(Time.time) * move + pos.y);
    }
}
