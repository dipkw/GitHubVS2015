using System;
using System.Collections.Generic;
using System.Text;

namespace dipndipInventory.Helpers
{
    public class ToWord
    {
        public static string NumberToWords(Decimal total)
        {
            string Sr = IntegerToWords((long)total) + " Riyals";
            string Hl = IntegerToWords((long)((total - (long)total) * 100)) + "  Halala";
            if (Hl != "zero  Halala")
                Sr = Sr + " and " + Hl;
            Sr = Sr + " Only";
            return Sr;
        }

        public static string NumberToWordsRupee(Decimal total)
        {
            string Rs = IntegerToWords((long)total) + " Rupees";
            string Ps = IntegerToWords((long)((total - (long)total) * 100)) + "  Paise";
            if (Ps != "zero  Paise")
                Rs = Rs + " and " + Ps;
            Rs = Rs + " Only";
            return Rs;
        }
        private  static string IntegerToWords(long inputNum)
        {
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;

            string retval = "";
            string x = "";
            string[] ones ={
                    "",
                    "One",
                    "Two",
                    "Three",
                    "Four",
                    "Five",
                    "Six",
                    "Seven",
                    "Eight",
                    "Nine",
                    "Ten",
                    "Eleven",
                    "Twelve",
                    "Thirteen",
                    "Fourteen",
                    "Fifteen",
                    "Sixteen",
                    "Seventeen",
                    "Eighteen",
                    "Nineteen"
                  };
            string[] tens ={
                    "zero",
                    "Ten",
                    "Twenty",
                    "Thirty",
                    "Forty",
                    "Fifty",
                    "Sixty",
                    "Seventy",
                    "Eighty",
                    "Ninety"
                  };
            string[] thou ={
                    "",
                    "Thousand",
                    "Million",
                    "Billion",
                    "Trillion",
                    "Quadrillion",
                    "Quintillion"
                  };

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }

            if (inputNum == 0)
                return ("zero");

            string s = inputNum.ToString();

            while (s.Length > 0)
            {
                // Get the three rightmost characters
                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                // Separate the three digits
                threeDigits = int.Parse(x);
                lasttwo = threeDigits % 100;
                dig1 = threeDigits / 100;
                dig2 = lasttwo / 10;
                dig3 = (threeDigits % 10);

                // append a "thousand" where appropriate
                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {
                    retval = thou[level] + " " + retval;
                    retval = retval.Trim();
                }

                // check that the last two digits is not a zero
                if (lasttwo > 0)
                {
                    if (lasttwo < 20) // if less than 20, use "ones" only
                        retval = ones[lasttwo] + " " + retval;
                    else // otherwise, use both "tens" and "ones" array
                        retval = tens[dig2] + " " + ones[dig3] + " " + retval;
                }

                // if a hundreds part is there, translate it
                if (dig1 > 0)
                    retval = ones[dig1] + " Hundred " + retval;

                s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                level++;
            }

            while (retval.IndexOf("  ") > 0)
                retval = retval.Replace("  ", " ");

            retval = retval.Trim();

            if (isNegative)
                retval = "negative " + retval;

            return (retval);
        }

    }
}
