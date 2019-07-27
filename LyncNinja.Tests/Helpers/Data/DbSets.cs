using LyncNinja.Data.EntityModels;
using System;
using System.Collections.Generic;

namespace LyncNinja.Tests.Helpers.Data
{
    public class DbSets
    {
        public static IEnumerable<LinkedResource> LinkedResources = new List<LinkedResource>
        {
            new LinkedResource { UID = 1, Url = "http://lync.ninja", Created = DateTime.UtcNow},
            new LinkedResource { UID = 2, Url = "thebeardeddevelopers.com", Created = DateTime.UtcNow},
            new LinkedResource { UID = 3, Url = "google.com", Created = DateTime.UtcNow},
        };
    }
}
