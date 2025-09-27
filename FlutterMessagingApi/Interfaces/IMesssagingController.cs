using FlutterMessaging.DTO;

namespace FlutterMessagingApi.Interfaces
{
    public interface IMesssagingController
    {

        public List<ConversationMessage> GetConversationMessages(Guid conversationId); 
        public List<Guid> GetConversationPartners (Guid conversationId); 
        public List<Conversation> GetConversationsForProfile(Guid profileId); 

    }
}
