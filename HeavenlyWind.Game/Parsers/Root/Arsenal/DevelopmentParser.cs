﻿using Sakuno.KanColle.Amatsukaze.Game.Models;
using Sakuno.KanColle.Amatsukaze.Game.Models.Raw;

namespace Sakuno.KanColle.Amatsukaze.Game.Parsers.Root.Arsenal
{
    [Api("api_req_kousyou/createitem")]
    class DevelopmentParser : ApiParser<RawEquipmentDevelopment>
    {
        public override void Process(RawEquipmentDevelopment rpData)
        {
            var rFuelConsumption = int.Parse(Requests["api_item1"]);
            var rBulletConsumption = int.Parse(Requests["api_item2"]);
            var rSteelConsumption = int.Parse(Requests["api_item3"]);
            var rBauxiteConsumption = int.Parse(Requests["api_item4"]);

            string rLogContent;
            if (!rpData.Success)
                rLogContent = StringResources.Instance.Main.Log_Development_Failure;
            else
            {
                Game.Port.AddEquipment(new Equipment(new RawEquipment() { ID = rpData.Result.ID, EquipmentID = rpData.Result.EquipmentID }));

                rLogContent = string.Format(StringResources.Instance.Main.Log_Development_Success,
                    Game.MasterInfo.Equipments[rpData.Result.ID].Name, rFuelConsumption, rBulletConsumption, rSteelConsumption, rBauxiteConsumption);
            }

            Logger.Write(LoggingLevel.Info, rLogContent);
        }
    }
}