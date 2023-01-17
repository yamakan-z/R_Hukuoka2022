using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountTime : MonoBehaviour
{
    //�J�E���g�A�b�v
    [Header("�������Ԃ�����")]
    public float countup = 0.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    private void Update()
    {
        //���Ԃ��J�E���g����
        countup += Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countup.ToString("00:00");

        if(countup==0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
