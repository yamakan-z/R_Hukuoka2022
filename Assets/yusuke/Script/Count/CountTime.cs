using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    //�J�E���g�A�b�v
    private float countup = 0.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    private void Update()
    {
        //���Ԃ��J�E���g����
        countup += Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countup.ToString("00:00");
    }
}
