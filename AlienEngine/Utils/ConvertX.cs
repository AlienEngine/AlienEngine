using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AlienEngine.Core.Utils
{
    public static class ConvertX
    {
        private static string ReplaceSplitters(string prmValue)
        {
            prmValue = prmValue.Replace(';', ',');
            prmValue = prmValue.Replace(':', ',');
            prmValue = prmValue.Replace('.', ',');
            prmValue = prmValue.Replace('-', ',');
            prmValue = prmValue.Replace('_', ',');

            return prmValue;
        }

        private static string PreProcess(string prmValue, string prmPreProcess)
        {
            prmPreProcess = ReplaceSplitters(prmPreProcess);
            string[] strPreProcessValues = prmPreProcess.Split(',');

            for (int Counter = 0; Counter < strPreProcessValues.Length; Counter++)
            {
                string strPreProcessValue = strPreProcessValues[Counter].Trim().ToLower();

                if (!String.IsNullOrEmpty(strPreProcessValue))
                {
                    if (strPreProcessValue == "trim")
                    {
                        prmValue = prmValue.Trim();
                    }

                    if (strPreProcessValue == "lower")
                    {
                        prmValue = prmValue.ToLower();
                    }

                    if (strPreProcessValue == "upper")
                    {
                        prmValue = prmValue.ToUpper();
                    }

                    if (strPreProcessValue == "space")
                    {
                        prmValue = prmValue.Replace(" ", "");
                    }

                    if (strPreProcessValue == "whitespace")
                    {
                        while (prmValue.Contains("  "))
                        {
                            prmValue = prmValue.Replace("  ", " ");
                        }
                    }
                }
            }

            return prmValue;
        }

        public static string ToString(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, string prmDefault)
        {
            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault;
                }
            }

            // Check Valid Values
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    CheckCount++;

                    if (strValidValue == prmValue)
                    {
                        ValidFound = true;
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                prmValue = prmDefault;
            }

            // Return result;
            return prmValue;
        }

        public static byte ToByte(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, byte prmDefault)
        {
            byte Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = Byte.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            byte ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = Byte.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static sbyte ToSByte(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, sbyte prmDefault)
        {
            sbyte Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = SByte.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            sbyte ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = SByte.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static ushort ToUShort(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, ushort prmDefault)
        {
            ushort Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = ushort.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            ushort ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = ushort.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static short ToShort(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, short prmDefault)
        {
            short Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = short.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            short ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = short.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static uint ToUInt(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, uint prmDefault)
        {
            uint Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = uint.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            uint ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = uint.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static int ToInt(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, int prmDefault)
        {
            int Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = int.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            int ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = int.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static ulong ToULong(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, ulong prmDefault)
        {
            ulong Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = ulong.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            ulong ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = ulong.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static long ToLong(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, long prmDefault)
        {
            long Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = long.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            long ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = long.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static float ToFloat(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, float prmDefault)
        {
            float Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = float.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            float ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = float.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static double ToDouble(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, double prmDefault)
        {
            double Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool Converted = double.TryParse(prmValue, out Result);
            if (!Converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            double ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    Converted = double.TryParse(strValidValue, out ValidValue);
                    if (Converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }

        public static decimal ToDecimal(string prmValue, uint prmLength, string prmValidValues, string prmPreProcess, decimal prmDefault)
        {
            decimal Result;

            // Pre Process
            prmValue = PreProcess(prmValue, prmPreProcess);

            // Check Length
            if (prmLength != 0)
            {
                if (prmValue.Length != prmLength)
                {
                    prmValue = prmDefault.ToString();
                }
            }

            // Try to Parse
            bool converted = decimal.TryParse(prmValue, out Result);
            if (!converted)
            {
                Result = prmDefault;
            }

            // Check Valid Values
            decimal ValidValue;
            bool ValidFound = false;
            int CheckCount = 0;

            prmValidValues = ReplaceSplitters(prmValidValues);
            string[] strValidValues = prmValidValues.Split(',');

            foreach (string strValidValue in strValidValues)
            {
                if (!String.IsNullOrEmpty(strValidValue))
                {
                    converted = decimal.TryParse(strValidValue, out ValidValue);
                    if (converted)
                    {
                        CheckCount++;

                        if (ValidValue == Result)
                        {
                            ValidFound = true;
                        }
                    }
                }
            }

            if (CheckCount > 0 && !ValidFound)
            {
                Result = prmDefault;
            }

            // Return result;
            return Result;
        }
    }
}