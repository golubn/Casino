using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBack : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject activate;
    [SerializeField] private GameObject disactivate;
    public void OnPointerClick(PointerEventData eventData)
    {
        activate.SetActive(true);
        disactivate.SetActive(false);
    }
}
