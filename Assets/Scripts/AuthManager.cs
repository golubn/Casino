using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;

public class AuthManager : MonoBehaviour
{
    public GameObject menuForm;
    public GameObject loginForm;

    [Header("Login / Sign In")]
    public InputField signInLogin;
    public InputField signInPassword;
    public Button startButton;



    [Header("Register / Sign Up")]
    public InputField signUpLogin;
    public InputField signUpPassword;
    public InputField signUpConfirmPassword;

    [Space(10)]
    public Text signUpMassageText;
    public Text signInMassageText;
   


    public static Action OnPlayerSignIn; //Login
    public static Action OnPlayerSignUp; //Register
   

    private void Start()
    {
        startButton.gameObject.SetActive(false);
        OnPlayerSignUp += SignUp;
        OnPlayerSignIn += SignIn;
       
    }
    private void OnEnable()
    {
        OnPlayerSignIn += SignIn;
        OnPlayerSignUp += SignUp;
        
    }
    private void OnDisable()
    {
        OnPlayerSignIn -= SignIn;
        OnPlayerSignUp -= SignUp;
        
    }
    private void OnDestroy()
    {
        OnPlayerSignUp -= SignUp;
        OnPlayerSignIn -= SignIn;
        
    }
    public void GetUserByLogin(string login)
    {
        Connection.GetUserByLogin(login);
    }

    public void SignIn()
    {
        
        string login = signInLogin.text;
        string password = signInPassword.text;
        if(login == "" || password == "")
        {
            signInMassageText.text = "Empty";
            signInMassageText.color = Color.red;
        }
        else
        {
            SignIn(login, password);            
        }
       

    }
    public void SignIn(string login, string password)
    {
        signInMassageText.text = "Search Account...";
        signInMassageText.color = Color.white;
        string t = Connection.GetPassword(login);
        Debug.Log("пароль для сравнения:  " + t);
        Debug.Log("пароль введенный    :  " + password);
        if (t != null)
        {
            if (t == password)
            {
                signInMassageText.text = "Go next";
                signInMassageText.color = Color.green;
                startButton.gameObject.SetActive(true);
                Connection.CloseBd();
            }
            else
            {
                signInMassageText.text = "Wrong password";
                signInMassageText.color = Color.red;
                Connection.CloseBd();
            }
        }
        else
        {
            signInMassageText.text = "No account with this login";
            signInMassageText.color = Color.red;
            Connection.CloseBd();
        }


    }

    public void SignUp()
    {
        string login = signUpLogin.text;
        string password = signUpPassword.text;
        if(login == "" || password == "")
        {
            signUpMassageText.text = "Empty";
            signUpMassageText.color = Color.red;
        }
        else
        {
            GetUserByLoginCallBack(login);
            Connection.CloseBd();
        }
       
    }
   
    public void GetUserByLoginCallBack(string login)
    {
        if (login != null && login != Connection.GetLogin(login))
        {

            if (signUpPassword.text.Length >= 6 && signUpConfirmPassword.text.Length >= 6)
            {
                if (signUpConfirmPassword.text == signUpPassword.text)
                {
                    signUpMassageText.text = "Account creating.Go back and sign in";
                    signUpMassageText.color = Color.green;

                    Connection.AddPlayer(login, signUpPassword.text);
                    Connection.CloseBd();
                }
                if (signUpConfirmPassword.text != signUpPassword.text)
                {
                    signUpMassageText.text = "Password Not equals !";
                    signUpMassageText.color = Color.red;
                    Connection.CloseBd();
                }
            }
            else if (signInPassword.text.Length < 6 && signUpConfirmPassword.text.Length < 6)
            {
                signUpMassageText.text = "Password so short!";
                signUpMassageText.color = Color.red;
                Connection.CloseBd();
            }
        }
        else
        {
            signUpMassageText.text = "Account with this login also created";
            signUpMassageText.color = Color.red;
            Connection.CloseBd();
        }
    }
}
