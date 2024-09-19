namespace BE
{
    public class BEProveedores : BEPersonas
    {
        public string Direccion { get; set; }
        public string CBU { get; set; }

        public BEProveedores()
        {

        }
        public BEProveedores(int ID)
        {
            this.Id = ID;
        }
        public BEProveedores(int ID,string Nombre, string Apellido, string Correo, string Direccion,string CBU) : this(ID)
        {
            {
                this.Nombre = Nombre;
                this.Apellido = Apellido;
                this.Correo = Correo;
                this.Direccion = Direccion;
                this.CBU = CBU;
            }
        }
        public override string ToString()
        {
            return this.Id + "- " + this.Nombre;
        }
    }
}
