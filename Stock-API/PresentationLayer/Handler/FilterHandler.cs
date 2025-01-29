using AutoMapper;
using DataAccessLayer.Entity;
using PresentationLayer.DTO;
using DataAccessLayer.Enums;
using Microsoft.Extensions.Localization;
using System.Runtime.CompilerServices;
namespace PresentationLayer.Handler;
public class FilterHandler : Profile
{
    public FilterHandler()
    {
        CreateMap<FilterDTO, FilterEntity>().
        ForMember(item => item.MaxBudget, opt => opt.MapFrom(item => ConvertToMaxBudget(item.Budget))).
        ForMember(item => item.MinBudget, opt => opt.MapFrom(item => ConvertToMinBudget(item.Budget))).
        ForMember(item => item.FuelTypes, opt => opt.MapFrom(item => ConvertToFuelType(item.FuelTypes)));
    }
    public static int ConvertToMaxBudget(string budget)
    {
        if(budget == null)
        {
            return 2100000;
        }
        string[] stringBudget = budget.Split('-');
        return Convert.ToInt32(stringBudget[1])*100000;
    }
    public static int ConvertToMinBudget(string budget)
    {
        if(budget == null)
        {
            return 100000;
        }
        string[] stringBudget = budget.Split('-');
        return Convert.ToInt32(stringBudget[0])*100000;
    }
    public static List<string> ConvertToFuelType(string fuelType)
    {
        if(fuelType == null)
        {
            return new List<string>() {"Petrol", "Diesel", "CNG", "LPG", "Electric", "Hybrid"}; 
        }
        string[] fuels = fuelType.Split('+');
        List<string> fuelTypes = new List<string>();
        for(int i = 0; i < fuels.Length; i++)
        {
            fuelTypes.Add(Enum.GetName(typeof(FuelTypes), Convert.ToInt32(fuels[i])));
        }
        return fuelTypes;
    }
}