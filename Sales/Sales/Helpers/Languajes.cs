namespace Sales.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Mensaje.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Aceptar
        {
            get { return Mensaje.Aceptar; }
        }
        public static string EncenderInternet
        {
            get { return Mensaje.EncenderInternet ; }
        }
        public static string Productos
        {
            get { return Mensaje.Productos; }
        }
        public static string SinConexionInternet
        {
            get { return Mensaje.SinConexionInternet; }
        }
        public static string ErrorConexion
        {
            get { return Mensaje.ErrorConexion; }
        }
        public static string Error
        {
            get { return Mensaje.Error; }
        }
    }

}
