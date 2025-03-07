using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Domain.ChatService;

public class ChatMessage : Entity<Guid>
{
    private ChatMessage() { }

    public string MessageContent { get; private set; }
    public Guid SenderId { get; private set; }
    public Guid ChatSessionId { get; private set; }

    public static ChatMessage Create(string message, Guid senderId, Guid chatSessionId)
    {
        var chatMessage = new ChatMessage
        {
            MessageContent = message,
            SenderId = senderId,
            ChatSessionId = chatSessionId,
            Id = Guid.NewGuid() 
        };
        return chatMessage;
    }
}
