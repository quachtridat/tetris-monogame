using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SimpleTetris.Core2.Physics;

namespace SimpleTetris.Core2.TetrisComponents.Mechanics {
    public class MinoRotate : IRotateMechanics {

        public RotatingDirections LastDirection { get; set; } = RotatingDirections.None;

        public bool DirectionChanged { get; protected set; } = false;

        public void HandleEvent(object sender, RotateEventArgs e) {
            if (sender is IRotatable) HandleEvent(sender as IRotatable, e);
        }
        public void HandleEvent(IRotatable sender, RotateEventArgs e) {
            if (sender == null || e == null) return;

            if (e.Direction != LastDirection) {
                DirectionChanged = true;
                LastDirection = e.Direction;
            } else DirectionChanged = false;

            if (e.Direction == RotatingDirections.None) return;

            if (sender is Polyomino) {
                Polyomino polyomino = sender as Polyomino;

                if (DirectionChanged) {
                    foreach (Mino mino in polyomino.Minoes) {
                        Vector2 vector = mino.Position - polyomino.OriginMino.Position;
                        float r = 0;
                        switch (e.Direction) {
                            case RotatingDirections.Clockwise:
                                r = +MathHelper.PiOver2;
                                break;
                            case RotatingDirections.Counterclockwise:
                                r = -MathHelper.PiOver2;
                                break;
                            default:
                                break;
                        }
                        var x = MathHelper.Clamp(Convert.ToSingle(vector.X * Math.Cos(r) - vector.Y * Math.Sin(r)), float.MinValue, float.MaxValue);
                        var y = MathHelper.Clamp(Convert.ToSingle(vector.X * Math.Sin(r) + vector.Y * Math.Cos(r)), float.MinValue, float.MaxValue);
                        mino.Position = polyomino.OriginMino.Position + new Vector2(x, y);
                    }
                }
            }
        }
    }
}
