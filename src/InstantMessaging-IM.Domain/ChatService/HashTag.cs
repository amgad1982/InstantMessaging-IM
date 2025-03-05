using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Domain.ChatService
{
    public class HashTag:ValueObject<Guid>
    {
        public string Tag { get; private set; }
        private HashTag()
        {
        }
        public static HashTag Create(string tag, Guid chatMessageId)
        {
            var hashTag = new HashTag
            {
                Tag = tag,
                Id = Guid.NewGuid()
            };
            return hashTag;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Tag;
        }
    }
    {
    }
}
