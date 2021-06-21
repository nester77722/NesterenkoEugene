using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Order
    {
        public Order(int id, int userId, uint orderNumber, DateTime orderDate)
            : this(id, userId, orderNumber, orderDate, 0)
        {

        }
        public Order(int id, int userId, uint orderNumber, DateTime orderDate, uint total)
        {
            Id = id;
            UserId = userId;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Total = total;
        }
        public int Id { get; init; }
        public int UserId { get; init; }
        public uint OrderNumber { get; init; }
        public DateTime OrderDate { get; init; }
        public uint Total { get; set; }

        public override string ToString()
        {
            return $"{Id} {UserId} {OrderNumber} {OrderDate.ToShortDateString()} {Total}";
        }
    }
}
