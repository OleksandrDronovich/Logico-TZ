using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int cardSelected = 3;
    public float costPerTicket = 0.2f;

    public float totalMoney = 100f;

    void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int value) 
    {
        totalMoney += value;
        GameUIController.Instance.SetTotalMoneyText(totalMoney.ToString("f2"));
        PlayerPrefs.SetFloat("Money", totalMoney);
    }

    public void Spin()
    {
        totalMoney -= cardSelected * costPerTicket;
        BoardController.Instance.StartRound();
        GameUIController.Instance.SetTotalMoneyText(totalMoney.ToString("f2"));
        switch (cardSelected) 
        {
            case 3:
                UIAnimatorController.Instance.PlayCardAnimation(UIAnimatorController.Instance.leftCardsColumn);
                break;
            case 6:
                UIAnimatorController.Instance.PlayCardAnimation(UIAnimatorController.Instance.leftCardsColumn);
                UIAnimatorController.Instance.PlayCardAnimation(UIAnimatorController.Instance.rightCardsColumn);
                break;
            case 10:
                UIAnimatorController.Instance.PlayCardAnimation(UIAnimatorController.Instance.leftCardsColumn);
                UIAnimatorController.Instance.PlayCardAnimation(UIAnimatorController.Instance.rightCardsColumn);
                UIAnimatorController.Instance.PlayCardAnimation(UIAnimatorController.Instance.middleCardsColumn);
                break;
        }

        if (totalMoney < 0)
            totalMoney = 100;
        GameUIController.Instance.SetTotalMoneyText(totalMoney.ToString("f2"));

        PlayerPrefs.SetFloat("Money", totalMoney);
    }

    public void PlusCost()
    {
        if (costPerTicket < 2f)
            costPerTicket += 0.2f;
        GameUIController.Instance.SetTicketCostText(costPerTicket.ToString("f2"));
        Calculate();
    }

    public void MinusCost() 
    {
        if (costPerTicket >= 0.4f)
            costPerTicket -= 0.2f;
        GameUIController.Instance.SetTicketCostText(costPerTicket.ToString("f2"));
        Calculate();
    }
    
    public void PlusCards() 
    {
        if(cardSelected < 9) cardSelected += 3;
        if(cardSelected >= 9) cardSelected = 10;
        GameUIController.Instance.SetSelectTicketText(cardSelected.ToString());
        Calculate();
    }

    public void MinusCards() 
    {
        if(cardSelected > 3 && cardSelected != 10) cardSelected -= 3;
        else if(cardSelected == 10) cardSelected = 6;
        GameUIController.Instance.SetSelectTicketText(cardSelected.ToString());
        Calculate();
    }

    void Calculate() 
    {
        float total = cardSelected * costPerTicket;
        GameUIController.Instance.SetTotalCostText(total.ToString("f2"));
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
            totalMoney = PlayerPrefs.GetFloat("Money");
        if (costPerTicket < 0.2f) costPerTicket = 0.2f;
        if(cardSelected < 3) cardSelected = 3;
        if(totalMoney < 0) totalMoney = 100;

        GameUIController.Instance.SetTotalMoneyText(totalMoney.ToString("f2"));
        GameUIController.Instance.SetSelectTicketText(cardSelected.ToString());
        GameUIController.Instance.SetTicketCostText(costPerTicket.ToString("f2"));
        Calculate();
    }
}