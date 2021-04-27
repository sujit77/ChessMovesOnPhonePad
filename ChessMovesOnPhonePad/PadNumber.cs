using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovesOnPhonePad
{
    public class PadNumber
    {

        private String number = "";
        private Point coordinates = null;

        public PadNumber(String number, Point coordinates)
        {
            if (number != null && string.IsNullOrEmpty(number) == false)
                this.number = number;
            else
                throw new  ArgumentException ("Input cannot be null or empty.");

            if (coordinates == null || coordinates.x < 0 || coordinates.y < 0)
                throw new ArgumentException();
            else
                this.coordinates = coordinates;

        }

        public string getNumber()
        {
            return this.number;
        }
        public int getNumberAsNumber()
        {
            return int.Parse(this.number);
        }

        public Point getCoordinates()
        {
            return this.coordinates;
        }
        public int getX()
        {
            return this.coordinates.x;
        }
        public int getY()
        {
            return this.coordinates.y;
        }

    }
}
