using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class BaseRequest : MonoBehaviour
{
    protected string loginText;
    protected string passwordText;

    protected TMP_InputField.OnChangeEvent onLoginValueChange;
    protected TMP_InputField.OnChangeEvent onPassValueChange;

    protected UnityWebRequest webRequest;

    public GameObject menuPage;

    protected string request;

    public virtual void OnLoginFieldEnd(string text)
    {
        loginText = text;
    }

    public virtual void OnPasswordFieldEnd(string text)
    {
        passwordText = text;
    }

    public virtual void Exit()
    {
        menuPage.SetActive(true);
        gameObject.SetActive(false);
    }

}
