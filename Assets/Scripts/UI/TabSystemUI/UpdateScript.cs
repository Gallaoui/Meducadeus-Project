using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase.Extensions;

using UnityEngine.UIElements;

public class UpdateScript : MonoBehaviour
{
    private UIDocument _document;
    private VisualElement _element;
    FirebaseAuth auth;

    private Button updateButton;
    private TextField nameField;
    private TextField emailField;
    private TextField passwordField;

    private void Start()
    {
        _document = GetComponent<UIDocument>();
        _element = _document.rootVisualElement;

        updateButton = _element.Q<Button>("ModButton");
        nameField = _element.Q<TextField>("Nom");
        emailField = _element.Q<TextField>("Email");
        passwordField = _element.Q<TextField>("Pass");

        if (FirebaseConnection.user != null)
        {
            nameField.value = FirebaseConnection.instance.getUsername();
            emailField.value = FirebaseConnection.instance.getUseremail();

            updateButton.clicked += () => { UpdateUserInformations(nameField.value, emailField.value, passwordField.value); };
        }
    }

    private void UpdateUserInformations(string Username, string Useremail, string Userpass)
    {
        Firebase.Auth.FirebaseUser user = FirebaseConnection.auth.CurrentUser;

        if (user != null)
        {
            if(Username != null && Username != user.DisplayName) 
            {
                Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
                {
                    DisplayName = Username,
                };
                user.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task => {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("UpdateUserProfileAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Debug.Log("User profile updated successfully.");
                });
            }
            if (Useremail != null && Useremail != user.Email)
            {

                user.UpdateEmailAsync(Useremail).ContinueWithOnMainThread(task =>
                {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateEmailAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateEmailAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User email updated successfully.");
                });
            }

            if (Userpass != null)
            {
                user.UpdatePasswordAsync(Userpass).ContinueWithOnMainThread(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("UpdatePasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("UpdatePasswordAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Debug.Log("Password updated successfully.");
                });
            }
        }
    }
}
