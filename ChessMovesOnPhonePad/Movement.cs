using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public abstract class Movement
    {
            public abstract int findNumbers(PadNumber start, int digits);
            public abstract bool canMove(PadNumber from, PadNumber to);
            public abstract List<PadNumber> allowedMoves(PadNumber from);
            public abstract int countAllowedMoves(PadNumber from);
        
    }
}
