using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform handPoint;
    private GameObject currentItem;
    
    public void AddItem(GameObject item)
    {
        if (currentItem != null)
        {
            return;
        }
        
        item.transform.SetParent(handPoint);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        currentItem = item;
    }
    public bool CheckHands()
    {
        if(currentItem != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject DropItem()
    {
        currentItem.GetComponent<Collider>().enabled = true;
        currentItem.transform.SetParent(null);
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        GameObject tmp = currentItem;
        currentItem = null;
        return tmp;
    }

}