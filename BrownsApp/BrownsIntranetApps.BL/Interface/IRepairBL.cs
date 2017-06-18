using BrownsIntranetApps.DTO;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL.Interface
{
    public interface IRepairBL
    {
        List<RepairDTO> GetAll();

        List<RepairHomeDTO> GetAllForHome();
        RepairDTO Get(int repairId);

        int Add(RepairDTO repairDTO);

        int Update(RepairDTO repairDTO);

        bool Delete(int repairId);
    }
}