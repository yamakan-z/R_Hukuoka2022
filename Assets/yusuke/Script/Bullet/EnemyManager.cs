using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public GameObject Wood;

    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    //�o�ߎ���
    private float time;

    private void Update()
    {
        //Instantiate(Wood);

        //�O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;

        //��3�b�����Ƀ����_���ɐ��������悤�ɂ���
        if(time>2.0f)
        {
            for (int i = 0; i < 4; i++)
            {
                //rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                //rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                //GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(createPrefab, new Vector2(x, y), createPrefab.transform.rotation);

            }

            //�o�ߎ��ԃ��Z�b�g
            time = 0f;
        }
    }
}
