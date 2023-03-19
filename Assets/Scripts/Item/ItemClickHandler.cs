using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public ItemClickDirection itemClickDirection;
    public void OnItemClick(){
        EventHandler.CallItemClickDirectionEvent(itemClickDirection);
    }
}
