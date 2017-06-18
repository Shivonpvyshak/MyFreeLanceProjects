using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BrownsIntranetApps.BL.Mappers
{
    public class InvoiceMapper
    {
        private CustomerMapper customerMapper;
        private InvoiceItemMapper itemMapper;
        private InvoiceLaborMapper laborMapper;

        public InvoiceDTO InvoiceDTOMapper(Invoice invoice)
        {
            InvoiceDTO invoiceDTO = new InvoiceDTO();
            customerMapper = new CustomerMapper();

            invoiceDTO.BalanceDue = Math.Round(invoice.BalanceDue.GetValueOrDefault(), 2);
            invoiceDTO.Customer = customerMapper.CustomerDTOMapper(invoice.Customer);
            invoiceDTO.Comments = invoice.Comments;
            invoiceDTO.CustomerID = invoice.CustomerID;
            invoiceDTO.CustomerPO = invoice.CustomerPO;
            invoiceDTO.Freight = Math.Round(invoice.Freight.GetValueOrDefault(), 2);
            invoiceDTO.ID = invoice.ID;
            invoiceDTO.InvoiceDate = invoice.InvoiceDate;
            invoiceDTO.InvoiceItems = invoice.InvoiceItems.ToList().ConvertAll(InvoiceItemDTOMapper);
            invoiceDTO.InvoiceLabors = invoice.InvoiceLabors.ToList().ConvertAll(InvoiceLaborDTOMapper);
            invoiceDTO.InvoiceNumber = invoice.InvoiceNumber;
            invoiceDTO.InvoiceType = invoice.InvoiceType;
            invoiceDTO.IsStorePickUp = invoice.IsStorePickUp.GetValueOrDefault();


            invoiceDTO.PartsSubTotal = Math.Round(invoice.PartsSubTotal.GetValueOrDefault(), 2);
            invoiceDTO.LaborSubTotal = Math.Round(invoice.LaborSubTotal.GetValueOrDefault(), 2);
            invoiceDTO.Tax = Math.Round(invoice.Tax, 2);
            invoiceDTO.Total = Math.Round(invoice.Total, 2);
            invoiceDTO.TravelCharge = Math.Round(invoice.TravelCharge.GetValueOrDefault(), 2);
            invoiceDTO.TravelExpense = Math.Round(invoice.TravelExpense.GetValueOrDefault(), 2);

            //TypeCodes

            invoiceDTO.InvoiceStatus = new TypeCodeDTO();
            invoiceDTO.InvoiceStatus.TypeCodeID = invoice.InvoiceStatusID.GetValueOrDefault();
            invoiceDTO.InvoiceStatus.TypeCode = invoice.InvoiceStatus;
            invoiceDTO.County = new TypeCodeDTO();
            invoiceDTO.County.TypeCodeID = invoice.CountyId.GetValueOrDefault();
            invoiceDTO.County.TypeCode = invoice.County;

            if (invoiceDTO.InvoiceType == "SERVICE-INVOICE")
            {
                if (invoice.InvoiceService != null)
                {
                    invoiceDTO.ServicedAt = invoice.InvoiceService.ServicedAt;
                    invoiceDTO.ServiceStartDate = invoice.InvoiceService.ServiceStartDate;
                    invoiceDTO.ServiceEndDate = invoice.InvoiceService.ServiceEndDate;
                    invoiceDTO.Make = invoice.InvoiceService.Make;
                    invoiceDTO.Model = invoice.InvoiceService.Model;
                    invoiceDTO.SerialNumber = invoice.InvoiceService.SerialNumber;
                    invoiceDTO.UnitNumber = invoice.InvoiceService.UnitNumber;
                }
            }

            if (invoiceDTO.InvoiceType == "PART-INVOICE")
            {
                invoiceDTO.OrderNumber = invoice.OrderNumber;
                invoiceDTO.SalesRep = invoice.SaleRep;
                invoiceDTO.PaymentStatus = new TypeCodeDTO();
                invoiceDTO.PaymentStatus.TypeCode = invoice.PaymentStatus;
                invoiceDTO.PaymentStatus.TypeCodeID = invoice.PaymentStatusID.GetValueOrDefault();
                invoiceDTO.ShippingMethod = new TypeCodeDTO();
                invoiceDTO.ShippingMethod.TypeCode = invoice.ShippingMethod;
                invoiceDTO.ShippingMethod.TypeCodeID = invoice.ShippingMethodID.GetValueOrDefault();
            }

            return invoiceDTO;
        }

        public Invoice InvoiceEntityMapper(InvoiceDTO invoice)
        {
            // customerMapper = new CustomerMapper();
            Invoice invoiceEntity = new Invoice();
            invoiceEntity.BalanceDue = invoice.BalanceDue == null ? 0.00M : Math.Round(invoice.BalanceDue.GetValueOrDefault(), 2);
            invoiceEntity.Comments = invoice.Comments;
            invoiceEntity.CustomerID = invoice.CustomerID;
            invoiceEntity.CustomerPO = invoice.CustomerPO;
            // invoiceEntity.Customer = customerMapper.CustomerEntityMapper(invoice.Customer);
            invoiceEntity.Freight = invoice.Freight == null ? 0.00M : Math.Round(invoice.Freight.GetValueOrDefault(), 2);
            invoiceEntity.ID = invoice.ID;
            invoiceEntity.InvoiceDate = invoice.InvoiceDate.Date;

            invoiceEntity.InvoiceItems = InvoiceItemEntityMapper(invoice.InvoiceItems);
            invoiceEntity.InvoiceLabors = InvoiceLaborEntityMapper(invoice.InvoiceLabors);
            invoiceEntity.InvoiceNumber = invoice.InvoiceNumber;

            invoiceEntity.OrderNumber = invoice.OrderNumber;
            invoiceEntity.InvoiceType = invoice.InvoiceType;
            if (invoice.County != null)
            {
                invoiceEntity.County = invoice.County.TypeCode;
                invoiceEntity.CountyId = invoice.County.TypeCodeID;
            }


            invoiceEntity.Tax = Math.Round(invoice.Tax, 2);
            invoiceEntity.Total = Math.Round(invoice.Total, 2);
            invoiceEntity.TravelCharge = Math.Round(invoice.TravelCharge.GetValueOrDefault(), 2);
            invoiceEntity.TravelExpense = Math.Round(invoice.TravelExpense.GetValueOrDefault(), 2);
            invoiceEntity.PartsSubTotal = Math.Round(invoice.PartsSubTotal, 2);
            invoiceEntity.LaborSubTotal = Math.Round(invoice.LaborSubTotal, 2);

            invoiceEntity.AddedBy = "Admin";
            invoiceEntity.AddedDate = DateTime.Now;
            if (invoice.InvoiceStatus != null)
            {
                invoiceEntity.InvoiceStatus = invoice.InvoiceStatus.TypeCode;
                invoiceEntity.InvoiceStatusID = invoice.InvoiceStatus.TypeCodeID;
            }
            if (invoice.InvoiceStatus.TypeCode == "Paid")
            {
                invoiceEntity.PaidDate = DateTime.Now;
            }
            if (invoice.InvoiceType.ToUpper() == "SERVICE-INVOICE")
            {
                invoiceEntity.InvoiceService = new InvoiceService();
                invoiceEntity.InvoiceService.ServicedAt = invoice.ServicedAt;
                invoiceEntity.InvoiceService.ServiceStartDate = invoice.ServiceStartDate;
                invoiceEntity.InvoiceService.ServiceEndDate = invoice.ServiceEndDate;
                invoiceEntity.InvoiceService.Make = invoice.Make;
                invoiceEntity.InvoiceService.Model = invoice.Model;
                invoiceEntity.InvoiceService.SerialNumber = invoice.SerialNumber == null ? "" : invoice.SerialNumber;
                invoiceEntity.InvoiceService.UnitNumber = invoice.UnitNumber == null ? "" : invoice.UnitNumber;
            }

            if (invoice.InvoiceType.ToUpper() == "PART-INVOICE")
            {
                invoiceEntity.IsStorePickUp = invoice.IsStorePickUp;
                if (invoice.PaymentStatus != null)
                {
                    invoiceEntity.PaymentStatus = invoice.PaymentStatus.TypeCode;
                    invoiceEntity.PaymentStatusID = invoice.PaymentStatus.TypeCodeID;
                }
                if (invoice.ShippingMethod != null)
                {
                    invoiceEntity.ShippingMethod = invoice.ShippingMethod.TypeCode;
                    invoiceEntity.ShippingMethodID = invoice.ShippingMethod.TypeCodeID;
                }
                invoiceEntity.SaleRep = invoice.SalesRep;
            }

            return invoiceEntity;
        }

        private InvoiceItemsDTO InvoiceItemDTOMapper(InvoiceItem invoiceItem)
        {
            itemMapper = new InvoiceItemMapper();

            return itemMapper.InvoiceItemDTOMapper(invoiceItem);
        }

        private InvoiceLaborDTO InvoiceLaborDTOMapper(InvoiceLabor invoiceLabor)
        {
            laborMapper = new InvoiceLaborMapper();

            return laborMapper.InvoiceLaborDTOMapper(invoiceLabor);
        }

        private ICollection<InvoiceItem> InvoiceItemEntityMapper(IList<InvoiceItemsDTO> invoiceItemsDTO)
        {
            if (invoiceItemsDTO != null && invoiceItemsDTO.Count > 0)
            {
                itemMapper = new InvoiceItemMapper();
                ICollection<InvoiceItem> invoiceItems = new Collection<InvoiceItem>();
                for (int i = 0; i < invoiceItemsDTO.Count; i++)
                {
                    invoiceItems.Add(itemMapper.InvoiceItemEntityMapper(invoiceItemsDTO[i]));
                }
                return invoiceItems;
            }
            else
                return null;
        }

        private ICollection<InvoiceLabor> InvoiceLaborEntityMapper(IList<InvoiceLaborDTO> invoiceLaborsDTO)
        {
            if (invoiceLaborsDTO != null && invoiceLaborsDTO.Count > 0)
            {
                laborMapper = new InvoiceLaborMapper();

                ICollection<InvoiceLabor> invoiceLabors = new Collection<InvoiceLabor>();
                for (int i = 0; i < invoiceLaborsDTO.Count; i++)
                {
                    invoiceLabors.Add(laborMapper.InvoiceLaborEntityMapper(invoiceLaborsDTO[i]));
                }

                return invoiceLabors;
            }
            else
                return null;
        }
    }
}