using Data;

namespace ServicesLayer.Bussiness
{
    public class DBaseContext
    {
        // Aplicación del patrón de diseño singletion para crear una instancia global del contexto de la base de datos
        static School_Manage_SystemContext ctxto = new School_Manage_SystemContext();
        private static DBaseContext contx;

        public School_Manage_SystemContext Ctxto { get { return ctxto; } }

        private DBaseContext() { }

        public static DBaseContext GetContexto()
        {
            if (contx == null)
            {
                contx = new DBaseContext();
            }
            return contx;
        }
    }
}