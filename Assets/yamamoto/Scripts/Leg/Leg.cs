using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbodyを取得
        var rb = GetComponent<Rigidbody2D>();

        //FreezePositionYをオンにする
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
