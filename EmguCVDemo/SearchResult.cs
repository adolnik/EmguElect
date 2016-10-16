using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmguCVDemo
{
    class SearchResult
    {
        public decimal backGroundCounter = 0;
        public decimal whiteColorCounter = 0;
        public decimal frameNumber = 0;
        public string RGBprofile = "";
        public string RGBprofileXY = "";

        public string getStringToSaveInFile() 
        {
            return string.Format("{0};{1};{2};{3};{4}", frameNumber, backGroundCounter, whiteColorCounter, RGBprofile, RGBprofileXY);
        }
    }
}
