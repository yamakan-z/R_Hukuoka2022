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

    [SerializeField]private int tentime = 10;//10�b���Ƃɕb���o�߂̃e�L�X�g���o������悤

    [SerializeField]
    private float extime;//30�b���̃{�C�X���o���p

   [SerializeField] private AudioSource audio;

    [SerializeField] private AudioClip[] se;

    private void Start()
    {
        timeText.text = "";//�e�L�X�g������
    }

    private void Update()
    {
        //���Ԃ��J�E���g����
        countup += Time.deltaTime;

        extime += Time.deltaTime;

        if (countup >= tentime)
        {
            if(extime >= 30.0f)
            {
                audio.PlayOneShot(se[1]);
                extime = 0;
            }
            else
            {
                audio.PlayOneShot(se[0]);
            }

            Debug.Log("����");
           
            timeText.text = tentime.ToString()+"�b�o�߁I�I";
            tentime += 10;
            Invoke("TimeText_Write", 2.0f);//��b��Ƀe�L�X�g��\��
        }

        
    }

    void TimeText_Write()
    {
        timeText.text = "";//�e�L�X�g������
    }

}
