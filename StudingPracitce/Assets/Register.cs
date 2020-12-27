using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Register : BaseRequest
{
    public TMP_InputField IFLogin;
    public TMP_InputField IFPass;

    public TextMeshProUGUI outputText;

    protected void Start()
    {
        onLoginValueChange = new TMP_InputField.OnChangeEvent();
        onLoginValueChange.AddListener(OnLoginFieldEnd);
        IFLogin.onValueChanged = onLoginValueChange;

        onPassValueChange = new TMP_InputField.OnChangeEvent();
        onPassValueChange.AddListener(OnPasswordFieldEnd);
        IFPass.onValueChanged = onPassValueChange;

        request = "http://localhost/grade_zero_ws/register.php?";
    }

    public void OnSubmitClick()
    {
        if (passwordText == "" || loginText == "" || passwordText == null || loginText == null)
        {
            outputText.text = "Uncorrect login or password";
            return;
        }
        else
        {
            outputText.text = "";
        }

        StartCoroutine(Select());
    }

    public IEnumerator Select()
    {

        webRequest = new UnityWebRequest(request + "login=" + loginText + "&pass=" + passwordText);
        webRequest.SendWebRequest();

        outputText.text = "You are registered! Your login - " + loginText;

        yield return new WaitForSeconds(2f);

        Exit();
    }


}
