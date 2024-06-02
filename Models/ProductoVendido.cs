using System.Reflection;

namespace Christian_Grimberg_58425_Desafio_2;

public class ProductoVendido
{
    private int id;
    public int Id
    {
        get
        {
            if (id.GetType() != typeof(int)) id = 0;
            return id;
        }
        set
        {
            if (value.GetType() == typeof(int)) id = value;
            else id = 0;
        }
    }

    private int idProducto;
    public int IdProducto
    {
        get
        {
            if (idProducto.GetType() != typeof(int)) idProducto = 0;
            return idProducto;
        }
        set
        {
            if (value.GetType() == typeof(int)) idProducto = value;
            else idProducto = 0;
        }
    }

    private int stock;
    public int Stock
    {
        get
        {
            if (stock.GetType() != typeof(int)) stock = 0;
            return stock;
        }
        set
        {
            if (value.GetType() == typeof(int)) stock = value;
            else stock = 0;
        }
    }

    private int idVenta;
    public int IdVenta
    {
        get
        {
            if (idVenta.GetType() != typeof(int)) idVenta = 0;
            return idVenta;
        }
        set
        {
            if (value.GetType() == typeof(int)) idVenta = value;
            else idVenta = 0;
        }
    }

    public ProductoVendido() { }

    public ProductoVendido(int _id, int _idProducto, int _stock, int _idVenta)
    {
        Id = _id;
        IdProducto = _idProducto;
        Stock = _stock;
        idVenta = _idVenta;
    }

    public override string ToString()
    {
        string returnedValue = string.Empty;

        foreach (PropertyInfo propertyInfo in GetType().GetProperties())
        {
            returnedValue += string.Format("{0} de {1} es: {2}\n", propertyInfo.Name, GetType().Name, propertyInfo.GetValue(this));
        }
        return returnedValue;
    }
}