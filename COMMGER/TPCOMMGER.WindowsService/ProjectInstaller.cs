using NetFwTypeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading.Tasks;

namespace TPCOMMGER.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        WindowsServiceHelper logHelper;
        public ProjectInstaller()
        {
            InitializeComponent();
            logHelper = new WindowsServiceHelper("ProjectInstall");
        }

        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            {
                try
                {
                    NetFwAddPorts(ServiceHelper.SocketName, ServiceHelper.SocketPort);
                    logHelper.WriteSuccess($"名称({ServiceHelper.SocketName}) 端口({ServiceHelper.SocketPort}) 入站规则添加成功!!!");

                }catch(Exception ex)
                {
                    logHelper.WriteError($"添加规则失败:{ex.Message}");
                }
            }
            {
                ////将服务更改为允许桌面交互模式
                //ConnectionOptions coOptions = new ConnectionOptions();
                //coOptions.Impersonation = ImpersonationLevel.Impersonate;
                //ManagementScope mgmtScope = new System.Management.ManagementScope(@"root\CIMV2", coOptions);
                //mgmtScope.Connect();
                //ManagementObject wmiService;
                //wmiService = new ManagementObject("Win32_Service.Name='SocketService1'");
                //ManagementBaseObject InParam = wmiService.GetMethodParameters("Change");
                //InParam["DesktopInteract"] = true;
                //ManagementBaseObject OutParam = wmiService.InvokeMethod("Change", InParam, null);
            }
        }
        public void NetFwAddPorts(string name, int port)
        {
            //创建firewall管理类的实例  
            INetFwMgr netFwMgr = (INetFwMgr)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwMgr"));

            INetFwOpenPort objPort = (INetFwOpenPort)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FwOpenPort"));

            objPort.Name = name;
            objPort.Port = port;
            objPort.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            objPort.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            objPort.Enabled = true;

            bool exist = false;
            //加入到防火墙的管理策略  
            foreach (INetFwOpenPort mPort in netFwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts)
            {
                if (objPort == mPort)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist) netFwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(objPort);
        }
    }
}
