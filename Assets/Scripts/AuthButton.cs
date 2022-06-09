using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AuthButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private ButtonType buttonType = ButtonType.None;
    private enum ButtonType
    {
        None = 0,
        SignIn = 1,
        SignUp = 2
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonType == ButtonType.SignIn)
        {
            AuthManager.OnPlayerSignIn?.Invoke();
        }
        else if (buttonType == ButtonType.SignUp)
        {
            AuthManager.OnPlayerSignUp?.Invoke();
        }
    }

}
