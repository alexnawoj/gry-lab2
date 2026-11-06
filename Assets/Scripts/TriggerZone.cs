using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private int cellsRequired = 4;
    [SerializeField] private AudioClip lockedSound;
    [SerializeField] private Light doorLight;
    [SerializeField] private TextHints textHints;
    [SerializeField, TextArea] private string noCellsHint = "The door is locked and will not open. The star is the key.";
    [SerializeField, TextArea] private string moreCellsHint = "Welcome Nerevar"; 

    void OnTriggerEnter(Collider other) {
        
        if(!other.CompareTag("Player") 
            || !other.TryGetComponent(out Inventory inventory))
            return;

        Transform door = transform.Find("door");

        if(inventory.Charge >= cellsRequired) {
            door.GetComponent<DoorManager>().DoorCheck();
            inventory.HudOff();
            doorLight.color = Color.green;        
        } else {
            door.GetComponent<AudioSource>().PlayOneShot(lockedSound);
            inventory.HudOn();
            textHints.ShowHint(inventory.Charge == 0 ? noCellsHint : moreCellsHint);            

        } 
    }
}
