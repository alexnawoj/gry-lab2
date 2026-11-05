using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private int cellsRequired = 4;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") 
            && other.TryGetComponent(out Inventory inventory)
            && inventory.Charge >= cellsRequired)

            transform.Find("door").GetComponent<DoorManager>().DoorCheck();    
    }
}
