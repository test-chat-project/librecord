using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lcmsgapi.Utils
{
    public class IdGen
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long UnixMillis()
        {
            return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }
    }
}
