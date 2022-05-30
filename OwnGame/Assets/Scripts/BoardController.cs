using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardController : MonoBehaviour
{
    [SerializeField] private List<Chip> boardChips;
    [SerializeField] private List<Sprite> chipSprites;

    private int ChipChecked = 0;

    private Chip firstChecked;
    private Chip secondChecked;

    public Counter Counter;
    private void Start()
    {
        boardChips = new List<Chip>(GetComponentsInChildren<Chip>());

        for(int i = 0; i < boardChips.Count; ++i)
        {
            boardChips[i].boardController = gameObject.GetComponent<BoardController>();
        }

        boardChips = InitRandomPairs(boardChips);
    }

    public void CheckChip(Chip chipFrom)
    {
        if (ChipChecked == 0)
        {
            firstChecked = chipFrom;
            firstChecked.Open();

            ChipChecked = 1;
        }
        else if (ChipChecked == 1)
        {
            chipFrom.Open();

            if(firstChecked.boardNumber == chipFrom.boardNumber && firstChecked != chipFrom)
            {
                firstChecked.Destroy();
                chipFrom.Destroy();
                Counter.Count();
            }
            else
            {
                firstChecked.Hide();
                chipFrom.Hide();
            }

            
            ChipChecked = 0;
            

        }
    }

    private List<Chip> InitRandomPairs(List<Chip> inList)
    {
        List<Sprite> openSprites = chipSprites;
        List<Chip> shuffleList = new List<Chip>();

        int count = inList.Count;

        System.Random random = new System.Random();

        for(int i = 0; i < count/2; ++i)
        {
            int sprite = random.Next(openSprites.Count);

            shuffleList.Add(inList[0]);
            inList[0].boardNumber = i;
            inList[0].SetOpen(openSprites[sprite]);
            inList.RemoveAt(0);

            int pair = random.Next(inList.Count);

            shuffleList.Add(inList[pair]);
            inList[pair].boardNumber = i;
            inList[pair].SetOpen(openSprites[sprite]);
            inList.RemoveAt(pair);

            openSprites.RemoveAt(sprite);
        }
        return shuffleList;
    }

}
