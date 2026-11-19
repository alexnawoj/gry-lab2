using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class ThrowTrigger : MonoBehaviour
{
    [SerializeField] private TextHints textHints;
    [SerializeField, TextArea] private string matHint = "Left click - throw coconut";

    // hint is visible only once
    private bool isVisible = true;

    void OnTriggerEnter(Collider other) => SetCanThrow(other, true);

    void OnTriggerExit(Collider other) => SetCanThrow(other, false);

    private void SetCanThrow(Collider other, bool canThrow) {
        var thrower = other.GetComponentInChildren<CoconutThrower>();
        if(thrower != null && isVisible) {
            textHints.ShowHint(matHint);
            thrower.CanThrow = canThrow;
            isVisible = false;
        }
              
    }
}
