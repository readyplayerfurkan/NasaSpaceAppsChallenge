using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket h�z�
    [SerializeField] private Joystick joystick;   // Unity'deki Joystick bile�eni referans�
    [SerializeField] private TMP_Text timerText;  // Zamanlay�c� UI bile�eni

    private Rigidbody2D rb;
    private Vector2 movement;
    private float timer = 60f;  // Ba�lang�� zaman� (�rnek olarak 60 saniye)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Timer s�f�rlanana kadar �al��t�r
        if (timer > 0)
        {
            // Zamanlay�c�y� g�ncelle
            timer -= Time.deltaTime;
            timerText.text = "Time: " + FormatTime(timer); // Formatlanm�� zaman� g�ncelle

            // Joystick giri�ini al
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        }
    }

    private void FixedUpdate()
    {
        // Karakterin hareketi fizik tabanl� olarak uyguland�
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Zaman� dakika:saniye olarak formatlamak i�in yard�mc� fonksiyon
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
