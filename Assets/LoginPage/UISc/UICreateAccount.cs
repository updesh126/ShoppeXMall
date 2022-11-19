﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UICreateAccount : MonoBehaviour
{
    [SerializeField] Text errorText;
    [SerializeField] Canvas canvas;

    string username, password, emailAddress;

    void OnEnable()
    {
        UserAccountManager.OnCreateAccountFailed.AddListener(OnCreateAccountFailed);
        UserAccountManager.OnSignInSucess.AddListener(OnSignInSuccess);
    }
    void OnDisable()
    {
        UserAccountManager.OnCreateAccountFailed.RemoveListener(OnCreateAccountFailed);
        UserAccountManager.OnSignInSucess.RemoveListener(OnSignInSuccess);
    }

    
    void OnSignInFailed()
    {
        errorText.text = "Error to SignIn";
    }

    void OnSignInSuccess()
    {
        errorText.gameObject.SetActive(true);
        canvas.enabled = false;
    }
    void OnCreateAccountFailed()
    {
        errorText.text = "Error to Create";
    }

    public void UpdateUsername( string _username)
    {
        username = _username;
    }
    public void UpdatePassword( string _password)
    {
        password = _password;
    }
    public void UpdateEmailAddress( string _emailAddress)
    {
        emailAddress = _emailAddress;
    }

    public void CreatAccount()
    {
        UserAccountManager.Instance.CreatAccount(username, emailAddress, password);
    }

}
