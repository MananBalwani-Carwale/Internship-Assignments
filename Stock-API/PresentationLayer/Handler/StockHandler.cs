using AutoMapper;
using DataAccessLayer.Entity;
using PresentationLayer.DTO;
using DataAccessLayer.Enums;
namespace PresentationLayer.Handler;

public class StockHandler : Profile
{
    public StockHandler()
    {
        CreateMap<StockEntity,StockDTO>()
        .ForMember(item => item.CarName, opt => opt.MapFrom(item => ConvertName(item.Name, item.MakeName, item.MakeModel, item.MakeYear)))
        .ForMember(item => item.FormattedPrice, opt => opt.MapFrom(item => FormatPrice(item.Price)));
        CreateMap<CreateStockDTO, StockEntity>()
        .ForMember(item => item.FuelType, opt => opt.MapFrom(item => GetFuelType(item.FuelType)));
        CreateMap<UpdateStockDTO, StockEntity>()
        .ForMember(item => item.FuelType, opt => opt.MapFrom(item => GetFuelType(item.FuelType)));
    } 
    public static string ConvertName(string name, string makeName, string makeModel, int makeYear)
    {
        return name+" "+makeName+" "+makeModel+" "+makeModel+" "+makeYear;
    }
    public static string FormatPrice(int price)
    {
        double formattedPrice = (double)price / 100000;
        formattedPrice = Math.Round(formattedPrice, 1);
        return Convert.ToString(formattedPrice)+" Lakhs";
    }
    public static string GetFuelType(int fuelType)
    {
        return Enum.GetName(typeof(FuelTypes), Convert.ToInt32(fuelType));
    }
}