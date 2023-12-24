using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TEST_CRUD.Data;
using TEST_CRUD.DTO.CartDTO;
using TEST_CRUD.DTO.OrderDTO;
using TEST_CRUD.Models;

namespace TEST_CRUD.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CyberSharkContext appDbContext;

        public OrderRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<GetOrderDto?> Add(AddOrderDto order)
        { 
            
            List<GetProductOrderDto> resultList = new List<GetProductOrderDto>();
            var cart = await appDbContext.Cart.FirstOrDefaultAsync(c => c.Customer_Id == order.Customer_Id);
            List<CartProductDto> cartDetail = JsonConvert.DeserializeObject<List<CartProductDto>>(cart.Cart_Detail);

            double? orderCost = 0.0;
            foreach (var item in order.ProductLists)
            {
                var productItem = await appDbContext.Product.FirstOrDefaultAsync(p => p.Id == item.Product_Id);
                int productIndex = cartDetail.FindIndex(cp => cp.Product_Id == item.Product_Id);
                if (item.Quantity > productItem.Quantity)
                {
                    return null;
                }
                else
                {
                    productItem.Quantity -= item.Quantity;
                    var addProduct = new GetProductOrderDto()
                    {
                        Product_Id = productItem.Id,
                        Product_Name = productItem.Name,
                        Quantity = item.Quantity,
                        Price = productItem.Sale_Price
                    };
                    resultList.Add(addProduct);
                    cartDetail.RemoveAt(productIndex);
                    cart.Cart_Number_Item -= addProduct.Quantity;
                    cart.Cart_Total -= addProduct.Price * addProduct.Quantity;
                    orderCost += addProduct.Price * addProduct.Quantity;

                }
            }
            string newJson = JsonConvert.SerializeObject(resultList, Newtonsoft.Json.Formatting.Indented);

            var newOrder = new Order()
            {
                Order_Number = order.Order_Number,
                Customer_Id = order.Customer_Id,
                Address_Id = order.Address_Id,
                Cost = orderCost,
                Order_Detail = newJson,
                Date_Created = DateTime.Now,
            };
            var addOrder = await appDbContext.Order.AddAsync(newOrder);
            string jsonCart = JsonConvert.SerializeObject(cartDetail, Newtonsoft.Json.Formatting.Indented);
            cart.Cart_Detail = jsonCart;
            await appDbContext.SaveChangesAsync();
            return new GetOrderDto()
            {
                Id = addOrder.Entity.Id,
                Order_Number = addOrder.Entity.Order_Number,
                Customer_Id = addOrder.Entity.Customer_Id,
                Address_Id = addOrder.Entity.Address_Id,
                Order_Detail = addOrder.Entity.Order_Detail,
                Cost = addOrder.Entity.Cost,
                Status = addOrder.Entity.Status,
            };
        }

        public async Task<GetOrderDto?> GetByCustomerId(int customerid)
        {
            var order = await appDbContext.Order.FirstOrDefaultAsync(od => od.Id == customerid);
            
            if (order == null)
            {
                return null;
            }
            return new GetOrderDto()
            {
                Id = order.Id,
                Order_Number = order.Order_Number,
                Customer_Id = order.Customer_Id,
                Address_Id = order.Address_Id,
                Order_Detail = order.Order_Detail,
                Cost = order.Cost,
                Status = order.Status,
            };
        }

        public async Task<GetOrderDto?> GetById(int id)
        {
            var order = await appDbContext.Order.FirstOrDefaultAsync(od => od.Id == id);

            if (order == null)
            {
                return null;
            }
            return new GetOrderDto()
            {
                Id = order.Id,
                Customer_Id = order.Customer_Id,
                Address_Id = order.Address_Id,
                Order_Detail = order.Order_Detail,
                Cost = order.Cost,
                Status = order.Status,
            };
        }

        public async Task<IEnumerable<GetOrderDto>> GetList(string search)
        {
            var orderList = appDbContext.Order.Where(od => od.IsDeleted != true);
            //// Filter Items has been Deleted /////////////////////
            List<GetOrderDto> resultList = new List<GetOrderDto>();
            //////// Search /////////////////////////
            ///
            if (!string.IsNullOrEmpty(search))
            {
                orderList = orderList.Where(od => od.Order_Number == search);
            }


            //var pageResult = 2f;  // The number of items in a page
            //var pageCount = Math.Ceiling(brandList.Count() / pageResult); // The number of items
            //brandList = brandList.Skip((page - 1) * (int) pageResult).Take((int)pageResult);
            foreach (var order in orderList)
            {
                var newOrderDto = new GetOrderDto()
                {
                    Id = order.Id,
                    Customer_Id = order.Customer_Id,
                    Address_Id = order.Address_Id,
                    Order_Detail = order.Order_Detail,
                    Cost = order.Cost,
                    Status = order.Status,
                };
                resultList.Add(newOrderDto);
            }
            return resultList;
        }

        public async Task<GetOrderDto> UpdateOrderStatus(int orderid, string status)
        {
            var order = await appDbContext.Order.FirstOrDefaultAsync(od => od.Id == orderid);
            if (order == null)
            {
                return null;
            }
            if(order.Status != "On Delivery" && status == "Cancel")
            {
                List<GetProductOrderDto> resultList = JsonConvert.DeserializeObject<List<GetProductOrderDto>>(order.Order_Detail);
                foreach (var item in resultList)
                {
                    var productItem = await appDbContext.Product.FirstOrDefaultAsync(p => p.Id == item.Product_Id);
                    productItem.Quantity += item.Quantity;
                }
            }
            order.Status = status;
            await appDbContext.SaveChangesAsync();
            //return order;
            return new GetOrderDto()
            {
                Id = order.Id,
                Customer_Id = order.Customer_Id,
                Address_Id = order.Address_Id,
                Order_Detail = order.Order_Detail,
                Cost = order.Cost,
                Status = order.Status,
            };
        }
    }
}
