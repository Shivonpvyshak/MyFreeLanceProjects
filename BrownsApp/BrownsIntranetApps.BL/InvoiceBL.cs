using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.BL.Mappers;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DAL.UOW;
using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL
{
    public class InvoiceBL : IInvoiceBL
    {
        private readonly BHEUnitOfWork _bheUOW;
        private InvoiceMapper mapper;
        private ISqlConnectionHelper sqlHelper;

        public InvoiceBL()
        {
            BrownsAppDBEntities1 _bheDBContext = new BrownsAppDBEntities1();
            _bheUOW = new BHEUnitOfWork(_bheDBContext);
        }

        public InvoiceDTO Get(string invoiceNumber)
        {
            var invoice = _bheUOW.InvoiceRepository.Query().Where(x => x.InvoiceNumber == invoiceNumber).FirstOrDefault();
            return InvoiceDTOMapper(invoice);
        }

        public BillingDashBoardDTO GetAllDashboardInvoices()
        {
            BillingDashBoardDTO billingDashBoard = new BillingDashBoardDTO();

            var allInvoices = _bheUOW.InvoiceRepository.Query();

            billingDashBoard.InProgressInvoices = allInvoices
                                                   .Where(x => x.InvoiceStatusID == 1)
                                                   .ToList().ConvertAll(InvoiceOnlyMapper);

            billingDashBoard.ApprovedInvoices = allInvoices
                  .Where(x => x.InvoiceStatusID == 3)
                  .ToList().ConvertAll(InvoiceOnlyMapper);

            billingDashBoard.PendingValidationInvoices = allInvoices
                              .Where(x => x.InvoiceStatusID == 2)
                              .ToList().ConvertAll(InvoiceOnlyMapper);

            billingDashBoard.PaymentPendingInvoices = allInvoices
                              .Where(x => x.InvoiceStatusID == 4)
                              .ToList().ConvertAll(InvoiceOnlyMapper);
            return billingDashBoard;
        }

        public long Add(InvoiceDTO invoiceDTO)
        {
            try
            {
                long invoiceID = 0;
                mapper = new InvoiceMapper();
                if (invoiceDTO.SubmitingMode == "Update")
                {
                }
                else
                {
                    invoiceID = _bheUOW.InvoiceRepository.Add(mapper.InvoiceEntityMapper(invoiceDTO));
                }
                _bheUOW.SaveChanges();
                return invoiceID;
            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                throw ex;
            }
        }

        public bool Delete(string invoiceNumber)
        {
            bool isDeleteSuccess = false;
            sqlHelper = new SqlConnectionHelper();
            SqlCommand command = new SqlCommand();

            //DataTable dtResults = new DataTable();
            DataSet dsResults = new DataSet();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[Billing].[DeleteInvoice]";

            command.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);

            dsResults = sqlHelper.ExecuteStoredProcedure(command);
            if (dsResults != null && dsResults.Tables.Count > 0)
            {
                if (Convert.ToInt32(dsResults.Tables[0].Rows[0][0]) == 1)
                {
                    isDeleteSuccess = true;
                }
            }
            return isDeleteSuccess;
        }

        public long Update(InvoiceDTO invoiceDTO)
        {
            long updatedID = -1;

            //Update Invoice
            var existingInvoice = _bheUOW.InvoiceRepository.Query().SingleOrDefault(x => x.ID == invoiceDTO.ID);
            if (existingInvoice != null)
            {
                existingInvoice.BalanceDue = Math.Round(invoiceDTO.BalanceDue.GetValueOrDefault(), 2);
                existingInvoice.Comments = invoiceDTO.Comments;
                existingInvoice.CustomerID = invoiceDTO.Customer.ID;
                existingInvoice.CustomerID = invoiceDTO.CustomerID;
                existingInvoice.CustomerPO = invoiceDTO.CustomerPO;
                existingInvoice.Freight = Math.Round(invoiceDTO.Freight.GetValueOrDefault(), 2);
                existingInvoice.InvoiceDate = invoiceDTO.InvoiceDate == DateTime.MinValue ? DateTime.Now : invoiceDTO.InvoiceDate;
                existingInvoice.InvoiceNumber = invoiceDTO.InvoiceNumber;
                existingInvoice.InvoiceStatus = invoiceDTO.InvoiceStatus.TypeCode;
                existingInvoice.InvoiceStatusID = invoiceDTO.InvoiceStatus.TypeCodeID;
                existingInvoice.InvoiceType = invoiceDTO.InvoiceType;
                existingInvoice.LaborSubTotal = Math.Round(invoiceDTO.LaborSubTotal, 2);

                existingInvoice.PartsSubTotal = Math.Round(invoiceDTO.PartsSubTotal, 2);
                existingInvoice.Tax = Math.Round(invoiceDTO.Tax, 2);
                existingInvoice.TravelCharge = Math.Round(invoiceDTO.TravelCharge.GetValueOrDefault(), 2);
                existingInvoice.TravelExpense = Math.Round(invoiceDTO.TravelExpense.GetValueOrDefault(), 2);
                existingInvoice.LastUpdatedBy = "Admin";
                existingInvoice.LastUpdatedDate = DateTime.Now;
                if (existingInvoice.InvoiceType == "SERVICE-INVOICE")
                {
                    existingInvoice.InvoiceService.Make = invoiceDTO.Make;
                    existingInvoice.InvoiceService.Model = invoiceDTO.Model;
                    existingInvoice.InvoiceService.SerialNumber = invoiceDTO.SerialNumber;
                    existingInvoice.InvoiceService.UnitNumber = invoiceDTO.UnitNumber;
                    existingInvoice.InvoiceService.ServicedAt = invoiceDTO.ServicedAt;
                    existingInvoice.InvoiceService.ServiceStartDate = invoiceDTO.ServiceStartDate;
                    existingInvoice.InvoiceService.ServiceEndDate = invoiceDTO.ServiceEndDate;
                }

                if (existingInvoice.InvoiceType == "PART-INVOICE")
                {
                    existingInvoice.OrderNumber = invoiceDTO.OrderNumber;
                    existingInvoice.PaymentStatus = invoiceDTO.PaymentStatus.TypeCode;
                    existingInvoice.SaleRep = invoiceDTO.SalesRep;
                    existingInvoice.ShippingMethod = invoiceDTO.ShippingMethod.TypeCode;
                }
                existingInvoice.IsStorePickUp = invoiceDTO.IsStorePickUp;
                updatedID = existingInvoice.ID;
            }

            //Insert/Update/Delete Parts Items
            if (invoiceDTO.InvoiceItems != null && invoiceDTO.InvoiceItems.Count > 0)
            {
                for (int i = 0; i < invoiceDTO.InvoiceItems.Count; i++)
                {
                    //Delete Invoice Item
                    if (invoiceDTO.InvoiceItems[i].RecordStatus.ToUpper() == "DELETED")
                    {
                        InvoiceItem invoiceItem = new InvoiceItem()
                        {
                            Description = invoiceDTO.InvoiceItems[i].Description,
                            ID = invoiceDTO.InvoiceItems[i].ID,
                            Price = invoiceDTO.InvoiceItems[i].Price,
                            Quantity = invoiceDTO.InvoiceItems[i].Quantity,
                            Total = invoiceDTO.InvoiceItems[i].Total
                        };
                        var invoiceItemID = _bheUOW.InvoiceItemsRepository.Delete(invoiceItem);
                    }
                    //Insert Item
                    if (invoiceDTO.InvoiceItems[i].ID == 0)
                    {
                        invoiceDTO.InvoiceItems[i].InvoiceID = invoiceDTO.ID;
                        InvoiceItemMapper mapper = new InvoiceItemMapper();
                        _bheUOW.InvoiceItemsRepository.Add(mapper.InvoiceItemEntityMapper(invoiceDTO.InvoiceItems[i]));
                    }
                }
            }

            //Insert/Update/Delete Labor Items
            if (invoiceDTO.InvoiceLabors != null && invoiceDTO.InvoiceLabors.Count > 0)
            {
                for (int i = 0; i < invoiceDTO.InvoiceLabors.Count; i++)
                {
                    //Delete Invoice Item
                    if (invoiceDTO.InvoiceLabors[i].RecordStatus.ToUpper() == "DELETED")
                    {
                        InvoiceLabor invoiceLabor = new InvoiceLabor()
                        {
                            ID = invoiceDTO.InvoiceLabors[i].ID,
                            InvoiceID = invoiceDTO.InvoiceLabors[i].InvoiceID,
                            Amount = invoiceDTO.InvoiceLabors[i].Amount,
                            Hours = invoiceDTO.InvoiceLabors[i].Hours,
                            LaborType = invoiceDTO.InvoiceLabors[i].LaborType.TypeCode,
                            Rate = invoiceDTO.InvoiceLabors[i].Rate,
                        };
                        var invoiceLaborID = _bheUOW.InvoiceLaborRepository.Delete(invoiceLabor);
                    }
                    //Insert Item
                    if (invoiceDTO.InvoiceLabors[i].ID == 0)
                    {
                        invoiceDTO.InvoiceLabors[i].InvoiceID = invoiceDTO.ID;
                        InvoiceLaborMapper mapper = new InvoiceLaborMapper();
                        _bheUOW.InvoiceLaborRepository.Add(mapper.InvoiceLaborEntityMapper(invoiceDTO.InvoiceLabors[i]));
                    }
                }
            }
            _bheUOW.SaveChanges();

            //Insert/Update/Delete Labor Items
            return updatedID;
        }

        private InvoiceDTO InvoiceDTOMapper(Invoice invoice)
        {
            if (invoice != null)
            {
                mapper = new InvoiceMapper();
                return mapper.InvoiceDTOMapper(invoice);
            }
            else return null;
        }

        private InvoiceDTO InvoiceOnlyMapper(Invoice invoice)
        {
            InvoiceDTO invoiceDTO = new InvoiceDTO();

            invoiceDTO.BalanceDue = invoice.BalanceDue;
            invoiceDTO.Customer = new CustomerDTO();
            invoiceDTO.Customer.Name = invoice.Customer.Name;
            invoiceDTO.CustomerPO = invoice.CustomerPO;
            invoiceDTO.Freight = invoice.Freight;
            invoiceDTO.ID = invoice.ID;
            invoiceDTO.InvoiceDate = invoice.InvoiceDate;
            invoiceDTO.InvoiceNumber = invoice.InvoiceNumber;
            invoiceDTO.InvoiceType = invoice.InvoiceType;

            invoiceDTO.PartsSubTotal = invoice.PartsSubTotal.GetValueOrDefault();
            invoiceDTO.LaborSubTotal = invoice.LaborSubTotal.GetValueOrDefault();
            invoiceDTO.Total = invoice.Total;
            invoiceDTO.InvoiceStatus = new TypeCodeDTO();
            invoiceDTO.InvoiceStatus.TypeCodeID = invoice.InvoiceStatusID.GetValueOrDefault();
            invoiceDTO.InvoiceStatus.TypeCode = invoice.InvoiceStatus;
            if (invoice.InvoiceType == "PART-INVOICE")
            {
                invoiceDTO.PaymentStatus = new TypeCodeDTO();
                invoiceDTO.PaymentStatus.TypeCode = invoice.PaymentStatus;
                invoiceDTO.SalesRep = invoice.SaleRep;
            }
            if (invoice.InvoiceType == "SERVICE-INVOICE")
            {
                if (invoice.InvoiceService != null)
                {
                    invoiceDTO.Make = invoice.InvoiceService.Make;
                    invoiceDTO.Model = invoice.InvoiceService.Model;
                    invoiceDTO.SerialNumber = invoice.InvoiceService.SerialNumber;
                    invoiceDTO.UnitNumber = invoice.InvoiceService.UnitNumber;
                    invoiceDTO.ServicedAt = invoice.InvoiceService.ServicedAt;
                    invoiceDTO.ServiceStartDate = invoice.InvoiceService.ServiceStartDate;
                    invoiceDTO.ServiceEndDate = invoice.InvoiceService.ServiceEndDate;
                }
            }

            return invoiceDTO;
        }

        public List<GeneralReportDTO> GetInvoiceGeneralReportData(DateTime? fromDate, DateTime? toDate, string invoiceType = "", string partsDescription = "", string customerName = "")
        {
          return ConvertToList(_bheUOW.InvoiceRepository.GetInvoiceGeneralReportData(fromDate, toDate,invoiceType,  partsDescription,  customerName));
        }


        private List<GeneralReportDTO> ConvertToList(DataSet dsResults)
        {
            List<GeneralReportDTO> data = new List<GeneralReportDTO>();
            data = (from DataRow dr in dsResults.Tables[0].Rows
                    select new GeneralReportDTO
                    {
                        BalanceDue = Convert.ToDecimal(dr["BalanceDue"]),
                        InvoiceDate = Convert.ToDateTime(dr["InvoiceDate"]),
                        InvoiceNumber = dr["InvoiceNumber"].ToString(),
                        InvoiceType = dr["InvoiceType"].ToString(),
                        LaborSubTotal = Convert.ToDecimal(dr["LaborSubTotal"]),
                        Name = dr["Name"].ToString(),
                        PartsSubTotal = Convert.ToDecimal(dr["PartsSubTotal"]),
                        Total = Convert.ToDecimal(dr["Total"])

                    }).ToList();

            return data;
        }
    }
}