using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float clickRadius = 2f;
    private Inventory _inventory;

    [Inject]
    public void Construct(Inventory inventory) 
    {
        _inventory = inventory;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_inventory == null)
        {
            return;
        }
        Vector3 clickWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(
            eventData.position.x,
            eventData.position.y,
            Camera.main.nearClipPlane));

        float distance = Vector3.Distance(transform.position, clickWorldPosition);
        if (distance <= clickRadius)
        {
            _inventory.AddItem(gameObject);
        }
    }
}