using System.Collections.Generic;
using UnityEngine;

namespace PositionsGenerator
{
    public class PositionsGenerator
    {
        public List<Vector3> Get(int rows, int columns, float spacing, Vector3 scale)
        {
            Vector3 screenCenter = Camera.main.ScreenToWorldPoint
                (new Vector3(Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane));

            List<Vector3> positions = new List<Vector3>();
            var gridWidth = columns * (scale.x + spacing) - spacing;
            var gridHeight = rows * (scale.y + spacing) - spacing;

            var startX = screenCenter.x - gridWidth / 2f + scale.x / 2f;
            var startY = screenCenter.y - gridHeight / 2f + scale.y / 2f;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var posX = startX + col * (scale.x + spacing);
                    var posY = startY + row * (scale.y + spacing);
                    positions.Add(new Vector3(posX, posY, 0));
                }
            }

            return positions;
        }
    }
}