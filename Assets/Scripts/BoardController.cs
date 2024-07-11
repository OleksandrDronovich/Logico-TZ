using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Round 
{
    public bool haveJoker;
    public int diamond;
}

public class BoardController : MonoBehaviour
{
    public static BoardController Instance;

    public CardController[] allCards;

    public Round currentRound;

    private void Awake()
    {
        Instance = this;
    }

    public void StartRound() 
    {
        for (int i = 0; i < 3; i++) 
        {
            UIAnimatorController.Instance.PlayDiamondAnimation(i, false);
        }
        currentRound.diamond = Random.Range(0, 4);
        currentRound.haveJoker = Random.Range(0, 3) == 0;
        Calculare();
        StartCoroutine(DiamondCoroutine());
    }

    IEnumerator DiamondCoroutine() 
    {
        yield return new WaitForSeconds(0.5f);
        

        for (int i = 0; i < currentRound.diamond; i++)
        {
            UIAnimatorController.Instance.PlayDiamondAnimation(i, true);
        }

        if(currentRound.diamond == 3) 
        {
            GameController.Instance.AddMoney(1000);
        }
    }

    void Calculare() 
    {
        for (int i = 0; i < allCards.Length; i++)
        {
            allCards[i].SetCardSprite(GameUIController.Instance.GetRandomCardImage(), false);
        }
        List<CardController> activeCards = new List<CardController>();
        for (int i = 0; i < allCards.Length; i++) 
        {
            if (allCards[i].IsActive()) activeCards.Add(allCards[i]);
        }

        for (int i = 0; i < currentRound.diamond; i++)
        {
            CardController card = activeCards[Random.Range(0, activeCards.Count)];
            card.SetDiamond();
            activeCards.Remove(card);
        }
        if(currentRound.haveJoker)
        activeCards[Random.Range(0, activeCards.Count)].SetJocker();
    }
}