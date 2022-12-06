using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGenerationlocation : MonoBehaviour
{

    [SerializeField, Header("���̐����ꏊ")]
    List<GameObject> Legs;

    [SerializeField, Header("�������鑫")]
    private GameObject CreateReg;

    [SerializeField, Header("�o�����������_���Ɍ��߂�ϐ�")]
    private int randnum;

    private bool g_flag;//�������m�F����

    enum LegAttckType//���̍U�����@
    {
        NONE = 0,
        RANDOM,
        CONTINUE,
    }

    [System.Serializable]
    struct LegData//���̃f�[�^
    {
        [Header("���̍U���^�C�v�I��")]
        public LegAttckType type;
    }

    [SerializeField]
    LegData legData = new LegData
    { type = LegAttckType.NONE };

    //�����_���ɐ�������
    public void RandNumCreate()
    {
        randnum = Random.Range(0, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        RandNumCreate();
    }

    // Update is called once per frame
    void Update()
    {
        //���̐�����������Ă���ΐ���
        if (!g_flag)
        LegCreate();
    }

    public void LegCreate()
    {
        Debug.Log("����");
        //���U���f�[�^���̏���
        switch (legData.type)
        {
            case LegAttckType.RANDOM:
                {
                    g_flag = true;//���̏o���𒆒f����
                    // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                    Instantiate(CreateReg, Legs[randnum].transform.position, Quaternion.identity);
                    RandNumCreate();//�o���ꏊ�̍Đݒ�
                }
                break;
        }
    }



}
