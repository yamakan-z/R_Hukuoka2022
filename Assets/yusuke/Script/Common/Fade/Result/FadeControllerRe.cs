using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeControllerRe : MonoBehaviour
{
    float fadeSpeed = 0.02f; //�s�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa; //�p�l���̐F�A�s�����x���Ǘ�

    public bool isFadeOut = false; //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
    public bool isFadeIn = false; //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O
    public string changeSceneName; //�t�F�[�h�A�E�g������A�V�[���J�ڂ���ꍇ�̃V�[����

    Image fadeImage; //�s�����x��ύX����p�l���̃C���[�W

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn)
        {
            StartFadeIn();
        }

        if(isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed; //a)�s�����x�����X�ɉ�����
        SetAlpha(); //b)�ύX�����s�����x�p�l���ɔ��f����
        if(alfa<=0)
        {
            //c)���S�ɓ����ɂȂ����珈���𔲂���
            isFadeIn = false;
            fadeImage.enabled = false; //d)�p�l���̕\�����I�t�ɂ���
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true; //a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed; //b)�s�����x�����X�ɏグ��
        SetAlpha(); //c)�ύX���������x���p�l���ɔ��f
        if(alfa>=1)
        {
            //d)���S�ɕs�����ɂȂ����珈���𔲂���
            isFadeOut = false;

            if(changeSceneName!="")
            {
                Debug.Log(changeSceneName + "�ɑJ�ڂ��܂��B");
                SceneManager.LoadScene(changeSceneName);
            }
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    //�X�^�[�g�{�^��������������s����
    public void GameStart()
    {
        isFadeOut = true;
        changeSceneName = "Title";
    }
}
