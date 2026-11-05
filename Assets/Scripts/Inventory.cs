using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private int charge;
    public int Charge => charge;

    public void CellPickup() {
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        print("Successfuly picked up a powercell");    
    }
    
}
