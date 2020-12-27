using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDebug : MonoBehaviour
{
    public void OnButtonClick(string message)
    {
        Debug.Log(message + ". Button clicked");
    }
}
