using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne
    public float smoothSpeed = 0.125f; // Kameranın ne kadar hızlı hareket edeceği
    public Vector3 offset; // Kamera ile nesne arasındaki ofset

    private void Start()
    {
        // Başlangıçta kamerayı nesnenin arkasına yerleştirir
        transform.position = target.position + offset;
    }

    private void Update()
    {
        // Kamerayı nesnenin arkasına yumuşak bir şekilde hareket ettirir
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
