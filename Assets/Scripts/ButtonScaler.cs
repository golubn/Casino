
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float exitScale = 1.0f;
    [SerializeField] private float enterScale = 1.1f;

    public void OnDisable()
    {
        gameObject.transform.localScale = new Vector3(exitScale, exitScale, exitScale);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(enterScale, enterScale, enterScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(exitScale, exitScale, exitScale);

    }
}
