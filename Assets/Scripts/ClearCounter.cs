using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO KitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public void Interact(Player player)
    {
        if(kitchenObject != null) // there is a kitchen object on the counter
        {
            //give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
            return;
        }

        if (KitchenObjectSO != null)
        {
            Transform KitchenObjectTransform = Instantiate(KitchenObjectSO.prefab, counterTopPoint);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            KitchenObjectTransform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("Counter not have an scriptable object");
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }   

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }   

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }   
}
