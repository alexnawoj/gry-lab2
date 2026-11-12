using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PowerCellCounter : MonoBehaviour
{
    private TextMeshProUGUI counter;
    private Inventory inventory;

    void Awake() {
        counter = GetComponent<TextMeshProUGUI>();
        counter.enabled = false;
        inventory = FindFirstObjectByType<Inventory>();
    }
    

    // Update is called once per frame
    void Update()
    {
         counter.text = "charge: " + inventory.Charge;
     
    }

     public void counterOn() => counter.enabled = true;
     public void counterOff() => counter.enabled = false;
}
