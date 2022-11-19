using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignIn : MonoBehaviour
{
    [SerializeField] Text errorText;
    [SerializeField] Canvas canvas;


    string username, password;

    void OnEnable()
    {
        UserAccountManager.OnSignInFailed.AddListener(OnSignInFailed);
        UserAccountManager.OnSignInSucess.AddListener(OnSignInSuccess);
    }
    void OnDisable()
    {
        UserAccountManager.OnSignInFailed.RemoveListener(OnSignInFailed);
        UserAccountManager.OnSignInSucess.RemoveListener(OnSignInSuccess);
    }
    void OnSignInFailed()
    {
        errorText.text="Error to SignIn";
    }

    void OnSignInSuccess()
    {
        errorText.gameObject.SetActive(true);
        canvas.enabled = false;
    }

    public void UpdateUsername(string _username)
    {
        username = _username;
    }
    public void UpdatePassword(string _password)
    {
        password = _password;
    }

    public void SignIn()
    {
        UserAccountManager.Instance.SignIn(username, password);
    }


}
