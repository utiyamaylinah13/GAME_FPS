using UnityEngine;

public class FPSCameraTouch : MonoBehaviour
{
    [Header("Pengaturan Sensitivitas")]
    public float lookSpeed = 0.2f; // Sensitivitas geser (bisa dinaik/turunkan)

    [Header("Referensi Objek")]
    public Transform playerBody; // Masukkan objek "player"
    public Touchpad touchpad; // Masukkan UI "TouchpadArea" ke sini

    private float xRotation = 0f;

    void Update()
    {
        // Hanya berputar jika layar kanan sedang disentuh/digeser
        if (touchpad.isPressed)
        {
            // Ambil jarak geser jari dari script Touchpad
            float lookX = touchpad.touchDelta.x * lookSpeed;
            float lookY = touchpad.touchDelta.y * lookSpeed;

            // 1. Kamera melihat ke atas dan ke bawah
            xRotation -= lookY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // 2. Badan Player berputar ke kiri dan ke kanan
            playerBody.Rotate(Vector3.up * lookX);
        }
    }
}