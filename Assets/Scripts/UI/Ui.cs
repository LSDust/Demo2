using Godot;
using System;
using System.Reflection;

public partial class Ui : CanvasLayer
{
    public int mode = 0;

    private Container joystick6;

    public override void _Ready()
    {
        this.joystick6 = this.GetNode<Joystick>("./Joystick6");
    }

    private void round1()
    {

    }
}
