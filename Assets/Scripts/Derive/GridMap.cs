using Godot;
using System;

public partial class GridMap : Godot.GridMap
{
    public override void _Ready()
    {
        // Math.Acos(Math.Sqrt(6)/3);
        this.Rotation = new Vector3(-0.6154797086703875f, -Mathf.Pi / 3, Mathf.Pi / 4);
        this.floor();
        // GD.Print(Math.Acos(Math.Sqrt(3) / 3) * 180 / Math.PI);
        // 54.735610317245346
        // GD.Print(Lib.Sqrt2 / 2);
        // GD.Print(Lib.Sqrt2 * Lib.Sqrt3 / 2);
    }
    private void floor()
    {
        int xSize = 5, zSize = 5;
        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                int y = 0 - x - z;
                this.SetCellItem(new Vector3I(x, y, z), 0);
            }
        }
    }
}
