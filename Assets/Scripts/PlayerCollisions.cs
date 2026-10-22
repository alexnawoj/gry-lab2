using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float reach = 3f;

    void Update() {
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, reach) && hit.collider.TryGetComponent(out DoorManager door))
            door.DoorCheck();    
    }
}
