using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KargoKutusu : MonoBehaviour
{
    public GameObject[] icerikler;
    public float cikmaMesafesi = 1.0f;

    void Start()
    {
        // Kargo kutusunun içindeki nesneleri al
        icerikler = GameObject.FindGameObjectsWithTag("icerik");
    }

    void OnMouseDown()
    {
        // Kargo kutusunun içindeki nesneleri dýþarý çýkar
        foreach (GameObject icerik in icerikler)
        {
            // Ýçerik nesnesinin pozisyonunu güncelle
            Vector3 cikmaPozisyonu = icerik.transform.position + new Vector3(0, cikmaMesafesi, 0); // Yukarý doðru çýkar
            icerik.transform.position = cikmaPozisyonu;
        }

        // Sadece kargo kutusunu yok et
        Destroy(gameObject);
    }
}
