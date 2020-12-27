using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
#if UNITY_STANDALONE

        Application.Quit();

#endif
    }
}
