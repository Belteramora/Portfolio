using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class Authorize : BaseRequest
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

        request = "http://localhost/grade_zero_ws/authorize.php?";
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


        StartCoroutine(GetText());
    }

    private IEnumerator GetText()
    {
        webRequest = UnityWebRequest.Get(request + "lcheck=" + loginText + "&pcheck=" + passwordText);
        yield return webRequest.SendWebRequest();

        string res = DownloadHandlerBuffer.GetContent(webRequest);

        if (res.Equals("0"))
        {
            outputText.text = "Login or password are wrong. Check it, and try again";
        }
        else
        {
            outputText.text = "Authorize success!";
            yield return new WaitForSeconds(100f);
            Exit();
        }
    }
}
