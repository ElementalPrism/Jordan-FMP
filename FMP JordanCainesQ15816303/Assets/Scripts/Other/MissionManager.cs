using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public GameObject BossObject;
    public GameObject BossSign;
    public GameObject WindmillObject;
    public GameObject Bucket;
    public GameObject Flower;
    public GameObject Sunflower;
    public GameObject WellBlockade;
    public GameObject Weed1;
    public GameObject Weed2;
    public GameObject Weed3;
    public GameObject Weed4;
    public GameObject Weed5;
    public GameObject Weed6;
    public GameObject Weed7;
    public GameObject Weed8;
    public GameObject Weed9;
    public GameObject Weed10;
    public GameObject Weed11;
    public GameObject Weed12;
    public GameObject Weed13;
    public GameObject Weed14;
    public GameObject Weed15;
    public GameObject Weed16;
    public GameObject Weed17;
    public GameObject Weed18;
    public GameObject Weed19;
    public GameObject Weed20;
    public GameObject Weed21;
    public GameObject Diamond2;
    public GameObject Diamond5;

    int Mission1 = 1;
    int Mission2 = 2;
    int Mission3 = 3;
    int Mission4 = 4;
    int Mission5 = 5;

    // Start is called before the first frame update
    void Start()
    { //Checks to see what mission has currently been selected, then loads/unloads what is necessary
        if (Level1Manager.CurrentMission == Mission1)
        {

            BossObject.SetActive(true);
            BossSign.SetActive(true);
            WindmillObject.SetActive(false);
            Bucket.SetActive(false);
            Flower.SetActive(true);
            WellBlockade.SetActive(true);
            Sunflower.SetActive(false);
            Weed1.SetActive(false);
            Weed2.SetActive(false);
            Weed3.SetActive(false);
            Weed4.SetActive(false);
            Weed5.SetActive(false);
            Weed6.SetActive(false);
            Weed7.SetActive(false);
            Weed8.SetActive(false);
            Weed9.SetActive(false);
            Weed10.SetActive(false);
            Weed11.SetActive(false);
            Weed12.SetActive(false);
            Weed13.SetActive(false);
            Weed14.SetActive(false);
            Weed15.SetActive(false);
            Weed16.SetActive(false);
            Weed17.SetActive(false);
            Weed18.SetActive(false);
            Weed19.SetActive(false);
            Weed20.SetActive(false);
            Weed21.SetActive(false);
            BossObject.SetActive(true);
            Diamond2.SetActive(false);
            Diamond5.SetActive(false);
        }
        else if (Level1Manager.CurrentMission == Mission2)
        {
            BossObject.SetActive(false);
            BossSign.SetActive(false);
            WindmillObject.SetActive(true);
            WellBlockade.SetActive(true);
            Bucket.SetActive(false);
            Flower.SetActive(true);
            Sunflower.SetActive(false);
            Weed1.SetActive(false);
            Weed2.SetActive(false);
            Weed3.SetActive(false);
            Weed4.SetActive(false);
            Weed5.SetActive(false);
            Weed6.SetActive(false);
            Weed7.SetActive(false);
            Weed8.SetActive(false);
            Weed9.SetActive(false);
            Weed10.SetActive(false);
            Weed11.SetActive(false);
            Weed12.SetActive(false);
            Weed13.SetActive(false);
            Weed14.SetActive(false);
            Weed15.SetActive(false);
            Weed16.SetActive(false);
            Weed17.SetActive(false);
            Weed18.SetActive(false);
            Weed19.SetActive(false);
            Weed20.SetActive(false);
            Weed21.SetActive(false);
            Diamond2.SetActive(true);
            Diamond5.SetActive(false);
        }
        else if (Level1Manager.CurrentMission == Mission3)
        {
            BossObject.SetActive(false);
            BossSign.SetActive(false);
            WindmillObject.SetActive(true);
            WellBlockade.SetActive(true);
            Bucket.SetActive(true);
            Flower.SetActive(true);
            Sunflower.SetActive(false);
            Weed1.SetActive(false);
            Weed2.SetActive(false);
            Weed3.SetActive(false);
            Weed4.SetActive(false);
            Weed5.SetActive(false);
            Weed6.SetActive(false);
            Weed7.SetActive(false);
            Weed8.SetActive(false);
            Weed9.SetActive(false);
            Weed10.SetActive(false);
            Weed11.SetActive(false);
            Weed12.SetActive(false);
            Weed13.SetActive(false);
            Weed14.SetActive(false);
            Weed15.SetActive(false);
            Weed16.SetActive(false);
            Weed17.SetActive(false);
            Weed18.SetActive(false);
            Weed19.SetActive(false);
            Weed20.SetActive(false);
            Weed21.SetActive(false);
            Diamond2.SetActive(true);
            Diamond5.SetActive(false);
        }
        else if (Level1Manager.CurrentMission == Mission4)
        {
            BossObject.SetActive(false);
            BossSign.SetActive(false);
            WindmillObject.SetActive(true);
            WellBlockade.SetActive(false);
            Bucket.SetActive(false);
            Flower.SetActive(false);
            Sunflower.SetActive(true);
            Weed1.SetActive(true);
            Weed2.SetActive(true);
            Weed3.SetActive(true);
            Weed4.SetActive(true);
            Weed5.SetActive(true);
            Weed6.SetActive(true);
            Weed7.SetActive(true);
            Weed8.SetActive(true);
            Weed9.SetActive(true);
            Weed10.SetActive(true);
            Weed11.SetActive(true);
            Weed12.SetActive(true);
            Weed13.SetActive(true);
            Weed14.SetActive(true);
            Weed15.SetActive(true);
            Weed16.SetActive(true);
            Weed17.SetActive(true);
            Weed18.SetActive(true);
            Weed19.SetActive(true);
            Weed20.SetActive(true);
            Weed21.SetActive(true);
            Diamond2.SetActive(true);
            Diamond5.SetActive(true);
        }
        else if (Level1Manager.CurrentMission >= Mission5)
        {
            BossObject.SetActive(false);
            BossSign.SetActive(false);
            WindmillObject.SetActive(true);
            WellBlockade.SetActive(false);
            Bucket.SetActive(false);
            Flower.SetActive(false);
            Sunflower.SetActive(true);
            Weed1.SetActive(false);
            Weed2.SetActive(false);
            Weed3.SetActive(false);
            Weed4.SetActive(false);
            Weed5.SetActive(false);
            Weed6.SetActive(false);
            Weed7.SetActive(false);
            Weed8.SetActive(false);
            Weed9.SetActive(false);
            Weed10.SetActive(false);
            Weed11.SetActive(false);
            Weed12.SetActive(false);
            Weed13.SetActive(false);
            Weed14.SetActive(false);
            Weed15.SetActive(false);
            Weed16.SetActive(false);
            Weed17.SetActive(false);
            Weed18.SetActive(false);
            Weed19.SetActive(false);
            Weed20.SetActive(false);
            Weed21.SetActive(false);
            Diamond2.SetActive(true);
            Diamond5.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {


    }
}

