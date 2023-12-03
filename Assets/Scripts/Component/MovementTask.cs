using Godot;
using Library;
using System;

public partial class MovementTask : Node
{
    [Export]
    public int speed = 1;

    private Node3D motion物体实例; 
    private bool task状态 = false;
    private Vector3 task位移方向;
    private float task剩余路程;
    //private stopDelegate stop回调委托;

    public override void _Ready()
    {
        this.motion物体实例 = this.GetParent<Node3D>();
    }

    public override void _Process(double delta)
    {
        if (!this.task状态)
        {
            return;
        }
        else
        {
            float tick位移 = (float)delta * this.speed;
            if (this.task剩余路程 < tick位移)
            {
                this.motion物体实例.Position += this.task位移方向 * task剩余路程;

                //CharacterBody3D a = new CharacterBody3D();
                //a.MoveAndSlide();

                this.stopTask();
                return;
            }
            this.motion物体实例.Position += this.task位移方向 * tick位移;
            this.task剩余路程 -= tick位移;
        }
    }

    public bool startMove(Vector3I target方向_60, int target距离_60)
    {
        if (this.task状态 || target方向_60 == Vector3I.Zero)
        {
            return false;
        }
        else
        {
            this.task状态 = true;
            this.task位移方向 = CoordinateLib.Vector2ToVector3(CoordinateLib.Maping60To90(target方向_60),0);
            this.task剩余路程 = target距离_60;
            return true;
        }
    }
    public bool startMove(Vector3I target方向_60, int target距离_60,Func<int,int> a) 
    {
        if(!startMove(target方向_60, target距离_60))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void stopTask()
    {
        this.task状态 = false;
        this.task位移方向 = Vector3I.Zero;
        this.task剩余路程 = 0;
        //if (this.stop回调委托 is not null)
        //{
        //    this.stop回调委托(98989897);
        //}
    }
}
