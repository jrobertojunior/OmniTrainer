using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject notificationCard;
    public GameObject teachingCard;
    public GameObject usedCard;

    float offsetx = -195;

    float offset1 = 135;
    float offset2 = -40;
    float offset3 = -215;

    public bool skipOne = false;

    int state = 0;
    int cardType = 0;
    void Start()
    {
        //CreateCard(offset1);
        //CreateCard(offset2);
        //CreateCard(offset3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeStateCard1();
        }
    }

    GameObject CreateCard(GameObject cardPrefab, float offset)
    {
        var card = Instantiate(cardPrefab, new Vector3(offsetx, offset, 0), Quaternion.identity);
        card.transform.SetParent(transform, false);

        return card;
    }

    void CreateCard(int slot, int type)
    {
        float offset = 0;
        switch (slot)
        {
            case 0:
                offset = offset1;
                break;
            case 1:
                offset = offset2;
                break;
            case 2:
                offset = offset3;
                break;
        }

        GameObject card;
        switch (type)
        {
            case 0:
                CreateCard(notificationCard, offset);
                break;
            case 1:
                CreateCard(teachingCard, offset);
                break;
            case 2:
                CreateCard(usedCard, offset);
                break;
        }
    }


    int card1State = 0;
    bool disableCard1 = false;
    public void ChangeStateCard1()
    {
        if (skipOne)
        {
            skipOne = false;
        }
        else
        {
            if (!disableCard1)
            {
                switch (card1State)
                {
                    case 0:
                        notificationCard.SetActive(true);
                        card1State += 1;
                        break;
                    case 1:
                        notificationCard.SetActive(false);
                        teachingCard.SetActive(true);
                        card1State += 1;
                        break;
                    case 2:
                        teachingCard.SetActive(false);
                        usedCard.SetActive(true);
                        card1State = 0;
                        disableCard1 = true;
                        break;
                }
            }
        }
    }
}
