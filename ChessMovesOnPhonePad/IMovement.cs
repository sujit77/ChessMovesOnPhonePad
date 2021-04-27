using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public interface IMovement
    {
           int findNumbers(PadNumber start, int digits);
           //bool canMove(PadNumber from, PadNumber to);
           List<PadNumber> allowedMoves(PadNumber from);
           int countAllowedMoves(PadNumber from);
        
    }
}
