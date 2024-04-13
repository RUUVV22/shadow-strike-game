using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
//using Newtonsoft.json;
public class PlayerFabManager : MonoBehaviour
{
    //[Header("UI")]
    //public Text meassgetext;
    private void Start()
    {
        Login();
    }
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, Onsuccess, OnError);
    }
    void Onsuccess(LoginResult result)
    {
        Debug.Log("success log in ");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account! ");
        Debug.Log(error.GenerateErrorReport());
    }
}
