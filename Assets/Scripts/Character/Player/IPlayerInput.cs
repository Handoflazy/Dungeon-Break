
using System;
using System.Numerics;

public interface IPlayerInput
{
    public delegate void OnAttack();
    public delegate void OnMovement(Vector2 input);
    event OnAttack onAttack;
}
