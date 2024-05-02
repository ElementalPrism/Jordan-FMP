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

    int ShotCounterReset = 0;
    int Phase1 = 1;
    int Phase2 = 2;
    int Phase3 = 3;
    int ReflectOrbIncrease = 1;
    int ShotIncrease = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OrbFire()
    {
        if (BossScript.CurrentPhase == Phase1) //Boss fires only the green reflect orb
        {
            ReflectAttack = Instantiate(ReflectOrb, AttackSpawnLocation);
            ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = BossScript.HomingTargetTransform;
            ReflectAttack.GetComponent<ReflectableAttack>().BossTransform = BossObject.transform;
            Boss.ReflectOrbCount = ReflectOrbIncrease;
            BossScript.CanFire = false;
        }

        if (BossScript.CurrentPhase >= Phase2) 
        {
            if (BossScript.ShotCounter < Phase3) //Boss fires 3 red damage orbs 
            {
                NormalAttack = Instantiate(NormalOrb, AttackSpawnLocation);
                NormalAttack.GetComponent<OrbAttack>().PlayerTarget = BossScript.StandardTargetTransform;
                NormalAttack.GetComponent<OrbAttack>().BossTransform = BossObject.transform;
                BossScript.ShotCounter = BossScript.ShotCounter + ShotIncrease;
            }

            if (BossScript.ShotCounter == Phase3) //Boss fires green reflect orb after 3 red damage orbs
            {
                ReflectAttack = Instantiate(ReflectOrb, AttackSpawnLocation);
                ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = BossScript.HomingTargetTransform;
                ReflectAttack.GetComponent<ReflectableAttack>().BossTransform = BossObject.transform;
                BossScript.ShotCounter = ShotCounterReset;
                Boss.ReflectOrbCount = ReflectOrbIncrease;
                BossScript.CanFire = false;
            }

        }
    }
}
