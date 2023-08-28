using System;
using System.Collections.Generic;
using System.Linq;
using ProductCatalog.Client.Models;

namespace ProductCatalog.Client
{
    public static class ProductClient
    {
        // Static list to hold product data
        private static readonly List<Product> products = new()
        {
            // Initial product data
            // ... (product entries) ...
              new Product()
            {
                Id = 1,
                Name = "Black Canvas",
                Description = "Size 42",
                Price = 19.99M,
                ReleaseDate = new DateTime(2022, 3, 12)
            },
            new Product()
            {
                Id = 2,
                Name = "IRL Back Pack",
                Description = "Ultimate Black",
                Price = 11.99M,
                ReleaseDate = new DateTime(2022, 6, 12)
            },
            new Product()
            {
                Id = 3,
                Name = "Stray Kids Girl's backpack",
                Description = "Pink",
                Price = 25.99M,
                ReleaseDate = new DateTime(2022, 10, 12)
            },
            new Product()
            {
                Id = 4,
                Name = "Laptop Travel Backpack",
                Description = "15.6 Inch with USB Port",
                Price = 59.65M,
                ReleaseDate = new DateTime(2022, 5, 12)
            },
            new Product()
            {
                Id = 5,
                Name = "Black Canvas",
                Description = "Size 42",
                Price = 19.99M,
                ReleaseDate = new DateTime(2022, 7, 12)
            },
            new Product()
            {
                Id = 6,
                Name = "Korean Backpack",
                Description = "Blue + White",
                Price = 30.20M,
                ReleaseDate = new DateTime(2022, 9, 12)
            },
            new Product()
            {
                Id = 7,
                Name = "Decathlon Backpack",
                Description = "Black + White",
                Price = 70.50M,
                ReleaseDate = new DateTime(2023, 5, 1)
            }
        };

         

        // Get a product by its ID
        public static Product GetProduct(int id)
        {
            return products.FirstOrDefault(product => product.Id == id) ?? throw new Exception("Could not find Product!");
        }

        // Add a new product to the list
        public static void AddProduct(Product product)
        {
            product.Id = GenerateRandomId();
            products.Add(product);
        }

        // Generate a random ID for a new product
        private static int GenerateRandomId()
        {
            // Implementation of the random ID generation logic...
            // Generate a random 5-digit number for the ID
            Random random = new Random();
            int id = random.Next(10000, 99999);

            // Ensure the generated ID is unique
            while (products.Any(p => p.Id == id))
            {
                id = random.Next(10000, 99999);
            }

            return id;
        }

        // Update an existing product
        public static void UpdateProduct(Product updatedProduct)
        {
            Product existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.ReleaseDate = updatedProduct.ReleaseDate;
                existingProduct.Images = updatedProduct.Images;
            }
            else
            {
                throw new InvalidOperationException("Product not found.");
            }
        }

        // Get an array of all products
        public static Product[] GetProducts()
        {
            return products.ToArray();
        }

        // Delete a product by its ID
        public static void DeleteProduct(int id)
        {
            Product product = GetProduct(id);
            products.Remove(product);
        }

        // ... other methods ...
    }
}
