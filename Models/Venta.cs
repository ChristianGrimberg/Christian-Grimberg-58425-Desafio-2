using System.Reflection;

namespace Christian_Grimberg_58425_Desafio_2;

public class Venta
{
	private int id;
	public int Id
	{
		get
		{
			if(id.GetType() != typeof(int)) id = 0;
			return id;
		}
		set
		{
			if(value.GetType() == typeof(int)) id = value;
			else id = 0;
		}
	}

	private string? comentarios;
	public string? Comentarios
	{
		get
		{
			if(string.IsNullOrEmpty(comentarios)) comentarios = "sin Descripcion";
			return comentarios;
		}
		set
		{
			if(!string.IsNullOrEmpty(value)) comentarios = value;
			else comentarios = string.Empty;
		}
	}

	private int idUsuario;
	public int IdUsuario
	{
		get
		{
			if(idUsuario.GetType() != typeof(int)) idUsuario = 0;
			return idUsuario;
		}
		set
		{
			if(value.GetType() == typeof(int)) idUsuario = value;
			else idUsuario = 0;
		}
	}

	public Venta() {}

	public Venta(int _id, string _comentarios, int _idUsuario)
	{
		this.Id = _id;
		this.Comentarios = _comentarios;
		this.IdUsuario = _idUsuario;
	}

	public override string ToString()
	{
		string returnedValue = string.Empty;

		foreach(PropertyInfo propertyInfo in this.GetType().GetProperties())
		{
			returnedValue += string.Format("{0} de {1} es: {2}\n", propertyInfo.Name, this.GetType().Name ,propertyInfo.GetValue(this));
		}
		return returnedValue;
	}
}
