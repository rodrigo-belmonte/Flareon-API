using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.User.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<GetProfileResponse>
    {
        public Guid Id { get; set; }
    }
}
