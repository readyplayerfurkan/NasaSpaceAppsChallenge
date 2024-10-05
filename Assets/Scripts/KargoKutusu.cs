using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KargoKutusu : MonoBehaviour
{
    public GameObject[] icerikler;
    public float cikmaMesafesi = 1.0f;

    void Start()
    {
        // Kargo kutusunun i�indeki nesneleri al
        icerikler = GameObject.FindGameObjectsWithTag("icerik");
    }

    void OnMouseDown()
    {
        // Kargo kutusunun i�indeki nesneleri d��ar� ��kar
        foreach (GameObject icerik in icerikler)
        {
            // ��erik nesnesinin pozisyonunu g�ncelle
            Vector3 cikmaPozisyonu = icerik.transform.position + new Vector3(0, cikmaMesafesi, 0); // Yukar� do�ru ��kar
            icerik.transform.position = cikmaPozisyonu;
        }

        // Sadece kargo kutusunu yok et
        Destroy(gameObject);
    }
}
