using UnityEngine;

public class UnloadItem : MonoBehaviour
{
    [SerializeField] Transform dropPoint;
    [SerializeField] Inventory inventory;
    private GameObject dropObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (inventory.CheckHands())
            {
                dropObject = inventory.DropItem();
                dropObject.transform.position = dropPoint.position;
            }           
        }
    }
}
