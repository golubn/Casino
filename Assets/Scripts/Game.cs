using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    
    Button[] squre;
    RawImage[] cells;
    Image[] images;
    Line line;
    
    System.Random rnd = new System.Random();
    

    public void Start()
    {
        //line = new Line(ShowFifureInSqure);
        //UnitSqure();
        //UnitImage();
        //line.Start();
    }
    public void ShowFifureInSqure(int x, int figure)
    {
        squre[x].GetComponent<Image>().sprite = images[figure].sprite;
    }

    public int[] SetFigure()
    {
        int[] figureMass = new int[3];
        int y = rnd.Next(1, 6);
        int x = rnd.Next(1, 6);
        int z = rnd.Next(1, 6);
        figureMass[0] = x; figureMass[1] = y; figureMass[2] = z;
        
        return figureMass;
    }


    public void Click()
    {
        line = new Line(ShowFifureInSqure);
        UnitSqure();
        UnitImage();
        line.Start();
         
        int[] vs = SetFigure();

        ShowFifureInSqure(0, vs[0]);
        ShowFifureInSqure(1, vs[1]);
        ShowFifureInSqure(2, vs[2]);
        //balance.Win(vs[0], vs[1], vs[2]);
        Balance.Win(1, 1, 2);
        Debug.Log("clicked");
        Debug.Log($"{vs[0]}   {vs[1]}   {vs[2]}");

    }

    private void UnitImage()
    {
        images = new Image[6];
        for (int i = 1; i < 6; i++)
        {
            images[i] = GameObject.Find($"Image ({i})").GetComponent<Image>();

        }
    }
    private void UnitSqure()
    {
        squre = new Button[Line.SIZE];
        for (int i = 0; i < Line.SIZE; i++)
        {
            squre[i] =
               GameObject.Find($"Button ({i})").GetComponent<Button>();
        }
    }
}
