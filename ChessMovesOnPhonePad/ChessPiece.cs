using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public abstract class ChessPiece : IMovement
    {

        protected String name = "";
        protected Dictionary<PadNumber, List<PadNumber>> moves = null;
        protected int fullNumbers = 0;
        protected int[] movesFrom = null;
        protected PadNumber[][] thePad = null;

        public abstract List<PadNumber> allowedMoves(PadNumber from);
        //public abstract bool canMove(PadNumber from, PadNumber to);
        public abstract int countAllowedMoves(PadNumber from);
        public abstract int findNumbers(PadNumber start, int digits);
    }
}
