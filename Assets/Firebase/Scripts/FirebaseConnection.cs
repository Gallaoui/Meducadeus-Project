using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using Firebase.Extensions;

public class FirebaseConnection : MonoBehaviour
{
    public FirebaseController firebaseController;
    public Login_Register_Home UIPages;

    public static FirebaseConnection instance;
    bool isSigned = false;
    private bool isConnected = false;

    public static Firebase.Auth.FirebaseAuth auth;
   public static Firebase.Auth.FirebaseUser user;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }

    private void Update()
    {
        if (isSigned)
        {
            if (!isConnected)
            {
                UIPages.AuthenticationScene();
                isConnected = !isConnected;
            }
        }
        if (!isSigned)
            UIPages.AuthenticationMenu();
    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
                isSigned = false;
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.DisplayName);

                isSigned = true;
            }
        }
    }

    public void CreateUser(string email, string password, string name)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                if (task.Exception != null)
                {
                    FirebaseException firebaseException = (FirebaseException)task.Exception.GetBaseException();
                    AuthError error = (AuthError)firebaseException.ErrorCode;
                    string output = "Erreur Inconnue";

                    switch (error)
                    {
                        case AuthError.EmailAlreadyInUse:
                            output = "cette e-mail déja existe";
                            break;
                        case AuthError.InvalidEmail:
                            output = "E-mail invalid";
                            break;
                    }
                    firebaseController.NotificationMessage("Données invalid", output);

                    return;
                }
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            UpdateUserProfile(name);
            UIPages.LoginPage();
        });

    }

    public void ConnectUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                if (task.Exception != null)
                {
                    FirebaseException firebaseException = (FirebaseException)task.Exception.GetBaseException();
                    AuthError error = (AuthError)firebaseException.ErrorCode;
                    string output = "Erreur Inconnue !!";

                    switch (error)
                    {
                        case AuthError.InvalidEmail:
                            output = "Cette e-mail n'existe pas";
                            break;
                        case AuthError.WrongPassword:
                            output = "Mot de passe incorrecte";
                            break;
                        case AuthError.UserNotFound:
                            output = "Compte n'existe pas";
                            break;
                    }

                    firebaseController.NotificationMessage("Données invalid", output);
                }
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            UIPages.AuthenticationScene();
        });
    }

    private void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    public void UpdateUserProfile(string Username)
    {
        FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = Username,
                PhotoUrl = new System.Uri("https://upload.wikimedia.org/wikipedia/commons/f/f4/User_Avatar_2.png"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
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
                firebaseController.NotificationMessage("Message", "Votre Compte à été créer avec succés");
            });
        }
    }

    public void ForgetPassword(string email)
    {
        auth.SendPasswordResetEmailAsync(email).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                print("password reset request canceled");
            }
            if (task.IsFaulted)
            {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    FirebaseException firebaseException = exception as FirebaseException;

                    if (firebaseException != null)
                    {
                        var error = (AuthError)firebaseException.ErrorCode;
                        if (error == AuthError.InvalidEmail)
                        {
                            firebaseController.NotificationMessage("Données invalid", "Cette e-mail n'existe pas");
                        }
                    }
                }
            }
                firebaseController.NotificationMessage("Succés", "Message envoyé avec succés");
        });
    }

    public string getUsername()
    {
        if (isSigned)
            return user.DisplayName;
        else 
            return "";
    }

    public string getUseremail()
    {
        if (isSigned)
            return user.Email;
        else
            return "";
    }
}
