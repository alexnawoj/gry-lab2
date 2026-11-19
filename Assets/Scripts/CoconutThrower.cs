using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CoconutThrower : MonoBehaviour
{
    [SerializeField] private Rigidbody coconutPrefab;
    [SerializeField] private AudioClip throwSound;
    [SerializeField] private float throwSpeed = 30f;
    private Coroutine throwCorutine;

    private InputAction attackAction;
    private AudioSource audioSource;

    public bool CanThrow { get; set; }

    void Awake() {
    
        attackAction = InputSystem.actions.FindAction("Player/Attack");
        audioSource = GetComponent<AudioSource>();    
    }
    
    void Update() {
        if(CanThrow && attackAction.WasPressedThisFrame())
            Throw();
    }
    
    private void Throw() {
        if(throwCorutine == null)
            throwCorutine = StartCoroutine(ThrowCorutine());
        
    }

    IEnumerator ThrowCorutine() {
        
        audioSource.PlayOneShot(throwSound);
        Rigidbody coconut = Instantiate(coconutPrefab, transform.position, transform.rotation);
        coconut.name = "coconut";
        coconut.linearVelocity = transform.forward * throwSpeed;

        yield return new WaitForSeconds(0.5f);
        throwCorutine = null;
    }
}   
