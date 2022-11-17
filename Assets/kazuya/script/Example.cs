using Coffee.UIExtensions;
using UnityEngine;

public class Example : MonoBehaviour
{
    public ShinyEffectForUGUI m_shiny;

    private void Start()
    {
        // 1秒かけて再生
        m_shiny.Play();

        // 指定した秒数かけて再生
        m_shiny.Play(1.5f);

        // 指定した秒数かけて再生（タイムスケールを無視）
        m_shiny.Play(1.5f, AnimatorUpdateMode.UnscaledTime);
    }
}
