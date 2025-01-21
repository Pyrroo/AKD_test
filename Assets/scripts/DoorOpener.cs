using DG.Tweening;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{ 
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 0), 1f);
    }
}
