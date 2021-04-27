using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    class Program
    {
        static void Main(string[] args)
        {
            PadNumber[][] thePad = new PadNumber[4][];
            thePad[0] = new PadNumber[3];
            thePad[1] = new PadNumber[3];
            thePad[2] = new PadNumber[3];
            thePad[3] = new PadNumber[3];

            thePad[0][0] = new PadNumber("1", new Point(0, 0));
            thePad[0][1] = new PadNumber("2", new Point(1, 0));
            thePad[0][2] = new PadNumber("3", new Point(2, 0));
            thePad[1][0] = new PadNumber("4", new Point(0, 1));
            thePad[1][1] = new PadNumber("5", new Point(1, 1));
            thePad[1][2] = new PadNumber("6", new Point(2, 1));
            thePad[2][0] = new PadNumber("7", new Point(0, 2));
            thePad[2][1] = new PadNumber("8", new Point(1, 2));
            thePad[2][2] = new PadNumber("9", new Point(2, 2));
            thePad[3][0] = new PadNumber("*", new Point(0, 3));
            thePad[3][1] = new PadNumber("0", new Point(1, 3));
            thePad[3][2] = new PadNumber("#", new Point(2, 3));

            PhoneChess phoneChess = new PhoneChess(thePad, "Knight");
            Console.WriteLine(phoneChess.findPossibleDigits(thePad[0][1], 5));
            Console.ReadKey();
        }
    }
}
