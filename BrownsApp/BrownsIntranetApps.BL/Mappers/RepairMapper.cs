using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL.Mappers
{
    internal class RepairMapper
    {
        internal static RepairDTO Map(Repair entity)
        {
            RepairDTO repairDTO = new RepairDTO() {
                Id= entity.Id,
                CustomerId = entity.CustomerId,
                CustomerName = entity.CustomerName,
                Date_Time=entity.Date_Time.GetValueOrDefault(),
                Labor=entity.Labor.GetValueOrDefault(),
                LaborHours= entity.LaborHours.GetValueOrDefault(),
                MachineHours = entity.MachineHours.GetValueOrDefault(),
                MachineMiles = entity.MachineMiles.GetValueOrDefault(),
                Make=entity.Make,
                Model=entity.Model,
                Parts=entity.Parts.GetValueOrDefault(),
                PartsCost=entity.PartsCost.GetValueOrDefault(),
                RepairType = entity.RepairType,
                SerialNumber=entity.SerialNumber,
                ServiceReportBillFile=entity.ServiceReportBillFile==null?"": entity.ServiceReportBillFile,
                TotalBill=entity.TotalBill.GetValueOrDefault(),
                UnitNumber=entity.UnitNumber,
                VendorInvoicesFile=entity.VendorInvoicesFile==null?"": entity.VendorInvoicesFile,
                RepairNumber=entity.RepairNumber
                

            };

            return repairDTO;
        }


        internal static RepairHomeDTO MapForHome(Repair entity)
        {
            RepairHomeDTO repairDTO = new RepairHomeDTO()
            {
                Id = entity.Id,
                RepairNumber = entity.RepairNumber,
                CustomerName = entity.CustomerName,
                Date_Time = entity.Date_Time.GetValueOrDefault(),
                Labor = entity.Labor.GetValueOrDefault(),
                LaborHours = entity.LaborHours.GetValueOrDefault(),
                MachineHours = entity.MachineHours.GetValueOrDefault(),
                MachineMiles = entity.MachineMiles.GetValueOrDefault(),
                Make = entity.Make,
                Model = entity.Model,
                Parts = entity.Parts.GetValueOrDefault(),
                PartsCost = entity.PartsCost.GetValueOrDefault(),
                RepairType = entity.RepairType,
                SerialNumber = entity.SerialNumber,
                TotalBill = entity.TotalBill.GetValueOrDefault(),
                UnitNumber = entity.UnitNumber,

            };

            return repairDTO;
        }

        internal static List<RepairDTO> Map(List<Repair> obj)
        {
            return obj.ConvertAll(Map);
        }
        internal static List<RepairHomeDTO> MapForHome(List<Repair> obj)
        {
            return obj.ConvertAll(MapForHome);
        }
        internal static Repair Map(RepairDTO dto)
        {
            Repair repair = new Repair() {
                VendorInvoicesFile=dto.VendorInvoicesFile == null ? "" : dto.VendorInvoicesFile,
                UnitNumber =dto.UnitNumber,
                TotalBill=dto.TotalBill,
                ServiceReportBillFile= dto.ServiceReportBillFile == null ? "" : dto.ServiceReportBillFile,
                SerialNumber =dto.SerialNumber,
                RepairType=dto.RepairType,
                CustomerId=dto.CustomerId,
                CustomerName=dto.CustomerName,
                Date_Time=dto.Date_Time,
                Id=dto.Id,
                Labor=dto.Labor,
                LaborHours=dto.LaborHours,
                MachineHours=dto.MachineHours,
                MachineMiles=dto.MachineMiles,
                Make=dto.Make,
                Model=dto.Model,
                Parts=dto.Parts,
                PartsCost=dto.PartsCost,
                RepairNumber=dto.RepairNumber              

            };
            return repair;
        }
    }
}