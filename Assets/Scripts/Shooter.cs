using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;          // Empty GameObject
    public float force = 500f;           // Fýrlatma gücü

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol týk
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Prefab'i firePoint konumunda ve yönünde oluþtur
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Rigidbody bileþenini al
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Rigidbody'e ileri doðru kuvvet uygula
        rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
    }
}
