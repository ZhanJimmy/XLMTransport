using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TPCOMMGER.Framework;
using TPCOMMGER.Framework.Helper;
using TPCOMMGER.Framework.CusEnum;
using TPCOMMGER.Framework.Model;
using Newtonsoft.Json;
using TPCOMMGER.WindowsService.OperateSocket;
using System.Threading;

namespace TPCOMMGER.WindowsService
{
    public partial class CommgerService : ServiceBase
    {
        List<Tuple<PlcDataModel, List<PlcDetailDataModel>>> lsTupe = new List<Tuple<PlcDataModel, List<PlcDetailDataModel>>>();
        WindowsServiceHelper Helper;
        public CommgerService()
        {
            InitializeComponent();
            Helper = new WindowsServiceHelper(this);         
        }

        protected override void OnStart(string[] args)
        {
            InitPlc();
            if (lsTupe == null || lsTupe.Count == 0) return;
            foreach(var tupe in lsTupe)
            {
                var parent = tupe.Item1;
                TcpClientAdapter adapter = new TcpClientAdapter(tupe.Item1.IpAddress, tupe.Item1.Port);
                adapter.HandleSuccess = new Action<SocketEx>((client) =>
                {
                    while (true)
                    {
                        try
                        {

                        }catch(Exception ex)
                        {

                        }
                        Thread.Sleep(1000);
                    }
                });
                adapter.HandleDisconnect = new Action(() =>
                {

                });
                adapter.Run();
            }
        }

        private void InitPlc()
        {
            var pkeys = BaseIniHelper.ReadKeys(PathHelper.PTPlcData, SectionHelper.SPlc);
            if (pkeys == null || pkeys.Any() == false) return;
            foreach (var pk in pkeys)
            {
                var pjson = BaseIniHelper.Read(PathHelper.PTPlcData, SectionHelper.SPlc, pk);
                PlcDataModel pt = JsonConvert.DeserializeObject<PlcDataModel>(pjson);
                string ip = pt.IpAddress;
                var ckeys = BaseIniHelper.ReadKeys(PathHelper.PTPlcDetailData, ip);
                if (ckeys == null || ckeys.Any() == false) continue;
                List<PlcDetailDataModel> lsChild = new List<PlcDetailDataModel>();
                foreach (var ck in ckeys)
                {
                    var cjson = BaseIniHelper.Read(PathHelper.PTPlcDetailData, ip, ck);
                    PlcDetailDataModel ct = JsonConvert.DeserializeObject<PlcDetailDataModel>(cjson);
                    lsChild.Add(ct);
                }
                lsTupe.Add(Tuple.Create(pt, lsChild));
            }
        }

        protected override void OnStop()
        {
        }


    }
}
