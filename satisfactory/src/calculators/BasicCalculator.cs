using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class BasicCalculator : Calculator
    {
        public override ConstructionTree adjustComponentTreeToAdditionalCondition(ConstructionTree component)
        {
            return component;
        }
    }
}
