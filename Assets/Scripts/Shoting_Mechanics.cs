using UnityEngine;

public class Shoting_Mechanics : MonoBehaviour
{
    public bool IsOnLoS(Vector3 enemyPosition, float weaponRange)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, enemyPosition, out hit, weaponRange))
        {
            Character character = hit.collider.GetComponent<Character>();

            if (character != null)
            {
                return true;
            }
        }
        return false;
    }
}
