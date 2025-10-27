using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 destination;
    [SerializeField] Transform destinoDumie;
    NavMeshAgent agent;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {
    
        
        if (Input.GetMouseButtonDown(1))
        {
 
            HandleCkick();
        }
    }

    private void HandleCkick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            destinoDumie.position = hit.point;
            agent.destination = destinoDumie.position;
        }
        
    }
}
