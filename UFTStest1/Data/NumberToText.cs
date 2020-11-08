using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UFTStest1.Models;

namespace UFTStest1.Data
{
    public class NumberToText : INumberText
    {
        /// <summary>
        /// Take a decimal number and return the text
        /// </summary>
        /// <param name="aNumber"></param>
        /// <returns>NumberText</returns>
        public NumberText GetTextFromANumber(string aNumber)
        {
            var returnNumberText = new NumberText();
            try
            {               
                // I dont want to call my backend if I cannot procede my translation or if the translation is easy e.g. 0
                if (!string.IsNullOrWhiteSpace(aNumber))
                {
                    aNumber = string.Format("{0:0.##}", Convert.ToDouble(aNumber)); // max. two decimal places

                    if (Convert.ToDouble(aNumber) < 0)
                    {
                        returnNumberText.inputNumber = aNumber;
                        returnNumberText.outputNumber = "The number is negative".ToUpper();
                    }
                    if (aNumber == "0")
                    {                       
                        returnNumberText.inputNumber = aNumber;
                        returnNumberText.outputNumber = "Zero Dollar and Zero cent".ToUpper();
                    }
                    else
                    {
                        returnNumberText = ConvertToNumberToText(aNumber);
                    }
                    
                }
                else
                {
                    returnNumberText.inputNumber = aNumber;
                    returnNumberText.outputNumber = "The input Is Null Or White Space".ToUpper();
                }
               
            }
            catch (Exception ex)
            {
                throw ex; //Use the 
            }
            return returnNumberText;
        }
        /// <summary>
        /// I deal with numbers from 1 to 9
        /// </summary>
        /// <param name="myNumber"></param>
        /// <returns>number</returns>
        private static string UnderNumberTen(string myNumber)
        {
            int _myNumber = Convert.ToInt32(myNumber);
            string myNumberText = string.Empty;
            try
            {
                switch (_myNumber)
                {

                    case 1:
                        myNumberText = "One";
                        break;
                    case 2:
                        myNumberText = "Two";
                        break;
                    case 3:
                        myNumberText = "Three";
                        break;
                    case 4:
                        myNumberText = "Four";
                        break;
                    case 5:
                        myNumberText = "Five";
                        break;
                    case 6:
                        myNumberText = "Six";
                        break;
                    case 7:
                        myNumberText = "Seven";
                        break;
                    case 8:
                        myNumberText = "Eight";
                        break;
                    case 9:
                        myNumberText = "Nine";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return myNumberText;
        }
        /// <summary>
        /// I return the text for number > 9
        /// </summary>
        /// <param name="myNumber"></param>
        /// <returns>the number text</returns>
        private static string OverNumberNine(string myNumber)
        {
            int _myNumber = Convert.ToInt32(myNumber);
            string myNumberText = string.Empty;
            try
            {
                switch (_myNumber)
                {
                    case 10:
                        myNumberText = "Ten";
                        break;
                    case 11:
                        myNumberText = "Eleven";
                        break;
                    case 12:
                        myNumberText = "Twelve";
                        break;
                    case 13:
                        myNumberText = "Thirteen";
                        break;
                    case 14:
                        myNumberText = "Fourteen";
                        break;
                    case 15:
                        myNumberText = "Fifteen";
                        break;
                    case 16:
                        myNumberText = "Sixteen";
                        break;
                    case 17:
                        myNumberText = "Seventeen";
                        break;
                    case 18:
                        myNumberText = "Eighteen";
                        break;
                    case 19:
                        myNumberText = "Nineteen";
                        break;
                    case 20:
                        myNumberText = "Twenty";
                        break;
                    case 30:
                        myNumberText = "Thirty";
                        break;
                    case 40:
                        myNumberText = "Fourty";
                        break;
                    case 50:
                        myNumberText = "Fifty";
                        break;
                    case 60:
                        myNumberText = "Sixty";
                        break;
                    case 70:
                        myNumberText = "Seventy";
                        break;
                    case 80:
                        myNumberText = "Eighty";
                        break;
                    case 90:
                        myNumberText = "Ninety";
                        break;
                    default:
                        if (_myNumber > 0)
                        {
                            myNumberText = OverNumberNine(myNumber.Substring(0, 1) + "0") + " " + UnderNumberTen(myNumber.Substring(1));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return myNumberText;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
        private static string ConvertWholeNumberToText(string inputNumber)
        {
            string returnText = string.Empty;
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(inputNumber));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = inputNumber.StartsWith("0");

                    int numDigits = inputNumber.Length;
                    int pos = 0;//store digit grouping    
                    string place = string.Empty;//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://digit range 
                            returnText = UnderNumberTen(inputNumber);
                            isDone = true;
                            break;
                        case 2://over 9 range    
                            returnText = OverNumberNine(inputNumber);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;                                                       
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (inputNumber.Substring(0, pos) != "0" && inputNumber.Substring(pos) != "0")
                        {
                            try
                            {
                                returnText = ConvertWholeNumberToText(inputNumber.Substring(0, pos)) + place + ConvertWholeNumberToText(inputNumber.Substring(pos));
                            }
                            catch (Exception ex)
                            {
                                throw (ex);
                            }
                        }
                        else
                        {
                            returnText = ConvertWholeNumberToText(inputNumber.Substring(0, pos)) + ConvertWholeNumberToText(inputNumber.Substring(pos));
                        }

                    }
                    //ignore digit grouping names    
                    if (returnText.Trim().Equals(place.Trim())) returnText = "";
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return returnText.Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numb"></param>
        /// <returns></returns>
        private static NumberText ConvertToNumberToText(string numb)
        {          
            string returnText = string.Empty, wholeNumber = numb, points = string.Empty, andText = string.Empty, decimalText = string.Empty;
            string centText = string.Empty;
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNumber = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andText = "and ";// just to separate whole numbers from points/cents    
                        centText = "Cents ";//Cents    
                        decimalText = ConvertWholeNumberToText(points);
                    }
                }
                else
                {
                    andText = "and Zero";
                    centText = "Cent";
                }


                if (!string.IsNullOrEmpty(decimalText))
                {
                    if (Convert.ToInt32(points) == 1)
                    {
                        centText = centText.Replace("Cents", "Cent");
                    }
                }

                string _convertWholeNumber = ConvertWholeNumberToText(wholeNumber).Trim();
                if (Convert.ToInt32(wholeNumber) > 1)
                {
                    _convertWholeNumber = _convertWholeNumber + " Dollars";
                }
                else
                {
                    _convertWholeNumber = _convertWholeNumber + " Dollar";
                }

                returnText = String.Format("{0} {1}{2} {3}", _convertWholeNumber, andText, decimalText, centText);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return new NumberText { inputNumber= numb, outputNumber = returnText.ToUpper() };
        }

    }
}
