using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance;
    //RightColumn
    public TextMeshProUGUI selectTicketText;
    public TextMeshProUGUI ticketCostText;
    public TextMeshProUGUI totalCostText;
    public TextMeshProUGUI winUpToText;

    //Card board
    /// LeftColumn
    public Image[] leftCards;
    /// MiddleColumn
    public Image[] midCards;
    /// RightColumn
    public Image[] rightCards;

    //Down board
    public TextMeshProUGUI totalMoneyText;
    public TextMeshProUGUI winMoneyText;
    public TextMeshProUGUI totalPayText;

    //Basic sprites
    public Sprite[] cards;
    public Sprite jokerImage;
    public Sprite basicImage;


    public Sprite GetRandomCardImage() 
    {
        return cards[Random.Range(0, cards.Length)];
    }

    public Sprite GetJokerSprite()
    {
        return jokerImage;
    }

    public Sprite GetBasicSprite()
    {
        return basicImage;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;    
    }

    void SelectCards(Image[] value, float alpha) 
    {
        for (int i = 0; i < value.Length; i++) 
        {
            value[i].color = new Color(1, 1, 1, alpha);
        }
    }

    public void SetSelectTicketText(string value) 
    {
        selectTicketText.SetText(value);

        switch (value)
        {
            case "3":
                SelectCards(leftCards, 1);
                SelectCards(rightCards, 0.5f);
                SelectCards(midCards, 0.5f);
                break;

            case "6":
                SelectCards(leftCards, 1);
                SelectCards(rightCards, 1f);
                SelectCards(midCards, 0.5f);
                break;

            case "10":
                SelectCards(leftCards, 1);
                SelectCards(rightCards, 1f);
                SelectCards(midCards, 1f);
                break;
        }
    }

    public void SetTicketCostText(string value) 
    {
        ticketCostText.SetText($"{value}$");
    }
    public void SetTotalCostText(string value)
    {
        totalCostText.SetText($"{value}$");
        totalPayText.SetText($"Pay: {value}$");
    }
    public void SetWinUpToText(string value)
    {
        winUpToText.SetText(value);
    }

    public void SetTotalMoneyText(string value) 
    {
        totalMoneyText.SetText($"Demo balance: {value}$");
    }
}