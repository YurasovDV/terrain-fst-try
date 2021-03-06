﻿using Common;
using Common.Input;
using OpenTK;
using SimpleShooter.Core.Events;
using SimpleShooter.Core.Weapons;

namespace SimpleShooter.PlayerControl
{
    class HumanPlayer : Player
    {

        public HumanPlayer(SimpleModel model, Vector3 position, Vector3 target, float mass) : base(model, mass)
        {
            Position = position;
            Target = target;
            Weapon = new BaseWeapon(100);
        }

        public override void Handle(InputSignal signal)
        {
            switch (signal)
            {
                case InputSignal.FORWARD:
                    StepXZ(StepForward);
                    break;
                case InputSignal.BACK:
                    StepXZ(StepBack);
                    break;
                case InputSignal.RIGHT:
                    StepXZ(StepRight);
                    break;
                case InputSignal.LEFT:
                    StepXZ(StepLeft);
                    break;
                case InputSignal.SPACE:
                    TryJump();
                    break;
                case InputSignal.MOUSE_CLICK:
                    TryShoot();
                    break;
                default:
                    break;
            }
        }

        protected void TryJump()
        {
            Acceleration += new Vector3(0, 0.05f, 0);
        }

        protected void TryShoot()
        {
            OnShot(new ShotEventArgs(Position));
        }
    }
}
