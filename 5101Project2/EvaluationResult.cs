using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    namespace _5101Project2
    {
        /*
         * Class Name: EvaluationResult
         * Purpose: Store processed data for an arithmetic expression, including conversions and evaluations.
         * Properties: Sno, InFix, PreFix, PostFix, PreFixRes, PostFixRes, Match (bool)
         * Coder: KG
         * Date: April 9, 2025
         */
        public class EvaluationResult
        {
            public int Sno { get; set; }
            public string InFix { get; set; }
            public string PreFix { get; set; }
            public string PostFix { get; set; }
            public double PreFixRes { get; set; }
            public double PostFixRes { get; set; }
            public bool Match { get; set; }
        }
    }
}
