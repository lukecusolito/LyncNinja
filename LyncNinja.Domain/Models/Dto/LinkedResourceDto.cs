using LyncNinja.Common.Utilities;
using Newtonsoft.Json;
using System;

namespace LyncNinja.Domain.Models.Dto
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LinkedResourceDto
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public string EncodedUrl { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        #region Public Methods
        /// <summary>
        /// Encodes the Key and generates an EncodedUrl
        /// </summary>
        /// <param name="encodedUrlBase"></param>
        public void EncodeKey(string encodedUrlBase)
        {
            Key = Base64.Encode(Id.ToString())?.Replace("=", string.Empty);
            EncodedUrl = encodedUrlBase + Key;
        }

        /// <summary>
        /// Decodes the Key and sets the Id
        /// </summary>
        public void DecodeKey()
        {
            Id = long.TryParse(Base64.Decode(Key), out long id) ? id : 0;
        }
        #endregion
    }
}
