﻿using PSMDataManagerMVC.Library.Api;
using PSMDataManagerMVC.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PSMDataManagerMVC.Models
{
    public class ProductViewModel
    {
        private IProductEndpoint _productEndpoint;

        private List<ProductModel> _products;

        public List<ProductModel> Products
        {
            get { return _products;  }
            set { _products = value; }
        }

        public ProductViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        public async Task LoadProducts()
        {
            var products = await _productEndpoint.GetAll();
            Products = new List<ProductModel>(products);
        }

        public async Task LoadProductById(int Id)
        {
            ProductModel products = await _productEndpoint.GetById(Id);
            Products = new List<ProductModel>();
            Products.Add(products);
        }

        public async Task LoadProductByCategory(int Id)
        {
            List<ProductModel> products = await _productEndpoint.GetByCategory(Id);
            Products = new List<ProductModel>(products);
        }

        public async Task LoadProductByBrand(int Id)
        {
            List<ProductModel> products = await _productEndpoint.GetByBrand(Id);
            Products = new List<ProductModel>(products);
        }

        public async Task InsertProduct(ProductModel newProduct)
        {
            await _productEndpoint.InsertNewProduct(newProduct);
        }
    }
}