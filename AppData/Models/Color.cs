using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Color
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Please fill")]
		public string ColorName { get; set; }
		[Required(ErrorMessage = "Not empty")]
		public string Description { get; set; }
		[Range(0, 9, ErrorMessage = "0-9")]
		public int Status { get; set; }
	}
}
//aa