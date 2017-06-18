using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.BL.Mappers;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DAL.UOW;
using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrownsIntranetApps.BL
{
    public class RepairBL : IRepairBL
    {
        private readonly BHEUnitOfWork _bheUOW;
        private RepairMapper mapper;

        public RepairBL()
        {
            BrownsAppDBEntities1 _bheDBContext = new BrownsAppDBEntities1();
            _bheUOW = new BHEUnitOfWork(_bheDBContext);
        }

        public List<RepairDTO> GetAll()
        {
            return RepairMapper.Map(_bheUOW.RepairRepository.Query().ToList());
        }

        public List<RepairHomeDTO> GetAllForHome()
        {
            return RepairMapper.MapForHome(_bheUOW.RepairRepository.Query().ToList());
        }

        public RepairDTO Get(int repairId)
        {
            return RepairMapper.Map(_bheUOW.RepairRepository.Query().Where(x => x.Id == repairId).FirstOrDefault());
        }

        public int Add(RepairDTO repairDTO)
        {
            try
            {
                Repair entity = RepairMapper.Map(repairDTO);
                _bheUOW.RepairRepository.Add(entity);
                _bheUOW.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                throw ex;
            }
        }
        public int Update(RepairDTO dto)
        {

            var existingRepair = _bheUOW.RepairRepository.Query().Where(x => x.Id == dto.Id).FirstOrDefault();
            if (existingRepair != null)
            {

                existingRepair.VendorInvoicesFile = dto.VendorInvoicesFile == null ? "" : dto.VendorInvoicesFile;
                existingRepair.UnitNumber = dto.UnitNumber;
                existingRepair.TotalBill = dto.TotalBill;
                existingRepair.ServiceReportBillFile = dto.ServiceReportBillFile == null ? "" : dto.ServiceReportBillFile;
                existingRepair.SerialNumber = dto.SerialNumber;
                existingRepair.RepairType = dto.RepairType;
                existingRepair.CustomerId = dto.CustomerId;
                existingRepair.CustomerName = dto.CustomerName;
                existingRepair.Date_Time = dto.Date_Time;
                existingRepair.Id = dto.Id;
                existingRepair.Labor = dto.Labor;
                existingRepair.LaborHours = dto.LaborHours;
                existingRepair.MachineHours = dto.MachineHours;
                existingRepair.MachineMiles = dto.MachineMiles;
                existingRepair.Make = dto.Make;
                existingRepair.Model = dto.Model;
                existingRepair.Parts = dto.Parts;
                existingRepair.PartsCost = dto.PartsCost;
                existingRepair.RepairNumber = dto.RepairNumber;
                _bheUOW.SaveChanges();

            }
            return existingRepair.Id;
        }
        public bool Delete(int repairId)
        {
            try
            {
                Repair repair = new Repair();
                var repairID = _bheUOW.RepairRepository.Delete(repairId);
                _bheUOW.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler exceptionHandler = new ExceptionHandler();
                exceptionHandler.WrapLogException(ex);
                throw ex;
            }
        }

    }
}