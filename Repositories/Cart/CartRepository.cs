using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using TEST_CRUD.Data;
using TEST_CRUD.DTO.CartDTO;
using TEST_CRUD.Models;

namespace TEST_CRUD.Repositories.Carts
{
    public class CartRepository : ICartRepository
    {
        private readonly CyberSharkContext appDbContext;

        public CartRepository(CyberSharkContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<GetCartDto?> AddCart(AddCartDto cart)
        {
            var product = await appDbContext.Product.FirstOrDefaultAsync(p => p.Id == cart.Product_Id);
            var customerCart = await appDbContext.Cart.FirstOrDefaultAsync(c => c.Customer_Id == cart.Customer_Id);
            List<CartProductDto> resultList;
            if (customerCart == null)
            {
                customerCart = new Cart()
                {
                    Customer_Id = cart.Customer_Id,
                    Cart_Total = 0,
                    Cart_Number_Item = 0,
                    Cart_Detail = "[]",
                    Date_Created = DateTime.Now,
                    Date_Deleted = null,
                    Date_Modified = DateTime.Now,
                };
                resultList = JsonConvert.DeserializeObject<List<CartProductDto>>(customerCart.Cart_Detail);
                resultList.Add(new CartProductDto()
                {
                    Product_Id = product.Id,
                    Product_Name = product.Name,
                    Quantity = cart.Quantity,
                    Price = product.Sale_Price
                });
                var addCart = await appDbContext.Cart.AddAsync(customerCart);
            }
            else
            {
                resultList = JsonConvert.DeserializeObject<List<CartProductDto>>(customerCart.Cart_Detail);
                int productIndex = resultList.FindIndex(cp => cp.Product_Id == cart.Product_Id);
                if (productIndex == -1)
                {
                    resultList.Add(new CartProductDto()
                    {
                        Product_Id = product.Id,
                        Product_Name = product.Name,
                        Quantity = cart.Quantity,
                        Price = product.Sale_Price
                    });
                }
                else
                {
                    // cập nhật số lượng +1
                    resultList[productIndex].Quantity += cart.Quantity;
                }
                // parse string của cartdetail sang dạng list 

            }
            string newJson = JsonConvert.SerializeObject(resultList, Newtonsoft.Json.Formatting.Indented);
            customerCart.Cart_Number_Item += cart.Quantity;
            customerCart.Cart_Total += product.Sale_Price * cart.Quantity;
            customerCart.Cart_Detail = newJson;
            await appDbContext.SaveChangesAsync();
            return new GetCartDto()
            {
                Id = customerCart.Id,
                Customer_Id = customerCart.Customer_Id,
                Cart_Detail = customerCart.Cart_Detail,
                Cart_Number_Item = customerCart.Cart_Number_Item,
                Cart_Total = customerCart.Cart_Total,
            };
        }
        public async Task<GetCartDto?> UpdateCart(AddCartDto cart)
        {
            // lay thong tin san pham
            var product = await appDbContext.Product.FirstOrDefaultAsync(p => p.Id == cart.Product_Id);
            // lay thong tin cart
            var customerCart = await appDbContext.Cart.FirstOrDefaultAsync(c => c.Customer_Id == cart.Customer_Id);
            List<CartProductDto> resultList = JsonConvert.DeserializeObject<List<CartProductDto>>(customerCart.Cart_Detail);
            
            int productIndex = resultList.FindIndex(cp => cp.Product_Id == cart.Product_Id);
           
            var oldQuantity = resultList[productIndex].Quantity;
            var oldPrice = resultList[productIndex].Price * oldQuantity;
            // cập nhật lại số lượng
            resultList[productIndex].Quantity = cart.Quantity;
            

            // cập nhật lại các thông tin trong giò hàng
            string newJson = JsonConvert.SerializeObject(resultList, Newtonsoft.Json.Formatting.Indented);
            customerCart.Cart_Detail = newJson;
            customerCart.Cart_Total = customerCart.Cart_Total - oldPrice + resultList[productIndex].Price * resultList[productIndex].Quantity;
            customerCart.Cart_Number_Item = customerCart.Cart_Number_Item - oldQuantity + resultList[productIndex].Quantity; 
            await appDbContext.SaveChangesAsync();
            return new GetCartDto()
            {
                Id = customerCart.Id,
                Customer_Id = customerCart.Customer_Id,
                Cart_Detail = customerCart.Cart_Detail,
                Cart_Number_Item = customerCart.Cart_Number_Item,
                Cart_Total = customerCart.Cart_Total
            };
        }
        public async Task<GetCartDto?> DeleteItemInCart(int customerId, int productId)
        {
            // lay thong tin san pham
            var product = await appDbContext.Product.FirstOrDefaultAsync(p => p.Id == productId);
            // lay thong tin cart
            var customerCart = await appDbContext.Cart.FirstOrDefaultAsync(c => c.Customer_Id == customerId);
            List<CartProductDto> resultList = JsonConvert.DeserializeObject<List<CartProductDto>>(customerCart.Cart_Detail);

            int productIndex = resultList.FindIndex(cp => cp.Product_Id == productId);
            
            var oldQuantity = resultList[productIndex].Quantity;
            var oldPrice = resultList[productIndex].Price * oldQuantity;

            resultList.RemoveAt(productIndex);

            // cập nhật lại các thông tin trong giò hàng
            string newJson = JsonConvert.SerializeObject(resultList, Newtonsoft.Json.Formatting.Indented);
            customerCart.Cart_Detail = newJson;
            customerCart.Cart_Total = customerCart.Cart_Total - oldPrice;
            customerCart.Cart_Number_Item = customerCart.Cart_Number_Item - oldQuantity;
            await appDbContext.SaveChangesAsync();
            return new GetCartDto()
            {
                Id = customerCart.Id,
                Customer_Id = customerCart.Customer_Id,
                Cart_Detail = customerCart.Cart_Detail,
                Cart_Number_Item = customerCart.Cart_Number_Item,
                Cart_Total = customerCart.Cart_Total
            };
        }
        public async Task<GetCartDto?> GetCart(int customerId)
        {
            var cart = await appDbContext.Cart.FirstOrDefaultAsync(c => c.Customer_Id == customerId);

            if(cart == null)
            {
                return null;
            }
            return new GetCartDto()
            {
                Id = cart.Id,
                Customer_Id = cart.Customer_Id,
                Cart_Detail = cart.Cart_Detail,
                Cart_Number_Item = cart.Cart_Number_Item,
                Cart_Total = cart.Cart_Total
            };
        }

    }
}
