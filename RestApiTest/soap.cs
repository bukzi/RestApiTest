
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
//using System.Threading.Tasks;

namespace RestApiTest
{
    class soap
    {

        public class ServerMessageLogger : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                return null;
            }

            public void BeforeSendReply(ref Message reply, object correlationState)
            {

                WebOperationContext ctx = WebOperationContext.Current;
                //ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                if (ctx.IncomingRequest.Method == "OPTIONS")
                {
                    ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST, PUT, DELETE");

                    ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
                    ctx.OutgoingResponse.Headers.Add("Access-Control-Max-Age", "1728000");
                }
            }
        }
        public class ClientMessageLogger : IClientMessageInspector
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
            }

            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                return null;
            }
        }
        [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false)]
        public class CustContractBehaviorAttribute : Attribute, IContractBehavior, IContractBehaviorAttribute
        {
            public Type TargetContract => throw new NotImplementedException();

            public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
                return;
            }

            public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                //clientRuntime.ClientMessageInspectors.Add(new ClientMessageLogger());
            }

            public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
            {
                dispatchRuntime.MessageInspectors.Add(new ServerMessageLogger());
            }

            public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
            {
                return;
            }
        }
    }
}
