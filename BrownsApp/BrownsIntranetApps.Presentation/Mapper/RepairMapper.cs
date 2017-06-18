using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Presentation.Models.Repair;
using System.Collections.Generic;

namespace BrownsIntranetApps.Presentation.Mapper
{
    internal class RepairMapper
    {
        internal static RepairVM Map(RepairDTO dto)
        {
            RepairVM repairVM = new RepairVM()
            {
                Id = dto.Id,
                RepairNumber = dto.RepairNumber,
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                InvoiceDate = dto.Date_Time,
                Labor = dto.Labor,
                LaborHours = dto.LaborHours,
                MachineHours = dto.MachineHours,
                MachineMiles = dto.MachineMiles,
                Make = dto.Make,
                MachineModel = dto.Model,
                Parts = dto.Parts,
                PartsCost = dto.PartsCost,
                RepairType = dto.RepairType,
                SerialNumber = dto.SerialNumber,
                ServiceReportBillFile = dto.ServiceReportBillFile,
                TotalBill = dto.TotalBill,
                UnitNumber = dto.UnitNumber,
                VendorInvoicesFile = dto.VendorInvoicesFile,
                
            };

            return repairVM;
        }

        internal static List<RepairVM> Map(List<RepairDTO> obj)
        {
            return obj.ConvertAll(Map);
        }

        internal static RepairDTO Map(RepairVM vm)
        {
            RepairDTO repairDTO = new RepairDTO()
            {
                Id = vm.Id,
                RepairNumber=vm.RepairNumber,
                CustomerId = vm.CustomerId,
                CustomerName = vm.CustomerName,
                Date_Time = vm.InvoiceDate.GetValueOrDefault(),
                Labor = vm.Labor.GetValueOrDefault(),
                LaborHours = vm.LaborHours.GetValueOrDefault(),
                MachineHours = vm.MachineHours.GetValueOrDefault(),
                MachineMiles = vm.MachineMiles.GetValueOrDefault(),
                Make = vm.Make,
                Model = vm.MachineModel,
                Parts = vm.Parts.GetValueOrDefault(),
                PartsCost = vm.PartsCost.GetValueOrDefault(),
                RepairType = vm.RepairType,
                SerialNumber = vm.SerialNumber,
                ServiceReportBillFile = vm.ServiceReportBillFile,
                TotalBill = vm.TotalBill.GetValueOrDefault(),
                UnitNumber = vm.UnitNumber,
                VendorInvoicesFile = vm.VendorInvoicesFile
            };

            return repairDTO;
        }
    }
}