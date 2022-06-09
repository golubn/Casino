using System;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public class Line
{

    public delegate void ShowFifureInSqure(int x, int figure);
    public const int SIZE = 3;
    public const int FIGURES = 6;
    System.Random rnd = new System.Random();
    int[] map;
    ShowFifureInSqure figureOnSqure;

    public Line(ShowFifureInSqure figureOnSqure)
    {
        this.figureOnSqure = figureOnSqure;
        map = new int[SIZE];
    }
    public void Start()
    {
        int x = rnd.Next(0, 2);
        int y = rnd.Next(1, 6);
        SetFigure(x, y);

    }
    public void Click(int x)
    {
        figureOnSqure(1, 1 % FIGURES);
    }
    private bool OnLine(int x)
    {
        return x >= 0 && x < SIZE;
    }

    private int GetLine(int x)
    {
        if (!OnLine(x)) return 0;
        return map[x];
    }

    public int WinOrNot(int x0, int sx)
    {
        int figures = map[x0];
        int count = 0;
        for (int x = x0; GetLine(x) == figures; x += sx)

            count++;

        if (count <= 1)

            return 0;


        return count;
    }

    private void SetFigure(int x, int figure)
    {
        map[x] = figure;
        figureOnSqure(x, figure);
    }
}


