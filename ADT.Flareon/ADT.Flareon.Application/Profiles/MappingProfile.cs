using AutoMapper;
using ADT.Flareon.Domain.Tables;
using ADT.Flareon.Application.Services.Order.Commands.Create;
using ADT.Flareon.Application.Services.Order.Commands.Update;
using ADT.Flareon.Application.Services.Customer.Commands.Create;
using ADT.Flareon.Application.Services.Customer.Commands.Update;
using ADT.Flareon.Application.Services.Employee.Commands.Create;
using ADT.Flareon.Application.Services.Employee.Commands.Update;
using ADT.Flareon.Application.Services.Product.Commands.Create;
using ADT.Flareon.Application.Services.Product.Commands.Update;
using ADT.Flareon.Application.Services.User.Commands.Create;
using ADT.Flareon.Application.Services.User.Commands.Update;
using ADT.Flareon.Application.ViewModels.Customer;
using ADT.Flareon.Application.ViewModels.Employee;
using ADT.Flareon.Application.ViewModels.Order;
using ADT.Flareon.Application.ViewModels.User;
using ADT.Flareon.Application.ViewModels.Product;
using ADT.Flareon.Application.Services.Sale.Commands.Create;
using ADT.Flareon.Application.Services.Sale.Commands.Update;
using ADT.Flareon.Application.ViewModels.Sale;
using ADT.Flareon.Application.Services.User.Queries.GetProfile;

namespace ADT.Flareon.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapProduct();
            MapCustomer();
            MapEmployee();
            MapUser();
            MapOrder();
            MapSale();
            MapPiece();
        }

        private void MapProduct()
        {
            CreateMap<ProductTable, CreateProductCommand>().ReverseMap();
            CreateMap<ProductTable, UpdateProductCommand>().ReverseMap();
            CreateMap<ProductTable, ProductVm>().ReverseMap();
            CreateMap<SelectedProducts, SelectedProductVm>().ReverseMap();
        }

        private void MapCustomer()
        {
            CreateMap<CustomerTable, CreateCustomerCommand>().ReverseMap();
            CreateMap<CustomerTable, UpdateCustomerCommand>().ReverseMap();
            CreateMap<CustomerTable, GetByIdCustomerVm>().ReverseMap();
            CreateMap<CustomerTable, GetAllCustomerListVm>().ReverseMap();
            CreateMap<CustomerTable, CustomerSelectVm>().ReverseMap();
        }

        private void MapEmployee()
        {
            CreateMap<EmployeeTable, CreateEmployeeCommand>().ReverseMap();
            CreateMap<EmployeeTable, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<EmployeeTable, GetByIdEmployeeVm>().ReverseMap();
            CreateMap<EmployeeTable, GetAllEmployeeListVm>().ReverseMap();
            CreateMap<EmployeeTable, EmployeeSelectVm>().ReverseMap();
        }

        private void MapOrder()
        {
            CreateMap<OrderTable, CreateOrderCommand>().ReverseMap();
            CreateMap<OrderTable, UpdateOrderCommand>().ReverseMap();
            CreateMap<OrderTable, GetByIdOrderVm>().ReverseMap();
            CreateMap<OrderTable, GetAllOrderListVm>().ReverseMap();
            CreateMap<OrderTable, OrderVm>().ReverseMap();
        }

        private void MapPiece()
        {
            CreateMap<PieceClothing, PieceClothingVm>().ReverseMap();

        }

        private void MapUser()
        {
            CreateMap<UserTable, CreateUserCommand>().ReverseMap();
            CreateMap<UserTable, UpdateUserCommand>().ReverseMap();
            CreateMap<UserTable, GetByIdUserVm>().ReverseMap();
            CreateMap<UserTable, GetAllUserListVm>().ReverseMap();
            CreateMap<UserTable, UserInfoVm>().ReverseMap();
            CreateMap<UserTable, GetProfileVm>().ReverseMap();
        }

        private void MapSale()
        {
            CreateMap<SaleTable, CreateSaleCommand>().ReverseMap();
            CreateMap<SaleTable, UpdateSaleCommand>().ReverseMap();
            CreateMap<SaleTable, GetByIdSaleVm>().ReverseMap();
            CreateMap<SaleTable, GetAllSaleListVm>().ReverseMap();
        }
    }
}
