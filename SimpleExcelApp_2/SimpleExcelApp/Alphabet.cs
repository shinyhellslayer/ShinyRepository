using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExcelApp.Model;

namespace SimpleExcelApp
{
    public class Alphabet
    {
        public enum AlphabetEnum
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z
        }

        //public static int[] AlphabetLetter(MathExpression mathExpression, string cell, int GridRowIndex, int location)
        //{
        //    int[] alphabetLocation = new int[2]; 
        //    Alphabet.AlphabetEnum rowIndex = (Alphabet.AlphabetEnum)GridRowIndex;
        //    string[] names = Enum.GetNames(rowIndex.GetType());

        //    //Check if a cell value is used with the enum provided
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        if (names[i] == cell.Substring(mathExpression.mathExpressionSymbol + 1, mathExpression.mathExpressionSymbol + 1))
        //        {
        //            alphabetLocation[location] = i;
        //            break;
        //        }
        //        else
        //        {
        //            alphabetLocation[location] = -1;
        //        }
        //    }
        //    return alphabetLocation;
        //}
    }
}
