using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO KitchenObjectSO;
    public override void Interact(Player player)
    {
        Transform KitchenObjectTransform = Instantiate(KitchenObjectSO.prefab);
        KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
}
