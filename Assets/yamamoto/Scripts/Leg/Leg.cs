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
        //Rigidbody���擾
        var rb = GetComponent<Rigidbody2D>();

        //FreezePositionY���I���ɂ���
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
