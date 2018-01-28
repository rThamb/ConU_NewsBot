using IBM.WatsonDeveloperCloud.Conversation.v1;
using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConuHackSandbox
{
    public class Conversation
    {
        public Conversation()
        { }

        //Authenticate the Conversation Service
        public ConversationService AuthenticateConvo()
        {
            ConversationService conversation = new ConversationService();
            conversation.SetCredential("f96e4559-0d68-41a2-a31f-70e7be5f47d9", "eFXSrj2Ajw7m");
            conversation.VersionDate = DateTime.Today.ToString("yyyy-MM-dd");
            return conversation;
        }

        //List the workspaces by name
        public List<Workspace> ListWorkspaces(ConversationService conversation)
        {
            var result = conversation.ListWorkspaces();
            List<Workspace> workspaces = result.Workspaces;
            return workspaces;
        }

        //Interaction with chatbot
        public MessageResponse Messenger(ConversationService conversation, string input, string id)
        {
            //Create a message request
            MessageRequest message = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = input
                }
            };

            //Send a message to the conversation instance
            var result = conversation.Message(id, message);
            return result;
        }

        /*public void UpdateNewsDialog(ConversationService conversation, string input, string id)
        {

        }*/
    }
}
