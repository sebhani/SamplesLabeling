using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesLabeling
{
    class SampleID
    {
        private int id;

        public SampleID(int iniID)
        {
            id = iniID;
        }

        public string getId()
        {
            return id.ToString();
        }

        public void setId(int newId)
        {
            id = newId;
        }
    }
}
