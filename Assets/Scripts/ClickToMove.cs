using System.Collections;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Rigidbody rb;
    Vector3 destination;
    [SerializeField] Transform destinoDumie;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 3f;
    }
    void Update()
    {
        destination = destinoDumie.position;
        if (Input.GetMouseButtonDown(1))
        {
            HandleCkick();
        }
    }

    private void HandleCkick()
    {
        StartCoroutine(MoveToPosition(destination));
    }

    IEnumerator MoveToPosition(Vector3 _destination)
    {
        Vector3 moveDirection = _destination - transform.position;
        moveDirection = moveDirection.normalized;
        rb.AddForce(moveDirection * moveSpeed, ForceMode.VelocityChange);
        yield return null;    
    }
}
