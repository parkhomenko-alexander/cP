using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cP
{   
    class bonusInfo
    {
        bonusInfo()
        {
            this.post = "";
            this.experience = 0;
            this.percent = 0;
        }
        bonusInfo(string post, int experience, int precent)
        {
            this.post = post;
            this.experience = experience;
            this.percent = percent;
        }

        public string post { get; set; }
        public int experience { get; set; }
        public int percent { get; set; }
    }
    class map
    {
        public map()
        {
            this.arraySize = 16;
            this.array = new bonusInfo[arraySize];
        }
        public int hFunction1(int num)
        {
            return 0;
        }
       // public int hFunction2(int num);
        public bonusInfo[] array;
        int arraySize;
    }
}
