using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirebaseController : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField LoginEmail, LoginPassword, RegisterName, RegisterEmail, RegisterPassword, RegisterConfirmPassword;
    [SerializeField] private TMPro.TMP_InputField RecoverEmail;

    [SerializeField] private GameObject NotificationPanel;
    [SerializeField] private TMPro.TMP_Text NotificationTitle, NotificationContent;

    public FirebaseConnection firebaseConnection;


    public void LoginUser()
    {
        if(string.IsNullOrEmpty(LoginEmail.text) && string.IsNullOrEmpty(LoginPassword.text))
        {
            NotificationMessage("Données invalid", "Merci de remplir les champs");
            return;
        }

        firebaseConnection.ConnectUser(LoginEmail.text, LoginPassword.text);
    }

    public void RegisterUser()
    {
        if(string.IsNullOrEmpty(RegisterName.text) && string.IsNullOrEmpty(RegisterEmail.text) && string.IsNullOrEmpty(RegisterPassword.text) && string.IsNullOrEmpty(RegisterConfirmPassword.text))
        {
            NotificationMessage("Données invalid", "Merci de remplir les champs");
            return;
        }

       firebaseConnection.CreateUser(RegisterEmail.text, RegisterPassword.text, RegisterName.text);
    }

    public void RecoverUser()
    {
        if (string.IsNullOrEmpty(RecoverEmail.text))
        {
            NotificationMessage("Email invalid", "Merci de remplir le champ Email");
            return;
        }
        firebaseConnection.ForgetPassword(RecoverEmail.text);
    }

    public void NotificationMessage(string title, string content)
    {
        NotificationTitle.text = "" + title;
        NotificationContent.text = "" + content;

        NotificationPanel.SetActive(true);
    }
}
