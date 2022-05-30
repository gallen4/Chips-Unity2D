using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public int boardNumber;

    public Sprite hideImage;
    public Sprite openImage;

    public BoardController boardController;
    private void OnMouseUpAsButton()
    {
        boardController.CheckChip(gameObject.GetComponent<Chip>());
    }

    public void SetOpen(Sprite sprite)
    {
        openImage = sprite;
    }

    public void Destroy()
    {
        Destroy(gameObject, 1);
    }

    public void Hide()
    {
        GetComponent<SpriteRenderer>().sprite = hideImage;
    }

    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = openImage;
    }
}
