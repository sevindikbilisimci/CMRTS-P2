using UnityEngine;

public class dusmealgilayici : MonoBehaviour
{
    public Transform baslangicNoktasi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            var controller = other.GetComponent<CharacterController>();
            controller.enabled = false;

            other.gameObject.transform.position = baslangicNoktasi.position;

            controller.enabled = true;
        }
    }

}
