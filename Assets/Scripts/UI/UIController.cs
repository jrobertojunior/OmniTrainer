using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject notificationCard;
    public GameObject teachingCard;
    public GameObject usedCard;

    float offset1 = 135;
    float offset2 = 0;
    float offset3 = -135;

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (state)
            {
                case 0:
                    CreateCard(slot: 0, type: cardType);
                    break;
                case 1:
                    CreateCard(slot: 1, type: cardType);
                    break;
                case 2:
                    CreateCard(slot: 2, type: cardType);
                    break;
            }
            if (state < 3)
            {
                state += 1;
            } else
            {
                state = 0;
                cardType += 1;
            }
        }
    }

    void CreateCard(GameObject cardPrefab, float offset)
    {
        var card = Instantiate(cardPrefab, new Vector3(0, offset, 0), Quaternion.identity);
        card.transform.SetParent(transform, false);
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
}
