using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerationControl : MonoBehaviour
{

    public GameObject player;
    public GameObject refer;
    public float width;
    public bool generated;



    public GameObject cloud;
    public GameObject LargePlatform;

    public float vertFix;

    public GameObject end;

    private Vector2 disp;

    public float scale;
    public float dispTest;

    public int minPlatformSize = 1;
    public int maxPlatformSize = 10;
    public int maxHazardSize = 3;
    public int maxHeight = 3;

    public float waitTime;

    public int maxDrop = -3;
    public static bool active;

    public int platforms = 100;
    [Range(0.0f, 1f)]
    public float hazardChance = .5f;
    [Range(0.0f, 1f)]

    private int blocknum;
    private int blockheight;
    private bool isHazard;
    //Purely a debug variable
    public float deA;
    public float goal;
    public float rate;

    public float minumumTreck;

    public GameObject placeA;
    public GameObject placeB;
    public GameObject placeC;
    public GameObject placeD;
    public GameObject placeE;

    public GameObject death;


    public float loc;
    // Start is called before the first frame update
    void Start()
    {
        blocknum = 1 * (int)scale;
        generated = false;
        GlobalVariables.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        loc = player.transform.position.x;
        deA = loc - refer.transform.position.x;
        if (loc - refer.transform.position.x > width && !generated)
        {
            generate(new Vector2(refer.transform.position.x + width * 2, refer.transform.position.z));
            generated = true;
        }
        if(generated && loc - goal < 0 && GlobalVariables.active)
        {
            clouds();
        }
        if (!GlobalVariables.active)
        {
            waitTime--;
            if (waitTime == 0)
            {
                GlobalVariables.inputScore = player.transform.position.x;
                SceneManager.LoadScene("InputScore", LoadSceneMode.Single);
            }
        }
    }

    void clouds()
    {
        minumumTreck += rate;
        for(int x = 0; x < 3; x++){
            Instantiate(cloud, new Vector3(minumumTreck, Random.Range(-50, 50), -10), Quaternion.identity);
        }

        if(minumumTreck > player.transform.position.x)
        {
            GlobalVariables.active = false;
            death.transform.localScale = new Vector3(150, 150, 150);
            Instantiate(death, new Vector3(player.transform.position.x, player.transform.position.y, -50), Quaternion.EulerAngles(0,(float)System.Math.PI, 0));
        }

    }

    IEnumerator Endgame()
    {
        Instantiate(death, new Vector3(player.transform.position.x, player.transform.position.y, -20), Quaternion.identity);
        active = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Input", LoadSceneMode.Single);
    }


    bool getActive()
    {
        return active;
    }

    void generate(Vector2 input)
    {
        disp = input;
        //begining tile.
        minumumTreck = disp.x - 100;

        LargePlatform.transform.localScale.Set(scale, scale, scale);
        Instantiate(LargePlatform, new Vector2(disp.x * 2, 0), Quaternion.identity);

        for (int plat = 1; plat < platforms; plat++)
        {



            if (isHazard == true)
            {
                isHazard = false;
            }
            else
            {
                if (Random.value < hazardChance) //value [0,1] ; hazardchance = 50%
                {
                    isHazard = true;
                }
                else
                {
                    isHazard = false;
                }
            }
            if (isHazard == true)
            {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazardSize));
                blocknum += hazardSize;
            }

            else
            {
                int platformsize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                //  int platformhight = Mathf.RoundToInt(Random.Range(maxDrop, maxHeight));

                blockheight = (blockheight + Random.Range(maxDrop, maxHeight));

                for (int tiles = 0; tiles < platformsize; tiles++)
                {

                    Instantiate(LargePlatform, new Vector2(blocknum + disp.x, blockheight), Quaternion.identity);

                    blocknum = blocknum + 3 * (int)scale;





                }


                GameObject placed;
                int run = Mathf.RoundToInt(Random.RandomRange(1, 3));
                for (int z = 0; z < 2; z++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = -2; x < run; x++)
                        {
                            int mark = Mathf.RoundToInt(Random.RandomRange(1, 5));
                            switch (mark)
                            {
                                case 1:
                                    placed = Instantiate(placeA, new Vector3(blocknum + disp.x + 120 * x, 20 - 20 * Random.RandomRange(1, 3) - 50 * y - 40 * z, 400 - 100 * y + 30 * Random.RandomRange(1, 3)), Quaternion.EulerRotation(0, Random.RandomRange(0, 6.28f),0));
                                    placed.transform.localScale = new Vector3(Random.RandomRange(10, 25), Random.RandomRange(10, 25), Random.RandomRange(10, 25));
                                    break;
                                case 2:
                                    placed = Instantiate(placeB, new Vector3(blocknum + disp.x + 120 * x, 20 - 20 * Random.RandomRange(1, 3) - 50 * y-40*z, 400 - 100 * y + 30 * Random.RandomRange(1, 3)), Quaternion.EulerRotation(0, Random.RandomRange(0, 6.28f),0));
                                    placed.transform.localScale = new Vector3(Random.RandomRange(10, 25), Random.RandomRange(10, 25), Random.RandomRange(10, 25));
                                    break;
                                case 3:
                                    placed = Instantiate(placeC, new Vector3(blocknum + disp.x + 120 * x, 20 - 20 * Random.RandomRange(1, 3) - 50 * y - 40 * z, 400 - 100 * y + 30 * Random.RandomRange(1, 3)), Quaternion.EulerRotation(0, Random.RandomRange(0, 6.28f),0));
                                    placed.transform.localScale = new Vector3(Random.RandomRange(10, 25), Random.RandomRange(10, 25), Random.RandomRange(10, 25));

                                    break;
                                case 4:
                                    placed = Instantiate(placeD, new Vector3(blocknum + disp.x + 120 * x, 20 - 20 * Random.RandomRange(1, 3) - 50 * y - 40 * z, 400 - 100 * y + 30 * Random.RandomRange(1, 3)), Quaternion.EulerRotation(0, Random.RandomRange(0, 6.28f),0));
                                    placed.transform.localScale = new Vector3(Random.RandomRange(10, 25), Random.RandomRange(10, 25), Random.RandomRange(10, 25));
                                    break;
                                case 5:
                                    placed = Instantiate(placeE, new Vector3(blocknum + disp.x + 120 * x, 20 - 20 * Random.RandomRange(1, 3) - 50 * y - 40 * z, 400 - 100 * y + 30 * Random.RandomRange(1, 3)), Quaternion.EulerRotation(0, Random.RandomRange(0, 6.28f),0));
                                    placed.transform.localScale = new Vector3(Random.RandomRange(10, 25), Random.RandomRange(10, 25), Random.RandomRange(10, 25));
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }
            }


        }

        goal = blocknum + dispTest + disp.x + 20;


        Instantiate(end, new Vector3(blocknum + dispTest + disp.x, blockheight, 20), Quaternion.EulerAngles(0, (float)System.Math.PI, 0));
    }
    // Instantiate(GetComponent<GameObject>(), new Vector2(blocknum + dispTest+50, blockheight) + disp, Quaternion.identity);
}

