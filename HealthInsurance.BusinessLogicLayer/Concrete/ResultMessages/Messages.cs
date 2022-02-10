using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Abstract.IBases;
using HealthInsurance.EntityLayer.Concrete.Bases;

namespace HealthInsurance.BusinessLogicLayer.Concrete.ResultMessages
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductAddingWrong = "Ürün Eklenemedi!";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductsNotListed = "Ürünler Listelenemedi!";
        public static string ProductDeleted = "Ürün Silindi.";
        public static string ProductNotDeleted = "Ürün Silinemedi!";
        public static string ProductListedById = "Ürün Id ile Listelendi.";
        public static string ProductNotListedById = "Ürün Id ile Listelenemedi!";
        public static string ProductAddedAsync = "Ürün Asenkron Eklendi.";
        public static string ProductAddingAsycnWrong = "Ürün Asenkron Eklenemedi!";
        public static string OrdersListed = "Siparişler Listelendi.";
        public static string OrdersNotListed = "Siparişler Listelenemedi!";
    }
}
