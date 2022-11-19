using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;

public class UserAccountManager : MonoBehaviour
{

    public static UserAccountManager Instance;
    public static UnityEvent OnSignInSucess = new UnityEvent();

    public static UnityEvent OnSignInFailed = new UnityEvent();

    public static UnityEvent OnCreateAccountFailed = new UnityEvent();

    private void Awake()
    {
        Instance = this;
    }

    public void CreatAccount(string username,string emailAddress,string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(
                new RegisterPlayFabUserRequest()
                {
                    Email = emailAddress,
                    Password =password,
                    Username =username,
                    RequireBothUsernameAndEmail=true
                },
                response =>
                {
                    Debug.Log($"Successful Account Creation: {username},{emailAddress}");
                    SignIn(username, password);
                },
                error =>
                {
                    Debug.Log($"Unsuccessful Account Creation: {username},{emailAddress} \n {error.ErrorMessage}");
                    OnCreateAccountFailed.Invoke();
                }
            );
    }

    

    public void SignIn(string username,string password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() { 
            Username =username,
            Password = password
        },
        response =>
        {
            Debug.Log($"Successful Account Login: {username}");
            OnSignInSucess.Invoke();
            SceneManager.LoadScene(sceneName: "Level1");

        },
        error =>
        {
            Debug.Log($"Unsuccessful Account Login: {username} \n {error.ErrorMessage}");
            OnSignInFailed.Invoke();
        }
        );
    }
    
}
