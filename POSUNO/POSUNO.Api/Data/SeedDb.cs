using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSUNO.Api.Data.Entities;

namespace POSUNO.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUserAsync();
            await CheckCustomersAsync();
            await CheckProductsAsync();

        }
        private async Task CheckUserAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User { Email = "uno@yopmail.com", FirstName = "javier", LastName = "quintero", Password = "123456" });
                _context.Users.Add(new User { Email = "dos@yopmail.com", FirstName = "tomas", LastName = "quintero", Password = "123456" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 1; i <= 200 ; i++)
                {
                    _context.Products.Add(new Product
                    {
                        Name= $"Producto{i}", Description= $"Producto{i}", Price=new Random().Next(5,1000), Stock=new Random().Next(0,500), User = user,
                        IsActive = true
                    });
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCustomersAsync()
        {
            if (!_context.Products.Any())
            {
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 1; i <= 50; i++)
                {
                    _context.Customers.Add(new Customer
                    {
                       FirstName=$"Cliente{i}", LastName=$"Apellido{i}", PhoneNumber="12345678", Address="7th Street", IsActive= true, User= user, Email=$"Cliente{i}@yopmail.com"
                        
                    });
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
