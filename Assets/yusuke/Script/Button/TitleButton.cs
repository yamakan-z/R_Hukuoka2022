using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
    }
}
