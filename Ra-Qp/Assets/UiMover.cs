using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMover : MonoBehaviour
{
    public float speed;
    public RectTransform rectTransform; 

    void LateUpdate()
    {
        float v = Input.GetAxis("Vertical") * speed;
        float h = Input.GetAxis("Horizontal") * speed;

        rectTransform.anchoredPosition = rectTransform.anchoredPosition + new Vector2(-h, -v);
    }
}
