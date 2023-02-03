using System;

namespace CoreEscuela.Entidades
{
    public abstract class ObjectSchoolBase
    {
        public string UniqueId { get; set; }
        public string Nombre { get; set; }    

        public ObjectSchoolBase()
        {
          UniqueId = Guid.NewGuid().ToString();
        }
    
    }
}