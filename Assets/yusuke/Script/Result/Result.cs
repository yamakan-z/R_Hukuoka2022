using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    private float step_time; //�o�ߎ��ԃJ�E���g�p

    private void Start()
    {
        step_time = 0.0f; //�o�ߎ��ԏ�����
    }

    private void Update()
    {
        //�o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;

        //3�b��ɉ�ʑJ��
        if(step_time>=3.0f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
