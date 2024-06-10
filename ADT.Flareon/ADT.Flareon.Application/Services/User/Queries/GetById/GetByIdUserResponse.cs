using ADT.Flareon.Application.Responses;
using ADT.Flareon.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Application.Services.User.Queries.GetById
{
    public class GetByIdUserResponse: BaseResponse
    {
        public GetByIdUserVm User { get; set; }
    }
}
