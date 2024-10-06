using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket hýzý
    [SerializeField] private Joystick joystick;   // Unity'deki Joystick bileþeni referansý
    [SerializeField] private TMP_Text timerText;  // Zamanlayýcý UI bileþeni

    private Rigidbody2D rb;
    private Vector2 movement;
    private float timer = 60f;  // Baþlangýç zamaný (örnek olarak 60 saniye)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Timer sýfýrlanana kadar çalýþtýr
        if (timer > 0)
        {
            // Zamanlayýcýyý güncelle
            timer -= Time.deltaTime;
            timerText.text = "Time: " + FormatTime(timer); // Formatlanmýþ zamaný güncelle

            // Joystick giriþini al
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        }
    }

    private void FixedUpdate()
    {
        // Karakterin hareketi fizik tabanlý olarak uygulandý
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Zamaný dakika:saniye olarak formatlamak için yardýmcý fonksiyon
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
