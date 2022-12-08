using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    [SerializeField, Header("�x���}�[�N")]
    private Renderer warning;

    [SerializeField, Header("�_�ł̑���")]
    private float level;

    private float w_time;//�_�ŗp�̃^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        w_time += Time.deltaTime;

        // ����level�ŌJ��Ԃ��l�̎擾
        // 0�`level�͈̔͂̒l��������
        var repeatValue = Mathf.Repeat(w_time, level);

        // ��������w_time�ɂ����閾�ŏ�Ԃ𔽉f
        warning.enabled = repeatValue >= level * 0.5f;
    }
}
