using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public sealed class Knight : ChessPiece, IMovement
    {

        /**Knight movements
         * One horizontal, followed by two vertical
         * Or 
         * One vertical, followed by two horizontal
         * @param name
         */

    public Knight(String name, PadNumber[][] thePad)
    {
        if (name == null || string.IsNullOrEmpty(name) == true)
            throw new ArgumentException("Name cannot be null or empty");

        this.name = name;
        this.thePad = thePad;
        this.moves = new Dictionary<PadNumber, List<PadNumber>>();
    }


    private new int fullNumbers;

    
   public override int findNumbers(PadNumber start, int digits)
    {
        if (start == null || "*".Equals(start.getNumber()) || "#".Equals(start.getNumber())) { throw new ArgumentException("Invalid start point"); }
        if (start.getNumberAsNumber() == 5) { return 0; } //Consider Adding an 'allowSpecialChars' condition
        if (digits == 1) { return 1; };

        //Initialise the jagged array with -1 for each cell
        this.movesFrom = new int[thePad.Length * thePad[0].Length];
        for (int i = 0; i < this.movesFrom.Length; i++)
            this.movesFrom[i] = -1;

        fullNumbers = 0;
        findNumbers(start, digits, 1);
        return fullNumbers;
    }

    private void findNumbers(PadNumber start, int digits, int currentDigits)
    {
        //Base condition
        if (currentDigits == digits)
        {
            //Reset
            currentDigits = 1;
            fullNumbers++;
            return;
        }
        if (!this.moves.ContainsKey(start))
            allowedMoves(start);

        List<PadNumber> options = this.moves[start];
        if (options != null)
        {
            currentDigits++; //More digits to get
            foreach (PadNumber option in options)
                findNumbers(option, digits, currentDigits);
        }
    }

    
//public override bool canMove(PadNumber from, PadNumber to)
//    {
//        //Is the moves list available?
//        if (!this.moves.ContainsKey(from))
//        {
//            //No? Process.
//            allowedMoves(from);
//        }
//        if (this.moves[from] != null)
//        {
//            foreach (PadNumber option in this.moves[from])
//            {
//                if (option.getNumber().Equals(to.getNumber()))
//                    return true;
//            }
//        }
//        return false;

//    }

    /***
     * Overriden method that defines each Piece's movement restrictions.
     */
    
public override List<PadNumber> allowedMoves(PadNumber from)
    {
        //First encounter
        if (this.moves == null)
            this.moves = new Dictionary<PadNumber, List<PadNumber>>();


        if (this.moves.ContainsKey(from))
            return this.moves[from];
        else
        {
            List<PadNumber> found = new List<PadNumber>();
            int row = from.getY();//rows
            int col = from.getX();//columns

            //Cases:
            //1. One horizontal move each way followed by two vertical moves each way
            if (col - 1 >= 0 && row - 2 >= 0)//valid
            {
                if (thePad[row - 2][col - 1].getNumber().Equals("*") == false &&
                        thePad[row - 2][col - 1].getNumber().Equals("#") == false)
                {
                    found.Add(thePad[row - 2][col - 1]);
                    this.movesFrom[from.getNumberAsNumber()] = this.movesFrom[from.getNumberAsNumber()] + 1;
                }

            }
            if (col - 1 >= 0 && row + 2 < thePad.Length)//valid
            {
                if (thePad[row + 2][col - 1].getNumber().Equals("*") == false &&
                        thePad[row + 2][col - 1].getNumber().Equals("#") == false)
                {
                    found.Add(thePad[row + 2][col - 1]);
                    this.movesFrom[from.getNumberAsNumber()] = this.movesFrom[from.getNumberAsNumber()] + 1;
                }
            }
            if (col + 1 < thePad[0].Length && row + 2 < thePad.Length)//valid
            {
                if (thePad[row + 2][col + 1].getNumber().Equals("*") == false &&
                        thePad[row + 2][col + 1].getNumber().Equals("#") == false)
                {
                    found.Add(thePad[row + 2][col + 1]);
                    this.movesFrom[from.getNumberAsNumber()] = this.movesFrom[from.getNumberAsNumber()] + 1;
                }
            }
            if (col + 1 < thePad[0].Length && row - 2 >= 0)//valid
            {
                if (thePad[row - 2][col + 1].getNumber().Equals("*") == false &&
                        thePad[row - 2][col + 1].getNumber().Equals("#") == false)
                    found.Add(thePad[row - 2][col + 1]);
            }
            //Case 2. One vertical move each way follow by two horizontal moves each way

            if (col - 2 >= 0 && row - 1 >= 0)
            {
                if (thePad[row - 1][col - 2].getNumber().Equals("*") == false &&
                        thePad[row - 1][col - 2].getNumber().Equals("#") == false)
                    found.Add(thePad[row - 1][col - 2]);
            }
            if (col - 2 >= 0 && row + 1 < thePad.Length)
            {
                if (thePad[row + 1][col - 2].getNumber().Equals("*") == false &&
                        thePad[row + 1][col - 2].getNumber().Equals("#") == false)
                    found.Add(thePad[row + 1][col - 2]);
            }

            if (col + 2 < thePad[0].Length && row - 1 >= 0)
            {
                if (thePad[row - 1][col + 2].getNumber().Equals("*") == false &&
                        thePad[row - 1][col + 2].getNumber().Equals("#") == false)
                    found.Add(thePad[row - 1][col + 2]);
            }
            if (col + 2 < thePad[0].Length && row + 1 < thePad.Length)
            {
                if (thePad[row + 1][col + 2].getNumber().Equals("*") == false &&
                        thePad[row + 1][col + 2].getNumber().Equals("#") == false)
                    found.Add(thePad[row + 1][col + 2]);
            }

            if (found.Count() > 0)
            {
                this.moves.Add(from, found);
                this.movesFrom[from.getNumberAsNumber()] = found.Count();
            }
            else
            {
                this.moves.Add(from, null); //for example the Knight cannot move from 5 to anywhere
                this.movesFrom[from.getNumberAsNumber()] = 0;
            }
        }

        return this.moves[from];


    }

    
public override int countAllowedMoves(PadNumber from)
    {
        int start = from.getNumberAsNumber();

        if (movesFrom[start] != -1)
            return movesFrom[start];
        else
        {
            movesFrom[start] = allowedMoves(from).Count();
        }
        return movesFrom[start];
    }

   
public override string ToString()
    {
        return this.name;
    }

}
}
