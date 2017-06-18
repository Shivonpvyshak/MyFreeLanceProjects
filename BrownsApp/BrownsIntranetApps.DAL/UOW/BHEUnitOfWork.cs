using BrownsIntranetApps.DAL.Interface;
using BrownsIntranetApps.DAL.Repository;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Data.Entity.Validation;

namespace BrownsIntranetApps.DAL.UOW
{
    public class BHEUnitOfWork

    {
        private readonly BrownsAppDBEntities1 _bheDBContext;

        public BHEUnitOfWork(BrownsAppDBEntities1 bheDBContext)
        {
            _bheDBContext = bheDBContext;

            PartsRepository = new PartsRepository(_bheDBContext);
            UserRepository = new UserRepository(_bheDBContext);
            CompanyRepository = new CompanyRepository(_bheDBContext);
            LogsRepository = new LogsRepository(_bheDBContext);
            CustomerRepository = new CustomerRepository(_bheDBContext);
            InvoiceRepository = new InvoiceRepository(_bheDBContext);
            InvoiceItemsRepository = new InvoiceItemsRepository(_bheDBContext);
            InvoiceLaborRepository = new InvoiceLaborRepository(_bheDBContext);
            RepairRepository = new RepairRepository(_bheDBContext);
        }

        public IPartsRepository PartsRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        public ILogsRepository LogsRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IInvoiceItemsRepository InvoiceItemsRepository { get; set; }
        public IInvoiceLaborRepository InvoiceLaborRepository { get; set; }
        public IInvoiceRepository InvoiceRepository { get; set; }
        public IRepairRepository RepairRepository { get; set; }

        public void SaveChanges()
        {
            try
            {
                _bheDBContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }
}