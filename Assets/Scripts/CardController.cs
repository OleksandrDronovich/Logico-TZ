using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    GameObject diamondSprite;
    Sprite cardSprite;
    Image myImage;
    bool joker;
    bool diamond;

    public void SetCardSprite(Sprite value, bool isJoker) 
    {
        diamond = false;
        cardSprite = value;
        joker = isJoker;
        if (isJoker) cardSprite = GameUIController.Instance.jokerImage;
    }

    public void SetDiamond() 
    {
        diamond = true;
    }

    public void SetJocker() 
    {
        joker = true;
        cardSprite = GameUIController.Instance.jokerImage;
    }

    public void ShowCard() 
    {
        myImage.sprite = cardSprite;
        diamondSprite.SetActive(diamond);
    }

    public void HideCard() 
    {
        diamondSprite.SetActive(false);
        if(joker) GameController.Instance.AddMoney(5);
        joker = false;
        myImage.sprite = GameUIController.Instance.GetBasicSprite();
    }

    void Start()
    {
        myImage = GetComponent<Image>();
        diamondSprite = transform.GetChild(0).gameObject;
        diamondSprite.SetActive(false);
    }

    public bool IsActive() 
    {
        return myImage.color == Color.white;
    }
}