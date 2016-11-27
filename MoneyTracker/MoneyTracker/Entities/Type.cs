using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Entities
{
    class Type : MoneyTrackerDataModel.Entities.TransactionType
    {

        public override string ToString()
        {
            return base.Description;
        }
    }

}
