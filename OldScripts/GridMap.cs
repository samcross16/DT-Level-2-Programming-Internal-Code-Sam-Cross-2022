using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridMap {
    
    //Defining variables for width and height and the size of the grid cells, and a multidimensional (the comma) array for storing coordinate data.
    private int width;
    private int height;
    private float cellSize;

    private int[,] gridArray;
    

    //Grid constructor (method without a return type)
    public GridMap(int width, int height, float cellSize) {
        //Variables (see comment on line 7)
        this.width = width;
        this.height =  height;
        this.cellSize = cellSize;
        //Array (see comment on line 7)
        gridArray = new int[width, height];
        
        //This entire chunk below basically cycles through each grid cell, by checking the x position that its currently at, checking all y positions for that x position, then adding 1 and repeating unitl the end of the grid
        //REMEMBER: This whole situation is 0-indexed
        //Loop that cycles through each of the grid x positions (checks  current position, and adds one)
        for (int x = 0; x < gridArray.GetLength(0); x++) {
            //Loop inside the loop one line above that does the same thing but on the y axis
            for (int y = 0; y < gridArray.GetLength(0); y++) {
                //References code library that prints text on to the game world. Defines position in the game world as the position found in the function that starts on line 39. Then prints text on the position specified.
                UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y), 5, Color.white, TextAnchor.MiddleCenter);
                //The next two lines of code draw lines around each grid cell in the game world.
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
    }

    //Finds the game world position for the function on lines 31-34 by multiplying grid position  by the size of the grid cells.
    private  Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize;
    }
}