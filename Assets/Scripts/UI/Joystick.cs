using Godot;
using System;
using System.Diagnostics;

public partial class Joystick : CenterContainer//准备做单例
{
    public Vector3I direction_60 { get; private set; }

    private int uiMode;
    private bool touchStatus = false;
    private Control control = null;
    private Sprite2D point = null;

    public override void _Ready()
    {
        this.uiMode = this.GetNode<Ui>("../").mode;
        this.control = this.GetChild<Control>(0);
        this.point = this.GetNode<Sprite2D>("./Control/Point");
    }
    public override void _GuiInput(InputEvent @event)
    {
        this.status控制();
        if (this.touchStatus) { this.work(this.angleLock()); }
        else { this.point.Position = Vector2.Zero; }
    }

    private void status控制()
    {
        if (Godot.Input.IsActionJustPressed("鼠标左键"))
        {
            this.touchStatus = true;
        }
        else if (Godot.Input.IsActionJustReleased("鼠标左键"))
        {
            this.touchStatus = false;
        }
    }

    /// <summary>
    /// 0：左，1：左上，2：右上，3：右边，4：右下，5：左下
    /// </summary>
    /// <returns></returns>
    private int? angleLock()
    {
        Vector2 direction_90 = this.GetViewport().GetMousePosition() - this.Position - this.control.Position;
        this.point.Position = Math.Min(100, direction_90.Length()) * direction_90.Normalized();
        if (direction_90.Length() >= 100)
        {
            int angle = (int)Math.Ceiling(direction_90.Angle() * 3f / Mathf.Pi + 2.5f);
            // Vector2 direction = Vector2.FromAngle(angle * Mathf.Pi / 3f - Mathf.Pi);
            angle = angle == 6 ? 0 : angle;
            return angle;
        }
        else { return null; }
    }

    private void work(int? angle)
    {
        if (angle is null) { return; }
        switch (angle)
        {
            case 0: this.direction_60 = new Vector3I(-1, 0, 1); break;
            case 1: this.direction_60 = new Vector3I(-1, 0, 0); break;
            case 2: this.direction_60 = new Vector3I(0, 0, -1); break;
            case 3: this.direction_60 = new Vector3I(1, 0, -1); break;
            case 4: this.direction_60 = new Vector3I(1, 0, 0); break;
            case 5: this.direction_60 = new Vector3I(0, 0, 1); break;
            default: GD.Print("虚拟摇杆方向异常"); break;
        }
    }

    public void reset()
    {
        this.direction_60 = Vector3I.Zero;
    }
}
