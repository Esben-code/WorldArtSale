using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassSalesValue : ClassNotify
    {
        private string _bidUSD;
        private string _bidEUR;
        private string _bidOwnValuta;
        private string _priceWithFeeUSD;
        private string _priceWithFeeEUR;
        private string _priceWithFeeOwnValuta;
        private ClassCurrency _classCurrency;
        private string _customerValuta;



        public ClassSalesValue()
        {
            bidUSD = "";
            bidEUR = "";
            bidOwnValuta = "";
            priceWithFeeUSD = "";
            priceWithFeeEUR = "";
            priceWithFeeOwnValuta = "";
            classCurrency = new ClassCurrency();
            customerValuta = "";
        }

        public ClassSalesValue(ClassSalesValue inSalesValue)
        {
            bidUSD = inSalesValue.bidUSD;
            bidEUR = "";
            bidOwnValuta = "";
            priceWithFeeUSD = "";
            priceWithFeeEUR = "";
            priceWithFeeOwnValuta = "";
            classCurrency = new ClassCurrency();
            customerValuta = "";
        }


        public string customerValuta
        {
            get { return _customerValuta; }
            set
            {
                if (_customerValuta != value)
                {
                    _customerValuta = value;
                }
                Notify("customerValuta");
            }
        }


        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (_classCurrency != value)
                {
                    _classCurrency = value;
                }
                Notify("classCurrency");
            }
        }


        public string priceWithFeeOwnValuta
        {
            get { return _priceWithFeeOwnValuta; }
            set
            {
                if (_priceWithFeeOwnValuta != value)
                {
                    _priceWithFeeOwnValuta = value;
                }
                Notify("priceWithFeeOwnValuta");
            }
        }


        public string priceWithFeeEUR
        {
            get { return _priceWithFeeEUR; }
            set
            {
                if (_priceWithFeeEUR != value)
                {
                    _priceWithFeeEUR = value;
                }
                Notify("priceWithFeeEUR");
            }
        }


        public string priceWithFeeUSD
        {
            get { return _priceWithFeeUSD; }
            set
            {
                if (_priceWithFeeUSD != value)
                {
                    _priceWithFeeUSD = value;
                }
                Notify("priceWithFeeUSD");
            }
        }


        public string bidOwnValuta
        {
            get { return _bidOwnValuta; }
            set
            {
                if (_bidOwnValuta != value)
                {
                    _bidOwnValuta = value;
                }
                Notify("bidOwnValuta");
            }
        }


        public string bidEUR
        {
            get { return _bidEUR; }
            set
            {
                if (_bidEUR != value)
                {
                    _bidEUR = value;
                }
                Notify("bidEUR");
            }
        }


        public string bidUSD
        {
            get { return _bidUSD; }
            set
            {
                if (_bidUSD != value)
                {
                    //for at sikrer os at det der bliver tastet ind er et tal og at vores rates proporty er
                    //blevet fyldt med dataen fra API'en.
                    if (decimal.TryParse(value, out decimal X) && classCurrency.rates.ContainsKey("USD"))
                    {


                        _bidUSD = X.ToString("#,##0.00");

                        CalculateAll();
                    }
                    else
                    {
                        _bidUSD = value;
                    }
                }
                Notify("bidUSD");
                
            }
        }

        /// <summary>
        /// tager vores bidUSD og udregner hvad det er i EURO og den valuta kunden har knyttet til deres dataset
        /// </summary>
        public void CalculateAll()
        {
            decimal temp = 0;
            temp = Convert.ToDecimal(bidUSD);

            bidEUR = (temp * classCurrency.rates["EUR"]).ToString("#,##0.00");
            bidOwnValuta = (temp * classCurrency.rates[$"{customerValuta}"]).ToString("#,##0.00");

            priceWithFeeUSD = (temp * 1.075M).ToString("#,##0.00");
            priceWithFeeEUR = (temp * 1.075M * classCurrency.rates["EUR"]).ToString("#,##0.00");
            priceWithFeeOwnValuta = (temp * 1.075M * classCurrency.rates[$"{customerValuta}"]).ToString("#,##0.00");


        }

    }
}
