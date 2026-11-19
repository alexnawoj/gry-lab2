using UnityEngine;

public class ThrowTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) => SetCanThrow(other, true);

    void OnTriggerExit(Collider other) => SetCanThrow(other, false);

    private void SetCanThrow(Collider other, bool canThrow) {
        var thrower = other.GetComponentInChildren<CoconutThrower>();
        if(thrower != null)
            thrower.CanThrow = canThrow;    
    }
}
