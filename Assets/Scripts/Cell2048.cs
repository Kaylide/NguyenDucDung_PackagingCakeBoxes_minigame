using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cell2048 : MonoBehaviour
{
    public Cell2048 right;
    public Cell2048 down;
    public Cell2048 left;
    public Cell2048 up;

    public Fill2048 fill;

    private void OnEnable()
    {
        GameController2048.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameController2048.slide -= OnSlide;
    }

    private void OnSlide(string whatWasSent)
    {
        CellCheck();
        Debug.Log(whatWasSent);
        if (whatWasSent == "w")
        {
            if (up != null)
                return;
            Cell2048 currentCell = this;
            SlideUp(currentCell);
        }
        if (whatWasSent == "d")
        {
            if (right != null)
                return;
            Cell2048 currentCell = this;
            SlideRight(currentCell);
        }
        if (whatWasSent == "s")
        {
            if (down != null)
                return;
            Cell2048 currentCell = this;
            SlideDown(currentCell);
        }
        if (whatWasSent == "a")
        {
            if (left != null)
                return;
            Cell2048 currentCell = this;
            SlideLeft(currentCell);
        }
        GameController2048.ticker++;
        if (GameController2048.ticker == 3)
        {
            GameController2048.instance.SpawnFill();
        }
    }

    void SlideUp(Cell2048 currentCell)
    {
        Debug.Log(currentCell.gameObject);
        if (currentCell.down == null)
            return;
        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                Debug.Log("Loop");
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    Debug.Log("doubled");
                    nextCell.fill.Double();
                    //nextCell.fill.transform.parent = currentCell.transform;
                    nextCell.fill.transform.SetParent(currentCell.transform, true);
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.down.fill != nextCell.fill)
                {
                    Debug.Log("!doubled");
                    //nextCell.fill.transform.parent = currentCell.down.transform;
                    nextCell.fill.transform.SetParent(currentCell.down.transform, true);
                    currentCell.down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                Debug.Log("here");
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                //nextCell.fill.transform.parent = currentCell.transform;
                nextCell.fill.transform.SetParent(currentCell.transform, true);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);
                Debug.Log("Slide to Empty");
            }
        }
        if (currentCell.down == null)
            return;
        SlideUp(currentCell.down);
    }

    void SlideRight(Cell2048 currentCell)
    {
        Debug.Log(currentCell.gameObject);
        if (currentCell.left == null)
            return;
        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                Debug.Log("Loop");
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    Debug.Log("doubled");
                    nextCell.fill.Double();
                    //nextCell.fill.transform.parent = currentCell.transform;
                    nextCell.fill.transform.SetParent(currentCell.transform, true);
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.left.fill != nextCell.fill)
                {
                    Debug.Log("!doubled");
                    //nextCell.fill.transform.parent = currentCell.left.transform;
                    nextCell.fill.transform.SetParent(currentCell.left.transform, true);
                    currentCell.left.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                Debug.Log("here");
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                //nextCell.fill.transform.parent = currentCell.transform;
                nextCell.fill.transform.SetParent(currentCell.transform, true);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);
                Debug.Log("Slide to Empty");
            }
        }
        if (currentCell.left == null)
            return;
        SlideRight(currentCell.left);
    }

    void SlideDown(Cell2048 currentCell)
    {
        Debug.Log(currentCell.gameObject);
        if (currentCell.up == null)
            return;
        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                Debug.Log("Loop");
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    Debug.Log("doubled");
                    nextCell.fill.Double();
                    //nextCell.fill.transform.parent = currentCell.transform;
                    nextCell.fill.transform.SetParent(currentCell.transform, true);
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.up.fill != nextCell.fill)
                {
                    Debug.Log("!doubled");
                    //nextCell.fill.transform.parent = currentCell.up.transform;
                    nextCell.fill.transform.SetParent(currentCell.up.transform, true);
                    currentCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                Debug.Log("here");
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                //nextCell.fill.transform.parent = currentCell.transform;
                nextCell.fill.transform.SetParent(currentCell.transform, true);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);
                Debug.Log("Slide to Empty");
            }
        }
        if (currentCell.up == null)
            return;
        SlideDown(currentCell.up);
    }

    void SlideLeft(Cell2048 currentCell)
    {
        Debug.Log(currentCell.gameObject);
        if (currentCell.right == null)
            return;
        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                Debug.Log("Loop");
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    Debug.Log("doubled");
                    nextCell.fill.Double();
                    //nextCell.fill.transform.parent = currentCell.transform;
                    nextCell.fill.transform.SetParent(currentCell.transform, true);
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.right.fill != nextCell.fill)
                {
                    Debug.Log("!doubled");
                    //nextCell.fill.transform.parent = currentCell.right.transform;
                    nextCell.fill.transform.SetParent(currentCell.right.transform, true);
                    currentCell.right.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                Debug.Log("here");
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                //nextCell.fill.transform.parent = currentCell.transform;
                nextCell.fill.transform.SetParent(currentCell.transform, true);
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);
                Debug.Log("Slide to Empty");
            }
        }
        if (currentCell.right == null)
            return;
        SlideLeft(currentCell.right);
    }

    void CellCheck() 
    {
        if (fill == null)
            return;
        if (up != null)
        {
            if (up.fill == null)
                return;
            if (up.fill.value == fill.value)
                return;
        }

        if (right != null)
        {
            if (right.fill == null)
                return;
            if (right.fill.value == fill.value)
                return;
        }

        if (down != null)
        {
            if (down.fill == null)
                return;
            if (down.fill.value == fill.value)
                return;
        }

        if (left != null)
        {
            if (left.fill == null)
                return;
            if (left.fill.value == fill.value)
                return;
        }
        GameController2048.instance.GameOverCheck();
    }
}