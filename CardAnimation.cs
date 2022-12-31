using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    bool mouseOver;
    Vector3 originalPos;
    private void Start() {
        originalPos = transform.position;
    }
    void OnMouseOver()
    {
        mouseOver = true;
    }
    private void OnMouseExit() {
        mouseOver = false;
    }
    private void FixedUpdate() {
        HandleMouseOver();
    }
    void HandleMouseOver()
    {
        if(mouseOver)
            transform.position = Vector3.Slerp(transform.position, new Vector3(originalPos.x, originalPos.y + 0.3f, originalPos.z), 0.5f);
        else
            transform.position = Vector3.Slerp(transform.position, originalPos, 0.5f);
    }
}
