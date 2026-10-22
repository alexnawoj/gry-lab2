using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorShutSound;
    [SerializeField] private float doorOpenTime = 3f;

    private AudioSource audioSource;
    private Animator animator;
    private bool doorIsOpen;
    private float doorTimer;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animator>();    
    }

    // Update is called once per frame
    void Update() {

        if (!doorIsOpen)
            return;

        doorTimer += Time.deltaTime;

        if(doorTimer > doorOpenTime)
            Door(false, doorShutSound);
    }

    public void DoorCheck() {
        if(!doorIsOpen)
            Door(true, doorOpenSound);    
    }

    private void Door(bool open, AudioClip sound) {
        doorIsOpen = open;
        doorTimer = 0f;
        audioSource.PlayOneShot(sound);
        animator.SetBool("DoorOpen", open);
    }
}
