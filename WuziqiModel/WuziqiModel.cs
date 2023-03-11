using Contracts.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wuziqi
{
    public enum Stone
    {
        Empty,
        Black,
        White
    }
    public class WuziqiMove : MoveBase
    {
        public Stone Stone { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public WuziqiMove(Stone stone, int x, int y)
        {
            Stone = stone;
            X = x;
            Y = y;
        }

    }

    public class WuziqiModel : GameModelBase
    {
        public Stone[,] Chessboard { get; set; } = new Stone[15, 15];
        public Stone WhoseTurn { get; set; }
        public Stone WhoIsAI { get; set; }
        public static Stone EnemyOf(Stone stone)
        {
            if (stone == Stone.Black)
            {
                return Stone.White;
            }
            else if (stone == Stone.White)
            {
                return Stone.Black;
            }
            return Stone.Empty;
        }
        public override bool ValidMove(MoveBase move)
        {
            WuziqiMove wuziqiMove = (WuziqiMove)move;
            if (Chessboard[wuziqiMove.Y, wuziqiMove.X] == Stone.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void DoMove(MoveBase move)
        {
            WuziqiMove wuziqiMove = (WuziqiMove)move;
            Chessboard[wuziqiMove.Y, wuziqiMove.X] = wuziqiMove.Stone;
            WhoseTurn = WuziqiModel.EnemyOf(WhoseTurn);
        }
        public override GameModelBase Copy()
        {
            WuziqiModel model = new WuziqiModel();
            model.WhoseTurn = WhoseTurn;
            model.WhoIsAI = WhoIsAI;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    model.Chessboard[i, j] = Chessboard[i, j];
                }
            }
            return model;
        }
        public WuziqiModel()
        {
            WhoseTurn = Stone.Black;
        }
    }
}