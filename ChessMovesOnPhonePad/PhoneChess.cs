using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public sealed class PhoneChess
    {
        private ChessPiece thePiece = null;
        private PieceFactory factory = null;

        public ChessPiece ThePiece()
        {
            return this.thePiece;
        }

        public PhoneChess(PadNumber[][] thePad, String piece)
        {
            if (thePad == null || thePad.Length == 0 || thePad[0].Length == 0)
                throw new ArgumentException("Invalid pad");
            if (piece == null)
                throw new ArgumentException("Invalid chess piece");

            this.factory = new PieceFactory();
            this.thePiece = this.factory.getPiece(piece, thePad);
        }

        public int findPossibleDigits(PadNumber start, int digits)
        {
            if (digits <= 0)
                throw new ArgumentException("Digits cannot be less than or equal to zero");

            return thePiece.findNumbers(start, digits);
        }

        //public bool isValidMove(PadNumber from, PadNumber to)
        //{
        //    return this.thePiece.canMove(from, to);
        //}

    }
}
