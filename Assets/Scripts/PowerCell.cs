using UnityEngine;
using UnityEngine.InputSystem;

public class PowerCell : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float amplitude = 5;
    [SerializeField] private float frequency = 4f;

    void Update () {

        float x = this.transform.position.x;
        float y = Mathf.Sin(Time.time * frequency) * amplitude + 30f;
        float z = this.transform.position.z;

        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
        this.transform.position = new Vector3(x, y, z);
    }

    void OnTriggerEnter (Collider other) {
        if (other.TryGetComponent(out Inventory inventory)) {
            inventory.CellPickup();
            Destroy(gameObject);
        }
    }
}
