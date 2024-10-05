using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneHareketi : MonoBehaviour
{
    private bool suruklemeBasladi = false; // Sürükleme durumu
    private Vector3 suruklemeOffset; // Sürükleme ofseti
    private Camera anaKamera; // Ana kamera referansı

    void Start()
    {
        // Ana kamerayı al
        anaKamera = Camera.main;
    }

    void Update()
    {
        // Fareyle tıklama
        if (Input.GetMouseButtonDown(0))
        {
            // Tıklanan noktanın dünya koordinatlarını al
            Vector3 tıklananNokta = anaKamera.ScreenToWorldPoint(Input.mousePosition);
            tıklananNokta.z = 0; // 2D düzlemde kalması için Z değerini sıfırla

            // Tıklanan noktada bir collider var mı kontrol et
            Collider2D collider = Physics2D.OverlapPoint(tıklananNokta);
            if (collider != null && collider.gameObject == gameObject) // Bu nesneye tıkladıysak
            {
                suruklemeBasladi = true;
                suruklemeOffset = transform.position - tıklananNokta; // Ofseti hesapla
            }
        }

        // Sürükleme devam ediyorsa
        if (suruklemeBasladi && Input.GetMouseButton(0))
        {
            // Tıklanan noktanın dünya koordinatlarını al
            Vector3 tıklananNokta = anaKamera.ScreenToWorldPoint(Input.mousePosition);
            tıklananNokta.z = transform.position.z; // Nesnenin Z eksenini koru

            // Nesnenin pozisyonunu güncelle
            transform.position = tıklananNokta + suruklemeOffset;
        }

        // Fare butonu bırakıldığında sürüklemeyi durdur
        if (Input.GetMouseButtonUp(0))
        {
            suruklemeBasladi = false;
        }
    }
}
