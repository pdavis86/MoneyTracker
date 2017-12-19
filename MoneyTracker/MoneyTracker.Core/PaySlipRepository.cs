using MoneyTrackerDataModel.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace MoneyTracker.Core
{
    public class PaySlipRepository : IRepository<PaySlip>
    {
        private MoneyTrackerDataModel.Contexts.Context _context;

        public PaySlipRepository(MoneyTrackerDataModel.Contexts.Context context)
        {
            _context = context;
        }

        public void Create(PaySlip item)
        {
            _context.PaySlips.Add(item);
        }

        public void Delete(int id)
        {
            _context.PaySlips.Remove(Retrieve(id));
        }

        public IEnumerable<PaySlip> Retrieve()
        {
            return _context.PaySlips;
        }

        public PaySlip Retrieve(int id)
        {
            return _context.PaySlips.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(PaySlip item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }


    }
}
