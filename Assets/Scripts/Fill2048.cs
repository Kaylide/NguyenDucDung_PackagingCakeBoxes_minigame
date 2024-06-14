using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fill2048 : MonoBehaviour
{
    public int value;
    [SerializeField] Text valueDisplay;
    [SerializeField] Image valueDisplayImage;
    [SerializeField] List<Sprite> valueSprites;
    [SerializeField] float speed;
    bool hasCombine;
    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        //valueDisplay.text = value.ToString();
        if (value == 2)
        {
            valueDisplayImage.sprite = valueSprites[0];
        }
        else if (value == 4)
        {
            valueDisplayImage.sprite = valueSprites[1];
        }
        else if (value == 8)
        {
            valueDisplayImage.sprite = valueSprites[2];
        }
    }


    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            hasCombine = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (hasCombine == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            hasCombine = true;
        }
    }
    public void Double()
    {
        value *= 2;
        GameController2048.instance.ScoreUpdate(value);
        valueDisplay.text = value.ToString();
        if (value == 2)
        {
            valueDisplayImage.sprite = valueSprites[0];
        }
        else if (value == 4)
        {
            valueDisplayImage.sprite = valueSprites[1];
        }
        else if (value == 8)
        {
            valueDisplayImage.sprite = valueSprites[2];
        }
        GameController2048.instance.WinCheck(value);
    }
}
