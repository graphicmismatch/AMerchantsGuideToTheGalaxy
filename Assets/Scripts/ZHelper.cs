using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZHelper : MonoBehaviour
{
    public SpriteRenderer obj;
    void Update()
    {
        obj.sortingOrder = -Mathf.CeilToInt(this.transform.position.y);
    }
}
