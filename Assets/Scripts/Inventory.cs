using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private int charge;
    public int Charge => charge;

    [Header("Charge indicators")]
    [SerializeField] private Texture2D[] hudCharge;
    [SerializeField] private RawImage chargeHud;
    [SerializeField] private PowerCellCounter counter;
    [SerializeField] private Texture2D[] meterCharge;
    [SerializeField] private Renderer meter;

    public void CellPickup() {
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        HudOn();
        counter.counterOn();
        int level = Mathf.Min(charge, hudCharge.Length - 1);
        chargeHud.texture = hudCharge[level];
        meter.material.mainTexture = meterCharge[level];
        print("Successfuly picked up a powercell");    
    }

    public void HudOn() => chargeHud.enabled = true;
    public void HudOff() => chargeHud.enabled = false;
}
