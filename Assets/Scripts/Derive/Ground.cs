using Godot;
using System;
using Library;

public partial class Ground : Node3D
{
    [Export]
    PackedScene TilePrefab;

    public override void _Ready()
    {
        this.floor();
    }

    private void floor()
    {
        int xSize = 4, zSize = 4;
        for (int x = -3; x < xSize; x++)
        {
            for (int z = -3; z < zSize; z++)
            {
                Tile TileInstance = this.TilePrefab.Instantiate<Tile>();
                this.AddChild(TileInstance);
                TileInstance.Position = CoordinateLib.Vector2ToVector3(CoordinateLib.Maping60To90(x, z), -0.2f);
            }
        }
    }
}
