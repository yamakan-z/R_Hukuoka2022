using Coffee.UIExtensions;
using UnityEngine;

public class Example : MonoBehaviour
{
    public ShinyEffectForUGUI m_shiny;

    private void Start()
    {
        // 1�b�����čĐ�
        m_shiny.Play();

        // �w�肵���b�������čĐ�
        m_shiny.Play(1.5f);

        // �w�肵���b�������čĐ��i�^�C���X�P�[���𖳎��j
        m_shiny.Play(1.5f, AnimatorUpdateMode.UnscaledTime);
    }
}
