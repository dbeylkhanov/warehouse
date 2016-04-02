﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using warehouse_app.Model;

namespace warehouse_app.ViewModel
{
    public class ProductViewModel : WindowViewModel
    {
        #region Private Members
        private readonly Product _product;
        //
        private DelegateCommand _addProductCommand;

        #endregion

        #region ctor

        public ProductViewModel()
        {
            this._product = new Product();
            Products = new List<Product>()
            {
                new Product() { Category= new Category() {Id=1, Name = "Сигареты"}, Id = 1, Name = "Winston" },
                new Product() { Category= new Category() {Id=2, Name = "Хлеб"}, Id = 2, Name = "Городской батон" }
            };
        }
        #endregion

        #region Commands

        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                {
                    _addProductCommand = new DelegateCommand(ExecuteAddProduct, CanExecuteAddProduct);
                }
                return _addProductCommand;
            }
        }

        private bool CanExecuteAddProduct()
        {
            // todo
            return true;
        }

        private void ExecuteAddProduct()
        {
            // todo
        }


        #endregion

        #region Public props

        public string Name
        {
            get { return _product.Name; }
            set { _product.Name = value; }
        }

        public Category Category
        {
            get { return _product.Category; }
            set { _product.Category = value; }
        }

        public IEnumerable<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        public AutoCompleteFilterPredicate<object> ProductFilter
        {
            get
            {
                return (searchText, obj) =>
                {
                    var product = obj as Product;
                    return product != null && (product.Name.ToLower().Contains(searchText.ToLower()) || (product.Category.Name.ToLower().Contains(searchText.ToLower())));
                };
            }
        }

        #endregion

    }
}