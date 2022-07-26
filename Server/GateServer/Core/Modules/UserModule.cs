﻿using Evt;
using GateServer.Services;
using Net;
using Net.Pt;
using Net.ServiceImpl;
using Notify;
using ServerDll.Service.Modules;
using Service.Core;
using Service.Event;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GateServer.Modules
{
    public class UserModule:BaseModule
    {
        internal class A { }
        public UserModule(BaseApplication app):base(app)
        {
            EventMgr<RequestMessageId, UnconnectedNetMessageEvt>.AddListener(RequestMessageId.UGS_SearchAvailableGate, OnSearchAvailableGate);          
        }

        void OnSearchAvailableGate(UnconnectedNetMessageEvt evt)
        {
            PtSearchHostResult result = new PtSearchHostResult();
            result.connectKey = ApplicationInstance.GetApplicationKey();
            result.hashCode = ApplicationInstance.GetHashCode();
            evt.Reply(GetNetManager(), PtMessagePackage.Write(PtMessagePackage.Build((int)ResponseMessageId.UGS_SearchAvailableGate, PtSearchHostResult.Write(result))));         
        }     
    }
}