using Godot;
using System;

public partial class SkillA : Button
{
    private Player player;
    private Joystick joystick;

    public override void _Ready()
    {
        this.player = this.GetNode<Player>("../../Player");
        this.joystick = this.GetNode<Joystick>("../Joystick6");
    }
    public override void _Pressed()
    {
        this.player.GetNode<MovementTask>("./MovementTask").startMove(this.joystick.direction_60,1);
    }
}
