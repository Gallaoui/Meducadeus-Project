using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Login_Register_Home : MonoBehaviour
{
    [SerializeField] private GameObject LoginPanel, RegisterPanel, HomePanel, RecoverPanel, NotificationPanel, ScenePanel;
    
    [SerializeField] private TMPro.TMP_Text NotificationTitle, NotificationContent;

    public FirebaseController firebaseController;

    public void LoginPage()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        RecoverPanel.SetActive(false);
    }

    public void RegiserPage()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
        RecoverPanel.SetActive(false);
    }

    public void RecoverPage()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        RecoverPanel.SetActive(true);
    }

    public void NotificationClose()
    {
        NotificationTitle.text = "";
        NotificationContent.text = "";

        NotificationPanel.SetActive(false);
    }

    public void AuthenticationMenu()
    {
        HomePanel.SetActive(true);
       // LoginPage();
        ScenePanel.SetActive(false);
    }

    public void AuthenticationScene()
    {
        HomePanel.SetActive(false);
        ScenePanel.SetActive(true);
    }

    public void LogoutRedirection()
    {
        FirebaseConnection.auth.SignOut();
        AuthenticationMenu();
    }
}
