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

        public ClassSalesValue()
        {
            bidUSD = "";
            bidEUR = "";
            bidOwnValuta = "";
            priceWithFeeUSD = "";
            priceWithFeeEUR = "";
            priceWithFeeOwnValuta = "";
            classCurrency = new ClassCurrency();
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
                    _bidUSD = value;
                }
                Notify("bidUSD");
            }
        }

        /// <summary>
        /// Denne metode skal tage BidUSD og bruge rates fra ClassCurrency til at fylde bidEUR og bidOwnValuta ud
        /// plus at gange det med 1,075 (7,5%). for at få priceWithFeeUSD og priceWithFeeEUR 
        /// </summary>
        public void CalculateBidInValuta()
        {

        }

    }
}
