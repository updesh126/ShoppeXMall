using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class UserAccountManager : MonoBehaviour
{
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
                    Debug.Log($"Successful Account Creation:{username},{emailAddress}");
                },
                error =>
                {
                    Debug.Log($"Unsuccessful Account Creation:{username},{emailAddress} \n {error.ErrorMessage}");
                }
            );
    }
    
}
