using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�̏o���ʒu�̎��
public enum RESPAWN_TYPE
{
    DOWN, //��
    SIZEOF, //�G�̏o���ʒu�̐�
}

public class AttackBelow : MonoBehaviour
{
    public Vector2 m_respawnPosInside; //�G�̏o���ʒu(����)
    public Vector2 m_respawnPosOutside; //�G�̏o���ʒu(�O��)

    private Vector3 m_direction; //�i�s����

    private float Speed; //���x

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    private void Update()
    {
        Vector2 force = new Vector2(0.0f, 8.5f);
        rb.AddForce(force, ForceMode2D.Force);

        //�^�������ړ�����
        transform.localPosition += m_direction * Speed;
    }

    //�G���o������Ƃ��ɏ���������֐�
    public void Init(RESPAWN_TYPE respawnType)
    {
        var pos = Vector3.zero;

        //�w�肳�ꂽ�o���ʒu�̎�ނɉ�����
        //�o���ʒu�Ɛi�s���������肷��
        switch(respawnType)
        {
            //�o���ʒu�����̏ꍇ
            case RESPAWN_TYPE.DOWN:
                pos.x = Random.Range(
                    -m_respawnPosInside.x, m_respawnPosInside.x);
                pos.y = m_respawnPosOutside.y;
                m_direction = Vector2.up;
                break;
        }

        //�ʒu�𔽉f����
        transform.localPosition = pos;
    }
}
