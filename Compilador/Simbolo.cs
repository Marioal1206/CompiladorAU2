using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
	public class Simbolo
	{
		private int _intID;

		public int intID
		{
			get { return _intID; }
			set { _intID = value; }
		}
		private string _strNombre;

		public string strNombre
		{
			get { return _strNombre; }
			set { _strNombre = value; }
		}
		private string _strTipoValor;

		public string strTipoValor
		{
			get { return _strTipoValor; }
			set { _strTipoValor = value; }
		}
		private string _strValor;

		public string strValor
		{
			get { return _strValor; }
			set { _strValor = value; }
		}
		public Simbolo()
		{
			_intID = 0;
			_strNombre = "PD";
			_strTipoValor = "PD";
			_strValor = "PD";
        }




    }
}
