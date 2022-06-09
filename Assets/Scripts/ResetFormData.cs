using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetFormData : MonoBehaviour
{
    [SerializeField] private  InputField[] inputFields;
    [SerializeField] private  Text[] texts;
    private void OnDisable()
    {
        for(int i = 0; i < inputFields.Length; i++)
        {
            inputFields[i].text = null;
        }
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = null;
        }
    }
}
