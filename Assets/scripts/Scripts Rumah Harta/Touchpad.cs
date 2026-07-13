using UnityEngine;
using UnityEngine.EventSystems; // Wajib untuk UI Event

public class Touchpad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [HideInInspector] public Vector2 touchDelta;
    [HideInInspector] public bool isPressed;
    
    private int pointerId;

    // Saat jari menyentuh layar
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pointerId = eventData.pointerId;
    }

    // Saat jari menggeser layar
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerId)
        {
            touchDelta = eventData.delta;
        }
    }

    // Saat jari dilepas dari layar
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerId)
        {
            isPressed = false;
            touchDelta = Vector2.zero;
        }
    }

    // Reset nilai geser di akhir frame agar kamera tidak terus muter saat jari berhenti
    private void LateUpdate()
    {
        touchDelta = Vector2.zero;
    }
}