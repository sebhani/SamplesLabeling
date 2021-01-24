using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesLabeling
{
    class SpecimenRepository
    {
        public static readonly IDictionary<string, int> areaA = new Dictionary<string, int> {{"Wound - Pus",4}, 
                                                                {"Vrs",1}, {"Genital",5}, {"Tissue",1},
                                                                {"Ear Swab",3}, {"Eye Swab",2}, {"Fluids",5},
                                                                {"Csf",5}, {"Aspirate - Exudates",5}, {"Tip",1}};

        public static readonly IDictionary<string, int> areaB = new Dictionary<string, int> {{"Spustum",3}, 
                                                               {"Nasal",2}, {"Throat",3},
                                                               {"Ett",3}, {"Tracheal Aspirate",3}, {"Enviroment",1},
                                                               {"Mrsa Screening",1}};

        public static readonly IDictionary<string, int> areaC = new Dictionary<string, int>  {{"Blood", 4}, {"Stool", 4}, {"Rectal", 2}};

        public static readonly IDictionary<string, int> areaD = new Dictionary<string, int> {{ "Urine", 1}};
    }
}
