using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassArt : ClassNotify
    {
        private int _artID;
        private string _picturePath;
        private string _pictureDescription;
        private string _pictureTitel;
        private bool _isAvailable;




        public ClassArt()
        {
            artID = 0;
            picturePath = @"C:\ImageSale\dsb1.jpg";
            pictureDescription = "";
            pictureTitel = "";
            isAvailable = false;
        }

        public bool isAvailable
        {
            get { return _isAvailable; }
            set
            {
                if (_isAvailable != value)
                {
                    _isAvailable = value;
                }
                Notify("isAvailable");
            }
        }

        public string pictureTitel
        {
            get { return _pictureTitel; }
            set
            {
                if (_pictureTitel != value)
                {
                    _pictureTitel = value;
                }
                Notify("pictureTitel");
            }
        }


        public string pictureDescription
        {
            get { return _pictureDescription; }
            set
            {
                if (_pictureDescription != value)
                {
                    _pictureDescription = value;
                }
                Notify("pictureDescription");
            }
        }


        public string picturePath
        {
            get { return _picturePath; }
            set
            {
                if (_picturePath != value)
                {
                    _picturePath = value;
                }
                Notify("picturePath");
            }
        }


        public int artID
        {
            get { return _artID; }
            set
            {
                if (_artID != value)
                {
                    _artID = value;
                }
                Notify("artID");
            }
        }





    }
}
