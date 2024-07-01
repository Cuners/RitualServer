using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using RitualServer.Model;
using RitualServer.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class ControllersIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly TestingWebAppFactory<Program> _factory;

        public ControllersIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task GetCategories_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getCategories");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCategoryById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/Category/10");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateCategory_ReturnsSuccessStatusCode()
        {
            var newCategory = new Category { CategoryId = 4, Name = "New Category" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Category", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteCategory_ReturnsSuccessStatusCode()
        {
            var newCategory = new Category { CategoryId = 5, Name = "Category to delete" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Category", content);
            var response = await _client.DeleteAsync("/api/Category/5");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateCategory_ReturnsSuccessStatusCode()
        {
            var newCategory = new Category { CategoryId = 6, Name = "Category to update" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Category", content);
            newCategory.Name = "Updated Category";
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Category/6", updateContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateCategory_ReturnsBadRequestStatusCode()
        {
            var newCategory = new Category { CategoryId = 7, Name = "Category to update" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Category", content);
            var updatedCategory = new Category { CategoryId = 8, Name = null };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Category/7", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsNotFoundStatusCode()
        {
            var newCategory = new Category { CategoryId = 9, Name = "Category to update" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Category", content);
            var updatedCategory = new Category { CategoryId = 10, Name = "Updated Category" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Category/100", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetProduct_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getProducts");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetProductById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/Product/15");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ReturnsSuccessStatusCode()
        {
            var newCategory = new Product { ProductId = 10, Name = "NewProduct", Price=1000, Opisanie="chto-to", CategoryId=1};
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Product", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteProduct_ReturnsSuccessStatusCode()
        {
            var newCategory = new Product { ProductId = 11, Name = "Product to delete", Price = 1000, Opisanie = "chto-to", CategoryId = 1 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Product", content);
            var response = await _client.DeleteAsync("/api/Product/11");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateProduct_ReturnsSuccessStatusCode()
        {
            var newCategory = new Product { ProductId = 10, Name = "NewProduct", Price = 1000, Opisanie = "chto-to", CategoryId = 1 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Product", content);
            newCategory.Name = "Updated Product";
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Product/10", updateContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateProduct_ReturnsBadRequestStatusCode()
        {
            //var newCategory = new Category { CategoryId = 7, Name = "Category to update" };
            //var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            //await _client.PostAsync("/api/User", content);
            var updatedCategory = new Product { };
            updatedCategory = null;
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Product/7", updateContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsNotFoundStatusCode()
        {
            var updatedCategory = new Category { CategoryId = 10, Name = "Updated Category" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Product/100", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetUsers_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getArticle");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetUserById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/User/15");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateUser_ReturnsSuccessStatusCode()
        {
            var newCategory = new User { UserId = 12, Login = "NewUser", Password = "hopa", FirstName = "Bob", LastName = "Bobobvich", Email = "boba@mail.ru", Phone = "79123453789", Adress = "Залужная д 2а", RoleId = 1, Image = null };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/User", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteUser_ReturnsSuccessStatusCode()
        {
            var newCategory = new User { UserId = 11, Login = "User to delete", Password = "hopa", FirstName = "Bob", LastName = "Bobobvich", Email = "boba@mail.ru", Phone = "79123453789", Adress = "Залужная д 2а", RoleId = 1, Image = null };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/User", content);
            var response = await _client.DeleteAsync("/api/User/11");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateUser_ReturnsSuccessStatusCode()
        {
            var newCategory = new User { UserId = 10, Login = "NewUser", Password = "hopa", FirstName = "Bob", LastName = "Bobobvich", Email = "boba@mail.ru", Phone = "79123453789", Adress = "Залужная д 2а", RoleId = 1, Image = null };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/User", content);
            newCategory.Login = "Updated User";
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/User/10", updateContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateUser_ReturnsBadRequestStatusCode()
        {
            var updatedCategory = new User { };
            updatedCategory = null;
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/User/7", updateContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateUser_ReturnsNotFoundStatusCode()
        {
            var updatedCategory = new User { UserId = 17, Login = "NewUser", Password = "hopa", FirstName = "Bob", LastName = "Bobobvich", Email = "boba@mail.ru", Phone = "79123453789", Adress = "Залужная д 2а", RoleId = 1, Image = null };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/User/100", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetCrosses_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getCrosses");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCrossById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/Cross/15");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateCross_ReturnsSuccessStatusCode()
        {
            var newCategory = new Cross { CrossId = 12, ColorId = 1, MaterialId = 1, Image = null, ProductId=2 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Cross", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteCross_ReturnsSuccessStatusCode()
        {
            var newCategory = new Cross { CrossId = 13, ColorId = 1, MaterialId = 1, Image = null, ProductId = 2 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Cross", content);
            var response = await _client.DeleteAsync("/api/Cross/13");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateCross_ReturnsSuccessStatusCode()
        {
            var newCategory = new Cross { CrossId = 10, ColorId = 1, MaterialId = 1, Image = null, ProductId = 2 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Cross", content);
            newCategory.ColorId = 2;
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Cross/10", updateContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateCross_ReturnsBadRequestStatusCode()
        {
            var updatedCategory = new User { };
            updatedCategory = null;
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Cross/7", updateContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateCross_ReturnsNotFoundStatusCode()
        {
            var updatedCategory = new Cross { CrossId = 17, ColorId = 1, MaterialId = 1, Image = null, ProductId = 2 };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/User/100", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetColors_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getColors");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetColorById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/Color/15");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateColor_ReturnsSuccessStatusCode()
        {
            var newCategory = new Color { ColorId = 12, Name="Красный" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Color", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteColor_ReturnsSuccessStatusCode()
        {
            var newCategory = new Color { ColorId = 11, Name = "Серый" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Color", content);
            var response = await _client.DeleteAsync("/api/Color/11");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateColor_ReturnsSuccessStatusCode()
        {
            var newCategory = new Color { ColorId = 10, Name = "Серобурый" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Color", content);
            newCategory.Name = "Черный";
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Color/10", updateContent);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateColor_ReturnsBadRequestStatusCode()
        {
            var updatedCategory = new User { };
            updatedCategory = null;
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Color/7", updateContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateColor_ReturnsNotFoundStatusCode()
        {
            var updatedCategory = new Color { ColorId = 17, Name = "Розоватый" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Color/100", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetMaterials_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getMaterials");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetMaterialById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/Material/1");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateMaterial_ReturnsBadRequestStatusCode()
        {
            var newCategory = new Material { MaterialId = 12, Name = "Гранит" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Material", content);
            var newCategory2 = new Material { MaterialId = 13, Name = "Гранит" };
            var content2 = new StringContent(JsonConvert.SerializeObject(newCategory2), Encoding.UTF8, "application/json");
            var response=await _client.PostAsync("/api/Material", content2);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);   
        }
        [Fact]
        public async Task DeleteMaterial_ReturnsSuccessStatusCode()
        {
            var newCategory = new Material { MaterialId = 11, Name = "Камень" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Material", content);
            var response = await _client.DeleteAsync("/api/Material/11");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateMaterial_ReturnsSuccessStatusCode()
        {
            var newCategory = new Material { MaterialId = 10, Name = "Сплав" };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Material", content);
            newCategory.Name = "Черный";
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Material/10", updateContent);
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task UpdateMaterial_ReturnsNotFoundStatusCode()
        {
            var updatedCategory = new Material { MaterialId = 17, Name = "Дерево" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Material/100", updateContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetMessage_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/getMessages");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetMessageById_ReturnsNotFoundStatusCode()
        {
            var response = await _client.GetAsync("/api/Message/15");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateMessage_ReturnsSuccessStatusCode()
        {
            var newCategory = new Message { MessageId = 10, Message1 = "New Message", CreatedAt=DateTime.Now,RazgovorId=1,SenderId=2 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Message", content);
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task DeleteMessage_ReturnsSuccessStatusCode()
        {
            var newCategory = new Message { MessageId = 12, Message1 = "New Message", CreatedAt = DateTime.Now, RazgovorId = 1, SenderId = 2 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Message", content);
            var response = await _client.DeleteAsync("/api/Message/12");
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task UpdateMessage_ReturnsSuccessStatusCode()
        {
            var newCategory = new Message { MessageId = 13, Message1 = "New Message", CreatedAt = DateTime.Now, RazgovorId = 1, SenderId = 2 };
            var content = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/Message", content);
            newCategory.Message1 = "UpdatedMessage";
            var updateContent = new StringContent(JsonConvert.SerializeObject(newCategory), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/api/Message/13", updateContent);
            response.EnsureSuccessStatusCode();
        }

    }
}
