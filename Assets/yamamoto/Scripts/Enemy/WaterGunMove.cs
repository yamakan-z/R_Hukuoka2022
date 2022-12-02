using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunMove : MonoBehaviour
{
    [SerializeField, Header("�ړ���")]
    private float move;

    private Vector2 pos;

    private bool movelock;//�㉺�ړ������Ȃ�

    [Header("���S�C�̈ʒu")]
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
        //�}�b�v�̒��SY�F2
        if(!movelock)
        {
            transform.position = new Vector2(pos.x, Mathf.Sin(Time.time) * move + pos.y);
        }
        else
        {
            //���S�C�����̎�
            if( left && transform.localPosition.y < 2.0f)
            {
               // Debug.Log("�Ƃ܂�");
                transform.Translate(Vector2.up * 0.05f);
            }
            //�E�̎�
            else if (right && transform.localPosition.y > 2.0f)
            {
                Debug.Log("�Ƃ܂�");
                transform.Translate(Vector2.up * -0.05f);
            }


        }

      
    }
}
