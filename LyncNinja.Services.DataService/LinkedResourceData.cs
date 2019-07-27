using LyncNinja.Data.EntityModels;
using LyncNinja.Data.Mappings;
using LyncNinja.Domain.Models.Dto;
using LyncNinja.Services.Interfaces.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LyncNinja.Services.DataService
{
    public class LinkedResourceData : ILinkedResourceData
    {
        #region Fields
        private readonly LyncNinjaContext _dbContext;
        private readonly ILogger<LinkedResource> _logger;
        #endregion

        #region Constructor
        public LinkedResourceData(LyncNinjaContext dbContext, ILogger<LinkedResource> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves a linked resource by id
        /// </summary>
        /// <param name="linkedResourceId"></param>
        /// <returns></returns>
        public LinkedResourceDto Get(long linkedResourceId)
        {
            try
            {
                var entity = _dbContext
                    .LinkedResources
                    .SingleOrDefault(x =>
                        x.UID == linkedResourceId);

                return Mappings.Map(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Retrieves a linked resource by un-encoded URL
        /// </summary>
        /// <param name="linkedResourceUrl"></param>
        /// <returns></returns>
        public LinkedResourceDto Get(string linkedResourceUrl)
        {
            try
            {
                var entity = _dbContext
                    .LinkedResources
                    .SingleOrDefault(x =>
                        x.Url.Equals(linkedResourceUrl, StringComparison.OrdinalIgnoreCase));

                return Mappings.Map(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Persists a linked resource
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public LinkedResourceDto Save(LinkedResourceDto dto)
        {
            try
            {
                var entity = new LinkedResource();

                if (dto.Id > 0)
                    entity = _dbContext.LinkedResources.SingleOrDefault(x => x.UID == dto.Id);
                else
                    _dbContext.LinkedResources.Add(entity);

                // Commit
                Mappings.Map(ref entity, dto);
                _dbContext.SaveChanges();

                return Mappings.Map(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return null;
        }
        #endregion
    }
}
