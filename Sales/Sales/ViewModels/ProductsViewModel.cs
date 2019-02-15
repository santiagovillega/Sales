namespace Sales.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Sales.Common.Models;
    using Service;
    using Xamarin.Forms;
    using Sales.Helpers;

    public class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Product> products;
        private bool esRefresh;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }
        public bool EsRefresh 
        {
            get { return this.esRefresh ; }
            set { this.SetValue(ref this.esRefresh, value); }
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            this.EsRefresh = true;
            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess )
            {
                this.EsRefresh = false;
                await Application.Current.MainPage.DisplayAlert(Languages.ErrorConexion , conexion.Message,Languages.Aceptar);
                return;
            }
            /// var url = Application.Current.Resources["UrlAPI"].ToString();            /// 
            /// debería reemplazar variable que viene del diccionario de recursos pero no los carga
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var urlPrefix = Application.Current.Resources["UrlPrefix"].ToString();
            var urlProductsController = Application.Current.Resources["UrlProductosController"].ToString();
            ///var response = await this.apiService.GetList<Product>("https://salesapi-sv.azurewebsites.net", "/api", "/Products");
            var response = await this.apiService.GetList<Product>(url, urlPrefix, urlProductsController);
            if (!response.IsSuccess)
            {
                this.EsRefresh = false ;
                await Application.Current.MainPage.DisplayAlert(Languages.Error , response.Message, Languages.Aceptar);
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
            this.EsRefresh = false;
        }
        public ICommand CmdRefresh
        {
            get { return new RelayCommand(LoadProducts); }
        }
    }
}
