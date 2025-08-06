namespace RestaurantHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> userOrderList = new List<string>();
            Console.WriteLine("Please enter the food items you would like to order. Type 'done' when finished.");
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    userOrderList.Add(input);

                }
            }

            Console.WriteLine("Choose a service type: (1) Online, (2) Delivery, (3) Dine-in");
            string serviceChoice = Console.ReadLine();

            IDelivery deliveryService;
            IReservation reservationService = null;

            switch (serviceChoice)
            {
                case "1":
                    deliveryService = new OnlineOrdering();

                    break;
                case "2":
                    deliveryService = new CourierDelivery();
                    break;
                case "3":
                    deliveryService = new DineInService();
                    reservationService = new TableReservation();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Dine-in.");
                    deliveryService = new DineInService();
                    reservationService = new TableReservation();
                    break;
            }

            IOrder userOrderObject = new CustomOrder(userOrderList);
            var myRestaurant = new Restaurant(userOrderObject, deliveryService, reservationService);
            myRestaurant.ProcessOrder();

        }

        public class Restaurant
        {
            private readonly IOrder order;
            private readonly IDelivery delivery;
            private readonly IReservation reservation;

            public Restaurant(IOrder order, IDelivery delivery, IReservation reservation)
            {
                this.order = order;
                this.delivery = delivery;
                this.reservation = reservation;
            }

            public void ProcessOrder()
            {
                order.Order();
                if (reservation != null)
                {
                    reservation.Reserve();
                }
                delivery.Deliver();
            }
        }

        public interface IReservation
        {
            public void Reserve();
        }

        public interface IOrder
        {
            public void Order();
        }

        public interface IDelivery
        {
            public void Deliver();
        }

        public class TableReservation : IReservation
        {
            public void Reserve()
            {
                Console.WriteLine("your reservation was successful");
            }
        }

        public class OnlineOrdering : IDelivery
        {
            public void Deliver()
            {
                Console.WriteLine("Order Submited.");
            }
        }

        public class DineInService : IDelivery
        {
            public void Deliver()
            {
                Console.WriteLine("Order in restaurant.");
            }
        }

        public class CourierDelivery : IDelivery
        {
            public void Deliver()
            {
                Console.WriteLine("your order is delivered.");
            }
        }

        public class CustomOrder : IOrder
        {
            private List<string> orderItems;

            public CustomOrder(List<string> items)
            {
                orderItems = items;
            }

            public void Order()
            {
                string orderDetails = $"User has ordered: {string.Join(", ", orderItems)}";
                Console.WriteLine(orderDetails);
            }
        }
    }
}
