using BrownsIntranetApps.DTO;
using System.Collections.Generic;

namespace BrownsIntranetApps.BL.Interface
{
    public interface IPartBL
    {
        IEnumerable<PartDTO> GetParts(string partNumber, string searchMode);

        long Add(PartDTO part);

        long Update(PartDTO partDTO);

        long Delete(PartDTO partDTO);

        IEnumerable<PartDTO> GetReportDetails(PartDTO partDTO);
    }
}