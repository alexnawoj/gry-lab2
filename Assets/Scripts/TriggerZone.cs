using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private int cellsRequired = 4;
    [SerializeField] private AudioClip lockedSound;
    [SerializeField] private Light doorLight;
    [SerializeField] private TextHints textHints;
    [SerializeField, TextArea] private string noCellsHint = "The door is locked and the generator is
dead. Maybe there are power cells somewhere on the island?";
    [SerializeField, TextArea] private string moreCellsHint = "The generator needs more power cells
to open the door."; 

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
