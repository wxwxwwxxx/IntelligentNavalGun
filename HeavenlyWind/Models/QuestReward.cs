﻿namespace Sakuno.KanColle.Amatsukaze.Models
{
    public abstract class QuestReward : ModelBase
    {
        public int Quantity { get; protected set; }

        public QuestReward(int rpQuantity)
        {
            Quantity = rpQuantity;
        }
    }
}
