using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public class PieceFactory
    {
        public ChessPiece getPiece(String piece, PadNumber[][] thePad)
        {
            if (thePad == null || thePad.Length == 0 || thePad[0].Length == 0)
                throw new ArgumentException("Invalid pad");
            if (piece == null)
                throw new ArgumentException("Invalid chess piece");

            if (piece.Equals("Knight",StringComparison.OrdinalIgnoreCase))
                return new Knight("Knight", thePad);
            else
                return null;
        }
    }
}
