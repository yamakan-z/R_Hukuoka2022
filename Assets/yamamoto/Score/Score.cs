using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�uSCORE�v�Ƃ����L�[�ŕۑ�����Ă���Int�l��ǂݍ���
        float resultScore = PlayerPrefs.GetFloat("TEST");
        Debug.Log("�ۑ�����Ă���_���F" + resultScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
