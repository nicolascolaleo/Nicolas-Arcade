using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour
{
    private Animator anim;
    public Sprite BreakPointOne, BreakPointTwo, BreakPointThree, BreakPointFour;
    public AudioClip BreakSoundOne, BreakSoundTwo, BreakSoundThree, FinalBreak;
    private AudioClip randomBreakSound;
    private int breakPoints;
    [SerializeField] 
    private float shakePower;
    public GameObject Player;
    private GameObject HeartUI, LifePointsUI;
    private bool isCellBroke, shakeCell;
    Vector3 newPos, originalPos;
    void Awake()
    {
        HeartUI = GameObject.Find("LifePointsSpinningHeart");
        LifePointsUI = GameObject.Find("LifePointsHealthPoints");
        originalPos = transform.position;
        //Debug.Log(transform.position);
        isCellBroke = false;
        breakPoints = 5;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(isCellBroke == false)
        {
            CageBreaking();
        }

        if(shakeCell)
        {
            newPos = new Vector3(transform.position.x + (Random.Range(0.018f, -0.018f)), transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }

    private void CageBreaking()
    {
    if(breakPoints == 5
        && Input.GetKeyDown(KeyCode.UpArrow))
        {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = BreakPointOne;
        RandomBreakSFX();
        SoundManager.instance.PlaySFX(randomBreakSound);
        StartCoroutine(ShakeEffect());
        breakPoints--;
        }
    else if( breakPoints == 4
        && Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = BreakPointTwo;
            RandomBreakSFX();
            SoundManager.instance.PlaySFX(randomBreakSound);
            StartCoroutine(ShakeEffect());
            breakPoints--;
        }
    else if( breakPoints == 3
        && Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = BreakPointThree;
            RandomBreakSFX();
            SoundManager.instance.PlaySFX(randomBreakSound);
            StartCoroutine(ShakeEffect());
            breakPoints--;
        }
        else if( breakPoints == 2
        && Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = BreakPointFour;
            RandomBreakSFX();
            SoundManager.instance.PlaySFX(randomBreakSound);
            StartCoroutine(ShakeEffect());
            breakPoints--;
        }
        else if( breakPoints == 1
        && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isCellBroke = true;
            SoundManager.instance.PlaySFX(FinalBreak);
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Destroy(GameObject.Find("ArrowUpStart"));
            anim.SetBool("isBreakTime", true);
            breakPoints--;
            transform.position = originalPos;
            LifePointsUI.transform.position = new Vector3(LifePointsUI.transform.position.x, LifePointsUI.transform.position.y, LifePointsUI.transform.position.z + 1f);
            HeartUI.transform.position = new Vector3(HeartUI.transform.position.x, HeartUI.transform.position.y, HeartUI.transform.position.z + 1f);
            GameObject.FindObjectOfType<DontDestroyOnLoadLeftSideDeadSpace>().DaveGameParentControllerLeftSide();
            GameObject.FindObjectOfType<DontDestroyOnLoadRightSideDeadSpace>().DaveGameParentControllerRightSide();
            Instantiate(Player, transform.position, transform.rotation);
        }
    }
    private IEnumerator ShakeEffect()
    {
        Vector3 originalPos = transform.position;
        if (shakeCell == false)
        {
            shakeCell = true;
        }
        yield return new WaitForSeconds(0.25f);

        shakeCell = false;
        transform.position = originalPos;
    }

    private void RandomBreakSFX()
    {
        int a = Random.Range(0,3);
        if (a == 0)
        {
            randomBreakSound = BreakSoundOne;
        }
        else if (a == 1)
        {
            randomBreakSound = BreakSoundTwo;
        }
        else
        {
            randomBreakSound = BreakSoundThree;
        }
    }
}
