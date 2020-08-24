using System;
using Store.Domain.StoreContext.Enums;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }


        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
        
        public void Ship()
        {
            //if(EstimatedDeliveryDate < DateTime.now)
            Status = EDeliveryStatus.Shipped;
        } 

        public void Cancel()
        {
            //Se o status ja estiver entregue não podemos cancelar
            Status = EDeliveryStatus.Canceled;
            
        }
    }
}