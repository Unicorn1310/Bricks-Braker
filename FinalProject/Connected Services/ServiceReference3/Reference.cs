﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.28307.960
// 
namespace FinalProject.ServiceReference3 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference3.CreditCSoap")]
    public interface CreditCSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.HelloWorldResponse> HelloWorldAsync(FinalProject.ServiceReference3.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddCard", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.AddCardResponse> AddCardAsync(FinalProject.ServiceReference3.AddCardRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsCardExists", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.IsCardExistsResponse> IsCardExistsAsync(FinalProject.ServiceReference3.IsCardExistsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsAddable", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.IsAddableResponse> IsAddableAsync(FinalProject.ServiceReference3.IsAddableRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/hiuv", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.hiuvResponse> hiuvAsync(FinalProject.ServiceReference3.hiuvRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cancel", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.cancelResponse> cancelAsync(FinalProject.ServiceReference3.cancelRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(FinalProject.ServiceReference3.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(FinalProject.ServiceReference3.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddCardRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddCard", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.AddCardRequestBody Body;
        
        public AddCardRequest() {
        }
        
        public AddCardRequest(FinalProject.ServiceReference3.AddCardRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddCardRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cardNum;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string expired;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int cvv;
        
        public AddCardRequestBody() {
        }
        
        public AddCardRequestBody(string cardNum, string expired, int cvv) {
            this.cardNum = cardNum;
            this.expired = expired;
            this.cvv = cvv;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddCardResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddCardResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.AddCardResponseBody Body;
        
        public AddCardResponse() {
        }
        
        public AddCardResponse(FinalProject.ServiceReference3.AddCardResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class AddCardResponseBody {
        
        public AddCardResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsCardExistsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsCardExists", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.IsCardExistsRequestBody Body;
        
        public IsCardExistsRequest() {
        }
        
        public IsCardExistsRequest(FinalProject.ServiceReference3.IsCardExistsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsCardExistsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cardNum;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string expired;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int cvv;
        
        public IsCardExistsRequestBody() {
        }
        
        public IsCardExistsRequestBody(string cardNum, string expired, int cvv) {
            this.cardNum = cardNum;
            this.expired = expired;
            this.cvv = cvv;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsCardExistsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsCardExistsResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.IsCardExistsResponseBody Body;
        
        public IsCardExistsResponse() {
        }
        
        public IsCardExistsResponse(FinalProject.ServiceReference3.IsCardExistsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsCardExistsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool IsCardExistsResult;
        
        public IsCardExistsResponseBody() {
        }
        
        public IsCardExistsResponseBody(bool IsCardExistsResult) {
            this.IsCardExistsResult = IsCardExistsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsAddableRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsAddable", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.IsAddableRequestBody Body;
        
        public IsAddableRequest() {
        }
        
        public IsAddableRequest(FinalProject.ServiceReference3.IsAddableRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsAddableRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cardNum;
        
        public IsAddableRequestBody() {
        }
        
        public IsAddableRequestBody(string cardNum) {
            this.cardNum = cardNum;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsAddableResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsAddableResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.IsAddableResponseBody Body;
        
        public IsAddableResponse() {
        }
        
        public IsAddableResponse(FinalProject.ServiceReference3.IsAddableResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class IsAddableResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool IsAddableResult;
        
        public IsAddableResponseBody() {
        }
        
        public IsAddableResponseBody(bool IsAddableResult) {
            this.IsAddableResult = IsAddableResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class hiuvRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="hiuv", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.hiuvRequestBody Body;
        
        public hiuvRequest() {
        }
        
        public hiuvRequest(FinalProject.ServiceReference3.hiuvRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class hiuvRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cardNum;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string expierd;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int cvv;
        
        public hiuvRequestBody() {
        }
        
        public hiuvRequestBody(string cardNum, string expierd, int cvv) {
            this.cardNum = cardNum;
            this.expierd = expierd;
            this.cvv = cvv;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class hiuvResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="hiuvResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.hiuvResponseBody Body;
        
        public hiuvResponse() {
        }
        
        public hiuvResponse(FinalProject.ServiceReference3.hiuvResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class hiuvResponseBody {
        
        public hiuvResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class cancelRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="cancel", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.cancelRequestBody Body;
        
        public cancelRequest() {
        }
        
        public cancelRequest(FinalProject.ServiceReference3.cancelRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class cancelRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cardNum;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string expierd;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int cvv;
        
        public cancelRequestBody() {
        }
        
        public cancelRequestBody(string cardNum, string expierd, int cvv) {
            this.cardNum = cardNum;
            this.expierd = expierd;
            this.cvv = cvv;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class cancelResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="cancelResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalProject.ServiceReference3.cancelResponseBody Body;
        
        public cancelResponse() {
        }
        
        public cancelResponse(FinalProject.ServiceReference3.cancelResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class cancelResponseBody {
        
        public cancelResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CreditCSoapChannel : FinalProject.ServiceReference3.CreditCSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreditCSoapClient : System.ServiceModel.ClientBase<FinalProject.ServiceReference3.CreditCSoap>, FinalProject.ServiceReference3.CreditCSoap {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CreditCSoapClient() : 
                base(CreditCSoapClient.GetDefaultBinding(), CreditCSoapClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.CreditCSoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CreditCSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(CreditCSoapClient.GetBindingForEndpoint(endpointConfiguration), CreditCSoapClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CreditCSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CreditCSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CreditCSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CreditCSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CreditCSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.HelloWorldResponse> FinalProject.ServiceReference3.CreditCSoap.HelloWorldAsync(FinalProject.ServiceReference3.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalProject.ServiceReference3.HelloWorldResponse> HelloWorldAsync() {
            FinalProject.ServiceReference3.HelloWorldRequest inValue = new FinalProject.ServiceReference3.HelloWorldRequest();
            inValue.Body = new FinalProject.ServiceReference3.HelloWorldRequestBody();
            return ((FinalProject.ServiceReference3.CreditCSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.AddCardResponse> FinalProject.ServiceReference3.CreditCSoap.AddCardAsync(FinalProject.ServiceReference3.AddCardRequest request) {
            return base.Channel.AddCardAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalProject.ServiceReference3.AddCardResponse> AddCardAsync(string cardNum, string expired, int cvv) {
            FinalProject.ServiceReference3.AddCardRequest inValue = new FinalProject.ServiceReference3.AddCardRequest();
            inValue.Body = new FinalProject.ServiceReference3.AddCardRequestBody();
            inValue.Body.cardNum = cardNum;
            inValue.Body.expired = expired;
            inValue.Body.cvv = cvv;
            return ((FinalProject.ServiceReference3.CreditCSoap)(this)).AddCardAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.IsCardExistsResponse> FinalProject.ServiceReference3.CreditCSoap.IsCardExistsAsync(FinalProject.ServiceReference3.IsCardExistsRequest request) {
            return base.Channel.IsCardExistsAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalProject.ServiceReference3.IsCardExistsResponse> IsCardExistsAsync(string cardNum, string expired, int cvv) {
            FinalProject.ServiceReference3.IsCardExistsRequest inValue = new FinalProject.ServiceReference3.IsCardExistsRequest();
            inValue.Body = new FinalProject.ServiceReference3.IsCardExistsRequestBody();
            inValue.Body.cardNum = cardNum;
            inValue.Body.expired = expired;
            inValue.Body.cvv = cvv;
            return ((FinalProject.ServiceReference3.CreditCSoap)(this)).IsCardExistsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.IsAddableResponse> FinalProject.ServiceReference3.CreditCSoap.IsAddableAsync(FinalProject.ServiceReference3.IsAddableRequest request) {
            return base.Channel.IsAddableAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalProject.ServiceReference3.IsAddableResponse> IsAddableAsync(string cardNum) {
            FinalProject.ServiceReference3.IsAddableRequest inValue = new FinalProject.ServiceReference3.IsAddableRequest();
            inValue.Body = new FinalProject.ServiceReference3.IsAddableRequestBody();
            inValue.Body.cardNum = cardNum;
            return ((FinalProject.ServiceReference3.CreditCSoap)(this)).IsAddableAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.hiuvResponse> FinalProject.ServiceReference3.CreditCSoap.hiuvAsync(FinalProject.ServiceReference3.hiuvRequest request) {
            return base.Channel.hiuvAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalProject.ServiceReference3.hiuvResponse> hiuvAsync(string cardNum, string expierd, int cvv) {
            FinalProject.ServiceReference3.hiuvRequest inValue = new FinalProject.ServiceReference3.hiuvRequest();
            inValue.Body = new FinalProject.ServiceReference3.hiuvRequestBody();
            inValue.Body.cardNum = cardNum;
            inValue.Body.expierd = expierd;
            inValue.Body.cvv = cvv;
            return ((FinalProject.ServiceReference3.CreditCSoap)(this)).hiuvAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalProject.ServiceReference3.cancelResponse> FinalProject.ServiceReference3.CreditCSoap.cancelAsync(FinalProject.ServiceReference3.cancelRequest request) {
            return base.Channel.cancelAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalProject.ServiceReference3.cancelResponse> cancelAsync(string cardNum, string expierd, int cvv) {
            FinalProject.ServiceReference3.cancelRequest inValue = new FinalProject.ServiceReference3.cancelRequest();
            inValue.Body = new FinalProject.ServiceReference3.cancelRequestBody();
            inValue.Body.cardNum = cardNum;
            inValue.Body.expierd = expierd;
            inValue.Body.cvv = cvv;
            return ((FinalProject.ServiceReference3.CreditCSoap)(this)).cancelAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.CreditCSoap)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.CreditCSoap)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:57512/CreditC.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return CreditCSoapClient.GetBindingForEndpoint(EndpointConfiguration.CreditCSoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return CreditCSoapClient.GetEndpointAddress(EndpointConfiguration.CreditCSoap);
        }
        
        public enum EndpointConfiguration {
            
            CreditCSoap,
        }
    }
}
