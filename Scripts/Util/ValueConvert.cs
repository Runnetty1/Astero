using UnityEngine;

namespace Assets.Scripts.Util
{
    class ValueConvert : MonoBehaviour
    {
        private static ValueConvert instance;
        public static ValueConvert Instance { get { return instance; } }

        public double convertValue = 1000;

        public enum ValueText
        {
            km,
            Mkm,
            Gkm,
            Tkm,
            Pkm,
            Ekm,
            Zkm,
            Ykm,
            KYkm,
            MYkm,
            GYkm,
            TYkm,
            PYkm,
            EYkm,
            ZYkm,
            YYkm,
            KYY,
            MYY,
            GYY,
            TYY,
            PYY,
            EYY,
            ZYY,
            YYY,
            KYYY,
            MYYY,
            GYYY,
            TYYY,
            PYYY,
            EYYY,
            ZYYY,
            YYYY,
            KYYYY,
            MYYYY,
            GYYYY,
            TYYYY,
            PYYYY,
            EYYYY,
            ZYYYY,
            YYYYY,
            KYYYYY,
            MYYYYY,
            GYYYYY,
            TYYYYY,
            PYYYYY,
            EYYYYY,
            ZYYYYY,
            YYYYYY,
            KYYYYYY,
            MYYYYYY,
            GYYYYYY,
            TYYYYYY,
            PYYYYYY,
            EYYYYYY,
            ZYYYYYY,
            YYYYYYY,
            KYYYYYYY,
            MYYYYYYY,
            GYYYYYYY,
            TYYYYYYY,
            PYYYYYYY,
            EYYYYYYY,
            ZYYYYYYY,
            YYYYYYYY,
            KYYYYYYYY,
            MYYYYYYYY,
            GYYYYYYYY,
            TYYYYYYYY,
            PYYYYYYYY,
            EYYYYYYYY,
            ZYYYYYYYY,
            YYYYYYYYY,
            KYYYYYYYYY,
            MYYYYYYYYY,
            GYYYYYYYYY,
            TYYYYYYYYY,
            PYYYYYYYYY,
            EYYYYYYYYY,
            ZYYYYYYYYY,
            YYYYYYYYYY
        };


        public ValueText valText = ValueText.km;

        void Awake()
        {
            CreateInstance();
        }

        void CreateInstance()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        public string getConvertedValue(double valueToConvert)
        {
            string finalVal = "ERROR";
            double value = valueToConvert;
            for (int i = 0; i <= (int)ValueText.YYYYYYYYYY; i++)
            {
                if ((value / convertValue) <= convertValue)
                {
                    if (value >= convertValue)
                    {
                        value = value / convertValue;
                        ValueText t = (ValueText)i;
                        finalVal = "" + value.ToString("f2") + " " + t;
                    }
                    else
                    {
                        finalVal = "" + valueToConvert.ToString("f0");
                    }
                    return finalVal;
                }
                else
                {
                    value = value / convertValue;
                }
            }
            return finalVal;
        }
    }
}
