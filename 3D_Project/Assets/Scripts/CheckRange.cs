//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CheckRange : Condition
//{
//    [Header("Stats")]
//    public float minRadius;
//    public float maxRadius;

//    private GameObject playerObj;

//    public void Start()
//    {
//        playerObj = GameObject.FindGameObjectWithTag("PLayer");
//    }

//    public override bool ConditionCheck()
//    {
//        float distance = Vector3.Distance(playerObj.transform.position, this.transform.position);
//        if(distance >= minRadius && distance <= maxRadius)
//        {
//            return true;
//        }
//        return false;
//    }
//}
