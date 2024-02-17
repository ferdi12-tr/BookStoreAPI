using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
	public record UserDTO(int Id, string? Image, string? Name, string? Email, string? Username);
}
