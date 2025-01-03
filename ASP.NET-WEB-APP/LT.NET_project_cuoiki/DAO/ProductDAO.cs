﻿using LT.NET_project_cuoiki.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace LT.NET_project_cuoiki.dao
{
    public class ProductDAO
    {
        public List<ProductEntity> getAllProduct()
        {
            List<ProductEntity> products = new List<ProductEntity>();

            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM product");
            foreach (DataRow r in d.Rows)
            {
                ProductEntity product = new ProductEntity();
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                product.Size = r["size"].ToString();
                product.Thumbnail = r["thumbnail"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());
                products.Add(product);
            }
            return products;
        }

        
         public List<ProductEntity> getProductByKey(string key)
        {
            List<ProductEntity> products = new List<ProductEntity>();

            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM product where Title like '%" + key + "%' ");
            foreach (DataRow r in d.Rows)
            {
                ProductEntity product = new ProductEntity();
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                product.Size = r["size"].ToString();
                product.Thumbnail = r["thumbnail"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());
                products.Add(product);
            }
            return products;
        }
        public ProductEntity getProductById(string id)
        {
            ProductEntity product = new ProductEntity();
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM product WHERE product.id = " + id);
            foreach (DataRow r in d.Rows)
            {
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                product.Size = r["size"].ToString();
                product.Thumbnail = r["thumbnail"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());

            }
            return product;
        }

        public string getCategoryName(String id)
        {
            string result = "";
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM category WHERE category.id = (SELECT category.parent_id FROM category  WHERE category.id = (SELECT product.category_id FROM product WHERE product.id = " + id + ")) ");
            foreach (DataRow r in d.Rows)
            {
                result = r["name"].ToString();
            }
            return result;
        }
        //public string getGem(String id)
        //{
        //    string result = "";
        //    ConnectionMysql c = new ConnectionMysql();
        //    var d = c.SQL_query_to_DataTable("SELECT* FROM category WHERE category.id = (SELECT product.category_id FROM product WHERE product.id = " + id + ")");
        //    foreach (DataRow r in d.Rows)
        //    {
        //        result = r["name"].ToString();
        //    }
        //    return result;
        //}
        public string getGem(String id)
        {
            string result = "";
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT* FROM category WHERE category.id = (SELECT product.category_id FROM product WHERE product.id = " + id + ")");
            foreach (DataRow r in d.Rows)
            {
                result = r["name"].ToString();
            }
            return result;
        }
        public string getGemColor(String id)
        {
            string result = "";
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM gem_color gc INNER JOIN product_gem_color pgc ON gc.id = pgc.color " +
                                                "WHERE pgc.id = " + id + ")");
            foreach (DataRow r in d.Rows)
            {
                result = r["color"].ToString();
            }
            return result;
        }
        public List<CategoryModel> loadCategoryModel()
        {
            List<CategoryModel> cates = new List<CategoryModel>();
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM category " +
                "WHERE parent_id IS NULL");
            foreach (DataRow r in d.Rows)
            {
                CategoryModel cate = new CategoryModel();
                cate.Id = Int32.Parse(r["id"].ToString());
                cate.Parent_id = 0;
                cate.Name = r["name"].ToString();
                cates.Add(cate);
            }
            return cates;
        }
        public List<ProductEntity> getProductByCate(int id)
        {
            List<ProductEntity> products = new List<ProductEntity>();
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT * FROM product INNER JOIN category ON product.category_id = category.id " +
                "WHERE category.parent_id = " + id);

            foreach (DataRow r in d.Rows)
            {
                ProductEntity product = new ProductEntity();
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                product.Size = r["size"].ToString();
                product.Thumbnail = r["thumbnail"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());
                products.Add(product);
            }
            return products;
        }
        public List<ProductEntity> Filter(String price, String color)
        {
            List<ProductEntity> products = new List<ProductEntity>();
            ConnectionMysql c = new ConnectionMysql();
            var d = c.SQL_query_to_DataTable("SELECT DISTINCT p.* FROM product p INNER JOIN product_gem_color pgc ON p.Id = pgc.product_id" +
                                                       $" INNER JOIN gem_color gc ON pgc.color = gc.id" +
                                                       $" INNER JOIN category c ON p.category_id = c.id WHERE c.name =" +
                                                       " AND p.price =" + price + " AND gc.color =" + color);
            foreach (DataRow r in d.Rows)
            {
                ProductEntity product = new ProductEntity();
                product.Id = Int32.Parse(r["id"].ToString());
                product.Category = r["category_id"].ToString();
                product.Title = r["title"].ToString();
                product.Keyword = r["keyword"].ToString();
                product.Price = Int32.Parse(r["price"].ToString());
                product.Size = r["size"].ToString();
                product.Description = r["description"].ToString();
                product.Quantity = Int32.Parse(r["quantity"].ToString());
                product.Is_on_sale = Int32.Parse(r["is_on_sale"].ToString());
                product.Color = r["color"].ToString();
                product.Img_link = r["image"].ToString();
                products.Add(product);
            }
            return products;
        }

    }
}