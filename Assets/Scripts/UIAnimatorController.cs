using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIAnimatorController : MonoBehaviour
{
    public static UIAnimatorController Instance;

    //Diamond part
    public Animator[] diamonds;
    public Animator[] diamondFX;

    public Animator[] leftCardsColumn;
    public Animator[] middleCardsColumn;
    public Animator[] rightCardsColumn;

    #region Diamond Animations
    public void PlayDiamondAnimation(int id, bool value) 
    {
        diamonds[id].SetBool("DiamondAnim", value);
        if(value)
            PlayDiamondFXAnimation(id);
    }

    public void PlayDiamondFXAnimation(int id) 
    {
        diamondFX[id].SetTrigger("Play FX");   
    }

    public bool GetPlayingAnim(Animator anim, string animName) 
    {
        return anim.GetBool(animName);
    }

    #endregion

    #region Basic functions
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Diamonds
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            PlayDiamondAnimation(0, !GetPlayingAnim(diamonds[0], "DiamondAnim"));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayDiamondAnimation(1, !GetPlayingAnim(diamonds[1], "DiamondAnim"));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayDiamondAnimation(2, !GetPlayingAnim(diamonds[2], "DiamondAnim"));
        }
    }
    #endregion

    public void PlayCardAnimation(Animator[] value) 
    {
        for (int i = 0; i < value.Length; i++)
        {
            value[i].SetTrigger("PlayCardAnim");
        }
    }


}