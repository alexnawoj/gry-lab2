using UnityEngine;

public class TidyObject : MonoBehaviour
{
    [SerializeField] private float removeTime = 3f;

    void Start() {
        Destroy(gameObject, removeTime);    
    }
}
