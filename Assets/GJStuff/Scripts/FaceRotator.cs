using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FaceRotator : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public float RotationSpeed;
    public GameObject info;
    public Sprite input;
    public Color trans = new Color(0, 0, 0, 0);
    public Color full = new Color(255,255,255,255);
    
    private void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime*RotationSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        info.GetComponent<Image>().sprite = input;
        info.GetComponent<Image>().color = full;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info.GetComponent<Image>().sprite = null;
        info.GetComponent<Image>().color = trans;
    }
}
