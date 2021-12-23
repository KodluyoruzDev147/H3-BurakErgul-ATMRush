using System;
using _Game_.Scripts.Input;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game_.Scripts.Player
{
  public class Player : MovementController
  {
    [FoldoutGroup("Player Settings")] [SerializeField]
    private Transform playerPivot;

    private bool onFirstTouch = true;
    private bool playerCanMove = false;

    public override void Initialize()
    {
      InputManager.Instance.OnStartTouch += MoveStarted;
      InputManager.Instance.OnPerformingTouch += MovePerforming;
      InputManager.Instance.OnEndTouch += MoveReleased;
    }

    private void OnFirstTouch()
    {
      onFirstTouch = false;
      playerCanMove = true;
    }

    private void Update()
    {
      if (playerCanMove)
      {
        MoveForward(transform);
      }
    }

    private void MoveStarted(object sender, TouchEventArgs args)
    {
      if (onFirstTouch)
        OnFirstTouch();
      _touchEventArgs = args;
    }

    private void MovePerforming(object sender, TouchEventArgs args)
    {
      if (!playerCanMove) return;
      MoveHorizontal(args, playerPivot);
    }

    private void MoveReleased(object sender, TouchEventArgs args)
    {
    }
  }
}
