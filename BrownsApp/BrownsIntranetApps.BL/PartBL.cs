using BrownsIntranetApps.BL.Interface;
using BrownsIntranetApps.Common;
using BrownsIntranetApps.DAL.UOW;
using BrownsIntranetApps.DTO;
using BrownsIntranetApps.Entity.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrownsIntranetApps.BL
{
    public class PartBL : IPartBL
    {
        private readonly BHEUnitOfWork _bheUOW;

        public PartBL()
        {
            BrownsAppDBEntities1 _bheDBContext = new BrownsAppDBEntities1();
            _bheUOW = new BHEUnitOfWork(_bheDBContext);
        }

        public IEnumerable<PartDTO> GetParts(string searchTerm, string searchMode)
        {
            // var parts = null;
            switch (searchMode)
            {
                case Constants.BYPARTNUMBER:
                    return GetPartsbyPartNumber(searchTerm);

                case Constants.BYPARTDESCRIPTION:
                    return GetPartsbyPartDescription(searchTerm);

                case Constants.BYMODEL:
                    return GetPartsbyModel(searchTerm);
            }
            return null;
        }

        public IEnumerable<PartDTO> GetReportDetails(PartDTO partDTO)
        {
            var parts = _bheUOW.PartsRepository.Query();

            if (!string.IsNullOrEmpty(partDTO.PartNumber))
                parts = parts.Where(x => x.PartNumber == partDTO.PartNumber);
            if (!string.IsNullOrEmpty(partDTO.Make) && partDTO.Make != "All")
                parts = parts.Where(x => x.Make == partDTO.Make);
            if (!string.IsNullOrEmpty(partDTO.Model))
                parts = parts.Where(x => x.Model == partDTO.Model);

            if (!string.IsNullOrEmpty(partDTO.PartDescription))
                parts = parts.Where(x => x.PartDescription.Contains(partDTO.PartDescription));
            if (!string.IsNullOrEmpty(partDTO.PartManual))
                parts = parts.Where(x => x.PartManual.Contains(partDTO.PartManual));
            if (!string.IsNullOrEmpty(partDTO.SerialNumberRange))
                parts = parts.Where(x => x.SerialNumberRange.Contains(partDTO.SerialNumberRange));

            return parts.ToList().ConvertAll(PartDTOMapper);
        }

        public long Add(PartDTO partDTO)
        {
            try
            {
                Part part = new Part()
                {
                    CompanyID = partDTO.CompanyID,
                    ListPrice = partDTO.ListPrice,
                    Make = partDTO.Make,
                    Model = partDTO.Model,
                    PartDescription = partDTO.PartDescription,
                    PartManual = partDTO.PartManual,
                    PartNumber = partDTO.PartNumber,
                    SerialNumberRange = partDTO.SerialNumberRange,
                    AddedBy = "Admin",
                    AddedDate = DateTime.Now,
                    IsDeleted = false
                };

                var partID = _bheUOW.PartsRepository.Add(part);
                _bheUOW.SaveChanges();
                return partID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Update(PartDTO partDTO)
        {
            long ID = -1;
            var existingPart = _bheUOW.PartsRepository.Query().SingleOrDefault(x => x.ID == partDTO.ID);
            if (existingPart != null)
            {
                existingPart.CompanyID = partDTO.CompanyID;
                existingPart.ListPrice = partDTO.ListPrice;
                existingPart.Make = partDTO.Make;
                existingPart.Model = partDTO.Model;
                existingPart.PartDescription = partDTO.PartDescription;
                existingPart.PartManual = partDTO.PartManual;
                existingPart.PartNumber = partDTO.PartNumber;
                existingPart.SerialNumberRange = partDTO.SerialNumberRange;
                existingPart.LastUpdatedBy = "Admin";
                existingPart.LastUpdatedDate = DateTime.Now;
                existingPart.IsDeleted = false;
                _bheUOW.SaveChanges();
                ID = existingPart.ID;
            }
            return ID;
        }

        public long Delete(PartDTO partDTO)
        {
            Part part = new Part()
            {
                CompanyID = partDTO.CompanyID,
                ListPrice = partDTO.ListPrice,
                Make = partDTO.Make,
                Model = partDTO.Model,
                PartDescription = partDTO.PartDescription,
                PartManual = partDTO.PartManual,
                PartNumber = partDTO.PartNumber,
                SerialNumberRange = partDTO.SerialNumberRange,
                ID = partDTO.ID
            };

            var partID = _bheUOW.PartsRepository.Delete(part);
            _bheUOW.SaveChanges();
            return partID;
        }

        #region Private Methods

        private IEnumerable<PartDTO> GetPartsbyModel(string model)
        {
            var parts = _bheUOW.PartsRepository
                        .Query()
                        .Where(x => x.Model.Contains(model))
                        .ToList().ConvertAll(PartDTOMapper);
            return parts;
        }

        private IEnumerable<PartDTO> GetPartsbyPartDescription(string partDescription)
        {
            var parts = _bheUOW.PartsRepository.Query().Where(x => x.PartDescription.Contains(partDescription));
            return parts.ToList().ConvertAll(PartDTOMapper);
        }

        private IEnumerable<PartDTO> GetPartsbyPartNumber(string partNumber)
        {
            var parts = _bheUOW.PartsRepository.Query().Where(x => x.PartNumber == partNumber);
            return parts.ToList().ConvertAll(PartDTOMapper);
        }

        private PartDTO PartDTOMapper(Part part)
        {
            return new PartDTO
            {
                CompanyID = part.CompanyID == null ? 0 : part.CompanyID,
                ID = part.ID,
                ListPrice = part.ListPrice,
                Make = part.Make,
                Model = part.Model,
                PartDescription = part.PartDescription,
                PartManual = part.PartManual,
                PartNumber = part.PartNumber,
                SerialNumberRange = part.SerialNumberRange
            };
        }

        #endregion Private Methods
    }
}