using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;
using Newtonsoft.Json;

namespace BIZ
{


    public class ClassBIZ : ClassNotify
    {

        
        ClassWorldArtSaleDB classDB = new ClassWorldArtSaleDB();
        ClassFileIO classFile = new ClassFileIO();
        ClassCallWebApi classAPI = new ClassCallWebApi();


        private ClassCurrency _selectedCurrency;
        private List<ClassCustomer> _listCustomer;
        private ClassCustomer _selectedCustomer;
        private ClassArt _selectedArt;
        private List<ClassArt> _listClassArt;

        public ClassBIZ()
        {
            selectedCurrency = new ClassCurrency();
            selectedCustomer = new ClassCustomer();
            selectedArt = new ClassArt();
            listClassArt = new List<ClassArt>();
            listCustomer = new List<ClassCustomer>();

            Task.Run(async () => await StartCurrencyApiCall());
            GetAllCurrencyIdAndNames();
            listCustomer = classDB.GetAllCustomerFromDB(selectedCurrency);
            listClassArt = classDB.GetAllArtFromDB();
        }

        public List<ClassArt> listClassArt
        {
            get { return _listClassArt; }
            set
            {
                if (_listClassArt != value)
                {
                    _listClassArt = value;
                }
                Notify("listClassArt");
            }
        }


        public ClassArt selectedArt
        {
            get { return _selectedArt; }
            set
            {
                if (_selectedArt != value)
                {
                    _selectedArt = value;
                }
                Notify("selectedArt");
            }
        }


        public ClassCustomer selectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    if (selectedCustomer.classSalesValue != null)
                    {
                        selectedCustomer.classSalesValue.classCurrency = selectedCurrency;
                        //selectedCustomer.classSalesValue.customerValuta = selectedCustomer.customerCurrencyID;
                        //en snørklet lille kode som gør det samme som det i ClassCustomer.customerCurrencyID
                    }
                }
                Notify("selectedCustomer");
            }
        }


        public List<ClassCustomer> listCustomer
        {
            get { return _listCustomer; }
            set
            {
                if (_listCustomer != value)
                {
                    _listCustomer = value;
                }
                Notify("listCustomer");
            }
        }


        public ClassCurrency selectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                if (_selectedCurrency != value)
                {
                    _selectedCurrency = value;

                    if (_selectedCurrency.rates.ContainsKey("USD"))
                    {
                        _selectedCurrency.SetValutaValueInProperty();
                    }
                    
                }
                Notify("selectedCurrency");
            }
        }



        public async Task StartCurrencyApiCall()
        {
            while (true)
            {
                byte[] urlContents = await classAPI.GetURLContentsAsync("https://openexchangerates.org/api/latest.json?app_id=5c02031ed690400cb11fe0224a861ad8&base=USD");

                string strJason = System.Text.Encoding.UTF8.GetString(urlContents);
                selectedCurrency = JsonConvert.DeserializeObject<ClassCurrency>(strJason);

                //await Task.Delay(300000);
                await Task.Delay(10000);
            }
        }

        private void GetAllCurrencyIdAndNames()
        {
            selectedCurrency.currencyIdName = classFile.ReadDataFromCurrencyFile();
            
            
            //få alle kontant koderne og navnen fra filen og match dem med api dataen
        } 







    }
}
