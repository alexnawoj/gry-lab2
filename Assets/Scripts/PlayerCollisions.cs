using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] private AudioClip doorOpenSound;

    private bool doorIsOpen;

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.CompareTag("playerDoor") && !doorIsOpen)
            OpenDoor(hit.gameObject);
    }

    private void OpenDoor(GameObject door) {
        doorIsOpen = true;
        door.GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
        door.GetComponentInParent<Animator>().SetBool("DoorOpen", true);    
    }
}
