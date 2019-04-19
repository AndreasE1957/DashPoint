
using UnityEngine;

public class LevelMapping : MonoBehaviour
{
    public GameObject LargePlatform;


    public GameObject end;

    private Vector2 disp;

    public float scale;
    public float dispTest;

    public int minPlatformSize = 1;
    public int maxPlatformSize = 10;
    public int maxHazardSize = 3;
    public int maxHeight = 3;

    public int maxDrop = -3;

    public int platforms = 100;
    [Range(0.0f, 1f)]
    public float hazardChance = .5f;
    [Range(0.0f, 1f)]

    private int blocknum = 1;
    private int blockheight;
    private bool isHazard;


    private void Start()
    {
        generate(new Vector2(0, 0));
    }

    // Start is called before the first frame update
    void generate(Vector2 input)
    {
        disp = input;
        //begining tile.

        LargePlatform.transform.localScale.Set(scale, scale, scale);
        Instantiate(LargePlatform, new Vector2(0, 0) + disp, Quaternion.identity);

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

                    blockheight = blockheight + Random.Range(maxDrop, maxHeight);

                    for (int tiles = 0; tiles < platformsize; tiles++)
                    {

                        Instantiate(LargePlatform, new Vector2(blocknum, blockheight) + disp, Quaternion.identity);

                        blocknum = blocknum + 3;

                        
                           
                        

                    }


                }


        }
        Instantiate(end, new Vector2(blocknum + dispTest, blockheight) + disp, Quaternion.identity);
    }

    
    // Update is called once per frame
    void Update()
    {


    }
}

