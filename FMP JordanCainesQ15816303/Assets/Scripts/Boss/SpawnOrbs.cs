using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrbs : MonoBehaviour
{
    public Boss BossScript;
    public GameObject BossObject;
    public Transform AttackSpawnLocation;

    public GameObject ReflectOrb;
    public GameObject NormalOrb;


    GameObject ReflectAttack;
    GameObject NormalAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(BossScript.CurrentPhase == 1)
        //{
        //    ReflectAttack = Instantiate(ReflectOrb, AttackSpawnLocation);
        //    ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = BossScript.HomingTargetTransform;
        //    BossScript.CanFire = false;
        //}

        //if(BossScript.CurrentPhase >= 2)
        //{
        //    if(BossScript.ShotCounter < 3)
        //    {
        //        NormalAttack = Instantiate(NormalOrb, AttackSpawnLocation);
        //        NormalAttack.GetComponent<OrbAttack>().PlayerTarget = BossScript.StandardTargetTransform;
        //        BossScript.ShotCounter = BossScript.ShotCounter + 1;
        //    }

        //    if(BossScript.ShotCounter == 3)
        //    {
        //        ReflectAttack = Instantiate(ReflectOrb, AttackSpawnLocation);
        //        ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = BossScript.HomingTargetTransform;
        //        BossScript.ShotCounter = 0;
        //        BossScript.CanFire = false;
        //    }

        //}




    }

    public void OrbFire()
    {
        if (BossScript.CurrentPhase == 1)
        {
            ReflectAttack = Instantiate(ReflectOrb, AttackSpawnLocation);
            ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = BossScript.HomingTargetTransform;
            ReflectAttack.GetComponent<ReflectableAttack>().BossTransform = BossObject.transform;
            Boss.ReflectOrbCount = 1;
            BossScript.CanFire = false;
        }

        if (BossScript.CurrentPhase >= 2)
        {
            if (BossScript.ShotCounter < 3)
            {
                NormalAttack = Instantiate(NormalOrb, AttackSpawnLocation);
                NormalAttack.GetComponent<OrbAttack>().PlayerTarget = BossScript.StandardTargetTransform;
                NormalAttack.GetComponent<OrbAttack>().BossTransform = BossObject.transform;
                BossScript.ShotCounter = BossScript.ShotCounter + 1;
            }

            if (BossScript.ShotCounter == 3)
            {
                ReflectAttack = Instantiate(ReflectOrb, AttackSpawnLocation);
                ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = BossScript.HomingTargetTransform;
                ReflectAttack.GetComponent<ReflectableAttack>().BossTransform = BossObject.transform;
                BossScript.ShotCounter = 0;
                Boss.ReflectOrbCount = 1;
                BossScript.CanFire = false;
            }

        }
    }
}
