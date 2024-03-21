using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public Slime SlimeObject;
    public Skeleton SkeletonObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        if(SlimeObject != null) 
        {
            SlimeObject.IsDead = true;
        }

        if(SkeletonObject != null)
        {
            SkeletonObject.IsDead = true;
        }
        
    }

}
