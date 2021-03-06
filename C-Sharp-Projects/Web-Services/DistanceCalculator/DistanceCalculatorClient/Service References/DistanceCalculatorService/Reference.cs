﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceCalculatorSoapClient.DistanceCalculatorService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Point", Namespace="http://schemas.datacontract.org/2004/07/DistanceCalculator")]
    [System.SerializableAttribute()]
    public partial class Point : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal YField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DistanceCalculatorService.IDistanceCalculator")]
    public interface IDistanceCalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceCalculator/CalcDistance", ReplyAction="http://tempuri.org/IDistanceCalculator/CalcDistanceResponse")]
        decimal CalcDistance(DistanceCalculatorSoapClient.DistanceCalculatorService.Point startPoint, DistanceCalculatorSoapClient.DistanceCalculatorService.Point endPoint);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceCalculator/CalcDistance", ReplyAction="http://tempuri.org/IDistanceCalculator/CalcDistanceResponse")]
        System.Threading.Tasks.Task<decimal> CalcDistanceAsync(DistanceCalculatorSoapClient.DistanceCalculatorService.Point startPoint, DistanceCalculatorSoapClient.DistanceCalculatorService.Point endPoint);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDistanceCalculatorChannel : global::DistanceCalculatorSoapClient.DistanceCalculatorService.IDistanceCalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DistanceCalculatorClient : System.ServiceModel.ClientBase<global::DistanceCalculatorSoapClient.DistanceCalculatorService.IDistanceCalculator>, global::DistanceCalculatorSoapClient.DistanceCalculatorService.IDistanceCalculator {
        
        public DistanceCalculatorClient() {
        }
        
        public DistanceCalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DistanceCalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public decimal CalcDistance(DistanceCalculatorSoapClient.DistanceCalculatorService.Point startPoint, DistanceCalculatorSoapClient.DistanceCalculatorService.Point endPoint) {
            return base.Channel.CalcDistance(startPoint, endPoint);
        }
        
        public System.Threading.Tasks.Task<decimal> CalcDistanceAsync(DistanceCalculatorSoapClient.DistanceCalculatorService.Point startPoint, DistanceCalculatorSoapClient.DistanceCalculatorService.Point endPoint) {
            return base.Channel.CalcDistanceAsync(startPoint, endPoint);
        }
    }
}
